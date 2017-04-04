namespace XmlTools.Tests.CodeGenerator
{
    public class SchemaWithEnumerationAttribute_EnumAttributeInvalidValue : CodeGeneratorTestsBase
    {
        public SchemaWithEnumerationAttribute_EnumAttributeInvalidValue() : base(ParserTestFile.SchemaWithEnumerationAttribute,
            SchemaCorrectorTestFile.SchemaWithEnumerationAttribute_EnumAttributeInvalidValue,
            SchemaCorrectorTestFile.SchemaWithEnumerationAttribute_EnumAttributeInvalidValue_Expected)
        { }
    }
}