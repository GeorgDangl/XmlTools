namespace XmlTools.Tests.CodeGenerator
{
    public class GAEB_XML_RootElementCasing : CodeGeneratorTestsBase
    {
        public GAEB_XML_RootElementCasing(): base(ParserTestFile.GAEB_XML_3_1_Schema,
            SchemaCorrectorTestFile.GAEB_XML_RootElementCasing,
            SchemaCorrectorTestFile.GAEB_XML_RootElementCasing_Expected) { }
    }
}