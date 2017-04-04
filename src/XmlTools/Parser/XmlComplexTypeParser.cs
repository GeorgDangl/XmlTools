using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XmlTools.Parser
{
    public class XmlComplexTypeParser : IXmlTypeParser
    {
        public XmlComplexTypeParser(XDocument document, XmlElementParser xmlElementParser, XmlAttributesParser xmlAttributesParser)
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
        private List<XElement> _documentComplexTypes;
        private List<XElement> _documentSimpleTypes;

        public bool CanParseElement(XElement element)
        {
            if (IsSimpleContentComplexType(element))
            {
                return false;
            }
            var elementTypeReference = element.Attributes().FirstOrDefault(a => a.Name == "type")?.Value;
            if (!string.IsNullOrWhiteSpace(elementTypeReference))
            {
                var referencedTypeIsComplexType = _document.Descendants().Any(e => e.Name == _xmlSchemaNamespace + "complexType" && e.Attributes().Any(a => a.Name == "name" && a.Value == elementTypeReference));
                if (referencedTypeIsComplexType)
                {
                    var referencedElement = _document.Descendants().Single(e => e.Name == _xmlSchemaNamespace + "complexType" && e.Attributes().Any(a => a.Name == "name" && a.Value == elementTypeReference));
                    var isSimpleContentReferencedElement = IsSimpleContentComplexType(referencedElement);
                    return !isSimpleContentReferencedElement;
                }
                return false;
            }
            var isInlineDefined = element.Elements().Any(e => e.Name == _xmlSchemaNamespace + "complexType");
            if (isInlineDefined)
            {
                var inlineElement = element.Elements().Single(e => e.Name == _xmlSchemaNamespace + "complexType");
                var isInlineSimpleContent = IsSimpleContentComplexType(inlineElement);
                return !isInlineSimpleContent;
            }
            return false;
        }

        private bool IsSimpleContentComplexType(XElement element)
        {
            var isSimpleContent = element.Elements().Any(e => e.Name == _xmlSchemaNamespace + "simpleContent");
            if (isSimpleContent)
            {
                return true;
            }
            return false;
        }

        public XmlType ParseElement(XElement element)
        {
            if (ElementIsInlineDefined(element))
            {
                return GetInlineXmlType(element);
            }
            return GetReferencedXmlType(element);
        }

        private bool ElementIsInlineDefined(XElement element)
        {
            var elementIsReferencingType = element.Attributes().Any(a => a.Name == "type");
            return !elementIsReferencingType;
        }

        private XmlType GetReferencedXmlType(XElement element)
        {
            var typeName = element.Attributes().Single(a => a.Name == "type").Value;
            if (_parsedTypes.ContainsKey(typeName))
            {
                return GetPreviouslyParsedType(typeName);
            }
            var result = new XmlComplexType
            {
                Name = typeName
            };
            _parsedTypes.Add(typeName, result);
            var typeElement = GetTypeDefinition(typeName);
            var allowedChildElements = GetAllowedChildElements(typeElement);
            result.PossibleChildElements = allowedChildElements;
            result.Attributes = GetAttributesForElement(typeElement);
            return result;
        }

        private List<XmlAttribute> GetAttributesForElement(XElement element)
        {
            var attributes = _xmlAttributesParser.GetAttributesForTypeDefinition(element);
            return attributes;
        }

        private XElement GetTypeDefinition(string typeName)
        {
            var complexTypeDefinitions = _documentComplexTypes ?? (_documentComplexTypes = _document.Descendants().Where(e => e.Name == _xmlSchemaNamespace + "complexType").ToList());
            var simpleTypeDefinitions = _documentSimpleTypes ?? (_documentSimpleTypes =_document.Descendants().Where(e => e.Name == _xmlSchemaNamespace + "simpleType").ToList());
            var complexTypesWithMatchingName = complexTypeDefinitions.Where(e => e.Attributes().Any(a => a.Name == "name" && a.Value == typeName));
            var simpleTypesWithMatchingName = simpleTypeDefinitions.Where(e => e.Attributes().Any(a => a.Name == "name" && a.Value == typeName));
            var typeElement = complexTypesWithMatchingName.Concat(simpleTypesWithMatchingName).Single();
            return typeElement;
        }

        private XElement GetInlineTypeDefinition(XElement element)
        {
            var inlineTypeDefinition = element.Elements().Single(e => e.Name == _xmlSchemaNamespace + "complexType");
            return inlineTypeDefinition;
        }

        private XmlType GetInlineXmlType(XElement element)
        {
            var typeName = "InlineComplexType_" + Guid.NewGuid();
            var typeElement = GetInlineTypeDefinition(element);
            var allowedChildElements = GetAllowedChildElements(typeElement);
            var result = new XmlComplexType
            {
                Name = typeName,
                PossibleChildElements = allowedChildElements,
                Attributes = GetAttributesForElement(typeElement)
            };
            return result;
        }

        private List<XmlElement> GetAllowedChildElements(XElement element)
        {
            var xElements = GetChildElementDefinitions(element);
            var result = new List<XmlElement>();
            foreach (var childElement in xElements)
            {
                var parsedElement = _xmlElementParser.ParseElement(childElement);

                result.Add(parsedElement);
            }
            result = RemoveDuplicateElementsFromList(result);
            return result;
        }

        private List<XmlElement> RemoveDuplicateElementsFromList(List<XmlElement> elements)
        {
            var result = new List<XmlElement>();
            foreach (var element in elements)
            {
                var foundElement = result.FirstOrDefault(e => e.Name == element.Name);
                if (foundElement == null)
                {
                    result.Add(element);
                    continue;
                }
                if (foundElement.Type != element.Type)
                {
                    throw new Exception("There is a complexType that has child elements defined with the same name but different types");
                }
            }
            return result;
        }

        private List<XElement> GetChildElementDefinitions(XElement element)
        {
            var sequenceElements = GetChildElementsFromSequence(element);
            var choiceElements = GetChildElementsFromChoice(element);
            var complexContentElements = GetChildElementsFromComplexContent(element);
            var baseTypeElements = GetChildElementsFromBaseType(element);
            var directElements = GetChildElementsFromDirectReference(element);

            var result = sequenceElements
                .Concat(choiceElements)
                .Concat(complexContentElements)
                .Concat(baseTypeElements)
                .Concat(directElements)
                .ToList();
            return result;
        }

        private List<XElement> GetChildElementsFromSequence(XElement element)
        {
            var sequenceElements = element.Elements()
                .Where(e => e.Name == _xmlSchemaNamespace + "sequence")
                .SelectMany(GetChildElementDefinitions)
                .ToList();
            return sequenceElements;
        }

        private List<XElement> GetChildElementsFromChoice(XElement element)
        {
            var choiceElements = element.Elements()
                .Where(e => e.Name == _xmlSchemaNamespace + "choice")
                .SelectMany(GetChildElementDefinitions)
                .ToList();
            return choiceElements;
        }

        private List<XElement> GetChildElementsFromComplexContent(XElement element)
        {
            var choiceElements = element.Elements()
                .Where(e => e.Name == _xmlSchemaNamespace + "complexContent")
                .SelectMany(e => new[] {e}.Concat(e.Elements().Where(c => c.Name == _xmlSchemaNamespace + "extension")))
                .SelectMany(GetChildElementDefinitions)
                .ToList();
            return choiceElements;
        }

        private List<XElement> GetChildElementsFromDirectReference(XElement element)
        {
            var directChildElements = element.Elements()
                .Where(e => e.Name == _xmlSchemaNamespace + "element")
                .ToList();
            return directChildElements;
        }

        public List<XElement> GetChildElementsFromBaseType(XElement element)
        {
            var baseTypeName = element.Elements()
                .Where(e=>e.Name==_xmlSchemaNamespace + "complexContent")
                .SelectMany(e => e.Elements().Where(c=> c.Name==_xmlSchemaNamespace + "extension"))
                .Select(e=>e.Attributes().FirstOrDefault(a=>a.Name=="base")?.Value)
                .FirstOrDefault();
            if (string.IsNullOrWhiteSpace(baseTypeName))
            {
                return new List<XElement>();
            }
            var typeDefinitionElement = _document.Descendants()
                .FirstOrDefault(e => e.Name == _xmlSchemaNamespace + "complexType" && e.Attributes().Any(a => a.Name == "name" && a.Value == baseTypeName));
            if (typeDefinitionElement == null)
            {
                return new List<XElement>();
            }
            return GetChildElementDefinitions(typeDefinitionElement);
        }

        private XmlType GetPreviouslyParsedType(string typeName)
        {
            return _parsedTypes[typeName];
        }
    }
}