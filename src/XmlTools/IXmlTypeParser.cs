using System.Xml.Linq;

namespace XmlTools
{
    public interface IXmlTypeParser
    {
        bool CanParseElement(XElement element);
        XmlType ParseElement(XElement element);
    }
}