using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeyerCorp.Usps.Core
{
	public interface IAddresses
	{
		Task<IEnumerable<Models.Address>> ValidateAsync(int revision, params Xml.Address[] addresses);
		Task<IEnumerable<Models.ZipCode>> LookupZipCodeAsync(params Xml.ZipCode[] addresses);
		Task<IEnumerable<Models.CityState>> LookupCityStateAsync(params Xml.CityState[] addresses);
	}
}
