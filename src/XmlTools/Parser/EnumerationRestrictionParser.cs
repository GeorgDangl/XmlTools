using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XmlTools.Parser
{
    public class EnumerationRestrictionParser
    {
        public EnumerationRestrictionParser(XDocument document)
        {
            _document = document;
        }

        private readonly XDocument _document;
        private readonly XNamespace _xmlSchemaNamespace = "http://www.w3.org/2001/XMLSchema";

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
            var isSimpleContent = element.Elements().Any(e => e.Name == _xmlSchemaNamespace + "simpleContent");
            if (isSimpleContent)
            {
                var baseElementName = element.Elements()
                    .Single(e => e.Name == _xmlSchemaNamespace + "simpleContent")
                    .Elements()
                    .FirstOrDefault(e => e.Name == _xmlSchemaNamespace + "extension")?
                    .Attributes()
                    .Single(a => a.Name == "base")
                    .Value;
                if (baseElementName != null)
                {
                    var baseElementDefinition = _document.Descendants()
                        .FirstOrDefault(e => e.Name == _xmlSchemaNamespace + "simpleType" && e.Attributes().Any(a => a.Name == "name" && a.Value == baseElementName));
                    if (baseElementDefinition != null)
                    {
                        return IsEnumerationType(baseElementDefinition);
                    }
                }
            }
            return false;
        }

        public List<string> GetEnumerationValues(XElement element)
        {
            var restrictionElement = element.Elements().FirstOrDefault(e => e.Name == _xmlSchemaNamespace + "restriction");
            var enumerationValues = restrictionElement?.Elements()
                .Where(e => e.Name == _xmlSchemaNamespace + "enumeration")
                .Select(e => e.Attributes().Single(a => a.Name == "value").Value) ?? new List<string>();
            var baseTypeEnumerationValues = GetEnumerationValuesOfBaseTypes(element);
            var allEnumerationValues = enumerationValues.Concat(baseTypeEnumerationValues);
            var valuesWithoutDuplicates = RemoveDuplicateValues(allEnumerationValues);
            return valuesWithoutDuplicates;
        }

        private List<string> RemoveDuplicateValues(IEnumerable<string> values)
        {
            var newValues = new List<string>();
            foreach (var value in values)
            {
                if (!newValues.Contains(value))
                {
                    newValues.Add(value);
                }
            }
            return newValues;
        }

        private bool HasRestrictionBaseTypeAsEnumerationType(XElement element)
        {
            var baseTypeName = GetBaseElementName(element);
            if (string.IsNullOrWhiteSpace(baseTypeName))
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
            var baseElementName = GetBaseElementName(element);
            var baseTypeElementIsPresent = _document.Descendants().Where(e => e.Name == _xmlSchemaNamespace + "simpleType")
                .Any(e => e.Attributes().Any(a => a.Name == "name" && a.Value == baseElementName));
            return baseTypeElementIsPresent;
        }

        private XElement GetRestrictionBaseType(XElement element)
        {
            var baseElementName = GetBaseElementName(element);
            var baseTypeElement = _document.Descendants().Where(e => e.Name == _xmlSchemaNamespace + "simpleType")
                .Single(e => e.Attributes().Any(a => a.Name == "name" && a.Value == baseElementName));
            return baseTypeElement;
        }

        private string GetBaseElementName(XElement element)
        {
            var restrictionElement = element.Elements().FirstOrDefault(e => e.Name == _xmlSchemaNamespace + "restriction");
            if (restrictionElement != null)
            {
                var restrictionBaseTypeName = restrictionElement.Attributes().FirstOrDefault(a => a.Name == "base")?.Value;
                if (!string.IsNullOrWhiteSpace(restrictionBaseTypeName))
                {
                    return restrictionBaseTypeName;
                }
            }
            var simpleContentBaseTypeName = element.Elements()
                .FirstOrDefault(e => e.Name == _xmlSchemaNamespace + "simpleContent")
                ?
                .Elements()
                .FirstOrDefault(e => e.Name == _xmlSchemaNamespace + "extension")
                ?
                .Attributes()
                .FirstOrDefault(a => a.Name == "base")
                ?.Value;
            return simpleContentBaseTypeName;
        }
    }
}