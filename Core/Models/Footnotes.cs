using System;
using System.Collections.Generic;

namespace MeyerCorp.Usps.Core.Models
{
	public abstract class Footnotes
	{
		/// <summary>
		/// String as returned from the USPS API
		/// </summary>
		public string Raw { get; set; }

		public abstract IEnumerable<EnumerationDefinition> Enumerations { get; }

		public override string ToString()
		{
			return String.IsNullOrWhiteSpace(Raw)
				? "(N/A)"
				: String.Join(Environment.NewLine, Enumerations);
		}
	}
}
