using System;
using System.Text;

namespace MeyerCorp.Usps.Core.Extensions
{
	public static partial class Methods
	{
		public static StringBuilder AppendXml(this StringBuilder builder, string tag, string value, params string[] attributeValuePairs)
		{
			if (string.IsNullOrWhiteSpace(tag))
				throw new ArgumentException();
			else if (attributeValuePairs.Length == 0)
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
