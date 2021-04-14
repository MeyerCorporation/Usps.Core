using MeyerCorp.Usps.Core.Xml;
using System;
using Xunit;

namespace Meyer.UspsCore.Test.Core.Xml
{
	public class TrackFieldsTest
	{
        [Fact(DisplayName="To String")]
		public void Test0()
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
