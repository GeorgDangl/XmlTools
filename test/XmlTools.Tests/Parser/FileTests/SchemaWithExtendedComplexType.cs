using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser.FileTests
{
    public class SchemaWithExtendedComplexType : TestFileBase
    {
        public SchemaWithExtendedComplexType() : base(ParserTestFile.SchemaWithExtendedComplexType) { }

        [Fact]
        public void HasOnlySingleRootElement()
        {
            Assert.Single(ParsedSchema.RootElements);
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
        public void HasOnlySingleType()
        {
            // There are three types in the schema, but one only extends the other so it should
            // only recognize the actually used types
            // Unknown types with the same name should be reference equal wherever used
            var countOfUsedTypes = GetAllElementTypesUsedInSchema().Count;
            Assert.Equal(2, countOfUsedTypes);
        }

        [Fact]
        public void RootElementName()
        {
            var expectedElementName = "Issue";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.Equal(expectedElementName, rootElement.Name);
        }

        [Fact]
        public void RootElementTypeName()
        {
            var expectedTypeName = "BugReport";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.Equal(expectedTypeName, rootElement.Type.Name);
        }

        [Fact]
        public void RootElementTypeIsComplexType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.IsType<XmlComplexType>(rootElementType);
        }

        [Fact]
        public void RootElementTypePropertyCount()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            Assert.Equal(2, rootElementType.PossibleChildElements.Count);
        }

        [Fact]
        public void RootElementTypeAttributesCount()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            Assert.Equal(2, rootElementType.Attributes.Count);
        }

        [Fact]
        public void RootElementTypeAttributeName1()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var expectedName = "IsResolved";
            Assert.Equal(expectedName, rootElementType.Attributes[1].Name);
        }

        [Fact]
        public void RootElementTypeAttributeName2()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var expectedName = "IsCritical";
            Assert.Equal(expectedName, rootElementType.Attributes[0].Name);
        }

        [Fact]
        public void RootElementTypeAttributeTypeName1()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var attributeType = rootElementType.Attributes[0].Type;
            var expectedName = "xs:boolean";
            Assert.Equal(expectedName, attributeType.Name);
        }

        [Fact]
        public void RootElementTypeAttributeTypeName2()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var attributeType = rootElementType.Attributes[1].Type;
            var expectedName = "xs:boolean";
            Assert.Equal(expectedName, attributeType.Name);
        }

        [Fact]
        public void RootElementTypeAttributeTypeType1()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var attributeType = rootElementType.Attributes[1].Type;
            Assert.IsType<XmlUnknownType>(attributeType);
            Assert.IsNotType<XmlEnumerationType>(attributeType);
        }

        [Fact]
        public void RootElementTypeAttributeTypeType2()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var attributeType = rootElementType.Attributes[0].Type;
            Assert.IsType<XmlUnknownType>(attributeType);
            Assert.IsNotType<XmlEnumerationType>(attributeType);
        }

        [Fact]
        public void RootElementTypeHasSelfDeclaredChild()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var selfDeclaredChild = rootElementType.PossibleChildElements.FirstOrDefault(c => c.Name == "IntroducedInCommit");
            Assert.NotNull(selfDeclaredChild);
            Assert.IsType<XmlUnknownType>(selfDeclaredChild.Type);
            Assert.Equal("xs:string", selfDeclaredChild.Type.Name);
        }

        [Fact]
        public void RootElementTypeHasChildDeclaredInBase()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var referenceDeclaredChild = rootElementType.PossibleChildElements.FirstOrDefault(c => c.Name == "Message");
            Assert.NotNull(referenceDeclaredChild);
            Assert.IsType<XmlUnknownType>(referenceDeclaredChild.Type);
            Assert.Equal("xs:string", referenceDeclaredChild.Type.Name);
        }
    }
}