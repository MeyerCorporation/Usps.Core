using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MeyerCorp.Usps.Api.Controllers
{
	public abstract class UspsController<T> : Controller
	{
		protected UspsOptions Options { get; set; }
		protected ILogger<T> Logger { get; set; }

		public UspsController(IOptions<UspsOptions> options, ILogger<T> logger)
		{
			Logger = logger;
			Options = options.Value;
		}

		protected string GetError(string responseString)
		{
			return XElement.Parse(responseString).DescendantsAndSelf("Error").First().Element("Description").Value;
		}

		protected bool CheckError(string responseString)
		{
			return XElement.Parse(responseString).DescendantsAndSelf("Error").Count() > 0;
		}

		protected Uri GetUrl(string api, string type, params Xml.XmlFormatter[] inputs)
		{
			var input = String.Join(String.Empty, inputs.Where(i=>i!=null).Select(a => a.ToString()));

			var request = new StringBuilder();

			return new Uri(request
				.Append($"{Options.BaseUrl}/{Options.Path}?API={api}&XML=")
				.AppendXml(type, input, "USERID", Options.UserId)
				.ToString());
		}

	}
}
