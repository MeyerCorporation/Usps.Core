using MeyerCorp.UspsCore.Core.Extensions;
using System.Text;

namespace MeyerCorp.UspsCore.Core.Xml
{
	public class Address : XmlFormatter
	{
		/// <summary>
		/// Firm Name
		/// </summary>
		/// <remarks>&lt;FirmName&gt;XYZ Corp.&lt;/FirmName&gt;</remarks>
		public string FirmName { get; set; }

		/// <summary>
		/// Delivery Address in the destination address
		/// </summary>
		/// <remarks>Required for all mail and packages, however 11-digit Destination Delivery Point ZIP+4 Code can be provided as an alternative in the Detail 1 Record.</remarks>
		public string Address1 { get; set; }

		/// <summary>
		/// Delivery Address in the destination address
		/// </summary>
		/// <remarks>May contain secondary unit designator, such as APT or SUITE, for Accountable mail.)</remarks>
		public string Address2 { get; set; }

		/// <summary>
		/// City name of the destination address. 
		/// </summary>
		/// <remarks>Maximum characters allowed: 15</remarks>
		public string City { get; set; }

		/// <summary>
		/// Two-character state code of the destination address.
		/// </summary>
		/// <remarks>Maximum characters allowed: 2</remarks>
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
		/// Urbanization
		/// </summary>
		/// <remarks>Maximum characters allowed: 28. For Puerto Rico addresses only.</remarks>
		public string Urbanization { get; set; }

		public override string ToString()
		{
			var address = new StringBuilder();

			address.AppendXml("Address1", Address1);
			address.AppendXml("Address2", Address2);
			address.AppendXml("City", City);
			address.AppendXml("State", State);
			address.AppendXml("Urbanization", Urbanization);
			address.AppendXml("Zip5", Zip5);
			address.AppendXml("Zip4", Zip4);

			return $"<Address ID=\"{Id}\">{address}</Address>";
		}
	}
}
