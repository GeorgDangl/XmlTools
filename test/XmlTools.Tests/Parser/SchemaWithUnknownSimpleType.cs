using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser
{
    public class SchemaWithUnknownSimpleType : TestFileBase
    {
        public SchemaWithUnknownSimpleType() : base(TestFilesFactory.GetStreamForTestFile(TestFile.SchemaWithUnknownSimpleType)) { }

        [Fact]
        public void HasOnlySingleRootElement()
        {
            Assert.Equal(1, ParsedSchema.RootElements.Count);
        }

        [Fact]
        public void RootElementName()
        {
            var expectedElementName = "Message";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.Equal(expectedElementName, rootElement.Name);
        }

        [Fact]
        public void RootElementTypeName()
        {
            var expectedTypeName = "xs:string";
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.Equal(expectedTypeName, rootElementType.Name);
        }

        [Fact]
        public void RootElementTypeType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.IsType(typeof(XmlUnknownType), rootElementType);
        }
    }
}