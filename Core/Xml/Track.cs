using MeyerCorp.UspsCore.Core.Extensions;
using System.Text;

namespace MeyerCorp.UspsCore.Core.Xml
{
	public class Track : XmlFormatter
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