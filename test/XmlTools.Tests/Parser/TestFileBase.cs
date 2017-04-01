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