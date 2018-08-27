using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XmlTools.Parser
{
    public class XmlDateTimeParser : IXmlTypeParser
    {
        public XmlDateTimeParser(XDocument document)
        {
            _document = document;
            _xmlSchemaNamespaceAbbreviation = _document
                .Root
                .Attributes()
                .FirstOrDefault(a => a.Value == _xmlSchemaNamespace.ToString())
                ?.Name.LocalName;
            if (!string.IsNullOrWhiteSpace(_xmlSchemaNamespaceAbbreviation))
            {
                _xmlSchemaNamespaceAbbreviation += ":";
            }
        }

        private readonly XDocument _document;
        private readonly XNamespace _xmlSchemaNamespace = "http://www.w3.org/2001/XMLSchema";
        private readonly string _xmlSchemaNamespaceAbbreviation;
        private readonly Dictionary<string, XmlDateTimeType> _dateTimeTypesByTypeName = new Dictionary<string, XmlDateTimeType>();

        public bool CanParseElement(XElement element)
        {
            return IsXmlDateTimeElementOrDerivedFromIt(element);
        }

        private bool IsXmlDateTimeElementOrDerivedFromIt(XElement element)
        {
            if (element.Attributes().Any(a => a.Name == _xmlSchemaNamespace + "date"))
            {
                return true;
            }

            var hasXmlDateTimeRestriction = element.Elements()
                .Any(e => e.Name == _xmlSchemaNamespace + "restriction" && e.Attributes().Any(a => a.Name == "base" && a.Value == _xmlSchemaNamespaceAbbreviation + "date"));
            if (hasXmlDateTimeRestriction)
            {
                return true;
            }

            var baseElementName = element.Attributes()
                .FirstOrDefault(a => a.Name == "type")
                ?.Value;
            if (baseElementName == null)
            {
                return false;
            }

            var baseElement = _document.Root
                .Descendants()
                .FirstOrDefault(e => e.Name == _xmlSchemaNamespace + "simpleType" && e.Attributes().Any(a => a.Name == "name" && a.Value == baseElementName));
            if (baseElement != null)
            {
                return IsXmlDateTimeElementOrDerivedFromIt(baseElement);
            }
            return false;
        }

        private XElement GetTypeDefinitionElement(XElement declaringElement)
        {
            var typeNameReference = declaringElement.Attributes().FirstOrDefault(a => a.Name == "type")?.Value;
            if (string.IsNullOrWhiteSpace(typeNameReference))
            {
                var inlineTypeDefinition = declaringElement.Elements().Single(e => e.Name == _xmlSchemaNamespace + "simpleType");
                return inlineTypeDefinition;
            }
            var typeReference = _document.Descendants().FirstOrDefault(e => e.Name == _xmlSchemaNamespace + "simpleType" && e.Attributes().Any(a => a.Name == "name" && a.Value == typeNameReference));
            return typeReference;
        }

        public XmlType ParseElement(XElement element)
        {
            var typeDefinitionElement = GetTypeDefinitionElement(element);
            var typeName = typeDefinitionElement.Attributes().FirstOrDefault(a => a.Name == "name")?.Value;
            if (_dateTimeTypesByTypeName.ContainsKey(typeName))
            {
                return _dateTimeTypesByTypeName[typeName];
            }
            var type = new XmlDateTimeType
            {
                Name = typeName
            };
            _dateTimeTypesByTypeName.Add(typeName, type);
            return type;
        }
    }
}
