using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XmlTools.Merger
{
    public class SimpleMerger
    {
        public SimpleMerger(Stream xsdSchemaStream,
            Func<string, Stream> referencedSchemaLoaderByIncludePath)
        {
            _xsdSchemaStream = xsdSchemaStream ?? throw new ArgumentNullException(nameof(xsdSchemaStream));
            _referencedSchemaLoaderByIncludePath = referencedSchemaLoaderByIncludePath;
        }

        private readonly Stream _xsdSchemaStream;
        private readonly XNamespace _xmlSchemaNamespace = "http://www.w3.org/2001/XMLSchema";
        private XDocument _sourceDocument;
        private readonly Func<string, Stream> _referencedSchemaLoaderByIncludePath;

        public Stream MergeSchemas()
        {
            _sourceDocument = XDocument.Load(_xsdSchemaStream);
            if (_sourceDocument.Root?.Name != _xmlSchemaNamespace + "schema")
            {
                throw new ArgumentException("This is not a valid Xml schema, the root element is expected to be called \"schema\"");
            }

            var includeElements = _sourceDocument.Root
                .Descendants()
                .Where(e => e.Name == _xmlSchemaNamespace + "include" && e.Attributes().Any(a => a.Name == "schemaLocation"))
                .ToList();

            foreach(var includeElement in includeElements)
            {
                InlineIncludeElement(includeElement);
                includeElement.Remove();
            }


            var memStream = new MemoryStream();
            _sourceDocument.Save(memStream);
            memStream.Position = 0;
            return memStream;
        }

        private readonly HashSet<string> _processedIncludes = new HashSet<string>();

        private void InlineIncludeElement(XElement includeElement)
        {
            var schemaLocation = includeElement.Attribute("schemaLocation").Value;
            if (_processedIncludes.Contains(schemaLocation))
            {
                return;
            }

            _processedIncludes.Add(schemaLocation);

            using (var includedStream = _referencedSchemaLoaderByIncludePath(schemaLocation))
            {
                var includedRoot = XDocument.Load(includedStream);
                if (includedRoot.Root?.Name != _xmlSchemaNamespace + "schema")
                {
                    throw new ArgumentException("This is not a valid Xml schema, the root element is expected to be called \"schema\"");
                }

                var childIncludeElements = includedRoot.Root
                    .Descendants()
                    .Where(e => e.Name == _xmlSchemaNamespace + "include" && e.Attributes().Any(a => a.Name == "schemaLocation"))
                    .ToList();

                foreach (var childIncludeElement in childIncludeElements)
                {
                    InlineIncludeElement(childIncludeElement);
                    childIncludeElement.Remove();
                }

                foreach (var element in includedRoot.Root.Elements())
                {
                    includeElement.AddAfterSelf(new XElement(element));
                }
            }
        }
    }
}
