using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XmlTools.Parser
{
    public class XmlElementParser
    {
        public XmlElementParser(XDocument document)
        {
            _document = document;
            SetUpXmlTypeParsers();
        }

        public List<IXmlTypeParser> XmlTypeParsers { get; } = new List<IXmlTypeParser>();
        private readonly XDocument _document;
        private readonly XNamespace _xmlSchemaNamespace = "http://www.w3.org/2001/XMLSchema";
        private readonly XmlUnknownTypeParser _xmlUnknownTypeParser = new XmlUnknownTypeParser();
        private readonly Dictionary<string, XmlUnknownType> _foundUnknownTypes = new Dictionary<string, XmlUnknownType>();

        public XmlElement ParseElement(XElement element)
        {
            if (IsExternallyReferencedElement(element))
            {
                var typeName = GetNameOfExternallyReferencedElement(element);
                var unknownType = _xmlUnknownTypeParser.GetUnknownTypeDefinitionByName(typeName);
                return new XmlElement
                {
                    Name = typeName,
                    IsExternallyDeclared = true,
                    Type = unknownType
                };
            }
            if (IsInternallyReferencedElement(element))
            {
                var referencedElementName = element.Attributes().Single(a => a.Name == "ref").Value;
                var internalReference = _document.Root?.Elements().Single(e => e.Name == _xmlSchemaNamespace + "element" && e.Attributes().Any(a => a.Name == "name" && a.Value == referencedElementName));
                return ParseElement(internalReference);
            }
            var elementName = GetNameForElement(element);
            var elementType = ParseXmlType(element);
            var result = new XmlElement
            {
                Name = elementName,
                Type = elementType
            };
            return result;
        }

        private XmlType ParseXmlType(XElement element)
        {
            foreach (var parser in XmlTypeParsers)
            {
                if (parser.CanParseElement(element))
                {
                    return parser.ParseElement(element);
                }
            }
            var unknownTypeName = TryGetNameForUnknownType(element);
            if (_foundUnknownTypes.ContainsKey(unknownTypeName))
            {
                return _foundUnknownTypes[unknownTypeName];
            }
            var unknownType = _xmlUnknownTypeParser.GetUnknownTypeDefinitionByName(unknownTypeName);
            _foundUnknownTypes.Add(unknownTypeName, unknownType);
            return unknownType;
        }

        private string TryGetNameForUnknownType(XElement element)
        {
            var referencedTypeName = element.Attributes().FirstOrDefault(a => a.Name == "type")?.Value;
            return referencedTypeName ?? $"UnknownType_{Guid.NewGuid()}";
        }

        private string GetNameForElement(XElement element)
        {
            var declaredName = element.Attributes().Single(a => a.Name == "name").Value;
            return declaredName;
        }

        private bool IsExternallyReferencedElement(XElement element)
        {
            var referencedElementName = element.Attributes().FirstOrDefault(a => a.Name == "ref")?.Value;
            if (string.IsNullOrWhiteSpace(referencedElementName))
            {
                return false;
            }
            var referencedElementIsPresent = !referencedElementName.Contains(":")
                                             && _document.Descendants().Any(e => e.Name == _xmlSchemaNamespace + "element" && e.Attributes().Any(a => a.Name == "name" && a.Value == referencedElementName));
            return !referencedElementIsPresent;
        }

        private bool IsInternallyReferencedElement(XElement element)
        {
            var referencedElementName = element.Attributes().FirstOrDefault(a => a.Name == "ref")?.Value;
            if (string.IsNullOrWhiteSpace(referencedElementName))
            {
                return false;
            }
            var referencedElementIsPresent = !referencedElementName.Contains(":")
                                 && _document.Descendants().Any(e => e.Name == _xmlSchemaNamespace + "element" && e.Attributes().Any(a => a.Name == "name" && a.Value == referencedElementName));
            return referencedElementIsPresent;
        }

        private string GetNameOfExternallyReferencedElement(XElement element)
        {
            var referencedElementName = element.Attributes().FirstOrDefault(a => a.Name == "ref")?.Value;
            return referencedElementName;
        }

        private void SetUpXmlTypeParsers()
        {
            var dateTimeParser = new XmlDateTimeParser(_document);
            XmlTypeParsers.Add(dateTimeParser);
            var decimalParser = new XmlDecimalParser(_document);
            XmlTypeParsers.Add(decimalParser);
            var enumerationRestrictionParser = new EnumerationRestrictionParser(_document);
            var simpleTypeParser = new XmlSimpleTypeParser(_document, _xmlUnknownTypeParser, enumerationRestrictionParser);
            XmlTypeParsers.Add(simpleTypeParser);
            var xmlAttributesParser = new XmlAttributesParser(_document, simpleTypeParser, _xmlUnknownTypeParser);
            var complexTypeParser = new XmlComplexTypeParser(_document, this, xmlAttributesParser);
            XmlTypeParsers.Add(complexTypeParser);
            var simpleContentComplexTypeParser = new XmlSimpleContentComplexTypeParser(_document, xmlAttributesParser, enumerationRestrictionParser);
            XmlTypeParsers.Add(simpleContentComplexTypeParser);
        }
    }
}