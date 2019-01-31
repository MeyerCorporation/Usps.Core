using MeyerCorp.Usps.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeyerCorp.Usps.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/usps")]
	[EnableCors("UspsCors")]
	[Authorize]
	public class AddressController : UspsController<AddressController>
	{
		public AddressController(IOptions<UspsOptions> options, ILogger<AddressController> logger) : base(options, logger) { }

		[HttpGet("verify", Name = "VerifyAddress")]
		[SwaggerResponse(statusCode: 200, type: typeof(Address))]
		[SwaggerResponse(statusCode: 400, type: typeof(string))]
		public async Task<IActionResult> VerifyAddressAsync([FromQuery]string firmname = null, [FromQuery]string address1 = null,
			[FromQuery]string address2 = null,
			[FromQuery]string city = null,
			[FromQuery]string state = null,
			[FromQuery]string zip5 = null,
			[FromQuery]string zip4 = null,
			[FromQuery]string urbanization = null)
		{
			var client = new HttpClient();
			var requestmessage = new HttpRequestMessage();

			try
			{
				requestmessage.RequestUri = GetUrl("Verify", "AddressValidateRequest", new Xml.Address
				{
					Address1 = address1,
					Address2 = address2,
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

		[HttpPost("verify", Name = "VerifyAddresses")]
		[SwaggerResponse(statusCode: 200, type: typeof(Address[]))]
		[SwaggerResponse(statusCode: 400, type: typeof(string))]
		public IActionResult VerifyAddresses([FromBody]Xml.Address[] addresses)
		{
			throw new NotImplementedException();
		}

		[HttpGet("citystatelookup", Name = "LookupCityState")]
		[SwaggerResponse(statusCode: 200, type: typeof(CityState[]))]
		[SwaggerResponse(statusCode: 400, type: typeof(string))]
		public async Task<IActionResult> LookupCityStateAsync([FromQuery]string zip51,
			[FromQuery]string zip52 = null,
			[FromQuery]string zip53 = null,
			[FromQuery]string zip54 = null,
			[FromQuery]string zip55 = null)
		{
			var client = new HttpClient();
			var requestmessage = new HttpRequestMessage();

			try
			{
				requestmessage.RequestUri = GetUrl(
					"CityStateLookup",
					"CityStateLookupRequest",
					new Xml.CityState { Zip5 = zip51, Id = 0, },
						zip52 == null ? null : new Xml.CityState { Zip5 = zip52, Id = 1, },
						zip53 == null ? null : new Xml.CityState { Zip5 = zip53, Id = 2, },
						zip54 == null ? null : new Xml.CityState { Zip5 = zip54, Id = 3, },
						zip55 == null ? null : new Xml.CityState { Zip5 = zip55, Id = 4, });

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
						return Ok(CityState.Parse(responseString));
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

		[HttpGet("zipcodelookup", Name = "LookupZipCode")]
		[SwaggerResponse(statusCode: 200, type: typeof(ZipCode))]
		public async Task<IActionResult> LookupZipCodeAsync([FromQuery]string address1 = null,
			[FromQuery]string address2 = null,
			[FromQuery]string city = null,
			[FromQuery]string firmname = null,
			[FromQuery]string state = null,
			[FromQuery]string urbanization = null)
		{
			var client = new HttpClient();
			var requestmessage = new HttpRequestMessage();

			try
			{
				requestmessage.RequestUri = GetUrl("ZipCodeLookup", "ZipCodeLookupRequest", new Xml.ZipCode
				{
					Address1 = address1,
					Address2 = address2,
					City = city,
					FirmName = firmname,
					Id = 0,
					State = state,
					Urbanization = urbanization,
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
						return Ok(ZipCode.Parse(responseString));
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

		[HttpPost("zipcodelookup", Name = "LookupZipCodes")]
		[SwaggerResponse(statusCode: 200, type: typeof(CityState[]))]
		[SwaggerResponse(statusCode: 400, type: typeof(string))]
		public IActionResult LookupZipCodes([FromBody]Xml.ZipCode[] zipCodes)
		{
			throw new NotImplementedException();
		}
	}
}
