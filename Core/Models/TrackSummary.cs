using System;
using System.Xml.Linq;

namespace MeyerCorp.Usps.Core.Models
{
	public class TrackSummary : TrackDetail
	{

		new public static TrackSummary Parse(XElement input)
		{
			return new TrackSummary
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
				DeliveryAttributeCode = input.Attribute("DeliveryAttributeCode")?.Value,
			};
		}

		public string DeliveryAttributeCode { get; set; }
	}
}