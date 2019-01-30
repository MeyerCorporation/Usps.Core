using MeyerCorp.Usps.Api;
using MeyerCorp.Usps.Api.Controllers;
using MeyerCorp.Usps.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
	public class VerifiyTest
	{
		[Fact]
		public async Task VerifyAddressTestAsync()
		{
			var options = new Options();

			var controller = new AddressController(options, null);

			var result = await controller.VerifyAddressAsync(firmname: String.Empty,
				address1: "3343 sueno dr",
				address2: null,
				city: "San Jose",
				state: "ca",
				zip5: "95148",
				zip4: String.Empty);
		}

		[Fact]
		public async Task LookupZipCodeTestAsync()
		{
			var options = new Options();

			var controller = new AddressController(options, null);

			var result = await controller.LookupZipCodeAsync(firmname: String.Empty,
				address1: "3343 sueno dr",
				address2: null,
				city: "San Jose",
				state: "ca");
		}

		[Fact]
		public async Task LookupCityStateTestAsync()
		{
			var options = new Options();

			var controller = new AddressController(options, null);

			var result = await controller.LookupCityStateAsync(zip51: "95148");
			var okobjectresult = result as OkObjectResult;

			Assert.IsType<OkObjectResult>(okobjectresult);

			var value = okobjectresult.Value as CityState[];

			Assert.IsType<CityState[]>(value);
			Assert.Single(value);
		}

		[Fact]
		public async Task LookupCityStatesTestAsync()
		{
			var options = new Options();

			var controller = new AddressController(options, null);

			var result = await controller.LookupCityStateAsync(zip51: "95148", zip52: "95122", zip53: "95687", zip54: "94590", zip55: "94591");
			var okobjectresult = result as OkObjectResult;

			Assert.IsType<OkObjectResult>(okobjectresult);

			var value = okobjectresult.Value as CityState[];

			Assert.IsType<CityState[]>(value);
			Assert.Equal(5, value.Count());
		}

		class Options : IOptions<UspsOptions>
		{
			public UspsOptions Value => new UspsOptions
			{
				UserId = Private.UserId,
				BaseUrl = "http://production.shippingapis.com",
				Path = "ShippingAPI.dll",
			};
		}
	}
}
