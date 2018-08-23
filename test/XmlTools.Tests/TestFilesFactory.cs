using System.IO;
using System.Linq;
using System.Reflection;

namespace XmlTools.Tests
{
    public static class TestFilesFactory
    {
        public static Stream GetStreamForTestFile(ParserTestFile file)
        {
            return GetStreamForTestFile("Parser", file.ToString());
        }

        public static Stream GetStreamForTestFile(InvalidParserTestFile file)
        {
            return GetStreamForTestFile("Parser", file.ToString());
        }

        public static Stream GetStreamForTestFile(SchemaCorrectorTestFile file)
        {
            return GetStreamForTestFile("SchemaCorrector", file.ToString());
        }

        public static Stream GetStreamForTestFile(GroupFlattenerTestFile file)
        {
            return GetStreamForTestFile("GroupFlattener", file.ToString());
        }

        private static Stream GetStreamForTestFile(string testFileCategory, string testFile)
        {
            var resourceNameStart = $"XmlTools.Tests.Testfiles.{testFileCategory}.{testFile}";
            var assembly = typeof(TestFilesFactory).GetTypeInfo().Assembly;
            var exactFileNameMatch = GetStreamForExactFileName(assembly, $"{resourceNameStart}.xsd")
                                     ?? GetStreamForExactFileName(assembly, $"{resourceNameStart}.xml");
            if (exactFileNameMatch != null)
            {
                return exactFileNameMatch;
            }
            var exactResourceNames = assembly.GetManifestResourceNames()
                .Where(name => name.StartsWith(resourceNameStart))
                .ToList();
            if (exactResourceNames.Count != 1)
            {
                throw new FileNotFoundException($"Resource name ambigious or file not found, was looking for testfiles that start with \"{resourceNameStart}\"");
            }
            return assembly.GetManifestResourceStream(exactResourceNames.First());
        }

        private static Stream GetStreamForExactFileName(Assembly assembly, string fileName)
        {
            var resourceNamePresent = assembly.GetManifestResourceNames().Any(r => r == fileName);
            if (resourceNamePresent)
            {
                return assembly.GetManifestResourceStream(fileName);
            }
            return null;
        }
    }
}
