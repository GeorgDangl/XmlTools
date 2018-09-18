using System.Xml.Linq;

namespace XmlTools.Parser
{
    public class XmlDateTimeParser : BuiltInTypeParserBase<XmlDateTimeType>
    {
        public XmlDateTimeParser(XDocument document)
            : base("date", document)
        {
        }
    }
}
