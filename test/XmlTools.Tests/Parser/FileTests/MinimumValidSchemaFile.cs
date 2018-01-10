using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser.FileTests
{
    public class MinimumValidSchemaFile : TestFileBase
    {
        public MinimumValidSchemaFile() : base(ParserTestFile.MinimumValidSchemaFile) { }

        [Fact]
        public void HasOnlySingleRootElement()
        {
            Assert.Single(ParsedSchema.RootElements);
        }

        [Fact]
        public void HasNoAttributeTypes()
        {
            var attributeTypes = ParsedSchema.GetAllDeclaredAttributeTypes().ToList();
            Assert.Empty(attributeTypes);
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
            var expectedElementName = "Order";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.Equal(expectedElementName, rootElement.Name);
        }

        [Fact]
        public void RootElementTypeName()
        {
            var expectedTypeName = "FoodOrder";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.Equal(expectedTypeName, rootElement.Type.Name);
        }

        [Fact]
        public void RootElementTypeType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.IsType<XmlComplexType>(rootElementType);
        }

        [Fact]
        public void NoPropertiesOnRootElementType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            Assert.False(rootElementType.PossibleChildElements.Any());
        }

        [Fact]
        public void NoAttributesOnRootElementType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            Assert.False(rootElementType.Attributes.Any());
        }
    }
}