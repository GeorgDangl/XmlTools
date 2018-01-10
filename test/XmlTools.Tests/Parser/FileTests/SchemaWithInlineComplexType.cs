using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser.FileTests
{
    public class SchemaWithInlineComplexType : TestFileBase
    {
        public SchemaWithInlineComplexType() : base(ParserTestFile.SchemaWithInlineComplexType) { }

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
            var expectedElementName = "WeatherForecast";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.Equal(expectedElementName, rootElement.Name);
        }

        [Fact]
        public void RootElementTypeName()
        {
            var expectedTypeNameStart = "InlineComplexType_";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.StartsWith(expectedTypeNameStart, rootElement.Type.Name);
        }

        [Fact]
        public void NoPropertiesOnRootElementType()
        {
            var rootElement = ParsedSchema.RootElements.First();
            Assert.False((rootElement.Type as XmlComplexType).PossibleChildElements.Any());
        }
    }
}