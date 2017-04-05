namespace XmlTools.Tests.CodeGenerator.FileTests
{
    public class SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute_InvalidEnum : CodeGeneratorTestsBase
    {
        public SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute_InvalidEnum() : base(ParserTestFile.SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute,
            SchemaCorrectorTestFile.SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute_InvalidEnum,
            SchemaCorrectorTestFile.SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute_InvalidEnum_Expected)
        { }
    }
}