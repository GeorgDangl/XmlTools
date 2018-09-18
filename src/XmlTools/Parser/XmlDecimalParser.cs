using System.Xml.Linq;

namespace XmlTools.Parser
{
    public class XmlDecimalParser : BuiltInTypeParserBase<XmlDecimalType>
    {
        public XmlDecimalParser(XDocument document)
            : base("decimal", document)
        { }
    }
}
