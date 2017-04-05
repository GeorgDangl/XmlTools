namespace XmlTools.Tests.CodeGenerator.FileTests
{
    public class SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_EnumCasing : CodeGeneratorTestsBase
    {
        public SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_EnumCasing() : base(ParserTestFile.SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute,
            SchemaCorrectorTestFile.SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_EnumCasing,
            SchemaCorrectorTestFile.SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_EnumCasing_Expected)
        { }
    }
}