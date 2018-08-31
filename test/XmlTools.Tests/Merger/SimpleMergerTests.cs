using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using XmlTools.GroupFlattener;
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

        [Fact]
        public void DebugTest()
        {
            using (var originalStream = GetMergerTestFileStreamByFileName("onlv.xsd"))
            {
                var merger = new SimpleMerger(originalStream, GetMergerTestFileStreamByFileName);
                using (var mergeResult = merger.MergeSchemas())
                {
                    var flattener = new Flattener(mergeResult);
                    var groupsToFlatten = new List<string>
                    {
                        "ontext.Inline.mix",
                        "ontext.Inline.class",
                        "ontext.InlPres.class",
                        "ontext.List.class",
                        "ontext.Flow.mix",
                        "ontext.Block.class",
                        "ontext.BlkSpecial.class",
                        "ontext.Table.class",
                    };
                    using (var flattenedresult = flattener.FlattenGroups(groupsToFlatten))
                    {
                        using (var strmRdr = new StreamReader(flattenedresult))
                        {
                            var text = strmRdr.ReadToEnd();
                            Assert.False(string.IsNullOrWhiteSpace(text));
                        }
                    }
                }
            }
        }
    }
}
