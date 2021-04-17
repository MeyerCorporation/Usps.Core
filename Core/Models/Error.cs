using System;
using System.Xml.Linq;

namespace MeyerCorp.Usps.Core.Models
{
	public class Error : Model
	{
		public int Number { get; set; }
		public string Description { get; set; }
		public string HelpFile { get; set; }
		public string HelpContext { get; set; }

		internal static Error Parse(XElement element)
		{
			if (element == null)
				return null;
			else
				return new Error
				{
					Number = Int32.Parse(element.Element("Number")?.Value),
					Description = element.Element("Description")?.Value,
					HelpFile = element.Element("HelpFile")?.Value,
					HelpContext = element.Element("HelpContext")?.Value,
				};
		}
	}
}