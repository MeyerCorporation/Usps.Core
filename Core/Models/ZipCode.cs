using System;
using System.Xml.Linq;

namespace MeyerCorp.Usps.Core.Models
{
	public class ZipCode : Model
	{
		/// <summary>
		/// Up to 5 address verifications can be included per transaction
		/// </summary>
		/// <remarks>Default is spaces.</remarks>
		public string FirmName { get; set; }

		/// <summary>
		/// Delivery Address in the destination
		/// </summary>
		/// <remarks>Required for all mail and packages, however 11-digit Destination Delivery Point ZIP+4 Code can be provided as an alternative in</remarks>
		public string Address1 { get; set; }

		/// <summary>
		/// Delivery Address in the destination
		/// </summary>
		/// <remarks>May contain secondary unit designator, such as APT or SUITE, for Accountable mail.)</remarks>
		public string Address2 { get; set; }

		/// <summary>
		/// City name of the destination address
		/// </summary>
		/// <remarks>Field is required, unless a verified 11 digit DPV is provided for the mailpiece.</remarks>
		public string City { get; set; }

		/// <summary>
		/// Two-character state code of the destination address
		/// </summary>
		/// <remarks>Default is spaces for International mail.</remarks>
		public string State { get; set; }

		/// <summary>
		/// Destination 5-digit ZIP Code
		/// </summary>
		/// <remarks>Must be 5-digits.Numeric values(0-9) only. If International, all zeroes.</remarks>
		public string Zip5 { get; set; }

		/// <summary>
		/// Destination ZIP+4
		/// </summary>
		/// <remarks>Numeric values(0-9) only.If International, all zeroes.</remarks>
		public string Zip4 { get; set; }

		internal static ZipCode Parse(XElement element)
		{
			var addressp1 = element.Element("Address1")?.Value;
			var addressp2 = element.Element("Address2")?.Value;

			return new ZipCode
			{
				Address1 = addressp1,
				Address2 = addressp2,
				City = element.Element("City")?.Value,
				//Error = Error.Parse(element.Element("Error")),
				FirmName = element.Element("FirmName")?.Value,
				State = element.Element("State")?.Value,
				Zip4 = element.Element("Zip4")?.Value,
				Zip5 = element.Element("Zip5")?.Value,
				Id = element.Attribute("ID")?.Value,
			};
		}
	}
}