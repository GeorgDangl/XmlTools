namespace XmlTools.Tests.CodeGenerator
{
    public class GAEB_XML_KeepContent : CodeGeneratorTestsBase
    {
        public GAEB_XML_KeepContent(): base(ParserTestFile.GAEB_XML_3_1_Schema,
            SchemaCorrectorTestFile.GAEB_XML_KeepContent,
            SchemaCorrectorTestFile.GAEB_XML_KeepContent) { }
    }
}