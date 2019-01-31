using MeyerCorp.Usps.Api.Models;
using Microsoft.AspNetCore.Authorization;
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
	[Authorize]
	public class TrackingController : UspsController<TrackingController>
	{
		public TrackingController(IOptions<UspsOptions> options, ILogger<TrackingController> logger) : base(options, logger) { }

		[HttpGet("Tracking", Name = "Tracking")]
		[SwaggerResponse(statusCode: 200, type: typeof(Address))]
		[SwaggerResponse(statusCode: 400, type: typeof(string))]
		public IActionResult Tracking([FromQuery]string trackId1,
			[FromQuery]string trackId2 = null,
			[FromQuery]string trackId3 = null,
			[FromQuery]string trackId4 = null,
			[FromQuery]string trackId5 = null)
		{
			var client = new HttpClient();
			var requestmessage = new HttpRequestMessage();

			try
			{
				requestmessage.RequestUri = GetUrl("TrackV2", "TrackRequest", new Xml.Track
				{
					Address1 = address1,
					TrackId = address2,
					City = city,
					FirmName = firmname,
					Id = 0,
					State = state,
					Urbanization = urbanization,
					Zip4 = zip4,
					Zip5 = zip5,
				});

				var response = await client.SendAsync(requestmessage);

				if (response.StatusCode == HttpStatusCode.OK)
				{
					var responseString = await response.Content.ReadAsStringAsync();

					if (CheckError(responseString))
					{
						var message = GetError(responseString);
						if (Logger != null) Logger.LogError("Bad Request", message);
						return BadRequest(message);
					}
					else
					{
						return Ok(Address.Parse(responseString));
					}
				}
				else
					return StatusCode((int)response.StatusCode);
			}
			catch (Exception ex)
			{
				if (Logger != null) Logger.LogCritical(ex.Message, ex.StackTrace.ToString(), ex);
				System.Diagnostics.Debug.WriteLine(ex.Message);
				throw;
			}
			finally
			{
				requestmessage.Dispose();
				client.Dispose();
			}
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

	}
}
