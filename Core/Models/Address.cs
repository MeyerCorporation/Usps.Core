using System.Xml.Linq;

namespace MeyerCorp.UspsCore.Core.Models
{
    public class Address : Model
    {
        public static Address Parse(XElement element)
        {
            var addressp1 = element.Element("Address1")?.Value;
            var addressp2 = element.Element("Address2")?.Value;

            return new Address
            {
                Address1 = addressp1,
                Address2 = addressp2,
                Business = ToBool(element.Element("Business")?.Value),
                CarrierRoute = element.Element("CarrierRoute")?.Value,
                CentralDeliveryPoint = ToBool(element.Element("CentralDeliveryPoint")?.Value),
                City = element.Element("City")?.Value,
                CityAbbreviation = element.Element("CityAbbreviation")?.Value,
                DeliveryPoint = element.Element("DeliveryPoint")?.Value,
                DPVCMRA = ToBool(element.Element("DPVCMRA")?.Value),
                DPVConfirmation = ToBool(element.Element("DPVConfirmation")?.Value),
                DPVFootnotes = element.Element("DPVFootnotes")?.Value,
                Error = element.Element("Error")?.Value,
                FirmName = element.Element("FirmName")?.Value,
                Footnotes = ToBool(element.Element("Footnotes")?.Value),
                Id = element.Attribute("ID")?.Value,
                State = element.Element("State")?.Value,
                Urbanization = element.Element("Urbanization")?.Value,
                Vacant = ToBool(element.Element("Vacant")?.Value),
                Zip4 = element.Element("Zip4")?.Value,
                Zip5 = element.Element("Zip5")?.Value,
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
