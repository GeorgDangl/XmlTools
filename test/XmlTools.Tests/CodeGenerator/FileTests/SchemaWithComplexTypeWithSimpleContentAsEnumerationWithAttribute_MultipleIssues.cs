namespace XmlTools.Tests.CodeGenerator.FileTests
{
    public class SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_MultipleIssues : CodeGeneratorTestsBase
    {
        public SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_MultipleIssues() : base(ParserTestFile.SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute,
            SchemaCorrectorTestFile.SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_MultipleIssues,
            SchemaCorrectorTestFile.SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_MultipleIssues_Expected)
        { }
    }
}