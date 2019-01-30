namespace MeyerCorp.Usps.Api.Xml
{
	public class CityStateResponse : XmlFormatter
	{
		public string Id { get; set; }
		public string Zip5 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Error { get; set; }
	}
}
