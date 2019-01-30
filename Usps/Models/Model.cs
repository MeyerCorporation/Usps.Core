using System;

namespace MeyerCorp.Usps.Api.Models
{
	public abstract class Model
	{
		public string Error { get; set; }

		protected static bool? ToBool(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
				return null;
			else if (value.Equals("n", StringComparison.InvariantCultureIgnoreCase))
				return false;
			else if (value.Equals("y", StringComparison.InvariantCultureIgnoreCase))
				return true;
			else
				throw new ArgumentException("Input value must be a 'Y', 'N', null, empty, or whitespace.");
		}

	}
}