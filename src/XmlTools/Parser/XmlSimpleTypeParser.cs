using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XmlTools.Parser
{
    public class XmlSimpleTypeParser : IXmlTypeParser
    {
        public XmlSimpleTypeParser(XDocument document, XmlUnknownTypeParser xmlUnknownTypeParser)
        {
            _document = document;
            _xmlUnknownTypeParser = xmlUnknownTypeParser;
        }

        private readonly XDocument _document;
        private readonly XNamespace _xmlSchemaNamespace = "http://www.w3.org/2001/XMLSchema";
        private readonly XmlUnknownTypeParser _xmlUnknownTypeParser; 
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
            if (IsEnumerationType(typeDefinitionElement))
            {
                var enumerationValues = GetEnumerationValues(typeDefinitionElement);
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

        public bool IsEnumerationType(XElement element)
        {
            var restrictionChildElements = element.Elements()
                .Where(e => e.Name == _xmlSchemaNamespace + "restriction")
                .ToList();
            if (restrictionChildElements.Any())
            {
                var hasEnumerationRestriction = restrictionChildElements.Any(e => e.Elements().Any(ce => ce.Name == _xmlSchemaNamespace + "enumeration"));
                if (hasEnumerationRestriction)
                {
                    return true;
                }
                return HasRestrictionBaseTypeAsEnumerationType(element);
            }
            return false;
        }

        public bool HasRestrictionBaseTypeAsEnumerationType(XElement element)
        {
            var restrictionBaseTypeName = GetRestrictionBaseTypeName(element);
            if (string.IsNullOrWhiteSpace(restrictionBaseTypeName))
            {
                return false;
            }
            if (HasEnumerationBaseTypeInCurrentSchema(element))
            {
                var restrictionBaseType = GetRestrictionBaseType(element);
                return IsEnumerationType(restrictionBaseType);
            }
            return false;
        }

        private List<string> GetEnumerationValues(XElement element)
        {
            var restrictionElement = element.Elements().Single(e => e.Name == _xmlSchemaNamespace + "restriction");
            var enumerationValues = restrictionElement.Elements()
                .Where(e => e.Name == _xmlSchemaNamespace + "enumeration")
                .Select(e => e.Attributes().Single(a => a.Name == "value").Value);
            var baseTypeEnumerationValues = GetEnumerationValuesOfBaseTypes(element);
            return enumerationValues.Concat(baseTypeEnumerationValues).ToList();
        }

        private List<string> GetEnumerationValuesOfBaseTypes(XElement element)
        {
            if (HasEnumerationBaseTypeInCurrentSchema(element))
            {
                var enumerationBaseType = GetRestrictionBaseType(element);
                var baseTypeEnumerationValues = GetEnumerationValues(enumerationBaseType);
                return baseTypeEnumerationValues;
            }
            return new List<string>();
        }

        private bool HasEnumerationBaseTypeInCurrentSchema(XElement element)
        {
            var restrictionBaseTypeName = GetRestrictionBaseTypeName(element);
            var restrictionBaseTypeElementIsPresent = _document.Descendants()
                .Where(e => e.Name == _xmlSchemaNamespace + "simpleType")
                .Any(e => e.Attributes().Any(a => a.Name == "name" && a.Value == restrictionBaseTypeName));
            return restrictionBaseTypeElementIsPresent;
        }

        private XElement GetRestrictionBaseType(XElement element)
        {
            var restrictionBaseTypeName = GetRestrictionBaseTypeName(element);
            var restrictionBaseTypeElement = _document.Descendants()
                .Where(e => e.Name == _xmlSchemaNamespace + "simpleType")
                .Single(e => e.Attributes().Any(a => a.Name == "name" && a.Value == restrictionBaseTypeName));
            return restrictionBaseTypeElement;
        }

        private string GetRestrictionBaseTypeName(XElement element)
        {
            var restrictionElement = element.Elements().Single(e => e.Name == _xmlSchemaNamespace + "restriction");
            var restrictionBaseTypeName = restrictionElement.Attributes().FirstOrDefault(a => a.Name == "base")?.Value;
            return restrictionBaseTypeName;
        }
    }
}