using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser
{
    public class SchemaWithExtendedEnumerationType : TestFileBase
    {
        public SchemaWithExtendedEnumerationType() : base(TestFilesFactory.GetStreamForTestFile(TestFile.SchemaWithExtendedEnumerationType)) { }

        [Fact]
        public void HasOnlySingleRootElement()
        {
            Assert.Equal(1, ParsedSchema.RootElements.Count);
        }

        [Fact]
        public void HasOnlySingleType()
        {
            // There are two types in the schema, but one only extends the other so it should
            // only recognize the actually used type
            var countOfUsedTypes = GetAllTypesUsedInSchema().Count;
            Assert.Equal(1, countOfUsedTypes);
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
            // There should also be the enumeration values that are included in the referenced type
            var expectedValues = new[] { "Rainy", "Cloudy", "Sunny", "Misty", "Probability of raining meatballs", "Raining cats and dogs" };
            var rootElement = ParsedSchema.RootElements.First().Type as XmlEnumerationType;
            Assert.Equal(expectedValues.Length, rootElement.EnumerationValues.Count);
            var allElementsPresent = expectedValues.All(v => rootElement.EnumerationValues.Contains(v));
            Assert.True(allElementsPresent);
        }
    }
}