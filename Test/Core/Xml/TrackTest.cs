using MeyerCorp.Usps.Api.Xml;
using System.Diagnostics;
using System.Xml.Linq;
using Xunit;

namespace Meyer.UspsCore.Test.Core.Xml
{
	public class TrackTest
	{
        [Fact(DisplayName="To String")]
		public void Test0()
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
	}
}
