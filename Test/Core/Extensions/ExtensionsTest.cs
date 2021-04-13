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
        [Fact(DisplayName = "AppendXml null string builder")]
        public void Test1()
        {
            var stringbuilder = default(StringBuilder);

            var result = Assert.Throws<ArgumentNullException>(() =>
            {
                stringbuilder.AppendXml("tag", "value");
            });

            Assert.Equal("Value cannot be null. (Parameter 'builder')", result.Message);
        }


        [Fact(DisplayName = "AppendXml null tag")]
        public void Test2()
        {
            var stringbuilder = new StringBuilder();

            var result = Assert.Throws<ArgumentException>(() =>
            {
                stringbuilder.AppendXml(null, "value");
            });

            Assert.Equal("The argument cannot be null, empty or contain only whitespace. (Parameter 'tag')"
, result.Message);
        }


        [Fact(DisplayName = "AppendXml empty tag")]
        public void Test3()
        {
            var stringbuilder = new StringBuilder();

            var result = Assert.Throws<ArgumentException>(() =>
            {
                stringbuilder.AppendXml(String.Empty, "value");
            });

            Assert.Equal("The argument cannot be null, empty or contain only whitespace. (Parameter 'tag')"
, result.Message);
        }


        [Fact(DisplayName = "AppendXml whitespace tag")]
        public void Test4()
        {
            var stringbuilder = new StringBuilder();

            var result = Assert.Throws<ArgumentException>(() =>
            {
                stringbuilder.AppendXml(" " + Environment.NewLine, "value");
            });

            Assert.Equal("The argument cannot be null, empty or contain only whitespace. (Parameter 'tag')"
, result.Message);
        }

        [Fact(DisplayName = "AppendXml tag and value")]
        public void Test5()
        {
            var stringbuilder = new StringBuilder();

            var result = stringbuilder.AppendXml("tag", "value");

            Assert.Equal("<tag>value</tag>", result.ToString());
        }

        [Fact(DisplayName = "AppendXml tag and value and single attribute")]
        public void Test6()
        {
            var stringbuilder = new StringBuilder();

            var result = stringbuilder.AppendXml("tag", "value", "attribute", "attributevalue");

            Assert.Equal("<tag attribute=\"attributevalue\">value</tag>", result.ToString());
        }

        [Fact(DisplayName = "AppendXml tag and value and double attribute")]
        public void Test7()
        {
            var stringbuilder = new StringBuilder();

            var result = stringbuilder.AppendXml("tag", "value", "attribute", "attributevalue", "attribute1", "attributevalue1");

            Assert.Equal("<tag attribute=\"attributevalue\" attribute1=\"attributevalue1\">value</tag>", result.ToString());
        }

        [Fact(DisplayName = "AppendXml tag and value and uneven attribute/value pair arguments")]
        public void Test8()
        {
            var stringbuilder = new StringBuilder();

            var result = Assert.Throws<ArgumentException>(() =>
            {
                var result = stringbuilder.AppendXml("tag", "value", "attribute", "attributevalue", "attribute1");
            });

            Assert.Equal("There must be an even number of non-null, non-empty and non-whitespace attribute-value pairs as each pair represents an attribute and its value. (Parameter 'attributeValuePairs')",
                result.Message);
        }

        [Fact(DisplayName = "AppendXml tag and value and null attribute/value pair arguments")]
        public void Test9()
        {
            var stringbuilder = new StringBuilder();

            var result = Assert.Throws<ArgumentException>(() =>
            {
                var result = stringbuilder.AppendXml("tag", "value", "attribute", null, "attribute1", "value1");
            });

            Assert.Equal("There must be an even number of non-null, non-empty and non-whitespace attribute-value pairs as each pair represents an attribute and its value. (Parameter 'attributeValuePairs')",
                result.Message);
        }
    }
}