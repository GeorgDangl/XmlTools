using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;

namespace XmlTools.Tests
{
    public class TestFilesFactoryTests
    {
        public static IEnumerable<object[]> AllValidParserEnums => (Enum.GetValues(typeof(ParserTestFile))).Cast<ParserTestFile>().Select(e => new object[] {e});
        public static IEnumerable<object[]> AllValidSchemaCorrectorEnums => (Enum.GetValues(typeof(SchemaCorrectorTestFile))).Cast<SchemaCorrectorTestFile>().Select(e => new object[] {e});

        [Fact]
        public void FindsAllValidParserTestFiles()
        {
            var expectedCountOfEnums = 21;
            Assert.Equal(expectedCountOfEnums, AllValidParserEnums.Count());
        }

        [Fact]
        public void FindsAllValidSchemaCorrectorTestFiles()
        {
            var expectedCountOfEnums = 27;
            Assert.Equal(expectedCountOfEnums, AllValidSchemaCorrectorEnums.Count());
        }

        [Theory]
        [MemberData(nameof(AllValidParserEnums))]
        public void CanGetStreamForAllParserTestFiles(ParserTestFile testFile)
        {
            using (var testFileStream = TestFilesFactory.GetStreamForTestFile(testFile))
            {
                Assert.NotNull(testFileStream);
                Assert.True(testFileStream.Length > 0);
            }
        }

        [Theory]
        [MemberData(nameof(AllValidSchemaCorrectorEnums))]
        public void CanGetStreamForAllSchemaCorrectorTestFiles(SchemaCorrectorTestFile testFile)
        {
            using (var testFileStream = TestFilesFactory.GetStreamForTestFile(testFile))
            {
                Assert.NotNull(testFileStream);
                Assert.True(testFileStream.Length > 0);
            }
        }

        [Fact]
        public void ThrowsExceptionForInvalidParserEnum()
        {
            var invalidEnumIntegerValue = 0;
            var invalidEnum = (ParserTestFile) invalidEnumIntegerValue;
            var enumIsValid = Enum.IsDefined(typeof(ParserTestFile), invalidEnumIntegerValue);
            Assert.False(enumIsValid);
            Assert.Throws(typeof(FileNotFoundException), () =>
            {
                TestFilesFactory.GetStreamForTestFile(invalidEnum);
            });
        }

        [Fact]
        public void ThrowsExceptionForInvalidSchemaCorrectorEnum()
        {
            var invalidEnumIntegerValue = 0;
            var invalidEnum = (SchemaCorrectorTestFile) invalidEnumIntegerValue;
            var enumIsValid = Enum.IsDefined(typeof(SchemaCorrectorTestFile), invalidEnumIntegerValue);
            Assert.False(enumIsValid);
            Assert.Throws(typeof(FileNotFoundException), () =>
            {
                TestFilesFactory.GetStreamForTestFile(invalidEnum);
            });
        }

        [Fact]
        public void ReturnsCorrectStreamForValidEnum_1()
        {
            // Can not use hard coded length comparisons here since git
            // might normalize line endings and therefore the file is
            // not binary compatible
            var fileEnum = ParserTestFile.GAEB_XML_3_1_Schema;
            var resourceName = "XmlTools.Tests.Testfiles.Parser.GAEB_XML_3_1_Schema.xsd";
            using (var testFilesFactoryStream = TestFilesFactory.GetStreamForTestFile(fileEnum))
            {
                Assert.NotNull(testFilesFactoryStream);
                using (var resourceStream = GetResourceStream(resourceName))
                {
                    var actualLength = testFilesFactoryStream.Length;
                    var expectedLength = resourceStream.Length;
                    Assert.Equal(expectedLength, actualLength);
                }
            }
        }

        [Fact]
        public void ReturnsCorrectStreamForValidEnum_2()
        {
            // Can not use hard coded length comparisons here since git
            // might normalize line endings and therefore the file is
            // not binary compatible
            var fileEnum = ParserTestFile.GreenBuildingXML_Ver6_01;
            var resourceName = "XmlTools.Tests.Testfiles.Parser.GreenBuildingXML_Ver6_01.xsd";
            using (var testFilesFactoryStream = TestFilesFactory.GetStreamForTestFile(fileEnum))
            {
                Assert.NotNull(testFilesFactoryStream);
                using (var resourceStream = GetResourceStream(resourceName))
                {
                    var actualLength = testFilesFactoryStream.Length;
                    var expectedLength = resourceStream.Length;
                    Assert.Equal(expectedLength, actualLength);
                }
            }
        }

        private Stream GetResourceStream(string resourceName)
        {
            var assembly = typeof(TestFilesFactoryTests).GetTypeInfo().Assembly;
            return assembly.GetManifestResourceStream(resourceName);
        }
    }
}