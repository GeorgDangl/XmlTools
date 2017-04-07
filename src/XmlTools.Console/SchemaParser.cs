using System.IO;

namespace XmlTools.Console
{
    public class SchemaParser
    {
        public SchemaParser(Stream xmlSchemaStream)
        {
            _xmlSchemaStream = xmlSchemaStream;
        }

        private readonly Stream _xmlSchemaStream;

        public XmlSchema GetSchema()
        {
            var xmlSchemaParser = new Parser.XmlSchemaParser(_xmlSchemaStream);
            var schema = xmlSchemaParser.GetSchema();
            return schema;
        }
    }
}