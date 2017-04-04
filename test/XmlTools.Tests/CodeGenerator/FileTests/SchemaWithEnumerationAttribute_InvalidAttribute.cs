namespace XmlTools.Tests.CodeGenerator.FileTests
{
    public class SchemaWithEnumerationAttribute_InvalidAttribute : CodeGeneratorTestsBase
    {
        public SchemaWithEnumerationAttribute_InvalidAttribute() : base(ParserTestFile.SchemaWithEnumerationAttribute,
            SchemaCorrectorTestFile.SchemaWithEnumerationAttribute_InvalidAttribute,
            SchemaCorrectorTestFile.SchemaWithEnumerationAttribute_InvalidAttribute_Expected)
        { }
    }
}