using System.Diagnostics.CodeAnalysis;

namespace XmlTools.Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum SchemaCorrectorTestFile
    {
        GAEB_XML_ChildElementCasing = 1,
        GAEB_XML_ChildElementCasing_Expected = 2,
        GAEB_XML_EnumElementCasing = 3,
        GAEB_XML_EnumElementCasing_Expected = 4,
        GAEB_XML_EnumElementInvalid = 5,
        GAEB_XML_EnumElementInvalid_Expected = 6,
        GAEB_XML_KeepContent = 7,
        GAEB_XML_RootElementCasing = 8,
        GAEB_XML_RootElementCasing_Expected = 9,
        SchemaWithEnumerationAttribute_EnumAttributeCasing = 10,
        SchemaWithEnumerationAttribute_EnumAttributeCasing_Expected = 11,
        SchemaWithEnumerationAttribute_EnumAttributeInvalidValue = 12,
        SchemaWithEnumerationAttribute_EnumAttributeInvalidValue_Expected = 13,
        SchemaWithEnumerationAttribute_InvalidAttribute = 14,
        SchemaWithEnumerationAttribute_InvalidAttribute_Expected = 15,
        GAEB_XML_MultipleIssues = 16,
        GAEB_XML_MultipleIssues_Expected = 17,
        SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute_InvalidEnum = 18,
        SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute_InvalidEnum_Expected = 19,
        SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute_EnumElementCasing = 20,
        SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute_EnumElementCasing_Expected = 21,
        SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_EnumCasing = 22,
        SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_EnumCasing_Expected = 23,
        SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_InvalidEnum = 24,
        SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_InvalidEnum_Expected = 25,
        SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_MultipleIssues = 26,
        SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute_MultipleIssues_Expected = 27
    }
}