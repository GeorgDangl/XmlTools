using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using XmlTools.Parser;
using Xunit;

namespace XmlTools.Tests.Parser.FileTests
{
    public abstract class TestFileBase
    {
        protected readonly ParserTestFile _testFile;
        private static readonly ConcurrentDictionary<ParserTestFile, XmlSchema> _knownSchemas = new ConcurrentDictionary<ParserTestFile, XmlSchema>();

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

        protected TestFileBase(ParserTestFile testFile)
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
                Assert.Single(typesWithThisName);
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

        [Fact]
        public void NoComplexTypeHasDuplicateElementDefinitions()
        {
            var complexTypes = ParsedSchema.GetAllDeclaredElementTypes()
                .OfType<XmlComplexType>()
                .ToList();
            foreach (var complexType in complexTypes)
            {
                AssertComplexTypeHasNoDuplicateChildElements(complexType);
            }
        }

        private void AssertComplexTypeHasNoDuplicateChildElements(XmlComplexType complexType)
        {
            foreach (var childElement in complexType.PossibleChildElements)
            {
                var childrenWithSameName = complexType.PossibleChildElements.Count(c => c.Name == childElement.Name);
                Assert.Equal(1, childrenWithSameName);
            }
        }

        protected List<XmlType> GetAllElementTypesUsedInSchema()
        {
            return ParsedSchema.GetAllDeclaredElementTypes().ToList();
        }
    }
}