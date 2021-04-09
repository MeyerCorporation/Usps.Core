using System;
using System.Collections.Generic;
using System.Linq;

namespace MeyerCorp.Usps.Core.Models
{
	/// <summary>
	/// Validation footnotes
	/// </summary>
	public class AddressValidationFootnotes : Footnotes
	{
		/// <summary>
		/// Collection of the notes returned with their corresponding definitions
		/// </summary>
		public override IEnumerable<EnumerationDefinition> Enumerations
		{
			get
			{
				var raw = Raw;
				var li = raw.Contains("LI")
					? new EnumerationDefinition
					{
						Enumeration = "LI",
						Definition = "Match has been converted via LACS",
					}
					: (EnumerationDefinition?)null;

				raw.Replace("LI", string.Empty);

				var list = raw
					.Select(r => new EnumerationDefinition
					{
						Enumeration = r.ToString(),
						Definition = GetDescription(r),
					}).ToList();

				if (li.HasValue) list.Add(li.Value);

				return list.OrderBy(l => l.Enumeration);
			}
		}

		public override string ToString()
		{
			return String.IsNullOrWhiteSpace(Raw)
				? "(N/A)"
				: String.Join(Environment.NewLine, Enumerations);
		}

		private string GetDescription(char enumeration)
		{
			return enumeration switch
			{
				'A' => "Zip Code Corrected",
				'B' => "City/State Spelling Corrected",
				'C' => "Invalid City/State/Zip",
				'D' => "NO ZIP + 4 Assigned",
				'E' => "Zip Code Assigned for Multiple Response",
				'F' => "Address could not be found in the National Directory File Database",
				'G' => "Information in Firm Line used for matching",
				'H' => "Missing Secondary Number",
				'I' => "Insufficient/Incorrect Address Data",
				'J' => "Dual Address",
				'K' => "Multiple Response due to Cardinal Rule",
				'L' => "Address component changed",
				'M' => "Street Name changed",
				'N' => "Address Standardized",
				'O' => "Lowest + 4 Tie - Breaker",
				'P' => "Better address exists",
				'Q' => "Unique Zip Code match",
				'R' => "No match due to EWS",
				'S' => "Incorrect Secondary Address",
				'T' => "Multiple response due to Magnet Street Syndrome",
				'U' => "Unofficial Post Office name",
				'V' => "Unverifiable City/State",
				'W' => "Invalid Delivery Address",
				'X' => "No match due to out of range alias",
				'Y' => "Military match",
				'Z' => "Match made using the ZIPMOVE product data",
				_ => throw new ArgumentOutOfRangeException(),
			};
		}
	}
}