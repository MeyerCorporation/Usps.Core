using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MeyerCorp.Usps.Core.Models
{
	/// <summary>
	/// Tracking information model
	/// </summary>
	/// <remarks>TODO: Consider parsing the date time data out of the trackdetails to create more sortability, etc.</remarks>
	public class TrackingInformation : Model
	{
		public string TrackSummary { get; set; }
		public IEnumerable<string> TrackDetails { get; set; }
		public Error Error { get; set; }

		internal static TrackingInformation Parse(XElement element)
		{
			return new TrackingInformation
			{
				TrackSummary = element.Element("TrackSummary")?.Value,
				TrackDetails = element.Elements("TrackDetail")?.Select(td => td?.Value),
				Id = element.Attribute("ID")?.Value,
				Error = Error.Parse(element.Element("Error")),
			};
		}

		public override string ToString()
		{
			var output = new StringBuilder();

			output.AppendLine(TrackSummary);
			output.AppendJoin(Environment.NewLine, TrackDetails);

			return output.ToString();
		}
	}
}