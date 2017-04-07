using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using XmlTools.Tests.CodeGenerator.FileTests;
using Xunit;

namespace XmlTools.Tests.CodeGenerator
{
    public class XmlSchemaCorrectorGeneratorTests
    {
        [Fact(Skip = "Invoke manually")]
        public void WriteCodeGenToDisk()
        {
            const string outputFilePath = @"C:\Users\Georg\Downloads\CodeGenOutput\Generated.cs";
            {
                var generatedCode = SchemaCorrectorHelper.GetSchemaCorrectorCode(ParserTestFile.GAEB_XML_3_1_Schema);
                using (var fs = File.CreateText(outputFilePath))
                {
                    fs.Write(generatedCode);
                }
            }
        }

        public static IEnumerable<object[]> AllValidParserEnums => (Enum.GetValues(typeof(ParserTestFile))).Cast<ParserTestFile>().Select(e => new object[] { e });

        [Theory]
        [MemberData(nameof(AllValidParserEnums))]
        public void CanParseSchemaAndGenerateCode(ParserTestFile xmlSchemaTestFile)
        {
            var generatedCode = SchemaCorrectorHelper.GetSchemaCorrectorCode(xmlSchemaTestFile);
            var didGenerateCode = !string.IsNullOrWhiteSpace(generatedCode);
            Assert.True(didGenerateCode);
        }

        [Theory]
        [MemberData(nameof(AllValidParserEnums))]
        public void CanCallCorrectCodeOnXml(ParserTestFile xmlSchemaTestFile)
        {
            var sourceDoc = GetExampleDocument();
            var actualDoc = SchemaCorrectorHelper.CorrectXmlInstanceForSchema(xmlSchemaTestFile, sourceDoc);
            var expectedDoc = GetExampleDocument();
            var xDocComparator = new XDocumentComparator(expectedDoc, actualDoc);
            xDocComparator.AssertXDocumentsAreEqual();
        }

        private XDocument GetExampleDocument()
        {
            var xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<XmlInstance>
  <DataElement>SomeData</DataElement>
  <AttributeElement type=""attribute"">SomeData</AttributeElement>
  <ComplexElement type=""anotherAttribute"">
    <Data>Red</Data>
    <Data>Blue</Data>
    <Data>Green</Data>
  </ComplexElement>
</XmlInstance>";
            return XDocument.Parse(xml);
        }
    }
}
