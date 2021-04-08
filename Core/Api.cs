﻿using MeyerCorp.Usps.Core.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MeyerCorp.Usps.Core
{
	public abstract class Api : IDisposable
	{
		public Api(IOptions<ApiOptions> options)
		{
			UserId = options.Value.UspsApiKey;
			BaseUrl = options.Value.UspsBaseUrl;
		}

		protected string UserId { get; set; }
		protected string BaseUrl { get; set; }
		protected string Path { get; set; }
		protected HttpClient HttpClient { get; set; } = new HttpClient();
		protected HttpRequestMessage Request { get; set; } = new HttpRequestMessage();
		private bool disposedValue;

		protected async Task<string> GetResponseStringAsync()
		{
			var response = await HttpClient.SendAsync(Request);
			var responseString = await response.Content.ReadAsStringAsync();

			if (response.StatusCode == HttpStatusCode.OK)
			{
				if (CheckError(responseString))
				{
					var message = GetError(responseString).Trim();
					throw new InvalidOperationException(message);
				}
				else
				{
					return responseString;
				}
			}
			else
				throw new InvalidOperationException(responseString);
		}

		protected Uri GetUrl(string apiName, string type, string input)
		{
			var request = new StringBuilder();

			return new Uri(request
				.Append($"{BaseUrl}/{Path}?API={apiName}&XML=")
				.AppendXml(type, input, "USERID", UserId)
				.ToString());
		}

		protected static bool CheckError(string responseString)
		{
			return XElement
				.Parse(responseString)
				.DescendantsAndSelf("Error")
				.Any();
		}

		protected static string GetError(string responseString)
		{
			return XElement
				.Parse(responseString)
				.DescendantsAndSelf("Error")
				.First()
				.Element("Description")
				.Value;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					if (Request != null) Request.Dispose();
					if (HttpClient != null) HttpClient.Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~Api()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
