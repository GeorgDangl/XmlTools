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
        SchemaWithComplexTypeWithSimpleContentButAlsoElementDefinition = 6,
        SchemaWithComplexTypeWithSimpleContentWithEnumeration = 7,
        SchemaWithComplexTypeWithSimpleContentWithEnumerationAsExtension = 8,
        SchemaWithEnumerationAttribute = 9,
        SchemaWithEnumerationType = 10,
        SchemaWithEnumerationTypeNestedInComplexType = 11,
        SchemaWithExtendedComplexType = 12,
        SchemaWithExtendedComplexTypeWithSimpleContent = 13,
        SchemaWithExtendedEnumerationType = 14,
        SchemaWithInlineComplexType = 15,
        SchemaWithInlineSimpleType = 16,
        SchemaWithoutRootElement = 17,
        SchemaWithRestrictionButNotEnumerationType = 18,
        SchemaWithTwoPossibleRootElements = 19,
        SchemaWithUnknownSimpleType = 20,
    }
}