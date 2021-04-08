using System.Linq;
using System.Xml.Linq;

namespace MeyerCorp.UspsCore.Core.Models
{
	public class CityState : Model
	{
		public string Zip5 { get; set; }
		public string City { get; set; }
		public string State { get; set; }

		public override void Parse(string input)
		{
			throw new System.NotImplementedException();
			//var parsed = XElement.Parse(input).Elements("ZipCode");

			//return parsed
			//	.Select(p => new CityState
			//	{
			//		City = p.Element("City")?.Value,
			//		Error = p.Element("Error")?.Value,
			//		Zip5 = p.Element("Zip5")?.Value,
			//		State = p.Element("State")?.Value,
			//		Id = p.Attribute("ID")?.Value,
			//	})
			//.ToArray();
		}
	}
}
