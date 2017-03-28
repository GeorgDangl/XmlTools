using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XmlTools.Parser;
using Xunit;

namespace XmlTools.Tests.Parser
{
    public abstract class TestFileBase : IDisposable
    {
        protected readonly Stream _xsdStream;
        private XmlSchema _parsedSchema;

        protected XmlSchema ParsedSchema
        {
            get
            {
                return _parsedSchema ?? (_parsedSchema = ParseSchema());
            }
        }

        public TestFileBase(Stream xsdStream)
        {
            _xsdStream = xsdStream;
        }

        public void Dispose()
        {
            _xsdStream.Dispose();
        }

        private XmlSchema ParseSchema()
        {
            var schemaParser = new XmlSchemaParser(_xsdStream);
            var parsedFile = schemaParser.GetSchema();
            return parsedFile;
        }

        [Fact]
        public void CanParseFile()
        {
            var schemaParser = new XmlSchemaParser(_xsdStream);
            var parsedFile = schemaParser.GetSchema();
            Assert.NotNull(parsedFile);
        }

        [Fact]
        public void AllUsedTypesHaveUniqueName()
        {
            var allUsedTypes = GetAllTypesUsedInSchema();
            foreach (var usedType in allUsedTypes)
            {
                var typesWithThisName = allUsedTypes.Count(t => t.Name == usedType.Name);
                Assert.Equal(1, typesWithThisName);
            }
        }

        protected List<XmlType> GetAllTypesUsedInSchema()
        {
            return ParsedSchema.GetAllDeclaredTypes().ToList();
        }
    }
}