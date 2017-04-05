using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser.FileTests
{
    public class SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute : TestFileBase
    {
        public SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute(): base(ParserTestFile.SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute) { }

        private XmlElement RootElementChild => (ParsedSchema.RootElements.First().Type as XmlComplexType).PossibleChildElements.First();
        private XmlSimpleContentEnumerationComplexType RootElementChildType => RootElementChild.Type as XmlSimpleContentEnumerationComplexType;

        [Fact]
        public void HasOnlySingleRootElement()
        {
            Assert.Equal(1, ParsedSchema.RootElements.Count);
        }

        [Fact]
        public void CountOfAttributeTypes()
        {
            var expectedCountOfAttributeTypes = 1;
            var attributeTypes = ParsedSchema.GetAllDeclaredAttributeTypes().ToList();
            Assert.Equal(expectedCountOfAttributeTypes, attributeTypes.Count);
        }

        [Fact]
        public void CountOfTypes()
        {
            var expectedCountOfTypes = 2;
            var types = ParsedSchema.GetAllDeclaredElementTypes().ToList();
            Assert.Equal(expectedCountOfTypes, types.Count);
        }

        [Fact]
        public void RootElementName()
        {
            var expectedElementName = "Monsters";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.Equal(expectedElementName, rootElement.Name);
        }

        [Fact]
        public void RootElementTypeName()
        {
            var expectedTypeNameStart = "InlineComplexType_";
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.StartsWith(expectedTypeNameStart, rootElementType.Name);
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
            Assert.Equal(0, rootElementType.Attributes.Count);
        }

        [Fact]
        public void RootElementChildElementsCount()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            Assert.Equal(1, rootElementType.PossibleChildElements.Count);
        }

        [Fact]
        public void RootElementChildElementName()
        {
            var expectedName = "Monster";
            var actualName = RootElementChild.Name;
            Assert.Equal(expectedName, actualName);
        }

        [Fact]
        public void RootElementChildElementTypeName()
        {
            var expectedName = "MonsterType";
            var rootElementChildType = RootElementChild.Type;
            Assert.Equal(expectedName, rootElementChildType.Name);
        }

        [Fact]
        public void RootElementChildElementTypeType()
        {
            var rootElementChildType = RootElementChild.Type;
            Assert.IsType(typeof(XmlSimpleContentEnumerationComplexType), rootElementChildType);
        }

        [Fact]
        public void RootElementChildElementTypeEnumerationValues()
        {
            var actualValues = RootElementChildType.EnumerationValues;
            var expectedValues = new[] { "Dragon", "Orc", "Ogre", "Lich" };
            Assert.Equal(expectedValues.Length, actualValues.Count);
            var allExpectedValuesPresent = expectedValues.All(v => actualValues.Any(e => e == v));
            Assert.True(allExpectedValuesPresent);
        }

        [Fact]
        public void RootElementChildElementAttributesCount()
        {
            Assert.Equal(1, RootElementChildType.Attributes.Count);
        }

        [Fact]
        public void RootElementChildElementAttributeName()
        {
            var attribute = RootElementChildType.Attributes.First();
            var expectedName = "Resistance";
            Assert.Equal(expectedName, attribute.Name);
        }

        [Fact]
        public void RootElementChildElementAttributeTypeName()
        {
            var attributeType = RootElementChildType.Attributes.First().Type;
            var expectedName = "DamageType";
            Assert.Equal(expectedName, attributeType.Name);
        }

        [Fact]
        public void RootElementChildElementAttributeTypeType()
        {
            var attributeType = RootElementChildType.Attributes.First().Type;
            Assert.IsType(typeof(XmlEnumerationType), attributeType);
        }

        [Fact]
        public void RootElementChildElementAttributeTypeEnumerationValues()
        {
            var attributeType = RootElementChildType.Attributes.First().Type as XmlEnumerationType;
            var actualValues = attributeType.EnumerationValues;
            var expectedValues = new[] { "Fire", "Ice", "Poison", "Energy" };
            Assert.Equal(expectedValues.Length, actualValues.Count);
            var allExpectedValuesPresent = expectedValues.All(v => actualValues.Any(e => e == v));
            Assert.True(allExpectedValuesPresent);
        }

        [Fact]
        public void ImplementMe()
        {
            // TODO ADD TESTS FOR CODEGENERATOR FOR THIS
            throw new System.NotImplementedException();
        }
    }
}