using System.Diagnostics.CodeAnalysis;

namespace XmlTools.Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum ParserTestFile
    {
        GAEB_XML_3_1_Schema = 1,
        GreenBuildingXML_Ver6_01 = 2,
        MinimumValidSchemaFile = 3,
        SchemaWithComplexType = 4,
        SchemaWithComplexTypeWithSimpleContent = 5,
        SchemaWithComplexTypeWithSimpleContentWithEnumerationAttribute = 6,
        SchemaWithComplexTypeWithSimpleContentWithEnumerationAttributeAsExtension = 7,
        SchemaWithEnumerationAttribute = 8,
        SchemaWithEnumerationType = 9,
        SchemaWithEnumerationTypeNestedInComplexType = 10,
        SchemaWithExtendedComplexType = 11,
        SchemaWithExtendedComplexTypeWithSimpleContent = 12,
        SchemaWithExtendedEnumerationType = 13,
        SchemaWithInlineComplexType = 14,
        SchemaWithInlineSimpleType = 15,
        SchemaWithRestrictionButNotEnumerationType = 16,
        SchemaWithTwoPossibleRootElements = 17,
        SchemaWithUnknownSimpleType = 18,
        SchemaWithComplexTypeWithSimpleContentAsEnumerationWithAttribute = 19,
        SchemaWithExtendedEnumerationTypeWithDuplicates = 20,
        SchemaWithPointInTypeName = 21
    }
}
