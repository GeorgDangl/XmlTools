namespace XmlTools.Tests.CodeGenerator
{
    public class GAEB_XML_EnumElementInvalid : CodeGeneratorTestsBase
    {
        public GAEB_XML_EnumElementInvalid(): base(ParserTestFile.GAEB_XML_3_1_Schema,
            SchemaCorrectorTestFile.GAEB_XML_EnumElementInvalid,
            SchemaCorrectorTestFile.GAEB_XML_EnumElementInvalid_Expected) { }
    }
}