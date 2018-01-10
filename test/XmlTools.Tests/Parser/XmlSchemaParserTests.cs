using System;
using XmlTools.Parser;
using Xunit;

namespace XmlTools.Tests.Parser
{
    public class XmlSchemaParserTests
    {
        [Fact]
        public void ArgumentNullExceptionOnNullInput()
        {
            Assert.Throws<ArgumentNullException>(() => new XmlSchemaParser(null));
        }
    }
}