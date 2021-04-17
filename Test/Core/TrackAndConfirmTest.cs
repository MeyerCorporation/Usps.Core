using MeyerCorp.Usps.Core;
using MeyerCorp.Usps.Core.Extentions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using CoreXmls = MeyerCorp.Usps.Core.Xml;
using CoreModel = MeyerCorp.Usps.Core.Models;

namespace Meyer.UspsCore.Test.Core
{
	public class TrackAndConfirmTest : Test
	{
		[Fact(DisplayName = "Track No Packages")]
		public async Task Test1Async()
		{
			var tracking = new TrackAndConfirm(ApiOptions);

			var results = await tracking.TrackAsync(new CoreXmls.TrackID[]
			{
				new CoreXmls.TrackID
				{
					Id = 0,
					TrackId = null,
				}
			});

			Assert.Single(results);
			Assert.NotNull(results.Errors().First());
			Assert.Equal("The &#39;ID&#39; attribute is invalid - The value &#39;&#39; is invalid according to its datatype &#39;http://www.w3.org/2001/XMLSchema:NMTOKEN&#39; - The empty string &#39;&#39; is not a valid name.", results.Errors().First().Description);
		}

		[Fact(DisplayName = "Track Bad Packages ID")]
		public async Task Test2Async()
		{
			var tracking = new TrackAndConfirm(ApiOptions);

			var results = await tracking.TrackAsync(new CoreXmls.TrackID[]
			{
				new CoreXmls.TrackID
				{
					TrackId = "9405 5036 9930 0333 4765 26",
				}
			});

			Assert.Single(results);
			Assert.NotNull(results.Errors().First());
			Assert.Equal("The &#39;ID&#39; attribute is invalid - The value &#39;9405 5036 9930 0333 4765 26&#39; is invalid according to its datatype &#39;http://www.w3.org/2001/XMLSchema:NMTOKEN&#39; - The &#39; &#39; character, hexadecimal value 0x20, cannot be included in a name.", results.Errors().First().Description);
		}

		[Fact(DisplayName = "Track Single ID")]
		public async Task Test3Async()
		{
			var tracking = new TrackAndConfirm(ApiOptions);

			var results = await tracking.TrackAsync(new CoreXmls.TrackID[]
			{
				new CoreXmls.TrackID
				{
					TrackId = "9405503699300333476526",
				}
			});

			var infos = results.As<CoreModel.TrackingInformation>();

			Assert.Empty(results.Errors());
			Assert.Single(infos);
			Assert.Equal("Your item was delivered to a parcel locker at 10:45 am on April 6, 2021 in ORLANDO, FL 32832.", infos.First().TrackSummary);
			Assert.Equal("Out for Delivery, 04/06/2021, 7:51 am, ORLANDO, FL 32832", infos.First().TrackDetails.First());
		}


		[Fact(DisplayName = "Track double ID")]
		public async Task Test4Async()
		{
			var tracking = new TrackAndConfirm(ApiOptions);

			var results = await tracking.TrackAsync(new CoreXmls.TrackID[]
			{
				new CoreXmls.TrackID
				{
					TrackId = "9405503699300333476526",
				},
				new CoreXmls.TrackID
				{
					TrackId = "9405503699300050852016",
				},
				new CoreXmls.TrackID
				{
					TrackId = "9405803699300034770504",
				},
				new CoreXmls.TrackID
				{
					TrackId = "XXXXXXXXXXX2",
				}
			});

			var list = results.ToList();

			Assert.Equal(4, results.Count());
			Assert.Equal(2,results.Select(r => r.Error).Where(r=>r!=null).Count());
			Assert.Equal("A status update is not yet available on your Priority Mail<SUP>&reg;</SUP> package. It will be available when the shipper provides an update or the package is delivered to USPS. Check back soon. Sign up for Informed Delivery<SUP>&reg;</SUP> to receive notifications for packages addressed to you.", list[1].Error.Description);
			Assert.Equal("Your item was delivered to a parcel locker at 10:45 am on April 6, 2021 in ORLANDO, FL 32832.", list[0].TrackSummary);
			Assert.Equal("Out for Delivery, 04/06/2021, 7:51 am, ORLANDO, FL 32832", list[0].TrackDetails.First());
			Assert.Equal("The Postal Service could not locate the tracking information for your request. Please verify your tracking number and try again later.", list[3].TrackSummary);
		}
	}
}
