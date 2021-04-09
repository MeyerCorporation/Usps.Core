using System;
using System.Collections.Generic;
using System.Linq;

namespace MeyerCorp.Usps.Core.Models
{
	/// <summary>
	/// DPV® Standardized Footnotes - EZ24x7Plus and Mail*STAR are required to express DPV results using USPS standard two character footnotes. 
	/// Example: AABB
	/// </summary>
	public class DpvFootnotes:Footnotes
	{
		/// <summary>
		/// Collection of the notes returned with their corresponding definitions
		/// </summary>
		public override IEnumerable<EnumerationDefinition> Enumerations
		{
			get
			{
				var output = new List<EnumerationDefinition>();

				for (int index = 0; index < Raw.Length; index += 2)
				{
					var enumeration = Raw.Substring(index, 2);

					output.Add(new EnumerationDefinition
					{
						Enumeration = enumeration,
						Definition = GetDescription(enumeration),
					});
				}

				return output.OrderBy(o => o.Enumeration);
			}
		}

		public override string ToString()
		{
			return String.IsNullOrWhiteSpace(Raw)
				? "(N/A)"
				: String.Join(Environment.NewLine, Enumerations);
		}

		private string GetDescription(string enumeration)
		{
			return enumeration switch
			{
				"AA" => "Input address matched to the ZIP+4 file.",
				"A1" => "Input address not matched to the ZIP+4 file.",
				"BB" => "Matched to DPV (all components).",
				"CC" => "Secondary number not matched (present but invalid).",
				"N1" => "High-rise address missing secondary number.",
				"M1" => "Primary number missing.",
				"M3" => "Primary number invalid.",
				"P1" => "Input Address RR or HC Box number Missing.",
				"P3" => "Input Address PO, RR, or HC Box number Invalid.",
				"F1" => "Input Address Matched to a Military Address.",
				"G1" => " Input Address Matched to a General Delivery Address.",
				"U1" => "Input Address Matched to a Unique ZIP Code™.",
				_ => throw new ArgumentOutOfRangeException(),
			};
		}
	}
}










