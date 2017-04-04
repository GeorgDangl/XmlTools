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
            using (var stream = TestFilesFactory.GetStreamForTestFile(ParserTestFile.SchemaWithoutRootElement))
            {
                Assert.Throws(typeof(InvalidDataException), () =>
                {
                    var schemaParser = new XmlSchemaParser(stream);
                    var parsedSchema = schemaParser.GetSchema();
                });
            }
        }
    }
}