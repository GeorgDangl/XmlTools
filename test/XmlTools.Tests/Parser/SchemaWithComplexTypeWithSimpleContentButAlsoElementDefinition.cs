using System.IO;
using XmlTools.Parser;
using Xunit;

namespace XmlTools.Tests.Parser
{
    public class SchemaWithComplexTypeWithSimpleContentButAlsoElementDefinition
    {
        [Fact]
        public void ThrowsExceptionDueToInvalidSchema()
        {
            // A simpleContent element may not have elements defined within itself
            var xsdStream = TestFilesFactory.GetStreamForTestFile(TestFile.SchemaWithComplexTypeWithSimpleContentButAlsoElementDefinition);
            var schemaParser = new XmlSchemaParser(xsdStream);
            Assert.Throws(typeof(InvalidDataException), () =>
            {
                var parsedFile = schemaParser.GetSchema();
            });
        }
    }
}