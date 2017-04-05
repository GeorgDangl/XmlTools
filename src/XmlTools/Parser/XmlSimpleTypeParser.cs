using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XmlTools.Parser
{
    public class XmlSimpleTypeParser : IXmlTypeParser
    {
        public XmlSimpleTypeParser(XDocument document, XmlUnknownTypeParser xmlUnknownTypeParser, EnumerationRestrictionParser enumerationRestrictionParser)
        {
            _document = document;
            _xmlUnknownTypeParser = xmlUnknownTypeParser;
            _enumerationRestrictionParser = enumerationRestrictionParser;
        }

        private readonly XDocument _document;
        private readonly XNamespace _xmlSchemaNamespace = "http://www.w3.org/2001/XMLSchema";
        private readonly XmlUnknownTypeParser _xmlUnknownTypeParser;
        private readonly EnumerationRestrictionParser _enumerationRestrictionParser;
        private readonly Dictionary<string, XmlSimpleType> _simpleTypesByTypeName = new Dictionary<string, XmlSimpleType>();

        public bool CanParseElement(XElement element)
        {
            var elementTypeReference = element.Attributes().FirstOrDefault(a => a.Name == "type")?.Value;
            if (!string.IsNullOrWhiteSpace(elementTypeReference))
            {
                var referencedTypeIsComplexType = _document.Descendants().Any(e => e.Name == _xmlSchemaNamespace + "simpleType" && e.Attributes().Any(a => a.Name == "name" && a.Value == elementTypeReference));
                return referencedTypeIsComplexType;
            }
            var isInlineDefined = element.Elements().Any(e => e.Name == _xmlSchemaNamespace + "simpleType");
            return isInlineDefined;
        }

        public XmlType ParseElement(XElement element)
        {
            if (IsUnknownType(element))
            {
                var unknownTypeName = element.Attributes().Single(a => a.Name == "type").Value;
                return _xmlUnknownTypeParser.GetUnknownTypeDefinitionByName(unknownTypeName);
            }
            var typeDefinitionElement = GetTypeDefinitionElement(element);
            var typeName = GetTypeName(typeDefinitionElement);
            if (_simpleTypesByTypeName.ContainsKey(typeName))
            {
                return _simpleTypesByTypeName[typeName];
            }
            XmlSimpleType result;
            if (_enumerationRestrictionParser.IsEnumerationType(typeDefinitionElement))
            {
                var enumerationValues = _enumerationRestrictionParser.GetEnumerationValues(typeDefinitionElement);
                result = new XmlEnumerationType
                {
                    Name = typeName,
                    EnumerationValues = enumerationValues
                };
            }
            else
            {
                result = new XmlSimpleType
                {
                    Name = typeName
                };
            }
            _simpleTypesByTypeName.Add(typeName, result);
            return result;
        }

        private bool IsUnknownType(XElement declaringElement)
        {
            var typeDefinitionElement = GetTypeDefinitionElement(declaringElement);
            return typeDefinitionElement == null;
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

        private string GetTypeName(XElement element)
        {
            var typeNameAttribute = element.Attributes().FirstOrDefault(a => a.Name == "name")?.Value;
            if (string.IsNullOrWhiteSpace(typeNameAttribute))
            {
                return "InlineSimpleType_" + Guid.NewGuid();
            }
            return typeNameAttribute;
        }
    }
}