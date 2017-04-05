namespace XmlTools.Tests.CodeGenerator.FileTests
{
    public class SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute_EnumElementCasing : CodeGeneratorTestsBase
    {
        public SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute_EnumElementCasing() : base(ParserTestFile.SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute,
            SchemaCorrectorTestFile.SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute_EnumElementCasing,
            SchemaCorrectorTestFile.SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute_EnumElementCasing_Expected)
        { }
    }
}