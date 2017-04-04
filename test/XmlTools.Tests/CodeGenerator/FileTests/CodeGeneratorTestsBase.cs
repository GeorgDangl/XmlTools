using System.Xml.Linq;
using Xunit;

namespace XmlTools.Tests.CodeGenerator.FileTests
{
    public abstract class CodeGeneratorTestsBase
    {
        protected CodeGeneratorTestsBase(ParserTestFile schemaFile, SchemaCorrectorTestFile invalidTestFile, SchemaCorrectorTestFile validTestFile)
        {
            _schemaFile = schemaFile;
            _invalidTestFile = invalidTestFile;
            _validTestFile = validTestFile;
        }

        private readonly ParserTestFile _schemaFile;
        private readonly SchemaCorrectorTestFile _invalidTestFile;
        private readonly SchemaCorrectorTestFile _validTestFile;

        [Fact]
        public void CanLoadValidFileAsXDocument()
        {
            var validXDoc = LoadValidTestFile();
            Assert.NotNull(validXDoc);
        }

        [Fact]
        public void CanLoadInvalidFileAsXDocument()
        {
            var invalidXDoc = LoadInvalidTestFile();
            Assert.NotNull(invalidXDoc);
        }

        [Fact]
        public void CanCorrectFile()
        {
            var invalidXDoc = LoadInvalidTestFile();
            var correctedXDoc = SchemaCorrectorHelper.CorrectXmlInstanceForSchema(_schemaFile, invalidXDoc);
            Assert.NotNull(correctedXDoc);
        }

        [Fact]
        public void CorrectedFileIsAsExpected()
        {
            var invalidXDoc = LoadInvalidTestFile();
            var correctedXDoc = SchemaCorrectorHelper.CorrectXmlInstanceForSchema(_schemaFile, invalidXDoc);
            var expectedXDoc = LoadValidTestFile();
            var xDocComparator = new XDocumentComparator(expectedXDoc, correctedXDoc);
            xDocComparator.AssertXDocumentsAreEqual();
        }

        private XDocument LoadInvalidTestFile()
        {
            return LoadXDocumentForTestfile(_invalidTestFile);
        }

        private XDocument LoadValidTestFile()
        {
            return LoadXDocumentForTestfile(_validTestFile);
        }

        private XDocument LoadXDocumentForTestfile(SchemaCorrectorTestFile testFile)
        {
            using (var fileStream = TestFilesFactory.GetStreamForTestFile(testFile))
            {
                var xDoc = XDocument.Load(fileStream);
                return xDoc;
            }
        }
    }
}