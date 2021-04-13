using System;
using System.Linq;
using System.Text;

namespace MeyerCorp.Usps.Core.Extensions
{
    ///<summary>
    ///Extension methods for Xml classes in the project.
    ///</summary>
    public static partial class Methods
    {
        ///<summary>
        ///Appends a string containing an XML element with optional simple content and any number of attributes.
        ///</summary>
        ///<param cref="builder"></param>
        ///<param cref="tag"></param>
        ///<param cref="value"></param>
        ///<param cref="attributeValuePairs"></param>
        ///<exception cref="ArgumentNullException">The string builder object which this method is applied to is null.</exception>
        ///<exception cref="ArgumentException">The tag parameter is null, empty or whitespace.</exception>
        ///<exception cref="ArgumentException">After filtering out any attribute tags and values in the attributeValuePairs which 
        //are null, emtpy or whitespace, the number of remaining parameter values are counted and determined to be an odd number.</exception>
        ///</exception>
        public static StringBuilder AppendXml(this StringBuilder builder, string tag, string value, params string[] attributeValuePairs)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var attributescheck = attributeValuePairs.Where(avp => !String.IsNullOrWhiteSpace(avp));

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
