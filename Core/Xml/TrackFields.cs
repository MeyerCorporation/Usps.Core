using System.Text;
using MeyerCorp.UspsCore.Core.Extensions;

namespace MeyerCorp.UspsCore.Core.Xml
{
	public class TrackFields : XmlFormatter
	{
		public string Revision { get; set; }

		public string ClientIp { get; set; }

		public string SourceId { get; set; }

		public string SourceIdZIP { get; set; }

		public TrackID[] TrackIDs { get; set; }

		public override string ToString()
		{
			var output = new StringBuilder();

			output.AppendXml("Revision", Revision);
			output.AppendXml("ClientIp", ClientIp);
			output.AppendXml("SourceId", SourceId);
			output.AppendXml("SourceIdZIP", SourceIdZIP);

			foreach (var trackid in TrackIDs)
				output.Append(trackid.ToString());

			return output.ToString();
		}
	}
}
