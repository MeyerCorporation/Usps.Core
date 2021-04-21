using System;
using System.Xml.Linq;

namespace MeyerCorp.Usps.Core.Models
{
	public class TrackDetail
	{
		public string EventTime { get; set; }
		public string EventDate { get; set; }
		public string Event { get; set; }
		public string EventCity { get; set; }
		public string EventState { get; set; }
		public string EventZIPCode { get; set; }
		public string EventCountry { get; set; }
		public string FirmName { get; set; }
		public string Name { get; set; }
		public bool AuthorizedAgent { get; set; }
		public string EventCode { get; set; }
		public string ActionCode { get; set; }
		public string ReasonCode { get; set; }

		public static TrackDetail Parse(XElement input)
		{
			return new TrackDetail
			{
				EventDate = input.Element("EventDate")?.Value,
				EventTime = input.Element("EventTime")?.Value,
				Event = input.Element("Event")?.Value,
				EventCity = input.Element("EventCity")?.Value,
				EventState = input.Element("EventState")?.Value,
				EventZIPCode = input.Element("EventZIPCode")?.Value,
				FirmName = input.Element("FirmName")?.Value,
				Name = input.Element("Name")?.Value,
				AuthorizedAgent = Boolean.Parse(input.Element("AuthorizedAgent").Value),
				EventCode = input.Attribute("EventCode")?.Value,
				ActionCode = input.Attribute("ActionCode")?.Value,
				ReasonCode = input.Attribute("ReasonCode")?.Value,
			};
		}
	}
}