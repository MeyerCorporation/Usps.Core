using MeyerCorp.Usps.Api.Xml;
using System.Diagnostics;
using Xunit;

namespace Meyer.UspsCore.Test.Core.Xml
{
    public class CityStateTest
    {
        [Fact(DisplayName="To String")]
        public void Test0()
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
    }
}