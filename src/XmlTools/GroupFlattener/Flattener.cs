using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace XmlTools.GroupFlattener
{
    public class Flattener
    {
        public Flattener(Stream xsdSchemaStream)
        {
            _xsdSchemaStream = xsdSchemaStream ?? throw new ArgumentNullException(nameof(xsdSchemaStream));
        }

        private readonly Stream _xsdSchemaStream;
        private readonly XNamespace _xmlSchemaNamespace = "http://www.w3.org/2001/XMLSchema";
        private XDocument _sourceDocument;

        public Stream FlattenGroups()
        {
            _sourceDocument = XDocument.Load(_xsdSchemaStream);
            if (_sourceDocument.Root?.Name != _xmlSchemaNamespace + "schema")
            {
                throw new ArgumentException("This is not a valid Xml schema, the root element is expected to be called \"schema\"");
            }

            FlattenGroupElements("group");
            FlattenGroupElements("attributeGroup");

            var keyElements = _sourceDocument.Root.Descendants()
                .Where(e => e.Name == _xmlSchemaNamespace + "key" && e.Attributes().Any(a => a.Name.LocalName == "name"))
                .ToList();
            var keyIdentifier = 1;
            foreach (var keyElement in keyElements)
            {
                keyElement.Attribute("name").Value += keyIdentifier++;
            }

            var memStream = new MemoryStream();
            _sourceDocument.Save(memStream);
            memStream.Position = 0;
            return memStream;
        }

        private void FlattenGroupElements(string elementName)
        {
            var hasRefGroups = true;
            while (hasRefGroups)
            {
                var refGroups = _sourceDocument.Root
                    .Descendants()
                    .Where(e => e.Name == _xmlSchemaNamespace + elementName
                                && e.Attributes().Any(a => a.Name.LocalName == "ref"))
                    .ToList();
                hasRefGroups = refGroups.Any();
                foreach (var refGroup in refGroups)
                {
                    foreach (var groupElement in GetGroupContent(refGroup))
                    {
                        refGroup.AddAfterSelf(groupElement);
                    }

                    refGroup.Remove();
                }
            }

            // Remove all groups
            var groups = _sourceDocument.Root
                .Descendants()
                .Where(e => e.Name == _xmlSchemaNamespace + elementName)
                .Where(g => g.Attributes().Any(a => a.Name.LocalName == "name"))
                .ToList();
            foreach (var group in groups)
            {
                group.Remove();
            }
        }

        private List<XElement> GetGroupContent(XElement group)
        {
            var groupName = group.Attributes()
                .Single(a => a.Name.LocalName == "ref")
                .Value;
            var groupContent = _sourceDocument.Root
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
