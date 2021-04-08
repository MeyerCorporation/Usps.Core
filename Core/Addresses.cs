using MeyerCorp.UspsCore.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeyerCorp.UspsCore.Core
{
	public class Addresses : Api
	{
		/// <summary>
		/// The Address/Standardization “Verify” API, which corrects errors in street addresses, including abbreviations and missing information, and supplies ZIP Codes and ZIP Codes + 4. The Verify API supports up to five lookups per transaction. By eliminating address errors, you will improve overall package delivery service.
		/// </summary>
		/// <returns></returns>
		/// <remarks>Sample Request <code>
		/// &lt;AddressValidateRequest USERID="XXXXXXXXXXXX"&gt;
		/// &lt;Revision&gt;1&lt;/Revision&gt;
		/// &lt;Address ID = "0" & gt;
		/// &lt;Address1&gt;SUITE K&lt;/Address1&gt;
		/// &lt;Address2&gt;29851 Aventura&lt;/Address2&gt;
		/// &lt;City/&gt;
		/// &lt;State&gt;CA&lt;/State&gt;
		/// &lt;Zip5&gt;92688&lt;/Zip5&gt;
		/// &lt;Zip4/&gt;
		/// &lt;/Address&gt;
		/// &lt;/AddressValidateRequest&gt;
		/// </code></remarks>
		public async Task<Models.Address> ValidateAsync(int revision, params Xml.Address[] addresses)
		{
			var xmlrequest = new AddressValidateRequest
			{
				UserId = UserId,
				Revision = revision,
				Addresses = addresses,
			};

			var id = 0;
			foreach (var address in addresses)
				address.Id = id++;

			Request.RequestUri = GetUrl(apiName: "Verify", type: "AddressValidateRequest", xmlrequest.ToString());

			var response = await HttpClient.SendAsync(Request);

			return await CheckResponseAsync<Models.Address>(response);

		}

		/// <summary>
		/// The ZipCodeLookup API, which returns the ZIP Code and ZIP Code + 4 corresponding to the given address, city, and state (use USPS state abbreviations). The ZipCodeLookup API processes up to five lookups per request.
		/// </summary>
		/// <returns></returns>
		public object LookupZipCode() { throw new NotImplementedException(); }

		/// <summary>
		/// City/State Lookup API returns the city and state corresponding to the given ZIP Code. The CityStateLookup API processes up to five lookups per request.
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<Models.CityState>> LookupCityStateAsync(string zip51,
			string zip52 = null,
			string zip53 = null,
			string zip54 = null,
			string zip55 = null)
		{
			var xmlrequest = new LookupCityStateRequest
			{
				Zip51 = zip51,
				Zip52 = zip52,
				Zip53 = zip53,
				Zip54 = zip54,
				Zip55 = zip55,
			};

			Request.RequestUri = GetUrl("CityStateLookup", "CityStateLookupRequest", xmlrequest.ToString());
			//new Api.Xml.CityState { Zip5 = zip51, Id = 0, },
			//		zip52 == null ? null : new Api.Xml.CityState { Zip5 = zip52, Id = 1, },
			//		zip53 == null ? null : new Api.Xml.CityState { Zip5 = zip53, Id = 2, },
			//		zip54 == null ? null : new Api.Xml.CityState { Zip5 = zip54, Id = 3, },
			//		zip55 == null ? null : new Api.Xml.CityState { Zip5 = zip55, Id = 4, });

			var response = await HttpClient.SendAsync(Request);

			return await CheckResponseAsync<Models.CityState>(response);
		}

		private class AddressValidateRequest
		{
			public string UserId { get; set; }
			public int Revision { get; set; }
			public Xml.Address[] Addresses { get; set; }

			public override string ToString()
			{
				var request = new StringBuilder();

				request.AppendXml("Revision", Revision.ToString());

				foreach (var address in Addresses.Where(i => i != null).Select(a => a.ToString()))
					request.Append(address);

				return request.ToString();
			}
		}

		private class LookupCityStateRequest
		{
			public string Zip51 { get; set; }
			public string Zip52 { get; set; }
			public string Zip53 { get; set; }
			public string Zip54 { get; set; }
			public string Zip55 { get; set; }
		}
	}
}
