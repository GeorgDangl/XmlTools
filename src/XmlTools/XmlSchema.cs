using System.Collections.Generic;
using System.Linq;

namespace XmlTools
{
    public class XmlSchema
    {
        public List<XmlElement> RootElements { get; set; }

        public IEnumerable<XmlType> GetAllDeclaredElementTypes()
        {
            var foundTypes = new HashSet<XmlType>();
            foreach (var rootElement in RootElements)
            {
                foreach (var childType in GetAllDeclaredTypesOfElementAndChildren(rootElement, foundTypes))
                {
                    yield return childType;
                }
            }
        }

        private IEnumerable<XmlType> GetAllDeclaredTypesOfElementAndChildren(XmlElement element, HashSet<XmlType> foundTypes)
        {
            if (!foundTypes.Contains(element.Type))
            {
                foundTypes.Add(element.Type);
                yield return element.Type;
                var elementComplexType = element.Type as XmlComplexType;
                if (elementComplexType != null)
                {
                    foreach (var childElement in elementComplexType.PossibleChildElements)
                    {
                        var childElementTypes = GetAllDeclaredTypesOfElementAndChildren(childElement, foundTypes);
                        foreach (var childElementType in childElementTypes)
                        {
                            yield return childElementType;
                        }
                    }
                }
            }
        }

        public IEnumerable<XmlType> GetAllDeclaredAttributeTypes()
        {
            var foundAttributeTypes = new HashSet<XmlType>();
            foreach (var schemaType in GetAllDeclaredElementTypes())
            {
                foreach (var attributeType in GetAllDeclaredAttributeTypesOfXmlType(schemaType, foundAttributeTypes))
                {
                    yield return attributeType;
                }
            }
        }

        private IEnumerable<XmlType> GetAllDeclaredAttributeTypesOfXmlType(XmlType xmlType, HashSet<XmlType> foundAttributeTypes)
        {
            var typeWithAttributes = xmlType as XmlTypeWithAttributes;
            if (typeWithAttributes != null)
            {
                foreach (var attributeType in typeWithAttributes.Attributes.Select(a => a.Type))
                {
                    if (!foundAttributeTypes.Contains(attributeType))
                    {
                        foundAttributeTypes.Add(attributeType);
                        yield return attributeType;
                    }
                }
            }
        }
    }
}