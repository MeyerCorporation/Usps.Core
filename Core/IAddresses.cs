using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeyerCorp.Usps.Core
{
	public interface IAddresses
	{
		Task<IEnumerable<Models.Address>> ValidateAsync(int revision, params Xml.Address[] addresses);
		Task<IEnumerable<Models.ZipCode>> LookupZipCodeAsync(params Xml.ZipCode[] addresses);
		Task<IEnumerable<Models.CityState>> LookupCityStateAsync(string zip51,
			string zip52 = null,
			string zip53 = null,
			string zip54 = null,
			string zip55 = null);
	}
}
