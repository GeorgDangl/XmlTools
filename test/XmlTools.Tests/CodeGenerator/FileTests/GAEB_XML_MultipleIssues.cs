namespace XmlTools.Tests.CodeGenerator.FileTests
{
    public class GAEB_XML_MultipleIssues : CodeGeneratorTestsBase
    {
        public GAEB_XML_MultipleIssues() : base(ParserTestFile.GAEB_XML_3_1_Schema,
            SchemaCorrectorTestFile.GAEB_XML_MultipleIssues,
            SchemaCorrectorTestFile.GAEB_XML_MultipleIssues_Expected)
        { }
    }
}