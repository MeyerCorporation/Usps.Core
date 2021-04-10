using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MeyerCorp.Usps.Core.Extensions;
using Microsoft.Extensions.Options;

namespace MeyerCorp.Usps.Core
{
    public class TrackAndConfirm : Api, ITrackAndConfirm
    {
        public TrackAndConfirm(IOptions<ApiOptions> options) : base(options) { }

        /// <summary>
        /// Four service APIs are offered in conjunction with �Revision=1� of the Package Tracking �Fields� API: Track and Confirm by Email, Proof of Delivery, Tracking Proof of Delivery, and Return Receipt Electronic. The response data from Track/Confirm Fields request determines which services are available for a tracking ID. Each request input to the Web Tools server for the tracking service APIs is limited to one tracking ID. These APIs require additional permissions from the WebTools Program Office in order to gain access. When you request access for these APIs, please identify your anticipated API volume, mailer ID, and how you will be utilizing this API. A mailer identification number (MID) is a 6 or 9-digit number assigned to a customer through the USPS Business Customer Gateway (BCG). Please refer to the following links for help:
        /// <seealso cref="https://gateway.usps.com/eAdmin/view/knowledge?securityId=MID"/>
        /// <seealso cref="https://postalpro.usps.com/mailing/mailer-id"/>
        /// </summary>
        /// <returns></returns>
        public async Task<object> TrackAsync(params Xml.TrackID[] trackingIds)
        {
            var xmlrequest = new StringBuilder();

            var request = String.Join(String.Empty, trackingIds.Select(ti=>ti.ToString()));

            Request.RequestUri = GetUrl(apiName: "TrackV2", type: "TrackRequest", request);

            var response = await GetResponseStringAsync();

            var document = XDocument.Parse(response);

            return document
                .Root
                .Elements("TrackInfo")
                .Select(e => Models.TrackingInformation.Parse(e));
        }

        /// <summary>
        /// The Package Tracking �Fields� API is similar to the Package Track API except for the request fields, API name, and the return information. Data returned still contains the detail and summary information, but this information is broken down into fields instead of having only one line of text. Up to 10 tracking IDs may be contained in each API request to the Web Tools server.
        /// <seealso cref="https://gateway.usps.com/eAdmin/view/knowledge?securityId=MID"/>
        /// <seealso cref="https://postalpro.usps.com/mailing/mailer-id"/>
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public object Track(object fields) { throw new NotImplementedException(); }

        /// <summary>
        /// Track Proof of Delivery is a letter that includes the recipient's name and a copy of their signature. The Track Proof of Delivery API allows the customer to request proof of delivery notification via email. When you request access for this API, please identify your anticipated API volume, mailer ID and how you will be utilizing this API. A mailer identification number (MID) is a 6 or 9-digit number assigned to a customer through the USPS Business Customer Gateway (BCG). Please refer to the following links for help:
        /// <seealso cref="https://gateway.usps.com/eAdmin/view/knowledge?securityId=MID"/>
        /// <seealso cref="https://postalpro.usps.com/mailing/mailer-id"/>
        /// </summary>
        /// <returns></returns>
        public object TrackByEmail() { throw new NotImplementedException(); }

        /// <summary>
        /// The Track and Confirm by Email API allows the customer to submit their email address to be notified of current or future tracking activity. When you request access for this API, please identify your anticipated API volume, mailer ID and how you will be utilizing this API. A mailer identification number (MID) is a 6 or 9-digit number assigned to a customer through the USPS Business Customer Gateway (BCG). Please refer to the following links for help:
        /// <seealso cref="https://gateway.usps.com/eAdmin/view/knowledge?securityId=MID"/>
        /// <seealso cref="https://postalpro.usps.com/mailing/mailer-id"/>
        /// </summary>
        /// <returns></returns>
        public object ProveDelivery() { throw new NotImplementedException(); }

        /// <summary>
        /// The Return Receipt Electronic API allows the customer to request a copy of the proof of delivery record via email. When you request access for this API, please identify your anticipated API volume, mailer ID and how you will be utilizing this API. A mailer identification number (MID) is a 6 or 9-digit number assigned to a customer through the USPS Business Customer Gateway (BCG). Please refer to the following links for help:
        /// <seealso cref="https://gateway.usps.com/eAdmin/view/knowledge?securityId=MID"/>
        /// <seealso cref="https://postalpro.usps.com/mailing/mailer-id"/>
        /// </summary>
        /// <returns></returns>
        public object ReturnElectronicReceipt() { throw new NotImplementedException(); }

        /// <summary>
        /// Track Proof of Delivery is a letter that includes the recipient's name and a copy of their signature. The Track Proof of Delivery API allows the customer to request proof of delivery notification via email. When you request access for this API, please identify your anticipated API volume, mailer ID and how you will be utilizing this API. A mailer identification number (MID) is a 6 or 9-digit number assigned to a customer through the USPS Business Customer Gateway (BCG). Please refer to the following links for help:
        /// <seealso cref="https://gateway.usps.com/eAdmin/view/knowledge?securityId=MID"/>
        /// <seealso cref="https://postalpro.usps.com/mailing/mailer-id"/>
        /// </summary>
        /// <returns></returns>
        public object TrackProofOfDelivery() { throw new NotImplementedException(); }
    }
}