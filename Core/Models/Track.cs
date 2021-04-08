using System.Linq;
using System.Xml.Linq;

namespace MeyerCorp.UspsCore.Core.Models
{
	public class Track : Model
	{
		public string TrackSummary { get; set; }

		public string[] TrackDetails { get; set; }

		//public static Track[] Parse(string input)
		//{
		//	var parsed = XElement.Parse(input).Elements("TrackInfo");

		//	return parsed
		//		.Select(p => new Track
		//		{
		//			Error = p.Element("Error")?.Value,
		//			TrackSummary = p.Element("TrackSummary")?.Value,
		//			TrackDetails = p.Elements("TrackDetail").Select(td=>td.Value).ToArray(),
		//			Id = p.Attribute("ID")?.Value,
		//		})
		//	.ToArray();
		//}
	}
}
