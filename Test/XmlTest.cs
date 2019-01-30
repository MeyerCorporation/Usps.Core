using MeyerCorp.Usps.Api.Xml;
using System;
using Xunit;

namespace Test
{
	public class XmlTest
	{
		[Fact]
		public void AddressTest()
		{
			var output = new Address
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
			};

			System.Diagnostics.Debug.WriteLine(output.ToString());

			var expected = "<Address ID=\"0\"><Address1>address1</Address1><Address2>address2</Address2><City>city</City><State>ST</State><Urbanization>urbanization</Urbanization><Zip5>00000</Zip5><Zip4>9999</Zip4></Address>";

			Assert.Equal(expected, output.ToString());
		}
	}
}
