namespace XmlTools.Tests.CodeGenerator.FileTests
{
    public class SchemaWithEnumerationAttribute_EnumAttributeNameCasing : CodeGeneratorTestsBase
    {
        public SchemaWithEnumerationAttribute_EnumAttributeNameCasing() : base(ParserTestFile.SchemaWithEnumerationAttribute,
            SchemaCorrectorTestFile.SchemaWithEnumerationAttribute_EnumAttributeNameCasing,
            SchemaCorrectorTestFile.SchemaWithEnumerationAttribute_EnumAttributeNameCasing_Expected)
        {
        }
    }
}
