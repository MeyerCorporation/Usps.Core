using System.Linq;
using System.Xml.Linq;

namespace MeyerCorp.Usps.Api.Models
{
	public class Track : Model
	{
		public string TrackSummary { get; set; }

		public static Track[] Parse(string input)
		{
			var parsed = XElement.Parse(input).Elements("TrackInfo");

			return parsed
				.Select(p => new Track
				{
					Error = p.Element("Error")?.Value,
					TrackSummary = p.Element("TrackSummary")?.Value,
					Id = p.Attribute("ID")?.Value,
				})
			.ToArray();
		}
	}
}
