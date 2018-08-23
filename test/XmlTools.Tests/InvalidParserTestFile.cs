namespace XmlTools.Tests
{
    /// <summary>
    /// These are not valid Xml schema files and should throw an exception during parsing
    /// </summary>
    public enum InvalidParserTestFile
    {
        SchemaWithComplexTypeWithSimpleContentButAlsoElementDefinition = 1,
        SchemaWithoutRootElement = 2
    }
}