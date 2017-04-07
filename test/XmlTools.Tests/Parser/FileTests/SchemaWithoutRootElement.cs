using System.IO;
using XmlTools.Parser;
using Xunit;

namespace XmlTools.Tests.Parser.FileTests
{
    public class SchemaWithoutRootElement
    {
        [Fact]
        public void InvalidDataExceptionWhenNoRootElementDefinedInSchema()
        {
            using (var stream = TestFilesFactory.GetStreamForTestFile(InvalidParserTestFile.SchemaWithoutRootElement))
            {
                Assert.Throws(typeof(InvalidDataException), () =>
                {
                    var schemaParser = new XmlSchemaParser(stream);
                    // ReSharper disable once UnusedVariable
                    var parsedSchema = schemaParser.GetSchema();
                });
            }
        }
    }
}