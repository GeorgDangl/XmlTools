using System.IO;
using System.Text;

namespace XmlTools.Tests
{
    public static class StringExtensions
    {
        public static Stream ToStream(this string source)
        {
            var memStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memStream, Encoding.UTF8, 1, true))
            {
                streamWriter.Write(source);
            }
            memStream.Position = 0;
            return memStream;
        }
    }
}
