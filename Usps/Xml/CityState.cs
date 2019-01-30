using System.Text;

namespace MeyerCorp.Usps.Api.Xml
{
	public class CityState : XmlFormatter
	{
		public string Zip5 { get; set; }

		public override string ToString()
		{
			var address = new StringBuilder();

			address.AppendXml("Zip5", Zip5);

			return $"<ZipCode ID=\"{Id}\">{address.ToString()}</ZipCode>";
		}
	}
}
