namespace XmlTools.Tests.CodeGenerator.FileTests
{
    public class GAEB_XML_ChildElementCasing : CodeGeneratorTestsBase
    {
        public GAEB_XML_ChildElementCasing() : base(ParserTestFile.GAEB_XML_3_1_Schema,
            SchemaCorrectorTestFile.GAEB_XML_ChildElementCasing,
            SchemaCorrectorTestFile.GAEB_XML_ChildElementCasing_Expected)
        { }
    }
    public class GAEB_XML_SimpleTypesWithElements : CodeGeneratorTestsBase
    {
        public GAEB_XML_SimpleTypesWithElements() : base(ParserTestFile.GAEB_XML_3_1_Schema,
            SchemaCorrectorTestFile.GAEB_XML_SimpleTypesWithElements,
            SchemaCorrectorTestFile.GAEB_XML_SimpleTypesWithElements_Expected)
        { }
    }
}
