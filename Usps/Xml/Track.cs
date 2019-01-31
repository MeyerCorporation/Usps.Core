using System.Text;

namespace MeyerCorp.Usps.Api.Xml
{
	internal class Track : XmlFormatter
	{
		public string TrackId { get; set; }

		public override string ToString()
		{
			var address = new StringBuilder();

			address.AppendXml("TrackID", string.Empty, "ID", TrackId);

			return address.ToString();
		}
	}
}