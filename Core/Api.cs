using MeyerCorp.Usps.Core.Extensions;
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
		protected HttpClient HttpClient { get; set; } = new HttpClient();
		protected HttpRequestMessage Request { get; set; } = new HttpRequestMessage();
		private bool disposedValue;

		protected async Task<XDocument> GetResponseStringAsync()
		{
			try
			{
				var response = await HttpClient.SendAsync(Request);
				var responseString = await response.Content.ReadAsStringAsync();

				if (response.StatusCode == HttpStatusCode.OK)
				{
					var xml = XDocument.Parse(responseString);

					if (xml.Root.Name == "Error")
					{
						var ex = new InvalidOperationException("The USPS API returned an error.");
						ex.Data.Add("Error", xml);
						throw ex;
					}
					else
						return xml;
				}
				else
					throw new InvalidOperationException(responseString);
			}
			finally { Request = new HttpRequestMessage(); }
		}

		protected Uri GetUrl(string apiName, string type, string input)
		{
			if (String.IsNullOrWhiteSpace(UserId)) throw new InvalidOperationException("The UserId value must be configured. Check application settings.");
			if (String.IsNullOrWhiteSpace(BaseUrl)) throw new InvalidOperationException("The BaseUrl value must be configured. Check application settings.");

			var request = new StringBuilder();

			return new Uri(request
				.Append($"{BaseUrl}/?API={apiName}&XML=")
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
