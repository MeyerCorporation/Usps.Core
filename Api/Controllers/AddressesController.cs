using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeyerCorp.Usps.WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AddressesController : ControllerBase
	{
		private readonly ILogger<AddressesController> _logger;
		private readonly Core.IAddresses AddressValidator;

		public AddressesController(Core.IAddresses addressesValidator, ILogger<AddressesController> logger)
		{
			AddressValidator = addressesValidator;
			_logger = logger;
		}

		[HttpGet]
		[Route("Validate")]
		public async Task<IActionResult> GetAsync([FromQuery] int revision,
			[FromQuery] string Address1_1, [FromQuery] string Address2_1, [FromQuery] string FirmName_1, [FromQuery] string city_1, [FromQuery] string state_1, [FromQuery] string zip5_1,[FromQuery] string zip4_1, [FromQuery] string urbanization_1,
			[FromQuery] string Address1_2, [FromQuery] string Address2_2, [FromQuery] string FirmName_2, [FromQuery] string city_2, [FromQuery] string state_2, [FromQuery] string zip5_2,[FromQuery] string zip4_2, [FromQuery] string urbanization_2,
			[FromQuery] string Address1_3, [FromQuery] string Address2_3, [FromQuery] string FirmName_3, [FromQuery] string city_3, [FromQuery] string state_3, [FromQuery] string zip5_3,[FromQuery] string zip4_3, [FromQuery] string urbanization_3,
			[FromQuery] string Address1_4, [FromQuery] string Address2_4, [FromQuery] string FirmName_4, [FromQuery] string city_4, [FromQuery] string state_4, [FromQuery] string zip5_4,[FromQuery] string zip4_4, [FromQuery] string urbanization_4,
			[FromQuery] string Address1_5, [FromQuery] string Address2_5, [FromQuery] string FirmName_5, [FromQuery] string city_5, [FromQuery] string state_5, [FromQuery] string zip5_5,[FromQuery] string zip4_5, [FromQuery] string urbanization_5)
		{
			var addresses = new List<Core.Xml.Address>();
			var index = 1;

			addresses.Add(GetAddress(index++, Address1_1, Address2_1, FirmName_1, city_1, state_1, zip5_1, zip4_1, urbanization_1));
			addresses.Add(GetAddress(index++, Address1_2, Address2_2, FirmName_2, city_2, state_2, zip5_2, zip4_2, urbanization_2));
			addresses.Add(GetAddress(index++, Address1_3, Address2_3, FirmName_3, city_3, state_3, zip5_3, zip4_3, urbanization_3));
			addresses.Add(GetAddress(index++, Address1_4, Address2_4, FirmName_4, city_4, state_4, zip5_4, zip4_4, urbanization_4));
			addresses.Add(GetAddress(index++, Address1_5, Address2_5, FirmName_5, city_5, state_5, zip5_5, zip4_5, urbanization_5));

			try
			{
				var result = await AddressValidator.ValidateAsync(revision, addresses.Where(a => a != null).ToArray());

				return Ok(result);
			}
			catch (InvalidOperationException ex) { return BadRequest(ex.Message); }
		}

		static Core.Xml.Address GetAddress(int id, string address1, string address2, string firmName, string city, string state, string zip5, string zip4, string urbanization)
		{
			var check = new string[] { address1, address2, address1, firmName, city, state, zip5, zip4, urbanization };

			return check.Any(c => !String.IsNullOrWhiteSpace(c))
				? new Core.Xml.Address
				{
					Address1 = address1,
					Address2 = address2,
					City = city,
					FirmName = firmName,
					State = state,
					Zip5 = zip5,
					Zip4 = zip4,
					Urbanization = urbanization,
					Id = id,
				}
				: null;
		}
	}
}
