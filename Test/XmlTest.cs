using MeyerCorp.Usps.Api.Xml;
using System;
using System.Xml.Linq;
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

			XElement.Parse(output.ToString());

			var expected = "<Address ID=\"0\"><Address1>address1</Address1><Address2>address2</Address2><City>city</City><State>ST</State><Urbanization>urbanization</Urbanization><Zip5>00000</Zip5><Zip4>9999</Zip4></Address>";

			Assert.Equal(expected, output.ToString());
		}

		[Fact]
		public void CityStateTest()
		{
			var output = new CityState
			{
				Id = 0,
				Zip5 = "00000",
			};

			System.Diagnostics.Debug.WriteLine(output.ToString());

			var expected = "<ZipCode ID=\"0\"><Zip5>00000</Zip5></ZipCode>";

			Assert.Equal(expected, output.ToString());
		}

		[Fact]
		public void TrackTest()
		{
			var output = new Track
			{
				TrackId = "id",
				Id = 0,
			};

			System.Diagnostics.Debug.WriteLine(output.ToString());

			var expected = "<TrackID ID=\"id\"></TrackID>";

			Assert.Equal(expected, output.ToString());
		}

		[Fact]
		public void TrackIDTest()
		{
			var output = new TrackID
			{
				DestinationZipCode = "98745",
				Id = 1,
				MailingDate = new DateTime(1999, 10, 03),
				TrackId = "456789",
			};

			System.Diagnostics.Debug.WriteLine(output.ToString());

			XElement.Parse(output.ToString());

			var expected = "<TrackID ID=\"456789\"><DestinationZipCode>98745</DestinationZipCode><MailingDate>1999-10-03</MailingDate></TrackID>";

			Assert.Equal(expected, output.ToString());
		}

		[Fact]
		public void TrackFieldsTest()
		{
			var output = new TrackFields
			{
				ClientIp = "192.168.0.12",
				Revision = "1",
				SourceId = "source",
				SourceIdZIP = "96321",
				TrackIDs = new TrackID[3]
				{
					new TrackID
					{
						DestinationZipCode = "98745",
						Id = 1,
						MailingDate= new DateTime(1999,10,03),
						TrackId="456789",
					},
					new TrackID
					{
						DestinationZipCode = "68745",
						Id = 1,
						MailingDate= new DateTime(2000,10,03),
						TrackId="256789",
					},
					new TrackID
					{
						DestinationZipCode = "88745",
						Id = 1,
						MailingDate= new DateTime(2001,10,03),
						TrackId="956789",
					},
				},
				Id = 0,
			};

			System.Diagnostics.Debug.WriteLine(output.ToString());

			//XElement.Parse(output.ToString());

			var expected = "<Revision>1</Revision><ClientIp>192.168.0.12</ClientIp><SourceId>source</SourceId><SourceIdZIP>96321</SourceIdZIP><TrackID ID=\"456789\"><DestinationZipCode>98745</DestinationZipCode><MailingDate>1999-10-03</MailingDate></TrackID><TrackID ID=\"256789\"><DestinationZipCode>68745</DestinationZipCode><MailingDate>2000-10-03</MailingDate></TrackID><TrackID ID=\"956789\"><DestinationZipCode>88745</DestinationZipCode><MailingDate>2001-10-03</MailingDate></TrackID>";

			Assert.Equal(expected, output.ToString());
		}
	}
}
