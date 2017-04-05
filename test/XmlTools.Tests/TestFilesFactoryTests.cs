using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var invalidEnum = (ParserTestFile)invalidEnumIntegerValue;
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
            var invalidEnum = (SchemaCorrectorTestFile)invalidEnumIntegerValue;
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
            var fileEnum = ParserTestFile.GAEB_XML_3_1_Schema;
            using (var fileStream = TestFilesFactory.GetStreamForTestFile(fileEnum))
            {
                Assert.NotNull(fileStream);
                Assert.Equal(135572, fileStream.Length);
            }
        }

        [Fact]
        public void ReturnsCorrectStreamForValidEnum_2()
        {
            var fileEnum = ParserTestFile.GreenBuildingXML_Ver6_01;
            using (var fileStream = TestFilesFactory.GetStreamForTestFile(fileEnum))
            {
                Assert.NotNull(fileStream);
                Assert.Equal(320910, fileStream.Length);
            }
        }
    }
}