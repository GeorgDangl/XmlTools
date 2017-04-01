using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser
{
    public class SchemaWithTwoPossibleRootElements : TestFileBase
    {
        public SchemaWithTwoPossibleRootElements() : base(TestFile.SchemaWithTwoPossibleRootElements) { }

        [Fact]
        public void HasTwoRootElements()
        {
            Assert.Equal(2, ParsedSchema.RootElements.Count);
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
            var expectedCountOfTypes = 2;
            var types = ParsedSchema.GetAllDeclaredTypes().ToList();
            Assert.Equal(expectedCountOfTypes, types.Count);
        }

        [Fact]
        public void RootElementName1()
        {
            var expectedElementName = "WeatherForecast";
            var actualName = ParsedSchema.RootElements[0].Name;
            Assert.Equal(expectedElementName, actualName);
        }

        [Fact]
        public void RootElementName2()
        {
            var expectedElementName = "Order";
            var actualName = ParsedSchema.RootElements[1].Name;
            Assert.Equal(expectedElementName, actualName);
        }

        [Fact]
        public void RootElementTypeName1()
        {
            var expectedTypeName = "WeatherPrediction";
            var actualName = ParsedSchema.RootElements[0].Type.Name;
            Assert.Equal(expectedTypeName, actualName);
        }

        [Fact]
        public void RootElementTypeName2()
        {
            var expectedTypeName = "FoodOrder";
            var actualName = ParsedSchema.RootElements[1].Type.Name;
            Assert.Equal(expectedTypeName, actualName);
        }

        [Fact]
        public void RootElementTypeIsEnumerationType1()
        {
            var rootElementType = ParsedSchema.RootElements[0].Type;
            Assert.IsType(typeof(XmlEnumerationType), rootElementType);
        }

        [Fact]
        public void RootElementTypeEnumerationTypeHasCorrectRestrictions1()
        {
            var expectedValues = new[] { "Rainy", "Cloudy", "Sunny", "Misty", "Probability of raining meatballs" };
            var rootElementType = ParsedSchema.RootElements[0].Type as XmlEnumerationType;
            Assert.Equal(expectedValues.Length, rootElementType.EnumerationValues.Count);
            var allElementsPresent = expectedValues.All(v => rootElementType.EnumerationValues.Contains(v));
            Assert.True(allElementsPresent);
        }

        [Fact]
        public void NoPropertiesOnRootElementType2()
        {
            var secondRootElementType = ParsedSchema.RootElements[1].Type;
            Assert.False((secondRootElementType as XmlComplexType).PossibleChildElements.Any());
        }

        [Fact]
        public void RootElementTypeType2()
        {
            var secondRootElementType = ParsedSchema.RootElements[1].Type;
            Assert.IsType(typeof(XmlComplexType), secondRootElementType);
        }
    }
}