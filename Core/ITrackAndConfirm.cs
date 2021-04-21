using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeyerCorp.Usps.Core
{
	public interface ITrackAndConfirm
	{
		Task<IEnumerable<Models.TrackingInformation>> TrackAsync(params string[] trackingIds);

		Task<IEnumerable<Models.TrackingInformationFields>> TrackByFieldsAsync(int revision, string clientIp, string sourceId, string destinationZipCode, DateTime? mailingDate, params string[] trackingIds);
	}
}