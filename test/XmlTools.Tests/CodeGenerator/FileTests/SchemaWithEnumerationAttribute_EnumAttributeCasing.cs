namespace XmlTools.Tests.CodeGenerator.FileTests
{
    // TODO MAKE TESTS LIKE THIS WITH A SIMPLECONTENTCOMPLEXTYPE
    public class SchemaWithEnumerationAttribute_EnumAttributeCasing : CodeGeneratorTestsBase
    {
        public SchemaWithEnumerationAttribute_EnumAttributeCasing() : base(ParserTestFile.SchemaWithEnumerationAttribute,
            SchemaCorrectorTestFile.SchemaWithEnumerationAttribute_EnumAttributeCasing,
            SchemaCorrectorTestFile.SchemaWithEnumerationAttribute_EnumAttributeCasing_Expected)
        { }
    }
}