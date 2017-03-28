using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser
{
    public class SchemaWithComplexType : TestFileBase
    {
        public SchemaWithComplexType() : base(TestFilesFactory.GetStreamForTestFile(TestFile.SchemaWithComplexType)) { }

        [Fact]
        public void HasOnlySingleRootElement()
        {
            Assert.Equal(1, ParsedSchema.RootElements.Count);
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
            Assert.Equal("IsResolved", attribute.Name);
        }

        [Fact]
        public void RootElementTypeAttributeTypeName()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var attributeType = rootElementType.Attributes.First().Type;
            Assert.Equal("xs:boolean", attributeType.Name);
        }

        [Fact]
        public void RootElementTypeAttributeTypeType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var attributeType = rootElementType.Attributes.First().Type;
            Assert.IsType(typeof(XmlUnknownSimpleType), attributeType);
        }

        [Fact]
        public void RootElementTypeChildCount()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            Assert.Equal(4, rootElementType.PossibleChildElements.Count);
        }

        [Fact]
        public void RootElementTypeChildNames()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var expectedTypeNames = new[] { "Message", "IntroducedInCommit", "Priority", "PersonToBlame" };
            var allChildTypeNamesPresent = expectedTypeNames.All(e => rootElementType.PossibleChildElements.Any(c => c.Name == e));
            Assert.True(allChildTypeNamesPresent);
        }

        [Fact]
        public void RootElementTypeChildTypesNames()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var messageType = rootElementType.PossibleChildElements.First(c => c.Name == "Message").Type;
            var introducedInCommitType = rootElementType.PossibleChildElements.First(c => c.Name == "IntroducedInCommit").Type;
            var priorityType = rootElementType.PossibleChildElements.First(c => c.Name == "Priority").Type;
            var personToBlameType = rootElementType.PossibleChildElements.First(c => c.Name == "PersonToBlame").Type;
            Assert.Equal("xs:string", messageType.Name);
            Assert.Equal("xs:string", introducedInCommitType.Name);
            Assert.Equal("xs:string", priorityType.Name);
            Assert.StartsWith("InlineComplexType_", personToBlameType.Name);
        }

        [Fact]
        public void RootElementTypeChildTypesTypes()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var messageType = rootElementType.PossibleChildElements.First(c => c.Name == "Message").Type;
            var introducedInCommitType = rootElementType.PossibleChildElements.First(c => c.Name == "IntroducedInCommit").Type;
            var priorityType = rootElementType.PossibleChildElements.First(c => c.Name == "Priority").Type;
            var personToBlameType = rootElementType.PossibleChildElements.First(c => c.Name == "PersonToBlame").Type;
            Assert.IsType(typeof(XmlUnknownType), messageType);
            Assert.IsType(typeof(XmlUnknownType), introducedInCommitType);
            Assert.IsType(typeof(XmlUnknownType), priorityType);
            Assert.IsType(typeof(XmlComplexType), personToBlameType);
        }

        [Fact]
        public void RootElementTypeChildTypesNestedTypeAttributesCount()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var personToBlameType = rootElementType.PossibleChildElements.First(c => c.Name == "PersonToBlame").Type as XmlComplexType;
            Assert.Equal(0, personToBlameType.Attributes.Count);
        }

        [Fact]
        public void RootElementTypeChildTypesNestedTypeChildCount()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var personToBlameType = rootElementType.PossibleChildElements.First(c => c.Name == "PersonToBlame").Type as XmlComplexType;
            Assert.Equal(2, personToBlameType.PossibleChildElements.Count);
        }

        [Fact]
        public void RootElementTypeChildTypesNestedTypeChildNames()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var personToBlameType = rootElementType.PossibleChildElements.First(c => c.Name == "PersonToBlame").Type as XmlComplexType;
            Assert.True(personToBlameType.PossibleChildElements.Any(e => e.Name == "Email"));
            Assert.True(personToBlameType.PossibleChildElements.Any(e => e.Name == "Name"));
        }

        [Fact]
        public void RootElementTypeChildTypesNestedTypeChildTypeNames()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var personToBlameType = rootElementType.PossibleChildElements.First(c => c.Name == "PersonToBlame").Type as XmlComplexType;
            Assert.True(personToBlameType.PossibleChildElements.All(e => e.Type.Name == "xs:string"));
        }

        [Fact]
        public void RootElementTypeChildTypesNestedTypeChildTypeTypes()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
            var personToBlameType = rootElementType.PossibleChildElements.First(c => c.Name == "PersonToBlame").Type as XmlComplexType;
            var emailType = personToBlameType.PossibleChildElements.First(c => c.Name == "Email").Type;
            Assert.IsType(typeof(XmlUnknownType), emailType);
            var nameType = personToBlameType.PossibleChildElements.First(c => c.Name == "Name").Type;
            Assert.IsType(typeof(XmlUnknownType), nameType);
        }
    }
}