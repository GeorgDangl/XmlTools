using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser.FileTests
{
    public class SchemaWithExtendedEnumerationTypeWithDuplicatesAndRedefinition : TestFileBase
    {
        public SchemaWithExtendedEnumerationTypeWithDuplicatesAndRedefinition() : base(ParserTestFile.SchemaWithExtendedEnumerationTypeWithDuplicatesAndRedefinition) { }

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
        public void HasOnlySingleType()
        {
            // There are two types in the schema, but one only extends the other so it should
            // only recognize the actually used type
            var countOfUsedTypes = GetAllElementTypesUsedInSchema().Count;
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
            Assert.IsType<XmlEnumerationType>(rootElementType);
        }

        [Fact]
        public void RootElementTypeEnumerationTypeHasCorrectRestrictions()
        {
            // There should only be the enumeration values from the actual type definition
            var expectedValues = new[] { "Sunny", "Probability of raining meatballs" };
            var rootElement = ParsedSchema.RootElements.First().Type as XmlEnumerationType;
            Assert.Equal(expectedValues.Length, rootElement.EnumerationValues.Count);
            var allElementsPresent = expectedValues.All(v => rootElement.EnumerationValues.Contains(v));
            Assert.True(allElementsPresent);
        }
    }
}