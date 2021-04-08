using System;

namespace MeyerCorp.UspsCore.Core.Models
{
	public class TrackFields : Model
	{
		public string TrackId { get; set; }

		public DateTime? GuaranteedDeliveryDate { get; set; }

		public TrackSummary TrackSummary { get; set; }

		public TrackDetail[] TrackDetails { get; set; }

		//public static TrackFields[] Parse(string input)
		//{
		//	throw new NotImplementedException();
		//	//var parsed = XElement.Parse(input).Elements("Address");

		//	//return new TrackFields
		//	//{
		//	//	//Address1 = addressp1,
		//	//	//Address2 = addressp2,
		//	//	//City = parsed.Element("City")?.Value,
		//	//	//Error = parsed.Element("Error")?.Value,
		//	//	//FirmName = parsed.Element("FirmName")?.Value,
		//	//	//State = parsed.Element("State")?.Value,
		//	//	//Zip4 = parsed.Element("Zip4")?.Value,
		//	//	//Zip5 = parsed.Element("Zip5")?.Value,
		//	//	//Id = parsed.Attribute("ID")?.Value,
		//	//};
		//}

		public override void Parse(string input)
		{
			throw new NotImplementedException();
		}
	}
}