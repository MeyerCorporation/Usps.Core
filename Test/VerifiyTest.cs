using MeyerCorp.Usps.Api;
using MeyerCorp.Usps.Api.Controllers;
using Microsoft.Extensions.Options;
using System;
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

			var controller = new VerifyController(options, null);

			var result = await controller.VerifyAddressAsync(firmname: String.Empty,
				address1: "3343 sueno dr",
				address2: null,
				city: "San Jose",
				state: "ca",
				zip5: "95148",
				zip4: String.Empty);
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
