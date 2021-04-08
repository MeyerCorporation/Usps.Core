using MeyerCorp.Usps.Core.Extensions;
using System.Text;

namespace MeyerCorp.Usps.Core.Xml
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
