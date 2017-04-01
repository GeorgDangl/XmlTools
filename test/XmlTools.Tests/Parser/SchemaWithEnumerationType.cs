using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser
{
    public class SchemaWithEnumerationType : TestFileBase
    {
        public SchemaWithEnumerationType() : base(TestFile.SchemaWithEnumerationType) { }

        [Fact]
        public void HasOnlySingleRootElement()
        {
            Assert.Equal(1, ParsedSchema.RootElements.Count);
        }

        [Fact]
        public void HasNoAttributeTypes()
        {
            var attributeTypes = ParsedSchema.GetAllDeclaredAttributeTypes().ToList();
            Assert.Equal(0, attributeTypes.Count);
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
            var expectedTypeName = "WeatherPrediction";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.Equal(expectedTypeName, rootElement.Type.Name);
        }

        [Fact]
        public void RootElementTypeType()
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