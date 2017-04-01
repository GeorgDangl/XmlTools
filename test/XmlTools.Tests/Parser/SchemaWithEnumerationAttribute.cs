using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser
{
    public class SchemaWithEnumerationAttribute : TestFileBase
    {
        public SchemaWithEnumerationAttribute() : base(TestFile.SchemaWithEnumerationAttribute) { }

        [Fact]
        public void HasOnlySingleRootElement()
        {
            Assert.Equal(1, ParsedSchema.RootElements.Count);
        }

        [Fact]
        public void RootElementName()
        {
            var expectedElementName = "Author";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.Equal(expectedElementName, rootElement.Name);
        }

        [Fact]
        public void RootElementTypeName()
        {
            var expectedTypeName = "Person";
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.Equal(expectedTypeName, rootElementType.Name);
        }

        [Fact]
        public void RootElementTypeType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.IsType(typeof(XmlComplexType), rootElementType);
        }

        [Fact]
        public void RootElementTypeAttributesCount()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            Assert.Equal(1, rootElementType.Attributes.Count);
        }

        [Fact]
        public void RootElementTypeAttributeName()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var attribute = rootElementType.Attributes.First();
            Assert.Equal("Gender", attribute.Name);
        }

        [Fact]
        public void RootElementTypeAttributeTypeName()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var attributeType = rootElementType.Attributes.First().Type;
            Assert.StartsWith("InlineSimpleType_", attributeType.Name);
        }

        [Fact]
        public void RootElementTypeAttributeTypeType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var attributeType = rootElementType.Attributes.First().Type;
            Assert.IsType(typeof(XmlEnumerationType), attributeType);
        }

        [Fact]
        public void RootElementTypeAttributeTypeEnumerationValues()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var attributeType = rootElementType.Attributes.First().Type as XmlEnumerationType;
            var expectedValues = new[] { "Female", "Male" };
            Assert.Equal(expectedValues.Length, attributeType.EnumerationValues.Count);
            var allExpectedValuesPresent = expectedValues.All(v => attributeType.EnumerationValues.Any(e => e == v));
            Assert.True(allExpectedValuesPresent);
        }

        [Fact]
        public void RootElementTypeChildCount()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            Assert.Equal(2, rootElementType.PossibleChildElements.Count);
        }

        [Fact]
        public void RootElementTypeChildNames()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var emailChildElement = rootElementType.PossibleChildElements[0];
            var nameChildElement = rootElementType.PossibleChildElements[1];
            Assert.Equal("Email", emailChildElement.Name);
            Assert.Equal("Name", nameChildElement.Name);
        }

        [Fact]
        public void RootElementTypeChildTypesNames()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var emailChildElementType = rootElementType.PossibleChildElements.First(c => c.Name == "Email").Type;
            var nameChildElementType = rootElementType.PossibleChildElements.First(c => c.Name == "Name").Type;
            Assert.Equal("xs:string", emailChildElementType.Name);
            Assert.Equal("xs:string", nameChildElementType.Name);
        }

        [Fact]
        public void RootElementTypeChildTypesTypes()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var emailChildElementType = rootElementType.PossibleChildElements.First(c => c.Name == "Email").Type;
            var nameChildElementType = rootElementType.PossibleChildElements.First(c => c.Name == "Name").Type;
            Assert.IsType(typeof(XmlUnknownType), emailChildElementType);
            Assert.IsType(typeof(XmlUnknownType), nameChildElementType);
        }
    }
}