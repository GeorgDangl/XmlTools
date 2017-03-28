using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser
{
    public class SchemaWithRestrictionButNotEnumerationType : TestFileBase
    {
        public SchemaWithRestrictionButNotEnumerationType() : base(TestFilesFactory.GetStreamForTestFile(TestFile.SchemaWithRestrictionButNotEnumerationType)) { }

        [Fact]
        public void HasOnlySingleRootElement()
        {
            Assert.Equal(1, ParsedSchema.RootElements.Count);
        }

        [Fact]
        public void RootElementName()
        {
            var expectedElementName = "OperatingTemperature";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.Equal(expectedElementName, rootElement.Name);
        }

        [Fact]
        public void RootElementTypeName()
        {
            var expectedTypeName = "OperatingTemperatureRange";
            var rootElement = ParsedSchema.RootElements.First();
            Assert.Equal(expectedTypeName, rootElement.Type.Name);
        }

        [Fact]
        public void RootElementTypeType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.IsType(typeof(XmlSimpleType), rootElementType);
        }

        [Fact]
        public void RootElementTypeIsNotEnumerationType()
        {
            var rootElementType = ParsedSchema.RootElements.First().Type;
            Assert.IsNotType(typeof(XmlEnumerationType), rootElementType);
        }
    }
}