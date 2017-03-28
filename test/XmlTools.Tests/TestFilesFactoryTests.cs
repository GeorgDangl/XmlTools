using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace XmlTools.Tests
{
    public class TestFilesFactoryTests
    {
        public static IEnumerable<object[]> AllValidEnums => (Enum.GetValues(typeof(TestFile))).Cast<TestFile>().Select(e => new object[] {e});

        [Fact]
        public void FindsAllValidTestFiles()
        {
            var expectedCountOfEnums = 2;
            Assert.Equal(expectedCountOfEnums, AllValidEnums.Count());
        }

        [Theory]
        [MemberData(nameof(AllValidEnums))]
        public void CanGetStreamForAllTestFiles(TestFile testFile)
        {
            using (var testFileStream = TestFilesFactory.GetStreamForTestFile(testFile))
            {
                Assert.NotNull(testFileStream);
                Assert.True(testFileStream.Length > 0);
            }
        }

        [Fact]
        public void ThrowsExceptionForInvalidEnum()
        {
            var invalidEnumIntegerValue = 0;
            var invalidEnum = (TestFile)invalidEnumIntegerValue;
            var enumIsValid = Enum.IsDefined(typeof(TestFile), invalidEnumIntegerValue);
            Assert.False(enumIsValid);
            Assert.Throws(typeof(FileNotFoundException), () =>
            {
                TestFilesFactory.GetStreamForTestFile(invalidEnum);
            });
        }

        [Fact]
        public void ReturnsCorrectStreamForValidEnum_1()
        {
            var fileEnum = TestFile.GAEB_XML_3_1_Schema;
            using (var fileStream = TestFilesFactory.GetStreamForTestFile(fileEnum))
            {
                Assert.NotNull(fileStream);
                Assert.Equal(135572, fileStream.Length);
            }
        }

        [Fact]
        public void ReturnsCorrectStreamForValidEnum_2()
        {
            var fileEnum = TestFile.GreenBuildingXML_Ver6_01;
            using (var fileStream = TestFilesFactory.GetStreamForTestFile(fileEnum))
            {
                Assert.NotNull(fileStream);
                Assert.Equal(320910, fileStream.Length);
            }
        }
    }
}