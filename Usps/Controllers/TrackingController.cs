using MeyerCorp.Usps.Api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MeyerCorp.Usps.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/usps")]
	[EnableCors("UspsCors")]
	public class TrackingController : Controller
	{
		readonly UspsOptions _Options;
		readonly ILogger<TrackingController> _Logger;

		public TrackingController(IOptions<UspsOptions> options, ILogger<TrackingController> logger)
		{
			_Logger = logger;
			_Options = options.Value;
		}

		[HttpGet("Tracking", Name = "Tracking")]
		[SwaggerResponse(statusCode: 200, type: typeof(Address))]
		[SwaggerResponse(statusCode: 400, type: typeof(string))]
		public IActionResult Tracking()
		{
				throw new NotImplementedException();

		}

		//[HttpPost("Tracking", Name = "Tracking")]
		//[SwaggerResponse(statusCode: 200, type: typeof(Address[]))]
		//[SwaggerResponse(statusCode: 400, type: typeof(string))]
		//public IActionResult VerifyAddresses([FromBody]Xml.Address[] addresses)
		//{
		//	throw new NotImplementedException();
		//}

		[HttpGet("TrackByEmail", Name = "TrackByEmail")]
		[SwaggerResponse(statusCode: 200, type: typeof(CityState))]
		[SwaggerResponse(statusCode: 400, type: typeof(string))]
		public IActionResult TrackByEmail()
		{
			throw new NotImplementedException();

		}

		//[HttpPost("TrackByEmail", Name = "TrackByEmail")]
		//[SwaggerResponse(statusCode: 200, type: typeof(CityState[]))]
		//[SwaggerResponse(statusCode: 400, type: typeof(string))]
		//public IActionResult LookupCityState([FromBody]Xml.CityState[] cityStates)
		//{
		//	throw new NotImplementedException();
		//}

		[HttpGet("ProofOfDelivery", Name = "ProofOfDelivery")]
		[SwaggerResponse(statusCode: 200, type: typeof(ZipCode))]
		public IActionResult ProofOfDelivery([FromQuery]string address1 = null,
			[FromQuery]string address2 = null,
			[FromQuery]string city = null,
			[FromQuery]string firmname = null,
			[FromQuery]string state = null,
			[FromQuery]string urbanization = null)
		{
			throw new NotImplementedException();

		}

		//[HttpPost("ProofOfDelivery", Name = "ProofOfDelivery")]
		//[SwaggerResponse(statusCode: 200, type: typeof(CityState[]))]
		//[SwaggerResponse(statusCode: 400, type: typeof(string))]
		//public IActionResult LookupZipCodes([FromBody]Xml.ZipCode[] zipCodes)
		//{
		//	throw new NotImplementedException();
		//}

		[HttpGet("ReturnReceiptElectronic", Name = "ReturnReceiptElectronic")]
		[SwaggerResponse(statusCode: 200, type: typeof(ZipCode))]
		public IActionResult ReturnReceiptElectronic([FromQuery]string address1 = null,
			[FromQuery]string address2 = null,
			[FromQuery]string city = null,
			[FromQuery]string firmname = null,
			[FromQuery]string state = null,
			[FromQuery]string urbanization = null)
		{
			throw new NotImplementedException();

		}

		//[HttpPost("zipcodelookup", Name = "LookupZipCodes")]
		//[SwaggerResponse(statusCode: 200, type: typeof(CityState[]))]
		//[SwaggerResponse(statusCode: 400, type: typeof(string))]
		//public IActionResult LookupZipCodes([FromBody]Xml.ZipCode[] zipCodes)
		//{
		//	throw new NotImplementedException();
		//}

		string GetError(string responseString)
		{
			return XElement.Parse(responseString).Descendants("Error").First().Element("Description").Value;
		}

		bool CheckError(string responseString)
		{
			return XElement.Parse(responseString).Descendants("Error").Count() > 0;
		}

		Uri GetUrl(string api, string type, params Xml.XmlFormatter[] inputs)
		{
			var input = String.Join(String.Empty, inputs.Select(a => a.ToString()));

			var request = new StringBuilder();

			return new Uri(request
				.Append($"{_Options.BaseUrl}/{_Options.Path}?API={api}&XML=")
				.AppendXml(type, input, "USERID", _Options.UserId)
				.ToString());
		}
	}
}
