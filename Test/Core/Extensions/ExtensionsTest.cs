using System;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;
using MeyerCorp.Usps.Core.Extensions;
using Xunit;

namespace Meyer.UspsCore.Test.Core
{
    public class ExtensionsTest
    {
        [Fact(DisplayName = "AppendXml")]
        public void Test1()
        {
            var stringbuilder = default(StringBuilder);

            var result = Assert.Throws<ArgumentNullException>(() =>
            {
                stringbuilder.AppendXml("tag", "value");
            });

            Assert.Equal("Value cannot be null. (Parameter 'builder')", result.Message);
        }
    }
}