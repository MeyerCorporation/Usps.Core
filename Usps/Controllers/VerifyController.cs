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
	public class VerifyController : Controller
	{
		readonly UspsOptions _Options;
		readonly ILogger<VerifyController> _Logger;

		public VerifyController(IOptions<UspsOptions> options, ILogger<VerifyController> logger)
		{
			_Logger = logger;
			_Options = options.Value;
		}

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
						if (_Logger != null) _Logger.LogError("Bad Request", message);
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
				if (_Logger != null) _Logger.LogCritical(ex.Message, ex.StackTrace.ToString(), ex);
				System.Diagnostics.Debug.WriteLine(ex.Message);
				throw;
			}
			finally
			{
				requestmessage.Dispose();
				client.Dispose();
			}
		}

		#region Lookup City State

		[HttpGet("citystatelookup", Name = "LookupCityState")]
		[SwaggerResponse(statusCode: 200, type: typeof(CityState))]
		public IActionResult LookupCityState([FromQuery]string zip5)
		{
			try
			{
				throw new NotImplementedException();
			}
			catch (Exception ex)
			{
				_Logger.LogCritical(ex.Message, ex.StackTrace.ToString(), ex);
				System.Diagnostics.Debug.WriteLine(ex.Message);
				throw;
			}
		}

		CityState ParseCityStateLookup(string input)
		{
			var parsed = XElement.Parse(input).Element("Address");

			return new CityState
			{
				City = parsed.Element("City")?.Value,
				State = parsed.Element("State")?.Value,
				Zip5 = parsed.Element("Zip5")?.Value,
				Error = parsed.Element("Error")?.Value,
			};
		}

		Uri GetCityStateUrl(string zip5, int id = 0)
		{
			var center = new StringBuilder();

			center
				.AppendXml("FirmName", zip5);

			var address = new StringBuilder();

			address
				.AppendXml("ZipCode", center.ToString(), "ID", "0");

			var request = new StringBuilder();

			return new Uri(request
				.Append($"{_Options.BaseUrl}/{_Options.Path}?API=CityStateLookup&XML=")
				.AppendXml("CityStateLookupRequ", address.ToString(), "USERID", _Options.UserId)
				.ToString());
		}

		#endregion

		#region Lookup Zip Code

		[HttpGet("zipcodelookup", Name = "LookupZipCode")]
		[SwaggerResponse(statusCode: 200, type: typeof(ZipCode))]
		public async Task<IActionResult> LookupZipCodeAsync([FromQuery]string firmName,
			[FromQuery]string firstZip5,
			[FromQuery]string secondZip5 = null,
			[FromQuery]string thirdZip5 = null,
			[FromQuery]string fourthZip5 = null,
			[FromQuery]string fifthZip5 = null)
		{
			var client = new HttpClient();
			var requestmessage = new HttpRequestMessage();

			try
			{
				requestmessage.RequestUri = GetZipCodeUrl(firstZip5, secondZip5, thirdZip5, fourthZip5, fifthZip5);

				var response = await client.SendAsync(requestmessage);

				if (response.StatusCode == HttpStatusCode.OK)
				{
					var responseString = await response.Content.ReadAsStringAsync();

					if (CheckError(responseString))
					{
						var message = GetError(responseString);
						if (_Logger != null) _Logger.LogError("Bad Request", message);
						return BadRequest(message);
					}
					else
					{
						return Ok(ParseZipCodeLookup(responseString));
					}
				}
				else
					return StatusCode((int)response.StatusCode);
			}
			catch (Exception ex)
			{
				if (_Logger != null) _Logger.LogCritical(ex.Message, ex.StackTrace.ToString(), ex);
				System.Diagnostics.Debug.WriteLine(ex.Message);
				throw;
			}
			finally
			{
				requestmessage.Dispose();
				client.Dispose();
			}
		}

		ZipCode ParseZipCodeLookup(string input)
		{
			var parsed = XElement.Parse(input).Element("Address");

			var addressp1 = parsed.Element("Address1")?.Value;
			var addressp2 = parsed.Element("Address2")?.Value;

			return new ZipCode
			{
				FirmName = parsed.Element("FirmName")?.Value,
				Address1 = addressp2,
				Address2 = addressp1,
				City = parsed.Element("City")?.Value,
				State = parsed.Element("State")?.Value,
				Zip5 = parsed.Element("Zip5")?.Value,
				Zip4 = parsed.Element("Zip4")?.Value,
				Error = parsed.Element("Error")?.Value,
			};
		}

		Uri GetZipCodeUrl(params string[] zip5)
		{
			if (zip5.Length > 5) throw new ArgumentException("Only five zip codes can be checked by one request.");

			var center = new StringBuilder();

			foreach (var zip in zip5)
			{
				center.AppendXml("ZipCode", $"<Zip5>{zip}</Zip5>", "ID", zip);
			}

			var request = new StringBuilder();

			return new Uri(request
				.Append($"{_Options.BaseUrl}/{_Options.Path}?API=CityStateLookup&XML=")
				.AppendXml("ZipCodeLookupRequest", center.ToString(), "USERID", _Options.UserId)
				.ToString());
		}

		#endregion

		static bool? ToBool(string value)
		{
			if (String.IsNullOrWhiteSpace(value))
				return null;
			else if (value == "Y")
				return true;
			else if (value == "N")
				return false;
			else
				throw new ArgumentException();
		}

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
