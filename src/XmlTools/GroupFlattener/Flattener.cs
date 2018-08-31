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

        public Stream FlattenGroups(List<string> specificGroupTypes = null) // If given, only specific group types will be flattened
        {
            _sourceDocument = XDocument.Load(_xsdSchemaStream);
            if (_sourceDocument.Root?.Name != _xmlSchemaNamespace + "schema")
            {
                throw new ArgumentException("This is not a valid Xml schema, the root element is expected to be called \"schema\"");
            }

            FlattenGroupElements("group", specificGroupTypes);
            FlattenGroupElements("attributeGroup", specificGroupTypes);

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

        private void FlattenGroupElements(string elementName, List<string> specificGroupTypes)
        {
            if (specificGroupTypes == null)
            {
                _sourceDocument.Root.Descendants().FlattenGroupElements(elementName);
            }
            else
            {
                foreach (var groupType in specificGroupTypes)
                {
                    _sourceDocument.Root.Descendants().FlattenGroupElements(elementName, groupType);
                }
            }
        }
    }
}
