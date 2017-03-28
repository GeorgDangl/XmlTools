using System.Xml.Linq;

namespace XmlTools.Parser
{
    public interface IXmlTypeParser
    {
        bool CanParseElement(XElement element);
        XmlType ParseElement(XElement element);
    }
}