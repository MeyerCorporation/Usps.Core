using MeyerCorp.UspsCore.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MeyerCorp.UspsCore.Test.Core
{
	public class AddressesTest
	{
		IConfiguration Configuration { get; set; }

		const string BaseUrl = "https://secure.shippingapis.com/ShippingAPI.dll";

		public AddressesTest()
		{
			var builder = new ConfigurationBuilder()
				.AddUserSecrets<AddressesTest>();

			Configuration = builder.Build();
		}

		[Fact(DisplayName = "Invalid Zip Code")]
		public async Task Test1Async()
		{
			var UserId = Configuration["ApiUsername"];

			var addresses = new Addresses
			{
				UserId = UserId,
				BaseUrl = BaseUrl,
			};

			var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => addresses.ValidateAsync(1, new UspsCore.Core.Xml.Address[]
			{
				new UspsCore.Core.Xml.Address
				{
					Address1 = "address1",
					Address2 = "address2",
					City = "city",
					FirmName = "firmname",
					Id = 0,
					State = "ST",
					Urbanization = "urbanization",
					Zip4 = "9999",
					Zip5 = "00000",
				}
			}));

			Assert.Equal("Invalid Zip Code.", ex.Message);
		}

		[Fact(DisplayName = "Address Not Found")]
		public async Task Test2Async()
		{
			var UserId = Configuration["ApiUsername"];

			var addresses = new Addresses
			{
				UserId = UserId,
				BaseUrl = BaseUrl,
			};

			var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => addresses.ValidateAsync(1, new UspsCore.Core.Xml.Address[]
				 {
				new UspsCore.Core.Xml.Address
				{
					Address1 = "address1",
					Address2 = "address2",
					City = "city",
					FirmName = "firmname",
					Id = 0,
					State = "ST",
					Urbanization = "urbanization",
					//Zip4 = "9999",
					Zip5 = "95687",
				}
				 }));

			Assert.Equal("Address Not Found.", ex.Message);
		}

		[Fact(DisplayName = "Single Address")]
		public async Task Test3Async()
		{
			var UserId = Configuration["ApiUsername"];

			var addresses = new Addresses
			{
				UserId = UserId,
				BaseUrl = BaseUrl,
			};

			var results = await addresses.ValidateAsync(1, new UspsCore.Core.Xml.Address[]
			{
				new UspsCore.Core.Xml.Address
				{
					Address1 = "2001 Meyer Way",
					//Address2 = "address2",
					City = "Fairfield",
					//FirmName = "firmname",
					Id = 0,
					State = "CA",
					//Urbanization = "urbanization",
					//Zip4 = "9999",
					//Zip5 = "95687",
				}
			});

			var result = results.First();

			Assert.Equal("0", result.Id);
			Assert.Null(result.Address1);
			Assert.Equal("2001 MEYER WAY", result.Address2);
			Assert.True(result.Business);
			Assert.Equal("C037", result.CarrierRoute);
			Assert.False(result.CentralDeliveryPoint);
			Assert.Equal("FAIRFIELD", result.City);
			Assert.Null(result.CityAbbreviation);
			Assert.Equal("01", result.DeliveryPoint);
			Assert.False(result.DPVCMRA);
			Assert.True(result.DPVConfirmation);
			Assert.Equal("AABB", result.DPVFootnotes);
			Assert.Null(result.Error);
			Assert.Null(result.FirmName);
			Assert.Null(result.Footnotes);
			Assert.Equal("CA", result.State);
			Assert.Null(result.Urbanization);
			Assert.False(result.Vacant);
			Assert.Equal("6802", result.Zip4);
			Assert.Equal("94533", result.Zip5);
		}

		[Fact(DisplayName = "Double Address")]
		public async Task Test4Async()
		{
			var UserId = Configuration["ApiUsername"];

			var addresses = new Addresses
			{
				UserId = UserId,
				BaseUrl = BaseUrl,
			};

			var results = await addresses.ValidateAsync(1, new UspsCore.Core.Xml.Address[]
			{
				new UspsCore.Core.Xml.Address
				{
					Address1 = "2001 Meyer Way",
					//Address2 = "address2",
					City = "Fairfield",
					//FirmName = "firmname",
					Id = 0,
					State = "CA",
					//Urbanization = "urbanization",
					//Zip4 = "9999",
					//Zip5 = "95687",
				},
				new UspsCore.Core.Xml.Address
				{
					Address1 = "1 Meyer Plaza",
					//Address2 = "address2",
					City = "Vallejo",
					//FirmName = "firmname",
					Id = 0,
					State = "CA",
					//Urbanization = "urbanization",
					//Zip4 = "9999",
					//Zip5 = "95687",
				}

			});

			var result = results.First();

			Assert.Equal("0", result.Id);
			Assert.Null(result.Address1);
			Assert.Equal("2001 MEYER WAY", result.Address2);
			Assert.True(result.Business);
			Assert.Equal("C037", result.CarrierRoute);
			Assert.False(result.CentralDeliveryPoint);
			Assert.Equal("FAIRFIELD", result.City);
			Assert.Null(result.CityAbbreviation);
			Assert.Equal("01", result.DeliveryPoint);
			Assert.False(result.DPVCMRA);
			Assert.True(result.DPVConfirmation);
			Assert.Equal("AABB", result.DPVFootnotes);
			Assert.Null(result.Error);
			Assert.Null(result.FirmName);
			Assert.Null(result.Footnotes);
			Assert.Equal("CA", result.State);
			Assert.Null(result.Urbanization);
			Assert.False(result.Vacant);
			Assert.Equal("6802", result.Zip4);
			Assert.Equal("94533", result.Zip5);
		}

		[Fact(DisplayName = "Double City State Lookup")]
		public async Task Test5Async()
		{
			var UserId = Configuration["ApiUsername"];

			var addresses = new Addresses
			{
				UserId = UserId,
				BaseUrl = BaseUrl,
			};

			var results = await addresses.LookupCityStateAsync("95687", "95127");

			Assert.Equal(2, results.Count());
			Assert.Equal("VACAVILLE", results.First().City);
			Assert.Equal("CA", results.First().State);
			Assert.Equal("SAN JOSE", results.Last().City);
			Assert.Equal("CA", results.Last().State);
		}

		[Fact(DisplayName = "Double Zip Code Lookup")]
		public async Task Test6Async()
		{
			var UserId = Configuration["ApiUsername"];

			var addresses = new Addresses
			{
				UserId = UserId,
				BaseUrl = BaseUrl,
			};

			var results = await addresses.LookupZipCodeAsync(new UspsCore.Core.Xml.ZipCode[]
			{
				new UspsCore.Core.Xml.ZipCode
				{
					Address1 = "2001 Meyer Way",
					//Address2 = "address2",
					City = "Fairfield",
					//FirmName = "firmname",
					Id = 0,
					State = "CA",
					//Urbanization = "urbanization",
					//Zip4 = "9999",
					//Zip5 = "95687",
				},
				new UspsCore.Core.Xml.ZipCode
				{
					Address1 = "1 Meyer Plaza",
					//Address2 = "address2",
					City = "Vallejo",
					//FirmName = "firmname",
					Id = 0,
					State = "CA",
					//Urbanization = "urbanization",
					//Zip4 = "9999",
					//Zip5 = "95687",
				}

			});

			var result = results.First();

			Assert.Equal("0", result.Id);
			Assert.Null(result.Address1);
			Assert.Equal("2001 MEYER WAY", result.Address2);
			Assert.Equal("FAIRFIELD", result.City);
			Assert.Null(result.Error);
			Assert.Null(result.FirmName);
			Assert.Equal("CA", result.State);
			Assert.Equal("6802", result.Zip4);
			Assert.Equal("94533", result.Zip5);
		}
	}
}
