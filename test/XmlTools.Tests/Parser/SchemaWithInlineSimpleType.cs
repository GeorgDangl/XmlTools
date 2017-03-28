using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser
{
    public class SchemaWithInlineSimpleType : TestFileBase
    {
        public SchemaWithInlineSimpleType() : base(TestFilesFactory.GetStreamForTestFile(TestFile.SchemaWithInlineSimpleType)) { }

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
            var expectedTypeNameStart = "InlineSimpleType_";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.True(rootElement.Type.Name.StartsWith(expectedTypeNameStart));
        }

        [Fact]
        public void RootElementTypeIsEnumerationType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.IsType(typeof(XmlEnumerationType), rootElementType);
        }

        [Fact]
        public void RootElementTypeEnumerationTypeHasCorrectRestrictions()
        {
            var expectedValues = new[] { "Rainy", "Cloudy", "Sunny", "Misty", "Probability of raining meatballs" };
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlEnumerationType;
            Assert.Equal(expectedValues.Length, rootElementType.EnumerationValues.Count);
            var allElementsPresent = expectedValues.All(v => rootElementType.EnumerationValues.Contains(v));
            Assert.True(allElementsPresent);
        }
    }
}