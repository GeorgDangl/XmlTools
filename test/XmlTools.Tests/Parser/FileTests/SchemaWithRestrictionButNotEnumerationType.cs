using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser.FileTests
{
    public class SchemaWithRestrictionButNotEnumerationType : TestFileBase
    {
        public SchemaWithRestrictionButNotEnumerationType() : base(ParserTestFile.SchemaWithRestrictionButNotEnumerationType) { }

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
            var expectedElementName = "OperatingTemperature";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.Equal(expectedElementName, rootElement.Name);
        }

        [Fact]
        public void RootElementTypeName()
        {
            var expectedTypeName = "OperatingTemperatureRange";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.Equal(expectedTypeName, rootElement.Type.Name);
        }

        [Fact]
        public void RootElementTypeType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.IsType<XmlSimpleType>(rootElementType);
        }

        [Fact]
        public void RootElementTypeIsNotEnumerationType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.IsNotType<XmlEnumerationType>(rootElementType);
        }
    }
}