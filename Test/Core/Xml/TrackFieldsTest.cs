using MeyerCorp.Usps.Core.Xml;
using System;
using Xunit;

namespace Meyer.UspsCore.Test.Core.Xml
{
	public class TrackFieldsTest
	{
		[Fact(DisplayName = "To String")]
		public void Test0()
		{
			var output = new TrackFields
			{
				ClientIp = "192.168.0.12",
				Revision = "1",
				SourceId = "source",
				DestinationZipCode = "96321",
				TrackIDs = new string[3]
				{
					//new TrackID
					//{
					//	DestinationZipCode = "98745",
					//	Id = 1,
					//	MailingDate= new DateTime(1999,10,03),
					//	TrackId=
						"456789",
					//},
					//new TrackID
					//{
					//	DestinationZipCode = "68745",
					//	Id = 1,
					//	MailingDate= new DateTime(2000,10,03),
						//TrackId=
						"256789",
					//},
					//new TrackID
					//{
						//DestinationZipCode = 
						"88745",
					//	Id = 1,
					//	MailingDate= new DateTime(2001,10,03),
					//	TrackId="956789",
					//},
				},
				Id = 0,
			};

			System.Diagnostics.Debug.WriteLine(output.ToString());

			//XElement.Parse(output.ToString());

			var expected = "<Revision>1</Revision><ClientIp>192.168.0.12</ClientIp><TrackID ID=\"456789\"></TrackID><TrackID ID=\"256789\"></TrackID><TrackID ID=\"88745\"></TrackID><SourceId>source</SourceId><DestinationZipCode>96321</DestinationZipCode><TrackID ID=\"456789\"></TrackID><TrackID ID=\"256789\"></TrackID><TrackID ID=\"88745\"></TrackID>";

			Assert.Equal(expected, output.ToString());
		}

		[Fact(DisplayName = "To String w/ Date")]
		public void Test1()
		{
			var output = new TrackFields
			{
				ClientIp = "192.168.0.12",
				Revision = "1",
				SourceId = "source",
				DestinationZipCode = "96321",
				MailingDate=DateTime.Now,
				TrackIDs = new string[3]
				{
					//new TrackID
					//{
					//	DestinationZipCode = "98745",
					//	Id = 1,
					//	MailingDate= new DateTime(1999,10,03),
					//	TrackId=
						"456789",
					//},
					//new TrackID
					//{
					//	DestinationZipCode = "68745",
					//	Id = 1,
					//	MailingDate= new DateTime(2000,10,03),
						//TrackId=
						"256789",
					//},
					//new TrackID
					//{
						//DestinationZipCode = 
						"88745",
					//	Id = 1,
					//	MailingDate= new DateTime(2001,10,03),
					//	TrackId="956789",
					//},
				},
				Id = 0,
			};

			System.Diagnostics.Debug.WriteLine(output.ToString());

			//XElement.Parse(output.ToString());

			var expected = $"<Revision>1</Revision><ClientIp>192.168.0.12</ClientIp><TrackID ID=\"456789\"></TrackID><TrackID ID=\"256789\"></TrackID><TrackID ID=\"88745\"></TrackID><SourceId>source</SourceId><DestinationZipCode>96321</DestinationZipCode><MailingDate>{DateTime.Now:yyyy-MM-dd}</MailingDate><TrackID ID=\"456789\"></TrackID><TrackID ID=\"256789\"></TrackID><TrackID ID=\"88745\"></TrackID>";

			Assert.Equal(expected, output.ToString());
		}
	}
}
