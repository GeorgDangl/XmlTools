﻿namespace XmlTools.Tests.CodeGenerator
{
    public class SchemaWithComplexTypeWithSimpleContentWithEnumeration_EnumElementCasing : CodeGeneratorTestsBase
    {
        public SchemaWithComplexTypeWithSimpleContentWithEnumeration_EnumElementCasing() : base(ParserTestFile.SchemaWithComplexTypeWithSimpleContentWithEnumeration,
            SchemaCorrectorTestFile.SchemaWithComplexTypeWithSimpleContentWithEnumeration_EnumElementCasing,
            SchemaCorrectorTestFile.SchemaWithComplexTypeWithSimpleContentWithEnumeration_EnumElementCasing_Expected)
        { }
    }
}