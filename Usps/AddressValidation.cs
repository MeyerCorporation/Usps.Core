using MeyerCorp.Usps.Api.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeyerCorp.Usps.Addresses
{
    public class AddressValidation : Validation
    {
        public async Task<Address> VerifyAddressAsync(string firmname = null,
            string address1 = null,
            string address2 = null,
            string city = null,
            string state = null,
            string zip5 = null,
            string zip4 = null,
            string urbanization = null)
        {
            using var client = new HttpClient();
            using var requestmessage = new HttpRequestMessage();

            requestmessage.RequestUri = GetUrl(userId: String.Empty,
            baseUrl: String.Empty,
            path: String.Empty,
            api: "Verify",
            type: "AddressValidateRequest", new Api.Xml.Address
            {
                Address1 = address1,
                Address2 = address2,
                City = city,
                FirmName = firmname,
                Id = 0,
                State = state,
                Urbanization = urbanization,
                Zip4 = zip4,
                Zip5 = zip5,
            });

            var response = await client.SendAsync(requestmessage);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                if (CheckError(responseString))
                {
                    var message = GetError(responseString);
                    throw new InvalidOperationException(message);
                }
                else
                {
                    return Address.Parse(responseString);
                }
            }
            else
                throw new InvalidOperationException(responseString);
        }

        public async Task<CityState[]> LookupCityStateAsync(string zip51,
            string zip52 = null,
            string zip53 = null,
            string zip54 = null,
            string zip55 = null)
        {
            using var client = new HttpClient();
            using var requestmessage = new HttpRequestMessage();

            requestmessage.RequestUri = GetUrl(userId: String.Empty,
            baseUrl: String.Empty,
            path: String.Empty,
            api: "CityStateLookup",
                "CityStateLookupRequest",
                new Api.Xml.CityState { Zip5 = zip51, Id = 0, },
                    zip52 == null ? null : new Api.Xml.CityState { Zip5 = zip52, Id = 1, },
                    zip53 == null ? null : new Api.Xml.CityState { Zip5 = zip53, Id = 2, },
                    zip54 == null ? null : new Api.Xml.CityState { Zip5 = zip54, Id = 3, },
                    zip55 == null ? null : new Api.Xml.CityState { Zip5 = zip55, Id = 4, });

            var response = await client.SendAsync(requestmessage);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                if (CheckError(responseString))
                {
                    var message = GetError(responseString);
                    throw new InvalidOperationException(message);
                }
                else
                {
                    return CityState.Parse(responseString);
                }
            }
            else
                throw new InvalidOperationException(responseString);
        }

        public async Task<ZipCode> LookupZipCodeAsync(string address1 = null,
            string address2 = null,
            string city = null,
            string firmname = null,
            string state = null,
            string urbanization = null)
        {
            using var client = new HttpClient();
            using var requestmessage = new HttpRequestMessage();

            requestmessage.RequestUri = GetUrl(userId: String.Empty,
            baseUrl: String.Empty,
            path: String.Empty,
            api: "ZipCodeLookup", "ZipCodeLookupRequest", new Api.Xml.ZipCode
            {
                Address1 = address1,
                Address2 = address2,
                City = city,
                FirmName = firmname,
                Id = 0,
                State = state,
                Urbanization = urbanization,
            });

            var response = await client.SendAsync(requestmessage);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (CheckError(responseString))
                {
                    var message = GetError(responseString);
                    throw new InvalidOperationException(message);
                }
                else
                {
                    return ZipCode.Parse(responseString);
                }
            }
            else
                throw new InvalidOperationException(responseString);
        }
    }
}
