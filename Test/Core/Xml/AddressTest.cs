using MeyerCorp.Usps.Api.Xml;
using System.Diagnostics;
using System.Xml.Linq;
using Xunit;

namespace Meyer.UspsCore.Test.Core.Xml
{
	public class AddressTest
	{
		[Fact(DisplayName = "To String")]
		public void Test1()
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

			Debug.WriteLine(output.ToString());

			XElement.Parse(output.ToString());

			var expected = "<Address ID=\"0\"><Address1>address1</Address1><Address2>address2</Address2><City>city</City><State>ST</State><Urbanization>urbanization</Urbanization><Zip5>00000</Zip5><Zip4>9999</Zip4></Address>";

			Assert.Equal(expected, output.ToString());
		}
	}
}
