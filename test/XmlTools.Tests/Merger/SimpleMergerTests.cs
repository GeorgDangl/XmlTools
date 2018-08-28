using System.IO;
using System.Reflection;
using XmlTools.Merger;
using Xunit;

namespace XmlTools.Tests.Merger
{
    public class SimpleMergerTests
    {
        [Theory]
        [InlineData("onlb.xsd")]
        [InlineData("onlv.xsd")]
        public void CanMergeSchemas(string rootSchemaDocument)
        {
            using (var originalStream = GetMergerTestFileStreamByFileName(rootSchemaDocument))
            {
                var merger = new SimpleMerger(originalStream, GetMergerTestFileStreamByFileName);
                using (var mergeResult = merger.MergeSchemas())
                {
                    Assert.NotNull(mergeResult);
                    using (var strmRdr = new StreamReader(mergeResult))
                    {
                        var text = strmRdr.ReadToEnd();
                        Assert.False(string.IsNullOrWhiteSpace(text));
                    }
                }
            }
        }

        private static Stream GetMergerTestFileStreamByFileName(string fileName)
        {
            var resourceName = $"XmlTools.Tests.Testfiles.Merger.{fileName}";
            var assembly = typeof(SimpleMergerTests).GetTypeInfo().Assembly;
            return assembly.GetManifestResourceStream(resourceName);
        }
    }
}
