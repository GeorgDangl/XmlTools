using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XmlTools.Parser
{
    public class XmlAttributesParser
    {
        public XmlAttributesParser(XDocument document, XmlElementParser xmlElementParser)
        {
            _document = document;
            _xmlElementParser = xmlElementParser;
        }

        private XDocument _document;
        private XmlElementParser _xmlElementParser;
        private readonly XNamespace _xmlSchemaNamespace = "http://www.w3.org/2001/XMLSchema";

        public List<XmlAttribute> GetAttributesForTypeDefinition(XElement element)
        {
            var attributes = new List<XmlAttribute>();
            foreach (var attributeElement in GetAttributeDefinitionsForElement(element))
            {
                var attributeHasReferenceButNoName = attributeElement.Attributes().Any(a => a.Name == "ref") && attributeElement.Attributes().All(a => a.Name != "name");
                if (attributeHasReferenceButNoName)
                {
                    var referencedAttribute = GetAttributeForReferencedAttribute(attributeElement);
                    attributes.Add(referencedAttribute);
                }
                else
                {
                    var namedAttribute = GetAttributeForAttributeWithName(attributeElement);
                    attributes.Add(namedAttribute);
                }
            }
            return attributes;
        }

        private XmlAttribute GetAttributeForReferencedAttribute(XElement element)
        {
            var attributeReference = element.Attributes().Single(a => a.Name == "ref").Value;
            var localAttribute = _document.Root.Elements().FirstOrDefault(e => e.Name == _xmlSchemaNamespace + "attribute" && e.Attributes().Any(a => a.Name == "name" && a.Value == attributeReference));
            if (localAttribute == null)
            {
                return new XmlAttribute
                {
                    Name = attributeReference,
                    Type = new XmlUnknownSimpleType
                    {
                        Name = attributeReference
                    }
                };
            }
            return GetAttributeForAttributeWithName(localAttribute);
        }

        private XmlAttribute GetAttributeForAttributeWithName(XElement element)
        {
            var attributeName = element.Attributes().Single(a => a.Name == "name").Value;
            var attributeType = new XmlSimpleTypeParser(_document, _xmlElementParser).ParseElement(element) as XmlSimpleType;
            return new XmlAttribute
            {
                Name = attributeName,
                Type = attributeType
            };
        }

        private List<XElement> GetAttributeDefinitionsForElement(XElement element)
        {
            var directAttributes = GetDirectDefinedAttributes(element);
            var baseTypeAttributes = GetAttributesOfReferenceTypes(element);
            //var contentAttributes = GetContentAttributes(element);
            return directAttributes.Concat(baseTypeAttributes).ToList();
        }

        private List<XElement> GetDirectDefinedAttributes(XElement element)
        {
            var directAttributes = element.Elements().Where(e => e.Name == _xmlSchemaNamespace + "attribute");
            var contentAttributes = GetAttributesFromSimpleOrComplexContent(element);
            return directAttributes.Concat(contentAttributes).ToList();
        }

        private List<XElement> GetAttributesFromSimpleOrComplexContent(XElement element)
        {
            var contentElements = GetSimpleOrComplexContentElements(element);
            var directAttributes = contentElements.Elements()
                .Where(e => e.Name == _xmlSchemaNamespace + "attribute");
            var extensionSubAttributes = contentElements.Elements()
                .Where(e => e.Name == _xmlSchemaNamespace + "extension")
                .SelectMany(e => e.Elements().Where(c => c.Name == _xmlSchemaNamespace + "attribute"));
            return directAttributes.Concat(extensionSubAttributes).ToList();
        }

        //private List<XElement> GetContentAttributes(XElement element)
        //{
        //    var contentElements = GetSimpleOrComplexContentElements(element);
        //    var result = new List<XElement>();
        //    foreach (var contentElement in contentElements)
        //    {
        //        var contentAttributeElements = Getatt
        //    }

        //    return result;
        //}

        private List<XElement> GetSimpleOrComplexContentElements(XElement element)
        {
            var contentAttributes = element.Elements().Where(e => e.Name == _xmlSchemaNamespace + "simpleContent" || e.Name == _xmlSchemaNamespace + "complexContent");
            return contentAttributes.ToList();
        }

        private List<XElement> GetAttributesOfReferenceTypes(XElement element)
        {
            var contentElements = GetSimpleOrComplexContentElements(element);
            var extensionElements = contentElements.Elements().Where(e => e.Name == _xmlSchemaNamespace + "extension");
            return extensionElements.SelectMany(GetAttributeDefinitionsOfBaseType).ToList();
        }

        private List<XElement> GetAttributeDefinitionsOfBaseType(XElement element)
        {
            var baseTypeName = element.Attributes().First(a => a.Name == "base").Value;
            var baseElement = _document.Descendants().FirstOrDefault(e => e.Name == _xmlSchemaNamespace + "complexType" && e.Attributes().Any(a => a.Name == "name" && a.Value == baseTypeName));
            if (baseElement == null)
            {
                return new List<XElement>();
            }
            var baseElementAttributeElements = GetAttributeDefinitionsForElement(baseElement);
            return baseElementAttributeElements;
        }
    }
}