using System;
using System.Xml.Linq;

namespace MeyerCorp.Usps.Core.Models
{
	public abstract class Model
	{
		public string Id { get; set; }

		protected static bool? ToBool(XElement xml)
		{
			if (xml == null)
				return null;
			else
			{
				var value = xml.Value;

				if (string.IsNullOrWhiteSpace(value))
					return null;
				else if (value.Equals("n", StringComparison.InvariantCultureIgnoreCase) || value.Equals("false", StringComparison.InvariantCultureIgnoreCase))
					return false;
				else if (value.Equals("y", StringComparison.InvariantCultureIgnoreCase) || value.Equals("true", StringComparison.InvariantCultureIgnoreCase))
					return true;
				else
					throw new ArgumentException("Input value must be a 'Y', 'N', true, false, null, empty, or whitespace.");
			}
		}

		protected static DateTime? ToDateTime(XElement xml)
		{
			if (xml == null)
				return null;
			else
			{
				var value = xml.Value;

				if (string.IsNullOrWhiteSpace(value))
					return null;
				else
					return DateTime.Parse(xml.Value);
			}
		}
	}
}