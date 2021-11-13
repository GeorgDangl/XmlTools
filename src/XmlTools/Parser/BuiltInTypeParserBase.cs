using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XmlTools.Parser
{
    public abstract class BuiltInTypeParserBase<T> : IXmlTypeParser where T : XmlType, new()
    {
        private readonly string _xsdBaseTypeName;

        public BuiltInTypeParserBase(string xsdBaseTypeName, XDocument document)
        {
            _xsdBaseTypeName = xsdBaseTypeName;
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
        private readonly Dictionary<string, T> _simpleTypesByTypeName = new Dictionary<string, T>();

        public bool CanParseElement(XElement element)
        {
            return IsXmlBaseElementOrDerivedFromIt(element);
        }

        private bool IsXmlBaseElementOrDerivedFromIt(XElement element)
        {
            if (element.Attributes().Any(a => a.Name == _xmlSchemaNamespace + _xsdBaseTypeName))
            {
                return true;
            }

            var hasXmlRestriction = HasXmlRestriction(element);
            if (hasXmlRestriction)
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
                return IsXmlBaseElementOrDerivedFromIt(baseElement);
            }
            return false;
        }

        private bool HasXmlRestriction(XElement declaringElement)
        {
            return declaringElement.Elements()
                .Any(e => e.Name == _xmlSchemaNamespace + "restriction" && e.Attributes().Any(a => a.Name == "base" && a.Value == _xmlSchemaNamespaceAbbreviation + _xsdBaseTypeName));
        }

        private XElement GetTypeDefinitionElement(XElement declaringElement)
        {
            var hasXmlRestriction = HasXmlRestriction(declaringElement);
            if (hasXmlRestriction)
            {
                // Having a restriction means the declaring element itself is the type
                return declaringElement;
            }

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
            if (_simpleTypesByTypeName.ContainsKey(typeName))
            {
                return _simpleTypesByTypeName[typeName];
            }
            var type = new T
            {
                Name = typeName
            };
            _simpleTypesByTypeName.Add(typeName, type);
            return type;
        }
    }
}
