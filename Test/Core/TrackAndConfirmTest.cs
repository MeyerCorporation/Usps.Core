using MeyerCorp.Usps.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using UspsXml = MeyerCorp.Usps.Core.Xml;

namespace Meyer.UspsCore.Test.Core
{
	public class TrackAndConfirmTest : Test
	{
		[Fact(DisplayName = "Track No Packages")]
		public async Task Test1Async()
		{
			var tracking = new TrackAndConfirm(ApiOptions);

			var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => tracking.TrackAsync(new UspsXml.TrackID[]
			{
				new UspsXml.TrackID
				{
					Id = 0,
					TrackId = null,
				}
			}));

			Assert.Equal("The &#39;ID&#39; attribute is invalid - The value &#39;&#39; is invalid according to its datatype &#39;http://www.w3.org/2001/XMLSchema:NMTOKEN&#39; - The empty string &#39;&#39; is not a valid name.", ex.Message);
		}

		[Fact(DisplayName = "Track Bad Packages ID")]
		public async Task Test2Async()
		{
			var tracking = new TrackAndConfirm(ApiOptions);

			var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => tracking.TrackAsync(new UspsXml.TrackID[]
			{
				new UspsXml.TrackID
				{
					TrackId = "9405 5036 9930 0333 4765 26",
				}
			}));

			Assert.Equal("The &#39;ID&#39; attribute is invalid - The value &#39;9405 5036 9930 0333 4765 26&#39; is invalid according to its datatype &#39;http://www.w3.org/2001/XMLSchema:NMTOKEN&#39; - The &#39; &#39; character, hexadecimal value 0x20, cannot be included in a name.", ex.Message);
		}

		[Fact(DisplayName = "Track Single ID")]
		public async Task Test3Async()
		{
			var tracking = new TrackAndConfirm(ApiOptions);

			var results = await tracking.TrackAsync(new UspsXml.TrackID[]
			{
				new UspsXml.TrackID
				{
					TrackId = "9405503699300333476526",
				}
			});

			Assert.Equal("Your item was delivered to a parcel locker at 10:45 am on April 6, 2021 in ORLANDO, FL 32832.", results.First().TrackSummary);
			Assert.Equal("Out for Delivery, 04/06/2021, 7:51 am, ORLANDO, FL 32832", results.First().TrackDetails.First());
		}


		[Fact(DisplayName = "Track double ID")]
		public async Task Test4Async()
		{
			var tracking = new TrackAndConfirm(ApiOptions);

			var results = await tracking.TrackAsync(new UspsXml.TrackID[]
			{
				new UspsXml.TrackID
				{
					TrackId = "9405503699300333476526",
				},
				new UspsXml.TrackID
				{
					TrackId = "9405503699300050852016",
				},
				new UspsXml.TrackID
				{
					TrackId = "9405803699300034770504",
				},
				new UspsXml.TrackID
				{
					TrackId = "XXXXXXXXXXX2",
				}
			});

			Assert.Equal("Your item was delivered to a parcel locker at 10:45 am on April 6, 2021 in ORLANDO, FL 32832.", results.First().TrackSummary);
			Assert.Equal("Out for Delivery, 04/06/2021, 7:51 am, ORLANDO, FL 32832", results.First().TrackDetails.First());
			Assert.Equal("The Postal Service could not locate the tracking information for your request. Please verify your tracking number and try again later.", results.Last().TrackSummary);
		}
	}
}
