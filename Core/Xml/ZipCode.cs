using MeyerCorp.Usps.Core.Extensions;
using System.Text;

namespace MeyerCorp.Usps.Core.Xml
{
	public class ZipCode : XmlFormatter
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

		/// <summary>
		/// Two-character state code of the destination address.String
		/// </summary>
		/// <remarks></remarks>
		public string Error { get; set; }
		public string Urbanization { get; internal set; }

		public override string ToString()
		{
			var address = new StringBuilder();

			address.AppendXml("FirmName", FirmName);
			address.AppendXml("Address1", Address1);
			address.AppendXml("Address2", Address2);
			address.AppendXml("City", City);
			address.AppendXml("State", State);
			address.AppendXml("Urbanization", Urbanization);
			address.AppendXml("Zip5", Zip5);
			address.AppendXml("Zip4", Zip4);

			return $"<Address ID =\"{Id}\">{address.ToString()}</Address>";
		}
	}
}