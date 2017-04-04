namespace XmlTools.Tests.CodeGenerator.FileTests
{
    public class GAEB_XML_EnumElementCasing : CodeGeneratorTestsBase
    {
        public GAEB_XML_EnumElementCasing(): base(ParserTestFile.GAEB_XML_3_1_Schema,
            SchemaCorrectorTestFile.GAEB_XML_EnumElementCasing,
            SchemaCorrectorTestFile.GAEB_XML_EnumElementCasing_Expected) { }
    }
}