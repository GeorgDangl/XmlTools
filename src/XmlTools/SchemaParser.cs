﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace XmlTools
{
    public class SchemaParser
    {
        // TODO LOOK OUT FOR EXTENSIONS LIKE THIS: <xs:extension base="tgCashDiscDays"/>

        public SchemaParser(Stream xsdSchemaStream)
        {
            if (xsdSchemaStream == null)
            {
                throw new ArgumentNullException(nameof(xsdSchemaStream));
            }
            _xsdSchemaStream = xsdSchemaStream;
        }


        private readonly Stream _xsdSchemaStream;
        private readonly XNamespace _xmlSchemaNamespace = "http://www.w3.org/2001/XMLSchema";
        private XDocument _document;
        private XmlSchema _result;
        private XmlElementParser _xmlElementParser;

        public XmlSchema GetSchema()
        {
            if (_result != null)
            {
                return _result;
            }
            _document = XDocument.Load(_xsdSchemaStream);
            if (_document.Root.Name != _xmlSchemaNamespace + "schema")
            {
                throw new ArgumentException("This is not a valid Xml schema, the root element is expected to be called \"schema\"");
            }

            _xmlElementParser = new XmlElementParser(_document);

            var rootXElements = GetRootElements();
            if (!rootXElements.Any())
            {
                throw new InvalidDataException("There is no root element defined within the given schema");
            }

            var result = new XmlSchema
            {
                RootElements = new List<XmlElement>()
            };

            foreach (var rootXElement in rootXElements)
            {
                var parsedElement = _xmlElementParser.ParseElement(rootXElement);
                result.RootElements.Add(parsedElement);
            }

            return _result = result;
        }

        private List<XElement> GetRootElements()
        {
            var rootXElements = _document.Root.Elements()
                .Where(e => e.Name == _xmlSchemaNamespace + "element")
                .ToList();
            return rootXElements;
        }
    }
}
