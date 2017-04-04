namespace XmlTools.Tests.CodeGenerator
{
    public class SchemaWithComplexTypeWithSimpleContentWithEnumeration_InvalidEnum : CodeGeneratorTestsBase
    {
        public SchemaWithComplexTypeWithSimpleContentWithEnumeration_InvalidEnum() : base(ParserTestFile.SchemaWithComplexTypeWithSimpleContentWithEnumeration,
            SchemaCorrectorTestFile.SchemaWithComplexTypeWithSimpleContentWithEnumeration_InvalidEnum,
            SchemaCorrectorTestFile.SchemaWithComplexTypeWithSimpleContentWithEnumeration_InvalidEnum_Expected)
        { }
    }
}