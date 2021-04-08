using System;
using System.Collections.Generic;
using System.Linq;

namespace MeyerCorp.Usps.Core.Models
{
	/// <summary>
	/// The DPV Confirmation Indicator is the primary method used by the USPS to determine whether an address was considered deliverable or undeliverable.
	/// </summary>
	public class DpvConfirmation
	{
		/// <summary>
		/// String as returned from the USPS API
		/// </summary>
		public string Raw { get; set; }

		/// <summary>
		/// Collection of the notes returned with their corresponding definitions
		/// </summary>
		public IEnumerable<EnumerationDefinition> Enumerations
		{
			get
			{
				return Raw
					.Select(r => new EnumerationDefinition
					{
						Enumeration = r.ToString(),
						Definition = GetDescription(r),
					})
					.OrderBy(l => l.Enumeration);
			}
		}

		public override string ToString()
		{
			return String.Join(Environment.NewLine, Enumerations);
		}

		private string GetDescription(char enumeration)
		{
			return enumeration switch
			{
				'D' => "Address was DPV confirmed for the primary number only, and the secondary number information was missing.",
				'N' => "Both primary and (if present) secondary number information failed to DPV confirm.",
				'S' => "Address was DPV confirmed for the primary number only, and the secondary number information was present by not confirmed.",
				'Y' => "Address was DPV confirmed for both primary and (if present) secondary numbers.",
				_ => throw new ArgumentOutOfRangeException(),
			};
		}
	}
}
