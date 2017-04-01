using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser
{
    public class SchemaWithInlineComplexType : TestFileBase
    {
        public SchemaWithInlineComplexType() : base(TestFile.SchemaWithInlineComplexType) { }

        [Fact]
        public void HasOnlySingleRootElement()
        {
            Assert.Equal(1, ParsedSchema.RootElements.Count);
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
            Assert.True(rootElement.Type.Name.StartsWith(expectedTypeNameStart));
        }

        [Fact]
        public void NoPropertiesOnRootElementType()
        {
            var rootElement = ParsedSchema.RootElements.First();
            Assert.False((rootElement.Type as XmlComplexType).PossibleChildElements.Any());
        }
    }
}