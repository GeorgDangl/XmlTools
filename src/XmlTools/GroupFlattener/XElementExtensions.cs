using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XmlTools.GroupFlattener
{
    public static class XElementExtensions
    {
        private static readonly XNamespace _xmlSchemaNamespace = "http://www.w3.org/2001/XMLSchema";

        public static void FlattenGroupElements(this IEnumerable<XElement> elements, string elementName, string groupType = null)
        {
            var hasRefGroups = true;
            while (hasRefGroups)
            {
                var refGroups = elements
                    .Where(e => e.Name == _xmlSchemaNamespace + elementName
                                && e.Attributes().Any(a => a.Name.LocalName == "ref"
                                    && (string.IsNullOrWhiteSpace(groupType) || a.Value == groupType)))
                    .ToList();
                hasRefGroups = refGroups.Any();
                foreach (var refGroup in refGroups)
                {
                    foreach (var groupElement in refGroup.GetGroupContent())
                    {
                        refGroup.AddAfterSelf(groupElement);
                    }

                    refGroup.Remove();
                }
            }

            // Remove all groups
            var groups = elements
                .Where(e => e.Name == _xmlSchemaNamespace + elementName)
                .Where(g => g.Attributes().Any(a => a.Name.LocalName == "name"
                    && (string.IsNullOrWhiteSpace(groupType) || a.Value == groupType)))
                .ToList();
            foreach (var group in groups)
            {
                group.Remove();
            }
        }

        public static List<XElement> GetGroupContent(this XElement group)
        {
            var groupName = group.Attributes()
                .Single(a => a.Name.LocalName == "ref")
                .Value;
            var groupContent = group.Document.Root
                .Descendants()
                .Where(e => e.Name == group.Name)
                .Where(g => g.Attributes().Any(a => a.Name.LocalName == "name" && a.Value == groupName))
                .SelectMany(g => g.Elements().Select(e => new XElement(e)))
                .Where(e => e.Name != _xmlSchemaNamespace + "annotation")
                .ToList();

            var annotations = groupContent
                .Descendants()
                .Where(e => e.Name == _xmlSchemaNamespace + "annotation")
                .ToList();

            foreach (var annotationElement in annotations)
            {
                // Otherwise, they'll violate the Xsd schema if annotations
                // are mixed with content
                annotationElement.Remove();
            }

            return groupContent;
        }
    }
}
