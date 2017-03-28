using System.Collections.Generic;

namespace XmlTools
{
    public class XmlSchema
    {
        public List<XmlElement> RootElements { get; set; }

        public IEnumerable<XmlType> GetAllDeclaredTypes()
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
    }
}