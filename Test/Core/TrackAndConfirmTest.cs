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

			var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => tracking.TrackAsync(new string[]
		   {
				null,
			}));

			Assert.Equal("The USPS API returned an error.", ex.Message);
			Assert.True(ex.Data.Contains("Error"));
			Assert.NotNull(ex.Data["Error"] as System.Xml.Linq.XDocument);
			Assert.Equal("Error", (ex.Data["Error"] as System.Xml.Linq.XDocument).Root.Name);
		}

		[Fact(DisplayName = "Track Bad Packages ID")]
		public async Task Test2Async()
		{
			var tracking = new TrackAndConfirm(ApiOptions);

			var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => tracking.TrackAsync(new string[]
		   {
				"9405 5036 9930 0333 4765 26",
		   }));

			Assert.Equal("The USPS API returned an error.", ex.Message);
			Assert.True(ex.Data.Contains("Error"));
			Assert.NotNull(ex.Data["Error"] as System.Xml.Linq.XDocument);
			Assert.Equal("Error", (ex.Data["Error"] as System.Xml.Linq.XDocument).Root.Name);
		}

		[Fact(DisplayName = "Track Single ID")]
		public async Task Test3Async()
		{
			var tracking = new TrackAndConfirm(ApiOptions);

			var results = await tracking.TrackAsync(new string[]
			{
				"9405503699300333476526",
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

			var results = await tracking.TrackAsync(new string[]
			{
				"9405503699300333476526",
				"9405503699300050852016",
				"9405803699300034770504",
				"XXXXXXXXXXX2",
			});

			var list = results.ToList();

			Assert.Equal(4, results.Count());
			Assert.Equal(2, results.Select(r => r.Error).Where(r => r != null).Count());
			Assert.Equal("A status update is not yet available on your Priority Mail<SUP>&reg;</SUP> package. It will be available when the shipper provides an update or the package is delivered to USPS. Check back soon. Sign up for Informed Delivery<SUP>&reg;</SUP> to receive notifications for packages addressed to you.", list[1].Error.Description);
			Assert.Equal("Your item was delivered to a parcel locker at 10:45 am on April 6, 2021 in ORLANDO, FL 32832.", list[0].TrackSummary);
			Assert.Equal("Out for Delivery, 04/06/2021, 7:51 am, ORLANDO, FL 32832", list[0].TrackDetails.First());
			Assert.Equal("The Postal Service could not locate the tracking information for your request. Please verify your tracking number and try again later.", list[3].TrackSummary);
		}
	}
}
