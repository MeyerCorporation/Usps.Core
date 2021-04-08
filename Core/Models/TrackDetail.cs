using System;
using System.Linq;
using System.Xml.Linq;

namespace MeyerCorp.Usps.Core.Models
{
	public class TrackDetail
	{
		public DateTime EventDateTime { get; set; }
		public string Event { get; set; }
		public string EventCity { get; set; }
		public string EventState { get; set; }
		public string EventZIPCode { get; set; }
		public string EventCountry { get; set; }
		public string FirmName { get; set; }
		public string Name { get; set; }
		public string AuthorizedAgent { get; set; }
		public string EventCode { get; set; }
		public string ActionCode { get; set; }
		public string ReasonCode { get; set; }

		public static TrackDetail[] Parse(string input)
		{
			var parsed = XElement.Parse(input).Elements("TrackDetail");

			return parsed
				.Select(p => new TrackDetail
				{
					EventDateTime = DateTime.Parse(String.Concat(p.Element("EventDate")?.Value, " ", p.Element("EventTime")?.Value)),
					Event = p.Element("Event")?.Value,
					EventCity = p.Element("EventCity")?.Value,
					EventState = p.Element("EventState")?.Value,
					EventZIPCode = p.Element("EventZIPCode")?.Value,
					FirmName = p.Element("FirmName")?.Value,
					Name = p.Element("Name")?.Value,
					AuthorizedAgent = p.Element("AuthorizedAgent")?.Value,
					EventCode = p.Attribute("EventCode")?.Value,
					ActionCode = p.Attribute("ActionCode")?.Value,
					ReasonCode = p.Attribute("ReasonCode")?.Value,
				})
				.ToArray();
		}
	}
}