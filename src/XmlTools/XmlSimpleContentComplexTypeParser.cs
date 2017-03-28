using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace XmlTools
{
    public class XmlSimpleContentComplexTypeParser : IXmlTypeParser
    {
        public XmlSimpleContentComplexTypeParser(XDocument document, XmlElementParser xmlElementParser, XmlAttributesParser xmlAttributesParser)
        {
            _document = document;
            _xmlElementParser = xmlElementParser;
            _xmlAttributesParser = xmlAttributesParser;
        }

        private readonly XDocument _document;
        private readonly XmlElementParser _xmlElementParser;
        private readonly XmlAttributesParser _xmlAttributesParser;
        private readonly Dictionary<string, XmlType> _parsedTypes = new Dictionary<string, XmlType>();
        private readonly XNamespace _xmlSchemaNamespace = "http://www.w3.org/2001/XMLSchema";

        public bool CanParseElement(XElement element)
        {
            if (IsComplexType(element))
            {
                var complexTypeDefinitionElement = GetComplexTypeDefinitionElement(element);
                if (ComplexTypeHasSimpleContent(complexTypeDefinitionElement))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsComplexType(XElement element)
        {
            var isInlineComplexType = element.Elements().Any(e => e.Name == _xmlSchemaNamespace + "complexType");
            if (isInlineComplexType)
            {
                return true;
            }
            var typeReferenceName = element.Attributes().FirstOrDefault(a => a.Name == "type")?.Value;
            if (string.IsNullOrWhiteSpace(typeReferenceName))
            {
                return false;
            }
            var complexTypeDefinitionElement = _document.Descendants().FirstOrDefault(e => e.Name == _xmlSchemaNamespace + "complexType" && e.Attributes().Any(a => a.Name == "name" && a.Value == typeReferenceName));
            if (complexTypeDefinitionElement != null)
            {
                return ComplexTypeHasSimpleContent(complexTypeDefinitionElement);
            }
            return false;
        }

        private XElement GetComplexTypeDefinitionElement(XElement element)
        {
            var isInlineComplexType = element.Elements().Any(e => e.Name == _xmlSchemaNamespace + "complexType");
            if (isInlineComplexType)
            {
                return element.Elements().Single(e => e.Name == _xmlSchemaNamespace + "complexType");
            }
            var typeReferenceName = element.Attributes().Single(a => a.Name == "type").Value;
            var complexTypeDefinitionElement = _document.Descendants().FirstOrDefault(e => e.Name == _xmlSchemaNamespace + "complexType" && e.Attributes().Any(a => a.Name == "name" && a.Value == typeReferenceName));
            return complexTypeDefinitionElement;
        }

        private bool ComplexTypeHasSimpleContent(XElement element)
        {
            var hasSimpleContentChild = element.Elements().Any(e => e.Name == _xmlSchemaNamespace + "simpleContent");
            return hasSimpleContentChild;
        }

        public XmlType ParseElement(XElement element)
        {
            var typeDefinitionElement = GetComplexTypeDefinitionElement(element);
            CheckAndThrowExceptionIfTypeContainsElementReferences(typeDefinitionElement);
            var typeName = typeDefinitionElement.Attributes().FirstOrDefault(a => a.Name == "name")?.Value;
            var result = new XmlSimpleContentComplexType();
            if (string.IsNullOrWhiteSpace(typeName))
            {
                typeName = "InlineSimpleContentComplexType_" + Guid.NewGuid();
            }
            else
            {
                if (_parsedTypes.ContainsKey(typeName))
                {
                    return _parsedTypes[typeName];
                }
                else
                {
                    _parsedTypes.Add(typeName, result);
                }
            }
            var attributes = _xmlAttributesParser.GetAttributesForTypeDefinition(typeDefinitionElement);

            result.Name = typeName;
            result.Attributes = attributes;

            return result;
        }

        private void CheckAndThrowExceptionIfTypeContainsElementReferences(XElement element)
        {
            var hasDirectElements = element.Elements()
                .Union(element.Elements().Where(e => e.Name == _xmlSchemaNamespace + "simpleContent").SelectMany(e => e.Elements()))
                .Any(e => e.Name == _xmlSchemaNamespace + "element");
            var hasExtendedElements = element.Elements().Any(e => e.Name == _xmlSchemaNamespace + "extension" && e.Elements().Any(c => c.Name == _xmlSchemaNamespace + "element"));
            if (hasDirectElements || hasExtendedElements)
            {
                throw new InvalidDataException("'simpleContent' Xml types may not contain 'element' definitions");
            }
        }
    }
}