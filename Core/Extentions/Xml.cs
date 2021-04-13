using System;
using System.Linq;
using System.Text;

namespace MeyerCorp.Usps.Core.Extensions
{
    public static partial class Methods
    {
        public static StringBuilder AppendXml(this StringBuilder builder, string tag, string value, params string[] attributeValuePairs)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var attributescheck = attributeValuePairs.Where(avp=>!String.IsNullOrWhiteSpace(avp));

            if (attributeValuePairs.Length > 0 && (attributescheck.Count() % 2) != 0)
                throw new ArgumentException("There must be an even number of non-null, non-empty and non-whitespace attribute-value pairs as each pair represents an attribute and its value.",
                 nameof(attributeValuePairs));

            if (string.IsNullOrWhiteSpace(tag))
                throw new ArgumentException("The argument cannot be null, empty or contain only whitespace.", nameof(tag));

            if (attributeValuePairs.Length == 0)
                return builder.AppendFormat("<{0}>{1}</{0}>", tag, value);
            else
            {
                var attributeList = new StringBuilder();

                for (var index = 0; index < attributeValuePairs.Length; index += 2)
                {
                    attributeList.AppendFormat("{0}=\"{1}\" ", attributeValuePairs[index], attributeValuePairs[index + 1]);
                }

                return builder.AppendFormat("<{0} {2}>{1}</{0}>", tag, value, attributeList.ToString().TrimEnd());
            }
        }
    }
}
