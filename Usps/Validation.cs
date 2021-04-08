using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MeyerCorp.Usps
{
	public abstract class Validation
	{
		readonly string BaseUrl;
		readonly string Path;

		protected Validation(string baseUrl, string path)
		{
			BaseUrl = baseUrl;
			Path = path;
		}

		protected Uri GetUrl(string userId, string api, string type, params Api.Xml.XmlFormatter[] inputs)
		{
			var input = String.Join(String.Empty, inputs.Where(i => i != null).Select(a => a.ToString()));

			var request = new StringBuilder();

			return new Uri(request
				.Append($"{BaseUrl}/{Path}?API={api}&XML=")
				.AppendXml(type, input, "USERID", userId)
				.ToString());
		}

		protected bool CheckError(string responseString)
		{
			return XElement
				.Parse(responseString)
				.DescendantsAndSelf("Error")
				.Count() > 0;
		}

		protected string GetError(string responseString)
		{
			return XElement
				.Parse(responseString)
				.DescendantsAndSelf("Error")
				.First()
				.Element("Description")
				.Value;
		}
	}
}