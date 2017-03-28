using System.IO;
using System.Linq;
using System.Reflection;

namespace XmlTools.Tests
{
    public static class TestFilesFactory
    {
        public static Stream GetStreamForTestFile(TestFile file)
        {
            var resourceNameStart = $"XmlTools.Tests.Testfiles.{file}";
            var assembly = typeof(TestFilesFactory).GetTypeInfo().Assembly;
            var exactFileNameMatch = GetStreamForExactFileName(assembly, $"{resourceNameStart}.xsd");
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
