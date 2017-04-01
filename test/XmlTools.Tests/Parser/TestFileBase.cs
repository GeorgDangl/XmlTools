using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XmlTools.Parser;
using Xunit;

namespace XmlTools.Tests.Parser
{
    public abstract class TestFileBase
    {
        protected readonly TestFile _testFile;
        private XmlSchema _parsedSchema;

        private static ConcurrentDictionary<TestFile, XmlSchema> _knownSchemas = new ConcurrentDictionary<TestFile, XmlSchema>();

        protected XmlSchema ParsedSchema
        {
            get
            {
                if (_knownSchemas.ContainsKey(_testFile))
                {
                    return _knownSchemas[_testFile];
                }
                var parsedSchema = ParseSchema();
                _knownSchemas.TryAdd(_testFile, parsedSchema);
                return parsedSchema;
            }
        }

        public TestFileBase(TestFile testFile)
        {
            _testFile = testFile;
        }

        private XmlSchema ParseSchema()
        {
            using (var xsdStream = TestFilesFactory.GetStreamForTestFile(_testFile))
            {
                var schemaParser = new XmlSchemaParser(xsdStream);
                var parsedFile = schemaParser.GetSchema();
                return parsedFile;
            }
        }

        [Fact]
        public void CanParseFile()
        {
            using (var xsdStream = TestFilesFactory.GetStreamForTestFile(_testFile))
            {
                var schemaParser = new XmlSchemaParser(xsdStream);
                var parsedFile = schemaParser.GetSchema();
                Assert.NotNull(parsedFile);
            }
        }

        [Fact]
        public void AllUsedTypesHaveUniqueName()
        {
            var attributeTypes = ParsedSchema.GetAllDeclaredAttributeTypes();
            var elementTypes = ParsedSchema.GetAllDeclaredElementTypes();
            var usedTypes = attributeTypes.Concat(elementTypes).Distinct().ToList();
            foreach (var usedType in usedTypes)
            {
                var typesWithThisName = usedTypes.Where(t => t.Name == usedType.Name).ToList();
                Assert.Equal(1, typesWithThisName.Count);
            }
        }

        [Fact]
        public void AttributeTypesHaveDistinctNames()
        {
            var attributeTypes = ParsedSchema.GetAllDeclaredAttributeTypes().ToList();
            foreach (var attributeType in attributeTypes)
            {
                var occurencesWithSameName = attributeTypes.Count(a => a.Name == attributeType.Name);
                Assert.Equal(1, occurencesWithSameName);
            }
        }

        [Fact]
        public void ElementTypesHaveDistinctNames()
        {
            var elementTypes = ParsedSchema.GetAllDeclaredElementTypes().ToList();
            foreach (var elementType in elementTypes)
            {
                var occurencesWithSameName = elementTypes.Count(e => e.Name == elementType.Name);
                Assert.Equal(1, occurencesWithSameName);
            }
        }

        protected List<XmlType> GetAllElementTypesUsedInSchema()
        {
            return ParsedSchema.GetAllDeclaredElementTypes().ToList();
        }
    }
}