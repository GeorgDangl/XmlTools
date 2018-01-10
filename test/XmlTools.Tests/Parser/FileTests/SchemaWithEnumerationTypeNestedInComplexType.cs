using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser.FileTests
{
    public class SchemaWithEnumerationTypeNestedInComplexType : TestFileBase
    {
        public SchemaWithEnumerationTypeNestedInComplexType() : base(ParserTestFile.SchemaWithEnumerationTypeNestedInComplexType) { }

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
            var expectedCountOfTypes = 3;
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
            var expectedTypeNameStart = "WeatherReport";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.StartsWith(expectedTypeNameStart, rootElement.Type.Name);
        }

        [Fact]
        public void RootElementTypeType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.IsType<XmlComplexType>(rootElementType);
        }

        [Fact]
        public void RootElementTypeChildCount()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            Assert.Equal(2, rootElementType.PossibleChildElements.Count);
        }

        [Fact]
        public void NestedTypeTemperatureName()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            Assert.Equal("Temperature", rootElementType.PossibleChildElements[0].Name);
        }

        [Fact]
        public void NestedTypeTemperatureTypeName()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            Assert.Equal("xs:integer", rootElementType.PossibleChildElements[0].Type.Name);
        }

        [Fact]
        public void NestedTypeTemperatureType()
        {
            var nestedType = (ParsedSchema.RootElements.First().Type as XmlComplexType).PossibleChildElements[0].Type;
            Assert.IsType<XmlUnknownType>(nestedType);
        }

        [Fact]
        public void NestedTypeWeatherForecastName()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            Assert.Equal("Forecast", rootElementType.PossibleChildElements[1].Name);
        }

        [Fact]
        public void NestedTypeWeatherForecastTypeName()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            Assert.Equal("WeatherPrediction", rootElementType.PossibleChildElements[1].Type.Name);
        }

        [Fact]
        public void NestedTypeWeatherForecastIsEnumerationType()
        {
            var nestedType = (ParsedSchema.RootElements.First().Type as XmlComplexType).PossibleChildElements[1].Type;
            Assert.IsType<XmlEnumerationType>(nestedType);
        }

        [Fact]
        public void NestedTypeWeatherForecastEnumerationValues()
        {
            var expectedValues = new[] { "Rainy", "Cloudy", "Sunny", "Misty", "Probability of raining meatballs" };
            var nestedType = (ParsedSchema.RootElements.First().Type as XmlComplexType).PossibleChildElements[1].Type as XmlEnumerationType;
            Assert.Equal(expectedValues.Length, nestedType.EnumerationValues.Count);
            var allElementsPresent = expectedValues.All(v => nestedType.EnumerationValues.Contains(v));
            Assert.True(allElementsPresent);
        }

    }
}