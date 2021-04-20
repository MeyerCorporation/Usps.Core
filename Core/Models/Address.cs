using System.Xml.Linq;

namespace MeyerCorp.Usps.Core.Models
{
	/// <summary>
	/// Validated Address
	/// </summary>
	public class Address : Model
	{
		/// <summary>
		/// Parse the incoming XML returned from the USPS API.
		/// </summary>
		/// <param name="element">Incoming XML</param>
		/// <returns> A new instance of this type</returns>
		internal static Address Parse(XElement element)
		{
			return new Address
			{
				Address1 = element.Element("Address1")?.Value,
				Address2 = element.Element("Address2")?.Value,
				Address2Abbreviation = element.Element("Address2Abbreviation")?.Value,
				Business = ToBool(element.Element("Business")),
				CarrierRoute = element.Element("CarrierRoute")?.Value,
				CentralDeliveryPoint = ToBool(element.Element("CentralDeliveryPoint")),
				City = element.Element("City")?.Value,
				CityAbbreviation = element.Element("CityAbbreviation")?.Value,
				DeliveryPoint = element.Element("DeliveryPoint")?.Value,
				DPVCMRA = ToBool(element.Element("DPVCMRA")),
				DPVConfirmation = new DpvConfirmation { Raw = element.Element("DPVConfirmation")?.Value },
				DPVFootnotes = new DpvFootnotes { Raw = element.Element("DPVFootnotes")?.Value, },
				Error = Error.Parse(element.Element("Error")),
				FirmName = element.Element("FirmName")?.Value,
				Footnotes = new AddressValidationFootnotes { Raw = element.Element("Footnotes")?.Value },
				Id = element.Attribute("ID")?.Value,
				State = element.Element("State")?.Value,
				Urbanization = element.Element("Urbanization")?.Value,
				Vacant = ToBool(element.Element("Vacant")),
				Zip4 = element.Element("Zip4")?.Value,
				Zip5 = element.Element("Zip5")?.Value,
			};
		}

		/// <summary>
		/// 
		/// </summary>
		public string FirmName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Address1 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Address2 { get; set; }

		/// <summary>
		/// Address line 2 abbreviation.
		/// </summary>
		/// <remarks>To return abbreviations you must set Revision=1</remarks>
		public string Address2Abbreviation { get; set; }

		/// <summary>
		/// City name of the destination address. 
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// Abbreviated city name of the destination address.
		/// </summary>
		/// <remarks>To return abbreviations you must set Revision=1</remarks>
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

		/// <summary>
		/// 
		/// </summary>
		public string DeliveryPoint { get; set; }

		/// <summary>
		/// Carrier Route code.
		/// </summary>
		/// <remarks>Default is spaces. Alphanumeric(5) </remarks>
		public string CarrierRoute { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public AddressValidationFootnotes Footnotes { get; set; }

		/// <summary>
		/// The DPV Confirmation Indicator is the primary method used by the USPS to determine whether an address was considered deliverable or undeliverable.
		/// </summary>
		public DpvConfirmation DPVConfirmation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public bool? DPVCMRA { get; set; }

		/// <summary>
		/// DPV® Standardized Footnotes - EZ24x7Plus and Mail* STAR are required to express DPV results using USPS standard two character footnotes.
		/// Example: AABB
		/// </summary>
		public DpvFootnotes DPVFootnotes { get; set; }

		/// <summary>
		/// Indicates whether address is a business or not
		/// </summary>
		public bool? Business { get; set; }

		/// <summary>
		/// Central Delivery is for all business office buildings, office complexes, and/or industrial/professional parks. This may include call windows, horizontal locked mail receptacles, cluster box units.
		/// </summary>
		public bool? CentralDeliveryPoint { get; set; }

		/// <summary>
		/// Is the location not occupied.
		/// </summary>
		public bool? Vacant { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Urbanization { get; set; }

		public Error Error { get; set; }
	}
}
