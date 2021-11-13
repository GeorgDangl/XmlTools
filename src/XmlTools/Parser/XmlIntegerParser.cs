using System.Xml.Linq;

namespace XmlTools.Parser
{
    public class XmlIntegerParser : BuiltInTypeParserBase<XmlIntegerType>
    {
        public XmlIntegerParser(XDocument document)
            : base("integer", document)
        { }
    }
}
