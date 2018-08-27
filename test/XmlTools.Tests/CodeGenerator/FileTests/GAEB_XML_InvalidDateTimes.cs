namespace XmlTools.Tests.CodeGenerator.FileTests
{
    public class GAEB_XML_InvalidDateTimes : CodeGeneratorTestsBase
    {
        public GAEB_XML_InvalidDateTimes() : base(ParserTestFile.GAEB_XML_3_1_Schema,
            SchemaCorrectorTestFile.GAEB_XML_InvalidDateTimes,
            SchemaCorrectorTestFile.GAEB_XML_InvalidDateTimes_Expected)
        { }
    }
}