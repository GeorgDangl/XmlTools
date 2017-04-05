namespace XmlTools.Tests.CodeGenerator.FileTests
{
    public class SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_InvalidEnum : CodeGeneratorTestsBase
    {
        public SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_InvalidEnum() : base(ParserTestFile.SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute,
            SchemaCorrectorTestFile.SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_InvalidEnum,
            SchemaCorrectorTestFile.SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_InvalidEnum_Expected)
        { }
    }
}