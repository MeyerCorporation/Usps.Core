using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MeyerCorp.Usps.Api;

namespace MeyerCorp.Usps
{
    public abstract class Validation
    {
        protected Uri GetUrl(string userId,string baseUrl, string path,string api, string type, params Api.Xml.XmlFormatter[] inputs)
        {
            var input = String.Join(String.Empty, inputs.Where(i => i != null).Select(a => a.ToString()));

            var request = new StringBuilder();

            return new Uri(request
                .Append($"{baseUrl}/{path}?API={api}&XML=")
                .AppendXml(type, input, "USERID", userId)
                .ToString());
        }
 
		protected bool CheckError(string responseString)
		{
			return XElement
                .Parse(responseString)
                .DescendantsAndSelf("Error")
                .Count() > 0;
		}
  
		protected string GetError(string responseString)
		{
			return XElement
                .Parse(responseString)
                .DescendantsAndSelf("Error")
                .First()
                .Element("Description")
                .Value;
		}
 }
}