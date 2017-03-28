using System.IO;
using XmlTools.Parser;
using Xunit;

namespace XmlTools.Tests.Parser
{
    public class SchemaWithoutRootElement
    {
        [Fact]
        public void InvalidDataExceptionWhenNoRootElementDefinedInSchema()
        {
            using (var stream = TestFilesFactory.GetStreamForTestFile(TestFile.SchemaWithoutRootElement))
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