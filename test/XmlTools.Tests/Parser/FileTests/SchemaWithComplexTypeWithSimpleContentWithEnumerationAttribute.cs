using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser.FileTests
{
    public class SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute : TestFileBase
    {
        public SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute() : base(ParserTestFile.SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute)
        {
        }

        [Fact]
        public void HasOnlySingleRootElement()
        {
            Assert.Equal(1, ParsedSchema.RootElements.Count);
        }

        [Fact]
        public void CountOfAttributeTypes()
        {
            var expectedCountOfAttributeTypes = 2;
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
        public void RootElementName()
        {
            var expectedElementName = "Commit";
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
            Assert.IsType(typeof(XmlSimpleContentComplexType), rootElementType);
        }

        [Fact]
        public void RootElementTypeAttributesCount()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            Assert.Equal(2, rootElementType.Attributes.Count);
        }

        [Fact]
        public void RootElementTypeAttributeName1()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            var attribute = rootElementType.Attributes[0];
            Assert.Equal("AuthorEmail", attribute.Name);
        }

        [Fact]
        public void RootElementTypeAttributeName2()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            var attribute = rootElementType.Attributes[1];
            Assert.Equal("Algorithm", attribute.Name);
        }

        [Fact]
        public void RootElementTypeAttributeTypeName1()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            var attributeType = rootElementType.Attributes[0].Type;
            Assert.StartsWith("xs:string", attributeType.Name);
        }

        [Fact]
        public void RootElementTypeAttributeTypeName2()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            var attributeType = rootElementType.Attributes[1].Type;
            Assert.StartsWith("InlineSimpleType_", attributeType.Name);
        }

        [Fact]
        public void RootElementTypeAttributeTypeType1()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            var attributeType = rootElementType.Attributes[0].Type;
            Assert.IsType(typeof(XmlUnknownType), attributeType);
        }

        [Fact]
        public void RootElementTypeAttributeTypeType2()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            var attributeType = rootElementType.Attributes[1].Type;
            Assert.IsType(typeof(XmlEnumerationType), attributeType);
        }

        [Fact]
        public void RootElementTypeAttributeTypeEnumerationValues()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            var attributeType = rootElementType.Attributes[1].Type as XmlEnumerationType;
            var expectedValues = new[] { "MD5", "SHA1", "SHA256" };
            Assert.Equal(expectedValues.Length, attributeType.EnumerationValues.Count);
            var allExpectedValuesPresent = expectedValues.All(v => attributeType.EnumerationValues.Any(e => e == v));
            Assert.True(allExpectedValuesPresent);
        }
    }
}