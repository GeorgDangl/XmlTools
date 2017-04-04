namespace XmlTools.Tests.CodeGenerator.FileTests
{
    public class SchemaWithComplexTypeWithSimpleContentWithEnumeration_InvalidEnum : CodeGeneratorTestsBase
    {
        public SchemaWithComplexTypeWithSimpleContentWithEnumeration_InvalidEnum() : base(ParserTestFile.SchemaWithComplexTypeWithSimpleContentWithEnumeration,
            SchemaCorrectorTestFile.SchemaWithComplexTypeWithSimpleContentWithEnumeration_InvalidEnum,
            SchemaCorrectorTestFile.SchemaWithComplexTypeWithSimpleContentWithEnumeration_InvalidEnum_Expected)
        { }
    }
}