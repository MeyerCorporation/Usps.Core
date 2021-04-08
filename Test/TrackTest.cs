//using MeyerCorp.Usps.Api;
//using MeyerCorp.Usps.Api.Controllers;
//using MeyerCorp.Usps.Api.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;

//namespace Test
//{
//	public class TrackTest
//	{
//		[Fact]
//		public async Task TrackTestAsync()
//		{
//			var options = new Options();

//			var controller = new TrackingController(options, null);

//			var result = await controller.TrackAsync(trackId1: "23452345",
//				trackId2: "3343suenodr",
//				trackId3: null,
//				trackId4: null,
//				trackId5: null);
//		}

//		//[Fact]
//		//public async Task LookupZipCodeTestAsync()
//		//{
//		//	var options = new Options();

//		//	var controller = new TrackingController(options, null);

//		//	var result = await controller.LookupZipCodeAsync(firmname: String.Empty,
//		//		address1: "3343 sueno dr",
//		//		address2: null,
//		//		city: "San Jose",
//		//		state: "ca");
//		//}

//		//[Fact(DisplayName = "Look Up City,State for null zip code.")]
//		//public async Task LookupCityStateFailTestAsync()
//		//{
//		//	var options = new Options();

//		//	var controller = new TrackingController(options, null);

//		//	var result = await controller.LookupCityStateAsync(zip51: null);
//		//	var badrequestobjectresult = result as BadRequestObjectResult;

//		//	Assert.IsType<BadRequestObjectResult>(badrequestobjectresult);
//		//}

//		//[Fact(DisplayName = "Look Up City,State for unknown/invalid zip code.")]
//		//public async Task LookupCityStateFail1TestAsync()
//		//{
//		//	var options = new Options();

//		//	var controller = new TrackingController(options, null);

//		//	var result = await controller.LookupCityStateAsync(zip51: "456789");
//		//	var badrequestobjectresult = result as BadRequestObjectResult;

//		//	Assert.IsType<BadRequestObjectResult>(badrequestobjectresult);
//		//}

//		//[Fact(DisplayName = "Look Up City,State for 1 zip code.")]
//		//public async Task LookupCityStateTestAsync()
//		//{
//		//	var options = new Options();

//		//	var controller = new TrackingController(options, null);

//		//	var result = await controller.LookupCityStateAsync(zip51: "95148");
//		//	var okobjectresult = result as OkObjectResult;

//		//	Assert.IsType<OkObjectResult>(okobjectresult);

//		//	var value = okobjectresult.Value as CityState[];

//		//	Assert.IsType<CityState[]>(value);
//		//	Assert.Single(value);
//		//}

//		//[Fact(DisplayName = "Look Up City,State for 5 zip codes.")]
//		//public async Task LookupCityStatesTestAsync()
//		//{
//		//	var options = new Options();

//		//	var controller = new TrackingController(options, null);

//		//	var result = await controller.LookupCityStateAsync(zip51: "95148", zip52: "95122", zip53: "95687", zip54: "94590", zip55: "94591");
//		//	var okobjectresult = result as OkObjectResult;

//		//	Assert.IsType<OkObjectResult>(okobjectresult);

//		//	var value = okobjectresult.Value as CityState[];

//		//	Assert.IsType<CityState[]>(value);
//		//	Assert.Equal(5, value.Count());
//		//}

//		class Options : IOptions<UspsOptions>
//		{
//			public UspsOptions Value => new UspsOptions
//			{
//				UserId = "",// Private.UserId,
//				BaseUrl = "http://production.shippingapis.com",
//				Path = "ShippingAPI.dll",
//			};
//		}
//	}
//}
