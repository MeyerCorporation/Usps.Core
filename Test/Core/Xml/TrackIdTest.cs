using System;
using MeyerCorp.Usps.Core.Xml;
using System.Xml.Linq;
using Xunit;

namespace Meyer.UspsCore.Test.Core.Xml
{
    public class TrackIdTest
    {
        [Fact(DisplayName="To String")]
        public void Test0()
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
    }
}