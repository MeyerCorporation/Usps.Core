using System;
using System.Collections.Generic;
using System.Text;
using MeyerCorp.Usps.Core.Extensions;

namespace MeyerCorp.Usps.Core.Xml
{
	public class TrackFields : XmlFormatter
	{
		/// <summary>
		/// This is for versioning of the API's and for triggering response tags for future versions. In this API use a value of 1 to return all available response tags and trigger new functionality.
		/// </summary>
		public string Revision { get; set; }

		/// <summary>
		/// User IP address.Required when TrackFieldRequest[Revision = '1'].
		/// </summary>
		public string ClientIp { get; set; }

		/// <summary>
		/// External integrators should pass company name.
		/// </summary>
		public string SourceId { get; set; }

		/// <summary>
		/// Package Tracking ID.  Must be alphanumeric characters.
		/// </summary>
		public IEnumerable<string> TrackIDs { get; set; }

		/// <summary>
		/// 5 digit destination zip code.
		/// </summary>
		public string DestinationZipCode { get; set; }

		/// <summary>
		/// Mailing date of package.  
		/// </summary><remarks>Format: YYYY-MM-DD</remarks>
		public DateTime? MailingDate { get; set; }

		public override string ToString()
		{
			var output = new StringBuilder();

			output.AppendXml("Revision", Revision);
			output.AppendXml("ClientIp", ClientIp);

			foreach (var trackid in TrackIDs)
				output.AppendXml("TrackID", null, "ID", trackid);

			output.AppendXml("SourceId", SourceId);
			output.AppendXml("DestinationZipCode", DestinationZipCode);
			if (MailingDate.HasValue)
				output.AppendXml("MailingDate", MailingDate.Value.ToString("yyyy-MM-dd"));

			foreach (var trackid in TrackIDs)
				output.AppendXml("TrackID", null, "ID", trackid.ToString());

			return output.ToString();
		}
	}
}
