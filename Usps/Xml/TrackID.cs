using System;
using System.Text;

namespace MeyerCorp.Usps.Api.Xml
{
	public class TrackID : XmlFormatter
	{
		public string TrackId { get; set; }

		public string DestinationZipCode { get; set; }

		public DateTime? MailingDate { get; set; }

		public override string ToString()
		{
			var output = new StringBuilder();

			output.AppendXml("DestinationZipCode", DestinationZipCode);
			if (MailingDate.HasValue) output.AppendXml("MailingDate", MailingDate.Value.ToString("yyyy-MM-dd"));

			return $"<TrackID ID=\"{TrackId}\">{output}</TrackID>";
		}

	}
}