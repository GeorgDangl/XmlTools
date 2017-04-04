using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser.FileTests
{
    public class SchemaWithExtendedComplexTypeWithSimpleContent : TestFileBase
    {
        public SchemaWithExtendedComplexTypeWithSimpleContent() : base(ParserTestFile.SchemaWithExtendedComplexTypeWithSimpleContent) { }

        [Fact]
        public void HasOnlySingleRootElement()
        {
            Assert.Equal(1, ParsedSchema.RootElements.Count);
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
            var countOfUsedTypes = GetAllElementTypesUsedInSchema().Count;
            Assert.Equal(1, countOfUsedTypes);
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
            var expectedTypeName = "CommitHash";
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.Equal(expectedTypeName, rootElementType.Name);
        }

        [Fact]
        public void RootElementTypeType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.IsType(typeof(XmlSimpleContentComplexType), rootElementType);
        }

        [Fact]
        public void RootElementAttributesCount()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            Assert.Equal(2, rootElementType.Attributes.Count);
        }

        [Fact]
        public void RootElementAttributeName1()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            var attribute = rootElementType.Attributes[1];
            Assert.Equal("Algorithm", attribute.Name);
        }

        [Fact]
        public void RootElementAttributeName2()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            var attribute = rootElementType.Attributes[0];
            Assert.Equal("AuthorEmail", attribute.Name);
        }

        [Fact]
        public void RootElementAttributeTypeName1()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            var attributeType = rootElementType.Attributes[1].Type;
            Assert.Equal("xs:string", attributeType.Name);
        }

        [Fact]
        public void RootElementAttributeTypeName2()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            var attributeType = rootElementType.Attributes[0].Type;
            Assert.Equal("xs:string", attributeType.Name);
        }

        [Fact]
        public void RootElementAttributeTypeType1()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            var attributeType = rootElementType.Attributes[1].Type;
            Assert.IsType(typeof(XmlUnknownType), attributeType);
        }

        [Fact]
        public void RootElementAttributeTypeType2()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
            var attributeType = rootElementType.Attributes[0].Type;
            Assert.IsType(typeof(XmlUnknownType), attributeType);
        }
    }
}