using System.IO;
using XmlTools.Parser;
using Xunit;

namespace XmlTools.Tests.Parser.FileTests
{
    public class SchemaWithComplexTypeWithSimpleContentButAlsoElementDefinition
    {
        [Fact]
        public void ThrowsExceptionDueToInvalidSchema()
        {
            // A simpleContent element may not have elements defined within itself
            var xsdStream = TestFilesFactory.GetStreamForTestFile(InvalidParserTestFile.SchemaWithComplexTypeWithSimpleContentButAlsoElementDefinition);
            var schemaParser = new XmlSchemaParser(xsdStream);
            Assert.Throws<InvalidDataException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var parsedFile = schemaParser.GetSchema();
            });
        }
    }
}