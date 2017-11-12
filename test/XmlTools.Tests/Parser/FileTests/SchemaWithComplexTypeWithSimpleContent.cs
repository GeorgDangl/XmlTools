using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser.FileTests
{
    public class SchemaWithComplexTypeWithSimpleContent : TestFileBase
    {
        public SchemaWithComplexTypeWithSimpleContent() : base(ParserTestFile.SchemaWithComplexTypeWithSimpleContent) { }

        [Fact]
        public void HasOnlySingleRootElement()
        {
            Assert.Single(ParsedSchema.RootElements);
        }

        [Fact]
        public void CountOfAttributeTypes()
        {
            var expectedCountOfAttributeTypes = 1;
            var attributeTypes = ParsedSchema.GetAllDeclaredAttributeTypes().ToList();
            Assert.Equal(expectedCountOfAttributeTypes, attributeTypes.Count);
        }

        [Fact]
        public void CountOfTypes()
        {
            var expectedCountOfTypes = 1;
            var types = ParsedSchema.GetAllDeclaredElementTypes().ToList();
            Assert.Equal(expectedCountOfTypes, types.Count);
        }

        [Fact]
        public void HasOnlySingleType()
        {
            // There are two types in the schema, but one only extends the other so it should
            // only recognize the actually used types
            var countOfUsedTypes = GetAllElementTypesUsedInSchema().Count;
            Assert.Equal(1, countOfUsedTypes);
        }

        [Fact]
        public void RootElementName()
        {
            var expectedElementName = "Temperature";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.Equal(expectedElementName, rootElement.Name);
        }

        [Fact]
        public void RootElementTypeName()
        {
            var expectedTypeNameStart = "InlineSimpleContentComplexType_";
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.StartsWith(expectedTypeNameStart, rootElementType.Name);
        }

        [Fact]
        public void RootElementTypeType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.IsType<XmlSimpleContentComplexType>(rootElementType);
        }

        [Fact]
        public void RootElementTypeAttributesCount()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            Assert.Single(rootElementType.Attributes);
        }

        [Fact]
        public void RootElementTypeAttributeName()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            var attribute = rootElementType.Attributes.First();
            Assert.Equal("IsFahrenheit", attribute.Name);
        }

        [Fact]
        public void RootElementTypeAttributeTypeName()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            var attributeType = rootElementType.Attributes.First().Type;
            Assert.Equal("xs:boolean", attributeType.Name);
        }

        [Fact]
        public void RootElementTypeAttributeTypeType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            var attributeType = rootElementType.Attributes.First().Type;
            Assert.IsType<XmlUnknownType>(attributeType);
        }
    }
}