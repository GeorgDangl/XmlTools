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
        SchemaWithComplexTypeWithSimpleContentWithEnumeration_InvalidEnum = 18,
        SchemaWithComplexTypeWithSimpleContentWithEnumeration_InvalidEnum_Expected = 19,
        SchemaWithComplexTypeWithSimpleContentWithEnumeration_EnumElementCasing = 20,
        SchemaWithComplexTypeWithSimpleContentWithEnumeration_EnumElementCasing_Expected = 21
    }
}