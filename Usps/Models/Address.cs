using System.Xml.Linq;

namespace MeyerCorp.Usps.Api.Models
{
	public class Address : Model
	{
		public static Address Parse(string input)
		{
			var parsed = XElement.Parse(input).Element("Address");

			var addressp1 = parsed.Element("Address1")?.Value;
			var addressp2 = parsed.Element("Address2")?.Value;

			return new Address
			{
				Address1 = addressp1,
				Address2 = addressp2,
				Business = ToBool(parsed.Element("Business")?.Value),
				CarrierRoute = parsed.Element("CarrierRoute")?.Value,
				CentralDeliveryPoint = ToBool(parsed.Element("CentralDeliveryPoint")?.Value),
				City = parsed.Element("City")?.Value,
				CityAbbreviation = parsed.Element("CityAbbreviation")?.Value,
				DeliveryPoint = parsed.Element("DeliveryPoint")?.Value,
				DPVCMRA = ToBool(parsed.Element("DPVCMRA")?.Value),
				DPVConfirmation = ToBool(parsed.Element("DPVConfirmation")?.Value),
				DPVFootnotes = parsed.Element("DPVFootnotes")?.Value,
				Error = parsed.Element("Error")?.Value,
				FirmName = parsed.Element("FirmName")?.Value,
				Footnotes = ToBool(parsed.Element("Footnotes")?.Value),
				Id = parsed.Attribute("ID")?.Value,
				State = parsed.Element("State")?.Value,
				Urbanization = parsed.Element("Urbanization")?.Value,
				Vacant = ToBool(parsed.Element("Vacant")?.Value),
				Zip4 = parsed.Element("Zip4")?.Value,
				Zip5 = parsed.Element("Zip5")?.Value,
			};
		}

		public string FirmName { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }

		/// <summary>
		/// City name of the destination address. 
		/// </summary>
		public string City { get; set; }
		public string CityAbbreviation { get; set; }

		/// <summary>
		/// Two-character state code of the destination address.
		/// </summary>
		public string State { get; set; }

		/// <summary>
		/// Destination 5-digit ZIP Code
		/// </summary>
		/// <remarks>Numeric values (0-9) only. If International, all zeroes. Default to spaces if not available.</remarks>
		public string Zip5 { get; set; }

		/// <summary>
		/// Destination ZIP+4
		/// </summary>
		/// <remarks>Numeric values (0-9) only. If International, all zeroes. Default to spaces if not available.</remarks>
		public string Zip4 { get; set; }
		public string DeliveryPoint { get; set; }

		/// <summary>
		/// Carrier Route code.
		/// </summary>
		/// <remarks>Default is spaces. Alphanumeric(5) </remarks>
		public string CarrierRoute { get; set; }
		public bool? Footnotes { get; set; }
		public bool? DPVConfirmation { get; set; }
		public bool? DPVCMRA { get; set; }
		public string DPVFootnotes { get; set; }
		public bool? Business { get; set; }
		public bool? CentralDeliveryPoint { get; set; }
		public bool? Vacant { get; set; }
		public string Urbanization { get; internal set; }
	}
}
