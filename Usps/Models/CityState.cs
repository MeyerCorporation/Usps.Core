using System.Xml.Linq;

namespace MeyerCorp.Usps.Api.Models
{
	public class CityState:Model
	{
		public string Zip5 { get; set; }
		public string City { get; set; }
		public string State { get; set; }

		public static CityState Parse(string input)
		{
			var parsed = XElement.Parse(input).Element("ZipCode");

			return new CityState
			{
				City = parsed.Element("City")?.Value,
				Error = parsed.Element("Error")?.Value,
				Zip5 = parsed.Element("Zip5")?.Value,
				State = parsed.Element("State")?.Value,
			};
		}
	}
}
