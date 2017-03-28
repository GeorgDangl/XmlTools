using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace XmlTools.Tests
{
    public class SchemaParserTests
    {
        [Fact]
        public void ArgumentNullExceptionOnNullInput()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new SchemaParser(null));
        }

        [Fact]
        public void InvalidDataExceptionWhenNoRootElementDefinedInSchema()
        {
            using (var stream = TestFilesFactory.GetStreamOfFileWithoutRootElement())
            {
                Assert.Throws(typeof(InvalidDataException), () =>
                {
                    var schemaParser = new SchemaParser(stream);
                    var parsedSchema = schemaParser.GetSchema();
                });
            }
        }

        public abstract class TestFileBase : IDisposable
        {
            protected readonly Stream _xsdStream;
            private XmlSchema _parsedSchema;

            protected XmlSchema ParsedSchema
            {
                get
                {
                    return _parsedSchema ?? (_parsedSchema = ParseSchema());
                }
            }

            public TestFileBase(Stream xsdStream)
            {
                _xsdStream = xsdStream;
            }

            public void Dispose()
            {
                _xsdStream.Dispose();
            }

            private XmlSchema ParseSchema()
            {
                var schemaParser = new SchemaParser(_xsdStream);
                var parsedFile = schemaParser.GetSchema();
                return parsedFile;
            }

            [Fact]
            public void CanParseFile()
            {
                var schemaParser = new SchemaParser(_xsdStream);
                var parsedFile = schemaParser.GetSchema();
                Assert.NotNull(parsedFile);
            }

            [Fact]
            public void AllUsedTypesHaveUniqueName()
            {
                var allUsedTypes = GetAllTypesUsedInSchema();
                foreach (var usedType in allUsedTypes)
                {
                    var typesWithThisName = allUsedTypes.Count(t => t.Name == usedType.Name);
                    Assert.Equal(1, typesWithThisName);
                }
            }

            protected List<XmlType> GetAllTypesUsedInSchema()
            {
                return ParsedSchema.GetAllDeclaredTypes().ToList();
            }
        }

        public class GetStreamOfMinimumValidSchemaFile : TestFileBase
        {
            public GetStreamOfMinimumValidSchemaFile() : base(TestFilesFactory.GetStreamOfMinimumValidSchemaFile()) { }

            [Fact]
            public void HasOnlySingleRootElement()
            {
                Assert.Equal(1, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void RootElementName()
            {
                var expectedElementName = "Order";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedElementName, rootElement.Name);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var expectedTypeName = "FoodOrder";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedTypeName, rootElement.Type.Name);
            }

            [Fact]
            public void RootElementTypeType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.IsType(typeof(XmlComplexType), rootElementType);
            }

            [Fact]
            public void NoPropertiesOnRootElementType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                Assert.False(rootElementType.PossibleChildElements.Any());
            }

            [Fact]
            public void NoAttributesOnRootElementType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                Assert.False(rootElementType.Attributes.Any());
            }
        }

        public class GetStreamOfSchemaWithEnumerationType : TestFileBase
        {
            public GetStreamOfSchemaWithEnumerationType() : base(TestFilesFactory.GetStreamOfSchemaWithEnumerationType()) { }

            [Fact]
            public void HasOnlySingleRootElement()
            {
                Assert.Equal(1, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void RootElementName()
            {
                var expectedElementName = "WeatherForecast";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedElementName, rootElement.Name);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var expectedTypeName = "WeatherPrediction";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedTypeName, rootElement.Type.Name);
            }

            [Fact]
            public void RootElementTypeType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.IsType(typeof(XmlEnumerationType), rootElementType);
            }

            [Fact]
            public void RootElementTypeEnumerationTypeHasCorrectRestrictions()
            {
                var expectedValues = new[] { "Rainy", "Cloudy", "Sunny", "Misty", "Probability of raining meatballs" };
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlEnumerationType;
                Assert.Equal(expectedValues.Length, rootElementType.EnumerationValues.Count);
                var allElementsPresent = expectedValues.All(v => rootElementType.EnumerationValues.Contains(v));
                Assert.True(allElementsPresent);
            }
        }

        public class GetStreamOfSchemaWithComplexType : TestFileBase
        {
            public GetStreamOfSchemaWithComplexType() : base(TestFilesFactory.GetStreamOfSchemaWithComplexType()) { }

            [Fact]
            public void HasOnlySingleRootElement()
            {
                Assert.Equal(1, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void RootElementName()
            {
                var expectedElementName = "Issue";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedElementName, rootElement.Name);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var expectedTypeName = "BugReport";
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.Equal(expectedTypeName, rootElementType.Name);
            }

            [Fact]
            public void RootElementTypeType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.IsType(typeof(XmlComplexType), rootElementType);
            }

            [Fact]
            public void RootElementTypeAttributesCount()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                Assert.Equal(1, rootElementType.Attributes.Count);
            }

            [Fact]
            public void RootElementTypeAttributeName()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var attribute = rootElementType.Attributes.First();
                Assert.Equal("IsResolved", attribute.Name);
            }

            [Fact]
            public void RootElementTypeAttributeTypeName()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var attributeType = rootElementType.Attributes.First().Type;
                Assert.Equal("xs:boolean", attributeType.Name);
            }

            [Fact]
            public void RootElementTypeAttributeTypeType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var attributeType = rootElementType.Attributes.First().Type;
                Assert.IsType(typeof(XmlUnknownSimpleType), attributeType);
            }

            [Fact]
            public void RootElementTypeChildCount()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                Assert.Equal(4, rootElementType.PossibleChildElements.Count);
            }

            [Fact]
            public void RootElementTypeChildNames()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var expectedTypeNames = new[] {"Message", "IntroducedInCommit", "Priority", "PersonToBlame"};
                var allChildTypeNamesPresent = expectedTypeNames.All(e => rootElementType.PossibleChildElements.Any(c => c.Name == e));
                Assert.True(allChildTypeNamesPresent);
            }

            [Fact]
            public void RootElementTypeChildTypesNames()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var messageType = rootElementType.PossibleChildElements.First(c => c.Name == "Message").Type;
                var introducedInCommitType = rootElementType.PossibleChildElements.First(c => c.Name == "IntroducedInCommit").Type;
                var priorityType = rootElementType.PossibleChildElements.First(c => c.Name == "Priority").Type;
                var personToBlameType = rootElementType.PossibleChildElements.First(c => c.Name == "PersonToBlame").Type;
                Assert.Equal("xs:string", messageType.Name);
                Assert.Equal("xs:string", introducedInCommitType.Name);
                Assert.Equal("xs:string", priorityType.Name);
                Assert.StartsWith("InlineComplexType_", personToBlameType.Name);
            }

            [Fact]
            public void RootElementTypeChildTypesTypes()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var messageType = rootElementType.PossibleChildElements.First(c => c.Name == "Message").Type;
                var introducedInCommitType = rootElementType.PossibleChildElements.First(c => c.Name == "IntroducedInCommit").Type;
                var priorityType = rootElementType.PossibleChildElements.First(c => c.Name == "Priority").Type;
                var personToBlameType = rootElementType.PossibleChildElements.First(c => c.Name == "PersonToBlame").Type;
                Assert.IsType(typeof(XmlUnknownType), messageType);
                Assert.IsType(typeof(XmlUnknownType), introducedInCommitType);
                Assert.IsType(typeof(XmlUnknownType), priorityType);
                Assert.IsType(typeof(XmlComplexType), personToBlameType);
            }

            [Fact]
            public void RootElementTypeChildTypesNestedTypeAttributesCount()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var personToBlameType = rootElementType.PossibleChildElements.First(c => c.Name == "PersonToBlame").Type as XmlComplexType;
                Assert.Equal(0, personToBlameType.Attributes.Count);
            }

            [Fact]
            public void RootElementTypeChildTypesNestedTypeChildCount()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var personToBlameType = rootElementType.PossibleChildElements.First(c => c.Name == "PersonToBlame").Type as XmlComplexType;
                Assert.Equal(2, personToBlameType.PossibleChildElements.Count);
            }

            [Fact]
            public void RootElementTypeChildTypesNestedTypeChildNames()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var personToBlameType = rootElementType.PossibleChildElements.First(c => c.Name == "PersonToBlame").Type as XmlComplexType;
                Assert.True(personToBlameType.PossibleChildElements.Any(e => e.Name == "Email"));
                Assert.True(personToBlameType.PossibleChildElements.Any(e => e.Name == "Name"));
            }

            [Fact]
            public void RootElementTypeChildTypesNestedTypeChildTypeNames()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var personToBlameType = rootElementType.PossibleChildElements.First(c => c.Name == "PersonToBlame").Type as XmlComplexType;
                Assert.True(personToBlameType.PossibleChildElements.All(e => e.Type.Name == "xs:string"));
            }

            [Fact]
            public void RootElementTypeChildTypesNestedTypeChildTypeTypes()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var personToBlameType = rootElementType.PossibleChildElements.First(c => c.Name == "PersonToBlame").Type as XmlComplexType;
                var emailType = personToBlameType.PossibleChildElements.First(c => c.Name == "Email").Type;
                Assert.IsType(typeof(XmlUnknownType), emailType);
                var nameType = personToBlameType.PossibleChildElements.First(c => c.Name == "Name").Type;
                Assert.IsType(typeof(XmlUnknownType), nameType);
            }
        }

        public class GetStreamOfSchemaWithEnumerationAttribute : TestFileBase
        {
            public GetStreamOfSchemaWithEnumerationAttribute() : base(TestFilesFactory.GetStreamOfSchemaWithEnumerationAttribute()) { }

            [Fact]
            public void HasOnlySingleRootElement()
            {
                Assert.Equal(1, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void RootElementName()
            {
                var expectedElementName = "Author";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedElementName, rootElement.Name);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var expectedTypeName = "Person";
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.Equal(expectedTypeName, rootElementType.Name);
            }

            [Fact]
            public void RootElementTypeType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.IsType(typeof(XmlComplexType), rootElementType);
            }

            [Fact]
            public void RootElementTypeAttributesCount()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                Assert.Equal(1, rootElementType.Attributes.Count);
            }

            [Fact]
            public void RootElementTypeAttributeName()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var attribute = rootElementType.Attributes.First();
                Assert.Equal("Gender", attribute.Name);
            }

            [Fact]
            public void RootElementTypeAttributeTypeName()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var attributeType = rootElementType.Attributes.First().Type;
                Assert.StartsWith("InlineSimpleType_", attributeType.Name);
            }

            [Fact]
            public void RootElementTypeAttributeTypeType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var attributeType = rootElementType.Attributes.First().Type;
                Assert.IsType(typeof(XmlEnumerationType), attributeType);
            }

            [Fact]
            public void RootElementTypeAttributeTypeEnumerationValues()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var attributeType = rootElementType.Attributes.First().Type as XmlEnumerationType;
                var expectedValues = new[] {"Female", "Male"};
                Assert.Equal(expectedValues.Length, attributeType.EnumerationValues.Count);
                var allExpectedValuesPresent = expectedValues.All(v => attributeType.EnumerationValues.Any(e => e == v));
                Assert.True(allExpectedValuesPresent);
            }

            [Fact]
            public void RootElementTypeChildCount()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                Assert.Equal(2, rootElementType.PossibleChildElements.Count);
            }

            [Fact]
            public void RootElementTypeChildNames()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var emailChildElement = rootElementType.PossibleChildElements[0];
                var nameChildElement = rootElementType.PossibleChildElements[1];
                Assert.Equal("Email", emailChildElement.Name);
                Assert.Equal("Name", nameChildElement.Name);
            }

            [Fact]
            public void RootElementTypeChildTypesNames()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var emailChildElementType = rootElementType.PossibleChildElements.First(c => c.Name == "Email").Type;
                var nameChildElementType = rootElementType.PossibleChildElements.First(c => c.Name == "Name").Type;
                Assert.Equal("xs:string", emailChildElementType.Name);
                Assert.Equal("xs:string", nameChildElementType.Name);
            }

            [Fact]
            public void RootElementTypeChildTypesTypes()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var emailChildElementType = rootElementType.PossibleChildElements.First(c => c.Name == "Email").Type;
                var nameChildElementType = rootElementType.PossibleChildElements.First(c => c.Name == "Name").Type;
                Assert.IsType(typeof(XmlUnknownType), emailChildElementType);
                Assert.IsType(typeof(XmlUnknownType), nameChildElementType);
            }
        }

        public class GetStreamOfSchemaWithRestrictionButNotEnumerationType : TestFileBase
        {
            public GetStreamOfSchemaWithRestrictionButNotEnumerationType() : base(TestFilesFactory.GetStreamOfSchemaWithRestrictionButNotEnumerationType()) { }

            [Fact]
            public void HasOnlySingleRootElement()
            {
                Assert.Equal(1, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void RootElementName()
            {
                var expectedElementName = "OperatingTemperature";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedElementName, rootElement.Name);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var expectedTypeName = "OperatingTemperatureRange";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedTypeName, rootElement.Type.Name);
            }

            [Fact]
            public void RootElementTypeType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.IsType(typeof(XmlSimpleType), rootElementType);
            }

            [Fact]
            public void RootElementTypeIsNotEnumerationType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.IsNotType(typeof(XmlEnumerationType), rootElementType);
            }
        }

        public class GetStreamOfSchemaWithExtendedEnumerationType : TestFileBase
        {
            public GetStreamOfSchemaWithExtendedEnumerationType() : base(TestFilesFactory.GetStreamOfSchemaWithExtendedEnumerationType()) { }

            [Fact]
            public void HasOnlySingleRootElement()
            {
                Assert.Equal(1, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void HasOnlySingleType()
            {
                // There are two types in the schema, but one only extends the other so it should
                // only recognize the actually used type
                var countOfUsedTypes = GetAllTypesUsedInSchema().Count;
                Assert.Equal(1, countOfUsedTypes);
            }

            [Fact]
            public void RootElementName()
            {
                var expectedElementName = "WeatherForecast";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedElementName, rootElement.Name);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var expectedTypeName = "WeatherPrediction";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedTypeName, rootElement.Type.Name);
            }

            [Fact]
            public void RootElementTypeType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.IsType(typeof(XmlEnumerationType), rootElementType);
            }

            [Fact]
            public void RootElementTypeEnumerationTypeHasCorrectRestrictions()
            {
                // There should also be the enumeration values that are included in the referenced type
                var expectedValues = new[] { "Rainy", "Cloudy", "Sunny", "Misty", "Probability of raining meatballs", "Raining cats and dogs" };
                var rootElement = ParsedSchema.RootElements.First().Type as XmlEnumerationType;
                Assert.Equal(expectedValues.Length, rootElement.EnumerationValues.Count);
                var allElementsPresent = expectedValues.All(v => rootElement.EnumerationValues.Contains(v));
                Assert.True(allElementsPresent);
            }
        }

        public class GetStreamOfSchemaWithExtendedComplexType : TestFileBase
        {
            public GetStreamOfSchemaWithExtendedComplexType() : base(TestFilesFactory.GetStreamOfSchemaWithExtendedComplexType()) { }

            [Fact]
            public void HasOnlySingleRootElement()
            {
                Assert.Equal(1, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void HasOnlySingleType()
            {
                // There are three types in the schema, but one only extends the other so it should
                // only recognize the actually used types
                // Unknown types with the same name should be reference equal wherever used
                var wow = GetAllTypesUsedInSchema();
                var countOfUsedTypes = GetAllTypesUsedInSchema().Count;
                Assert.Equal(2, countOfUsedTypes);
            }

            [Fact]
            public void RootElementName()
            {
                var expectedElementName = "Issue";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedElementName, rootElement.Name);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var expectedTypeName = "BugReport";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedTypeName, rootElement.Type.Name);
            }

            [Fact]
            public void RootElementTypeIsComplexType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.IsType(typeof(XmlComplexType), rootElementType);
            }

            [Fact]
            public void RootElementTypePropertyCount()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                Assert.Equal(2, rootElementType.PossibleChildElements.Count);
            }

            [Fact]
            public void RootElementTypeAttributesCount()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                Assert.Equal(2, rootElementType.Attributes.Count);
            }

            [Fact]
            public void RootElementTypeAttributeName1()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var expectedName = "IsResolved";
                Assert.Equal(expectedName, rootElementType.Attributes[1].Name);
            }

            [Fact]
            public void RootElementTypeAttributeName2()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var expectedName = "IsCritical";
                Assert.Equal(expectedName, rootElementType.Attributes[0].Name);
            }

            [Fact]
            public void RootElementTypeAttributeTypeName1()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var attributeType = rootElementType.Attributes[0].Type;
                var expectedName = "xs:boolean";
                Assert.Equal(expectedName, attributeType.Name);
            }

            [Fact]
            public void RootElementTypeAttributeTypeName2()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var attributeType = rootElementType.Attributes[1].Type;
                var expectedName = "xs:boolean";
                Assert.Equal(expectedName, attributeType.Name);
            }

            [Fact]
            public void RootElementTypeAttributeTypeType1()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var attributeType = rootElementType.Attributes[1].Type;
                Assert.IsType(typeof(XmlUnknownSimpleType), attributeType);
                Assert.IsNotType(typeof(XmlEnumerationType), attributeType);
            }

            [Fact]
            public void RootElementTypeAttributeTypeType2()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var attributeType = rootElementType.Attributes[0].Type;
                Assert.IsType(typeof(XmlUnknownSimpleType), attributeType);
                Assert.IsNotType(typeof(XmlEnumerationType), attributeType);
            }

            [Fact]
            public void RootElementTypeHasSelfDeclaredChild()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var selfDeclaredChild = rootElementType.PossibleChildElements.FirstOrDefault(c => c.Name == "IntroducedInCommit");
                Assert.NotNull(selfDeclaredChild);
                Assert.IsType(typeof(XmlUnknownType), selfDeclaredChild.Type);
                Assert.Equal("xs:string", selfDeclaredChild.Type.Name);
            }

            [Fact]
            public void RootElementTypeHasChildDeclaredInBase()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                var referenceDeclaredChild = rootElementType.PossibleChildElements.FirstOrDefault(c => c.Name == "Message");
                Assert.NotNull(referenceDeclaredChild);
                Assert.IsType(typeof(XmlUnknownType), referenceDeclaredChild.Type);
                Assert.Equal("xs:string", referenceDeclaredChild.Type.Name);
            }
        }

        public class GetStreamOfSchemaWithComplexTypeWithSimpleContent : TestFileBase
        {
            public GetStreamOfSchemaWithComplexTypeWithSimpleContent() : base(TestFilesFactory.GetStreamOfSchemaWithComplexTypeWithSimpleContent()) { }

            [Fact]
            public void HasOnlySingleRootElement()
            {
                Assert.Equal(1, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void HasOnlySingleType()
            {
                // There are two types in the schema, but one only extends the other so it should
                // only recognize the actually used types
                var countOfUsedTypes = GetAllTypesUsedInSchema().Count;
                Assert.Equal(1, countOfUsedTypes);
            }

            [Fact]
            public void RootElementName()
            {
                var expectedElementName = "Temperature";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedElementName, rootElement.Name);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var expectedTypeNameStart = "InlineSimpleContentComplexType_";
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.StartsWith(expectedTypeNameStart, rootElementType.Name);
            }

            [Fact]
            public void RootElementTypeType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.IsType(typeof(XmlSimpleContentComplexType), rootElementType);
            }

            [Fact]
            public void RootElementTypeAttributesCount()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                Assert.Equal(1, rootElementType.Attributes.Count);
            }

            [Fact]
            public void RootElementTypeAttributeName()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attribute = rootElementType.Attributes.First();
                Assert.Equal("IsFahrenheit", attribute.Name);
            }

            [Fact]
            public void RootElementTypeAttributeTypeName()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attributeType = rootElementType.Attributes.First().Type;
                Assert.Equal("xs:boolean", attributeType.Name);
            }

            [Fact]
            public void RootElementTypeAttributeTypeType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attributeType = rootElementType.Attributes.First().Type;
                Assert.IsType(typeof(XmlUnknownSimpleType), attributeType);
            }
        }

        public class GetStreamOfSchemaWithComplexTypeWithSimpleContentButAlsoElementDefinition
        {
            [Fact]
            public void ThrowsExceptionDueToInvalidSchema()
            {
                // A simpleContent element may not have elements defined within itself
                var xsdStream = TestFilesFactory.GetStreamOfSchemaWithComplexTypeWithSimpleContentButAlsoElementDefinition();
                var schemaParser = new SchemaParser(xsdStream);
                Assert.Throws(typeof(InvalidDataException), () =>
                {
                    var parsedFile = schemaParser.GetSchema();
                });
            }
        }

        public class GetStreamOfSchemaWithExtendedComplexTypeWithSimpleContent : TestFileBase
        {
            public GetStreamOfSchemaWithExtendedComplexTypeWithSimpleContent() : base(TestFilesFactory.GetStreamOfSchemaWithExtendedComplexTypeWithSimpleContent()) { }

            [Fact]
            public void HasOnlySingleRootElement()
            {
                Assert.Equal(1, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void HasOnlySingleType()
            {
                var countOfUsedTypes = GetAllTypesUsedInSchema().Count;
                Assert.Equal(1, countOfUsedTypes);
            }

            [Fact]
            public void RootElementName()
            {
                var expectedElementName = "Commit";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedElementName, rootElement.Name);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var expectedTypeName = "CommitHash";
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.Equal(expectedTypeName, rootElementType.Name);
            }

            [Fact]
            public void RootElementTypeType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.IsType(typeof(XmlSimpleContentComplexType), rootElementType);
            }

            [Fact]
            public void RootElementAttributesCount()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                Assert.Equal(2, rootElementType.Attributes.Count);
            }

            [Fact]
            public void RootElementAttributeName1()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attribute = rootElementType.Attributes[1];
                Assert.Equal("Algorithm", attribute.Name);
            }

            [Fact]
            public void RootElementAttributeName2()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attribute = rootElementType.Attributes[0];
                Assert.Equal("AuthorEmail", attribute.Name);
            }

            [Fact]
            public void RootElementAttributeTypeName1()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attributeType = rootElementType.Attributes[1].Type;
                Assert.Equal("xs:string", attributeType.Name);
            }

            [Fact]
            public void RootElementAttributeTypeName2()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attributeType = rootElementType.Attributes[0].Type;
                Assert.Equal("xs:string", attributeType.Name);
            }

            [Fact]
            public void RootElementAttributeTypeType1()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attributeType = rootElementType.Attributes[1].Type;
                Assert.IsType(typeof(XmlUnknownSimpleType), attributeType);
            }

            [Fact]
            public void RootElementAttributeTypeType2()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attributeType = rootElementType.Attributes[0].Type;
                Assert.IsType(typeof(XmlUnknownSimpleType), attributeType);
            }
        }

        public class GetStreamOfSchemaWithComplexTypeWithSimpleContentWithEnumeration : TestFileBase
        {
            public GetStreamOfSchemaWithComplexTypeWithSimpleContentWithEnumeration() : base(TestFilesFactory.GetStreamOfSchemaWithComplexTypeWithSimpleContentWithEnumeration())
            {
            }

            [Fact]
            public void HasOnlySingleRootElement()
            {
                Assert.Equal(1, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void RootElementName()
            {
                var expectedElementName = "Commit";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedElementName, rootElement.Name);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var expectedTypeNameStart = "InlineSimpleContentComplexType_";
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.StartsWith(expectedTypeNameStart, rootElementType.Name);
            }

            [Fact]
            public void RootElementTypeType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.IsType(typeof(XmlSimpleContentComplexType), rootElementType);
            }

            [Fact]
            public void RootElementTypeAttributesCount()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                Assert.Equal(2, rootElementType.Attributes.Count);
            }

            [Fact]
            public void RootElementTypeAttributeName1()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attribute = rootElementType.Attributes[0];
                Assert.Equal("AuthorEmail", attribute.Name);
            }

            [Fact]
            public void RootElementTypeAttributeName2()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attribute = rootElementType.Attributes[1];
                Assert.Equal("Algorithm", attribute.Name);
            }

            [Fact]
            public void RootElementTypeAttributeTypeName1()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attributeType = rootElementType.Attributes[0].Type;
                Assert.StartsWith("xs:string", attributeType.Name);
            }

            [Fact]
            public void RootElementTypeAttributeTypeName2()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attributeType = rootElementType.Attributes[1].Type;
                Assert.StartsWith("InlineSimpleType_", attributeType.Name);
            }

            [Fact]
            public void RootElementTypeAttributeTypeType1()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attributeType = rootElementType.Attributes[0].Type;
                Assert.IsType(typeof(XmlUnknownSimpleType), attributeType);
            }

            [Fact]
            public void RootElementTypeAttributeTypeType2()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attributeType = rootElementType.Attributes[1].Type;
                Assert.IsType(typeof(XmlEnumerationType), attributeType);
            }

            [Fact]
            public void RootElementTypeAttributeTypeEnumerationValues()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attributeType = rootElementType.Attributes[1].Type as XmlEnumerationType;
                var expectedValues = new[] { "MD5", "SHA1", "SHA256" };
                Assert.Equal(expectedValues.Length, attributeType.EnumerationValues.Count);
                var allExpectedValuesPresent = expectedValues.All(v => attributeType.EnumerationValues.Any(e => e == v));
                Assert.True(allExpectedValuesPresent);
            }
        }

        public class GetStreamOfSchemaWithComplexTypeWithSimpleContentWithEnumerationAsExtension : TestFileBase
        {
            public GetStreamOfSchemaWithComplexTypeWithSimpleContentWithEnumerationAsExtension() : base(TestFilesFactory.GetStreamOfSchemaWithComplexTypeWithSimpleContentWithEnumerationAsExtension())
            {
            }

            [Fact]
            public void HasOnlySingleRootElement()
            {
                Assert.Equal(1, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void RootElementName()
            {
                var expectedElementName = "Commit";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedElementName, rootElement.Name);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var expectedTypeNameStart = "InlineSimpleContentComplexType_";
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.StartsWith(expectedTypeNameStart, rootElementType.Name);
            }

            [Fact]
            public void RootElementTypeType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.IsType(typeof(XmlSimpleContentComplexType), rootElementType);
            }

            [Fact]
            public void RootElementTypeAttributesCount()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                Assert.Equal(2, rootElementType.Attributes.Count);
            }

            [Fact]
            public void RootElementTypeAttributeName1()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attribute = rootElementType.Attributes[0];
                Assert.Equal("AuthorEmail", attribute.Name);
            }

            [Fact]
            public void RootElementTypeAttributeName2()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attribute = rootElementType.Attributes[1];
                Assert.Equal("Algorithm", attribute.Name);
            }

            [Fact]
            public void RootElementTypeAttributeTypeName1()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attributeType = rootElementType.Attributes[0].Type;
                Assert.StartsWith("xs:string", attributeType.Name);
            }

            [Fact]
            public void RootElementTypeAttributeTypeName2()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attributeType = rootElementType.Attributes[1].Type;
                Assert.StartsWith("HashAlgorithm", attributeType.Name);
            }

            [Fact]
            public void RootElementTypeAttributeTypeType1()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attributeType = rootElementType.Attributes[0].Type;
                Assert.IsType(typeof(XmlUnknownSimpleType), attributeType);
            }

            [Fact]
            public void RootElementTypeAttributeTypeType2()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attributeType = rootElementType.Attributes[1].Type;
                Assert.IsType(typeof(XmlEnumerationType), attributeType);
            }

            [Fact]
            public void RootElementTypeAttributeTypeEnumerationValues()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlSimpleContentComplexType;
                var attributeType = rootElementType.Attributes[1].Type as XmlEnumerationType;
                var expectedValues = new[] { "MD5", "SHA1", "SHA256" };
                Assert.Equal(expectedValues.Length, attributeType.EnumerationValues.Count);
                var allExpectedValuesPresent = expectedValues.All(v => attributeType.EnumerationValues.Any(e => e == v));
                Assert.True(allExpectedValuesPresent);
            }
        }

        public class GetStreamOfSchemaWithEnumerationTypeNestedInComplexType : TestFileBase
        {
            public GetStreamOfSchemaWithEnumerationTypeNestedInComplexType() : base(TestFilesFactory.GetStreamOfSchemaWithEnumerationTypeNestedInComplexType()) { }

            [Fact]
            public void HasOnlySingleRootElement()
            {
                Assert.Equal(1, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void RootElementName()
            {
                var expectedElementName = "WeatherForecast";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedElementName, rootElement.Name);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var expectedTypeNameStart = "WeatherReport";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.True(rootElement.Type.Name.StartsWith(expectedTypeNameStart));
            }

            [Fact]
            public void RootElementTypeType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.IsType(typeof(XmlComplexType), rootElementType);
            }

            [Fact]
            public void RootElementTypeChildCount()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                Assert.Equal(2, rootElementType.PossibleChildElements.Count);
            }

            [Fact]
            public void NestedTypeTemperatureName()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                Assert.Equal("Temperature", rootElementType.PossibleChildElements[0].Name);
            }

            [Fact]
            public void NestedTypeTemperatureTypeName()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                Assert.Equal("xs:integer", rootElementType.PossibleChildElements[0].Type.Name);
            }

            [Fact]
            public void NestedTypeTemperatureType()
            {
                var nestedType = (ParsedSchema.RootElements.First().Type as XmlComplexType).PossibleChildElements[0].Type;
                Assert.IsType(typeof(XmlUnknownType), nestedType);
            }

            [Fact]
            public void NestedTypeWeatherForecastName()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                Assert.Equal("Forecast", rootElementType.PossibleChildElements[1].Name);
            }

            [Fact]
            public void NestedTypeWeatherForecastTypeName()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlComplexType;
                Assert.Equal("WeatherPrediction", rootElementType.PossibleChildElements[1].Type.Name);
            }

            [Fact]
            public void NestedTypeWeatherForecastIsEnumerationType()
            {
                var nestedType = (ParsedSchema.RootElements.First().Type as XmlComplexType).PossibleChildElements[1].Type;
                Assert.IsType(typeof(XmlEnumerationType), nestedType);
            }

            [Fact]
            public void NestedTypeWeatherForecastEnumerationValues()
            {
                var expectedValues = new[] { "Rainy", "Cloudy", "Sunny", "Misty", "Probability of raining meatballs" };
                var nestedType = (ParsedSchema.RootElements.First().Type as XmlComplexType).PossibleChildElements[1].Type as XmlEnumerationType;
                Assert.Equal(expectedValues.Length, nestedType.EnumerationValues.Count);
                var allElementsPresent = expectedValues.All(v => nestedType.EnumerationValues.Contains(v));
                Assert.True(allElementsPresent);
            }

        }

        public class GetStreamOfSchemaWithInlineSimpleType : TestFileBase
        {
            public GetStreamOfSchemaWithInlineSimpleType() : base(TestFilesFactory.GetStreamOfSchemaWithInlineSimpleType()) { }

            [Fact]
            public void HasOnlySingleRootElement()
            {
                Assert.Equal(1, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void RootElementName()
            {
                var expectedElementName = "WeatherForecast";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedElementName, rootElement.Name);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var expectedTypeNameStart = "InlineSimpleType_";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.True(rootElement.Type.Name.StartsWith(expectedTypeNameStart));
            }

            [Fact]
            public void RootElementTypeIsEnumerationType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.IsType(typeof(XmlEnumerationType), rootElementType);
            }

            [Fact]
            public void RootElementTypeEnumerationTypeHasCorrectRestrictions()
            {
                var expectedValues = new[] { "Rainy", "Cloudy", "Sunny", "Misty", "Probability of raining meatballs" };
                var rootElementType = ParsedSchema.RootElements.First().Type as XmlEnumerationType;
                Assert.Equal(expectedValues.Length, rootElementType.EnumerationValues.Count);
                var allElementsPresent = expectedValues.All(v => rootElementType.EnumerationValues.Contains(v));
                Assert.True(allElementsPresent);
            }
        }

        public class GetStreamOfSchemaWithUnknownSimpleType : TestFileBase
        {
            public GetStreamOfSchemaWithUnknownSimpleType() : base(TestFilesFactory.GetStreamOfSchemaWithUnknownSimpleType()) { }

            [Fact]
            public void HasOnlySingleRootElement()
            {
                Assert.Equal(1, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void RootElementName()
            {
                var expectedElementName = "Message";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedElementName, rootElement.Name);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var expectedTypeName = "xs:string";
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.Equal(expectedTypeName, rootElementType.Name);
            }

            [Fact]
            public void RootElementTypeType()
            {
                var rootElementType = ParsedSchema.RootElements.First().Type;
                Assert.IsType(typeof(XmlUnknownType), rootElementType);
            }
        }

        public class GetStreamOfSchemaWithInlineComplexType : TestFileBase
        {
            public GetStreamOfSchemaWithInlineComplexType() : base(TestFilesFactory.GetStreamOfSchemaWithInlineComplexType()) { }

            [Fact]
            public void HasOnlySingleRootElement()
            {
                Assert.Equal(1, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void RootElementName()
            {
                var expectedElementName = "WeatherForecast";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.Equal(expectedElementName, rootElement.Name);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var expectedTypeNameStart = "InlineComplexType_";
                var rootElement = ParsedSchema.RootElements.First();
                Assert.True(rootElement.Type.Name.StartsWith(expectedTypeNameStart));
            }

            [Fact]
            public void NoPropertiesOnRootElementType()
            {
                var rootElement = ParsedSchema.RootElements.First();
                Assert.False((rootElement.Type as XmlComplexType).PossibleChildElements.Any());
            }
        }

        public class GetStreamOfFileWithTwoPossibleRootElements : TestFileBase
        {
            public GetStreamOfFileWithTwoPossibleRootElements() : base(TestFilesFactory.GetStreamOfFileWithTwoPossibleRootElements()) { }

            [Fact]
            public void HasTwoRootElements()
            {
                Assert.Equal(2, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void RootElementName1()
            {
                var expectedElementName = "WeatherForecast";
                var actualName = ParsedSchema.RootElements[0].Name;
                Assert.Equal(expectedElementName, actualName);
            }

            [Fact]
            public void RootElementName2()
            {
                var expectedElementName = "Order";
                var actualName = ParsedSchema.RootElements[1].Name;
                Assert.Equal(expectedElementName, actualName);
            }

            [Fact]
            public void RootElementTypeName1()
            {
                var expectedTypeName = "WeatherPrediction";
                var actualName = ParsedSchema.RootElements[0].Type.Name;
                Assert.Equal(expectedTypeName, actualName);
            }

            [Fact]
            public void RootElementTypeName2()
            {
                var expectedTypeName = "FoodOrder";
                var actualName = ParsedSchema.RootElements[1].Type.Name;
                Assert.Equal(expectedTypeName, actualName);
            }

            [Fact]
            public void RootElementTypeIsEnumerationType1()
            {
                var rootElementType = ParsedSchema.RootElements[0].Type;
                Assert.IsType(typeof(XmlEnumerationType), rootElementType);
            }

            [Fact]
            public void RootElementTypeEnumerationTypeHasCorrectRestrictions1()
            {
                var expectedValues = new[] { "Rainy", "Cloudy", "Sunny", "Misty", "Probability of raining meatballs" };
                var rootElementType = ParsedSchema.RootElements[0].Type as XmlEnumerationType;
                Assert.Equal(expectedValues.Length, rootElementType.EnumerationValues.Count);
                var allElementsPresent = expectedValues.All(v => rootElementType.EnumerationValues.Contains(v));
                Assert.True(allElementsPresent);
            }

            [Fact]
            public void NoPropertiesOnRootElementType2()
            {
                var secondRootElementType = ParsedSchema.RootElements[1].Type;
                Assert.False((secondRootElementType as XmlComplexType).PossibleChildElements.Any());
            }

            [Fact]
            public void RootElementTypeType2()
            {
                var secondRootElementType = ParsedSchema.RootElements[1].Type;
                Assert.IsType(typeof(XmlComplexType), secondRootElementType);
            }
        }

        public class GAEB_XML_3_1_Schema : TestFileBase
        {
            public GAEB_XML_3_1_Schema() : base(TestFilesFactory.GetStreamForTestFile(TestFile.GAEB_XML_3_1_Schema)) { }

            [Fact]
            public void HasOnlySingleRootElement()
            {
                Assert.Equal(1, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void RootElementName()
            {
                var rootElementName = ParsedSchema.RootElements[0].Name;
                Assert.Equal("GAEB", rootElementName);
            }

            [Fact]
            public void RootElementTypeType()
            {
                var rootElementType = ParsedSchema.RootElements[0].Type;
                Assert.IsType(typeof(XmlComplexType), rootElementType);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var rootElementType = ParsedSchema.RootElements[0].Type;
                Assert.Equal("tgGAEB", rootElementType.Name);
            }

            [Fact]
            public void RootElementTypePropertyCount()
            {
                var rootElementType = ParsedSchema.RootElements[0].Type as XmlComplexType;
                // 5th element is external reference (Xml Signature)
                Assert.Equal(5, rootElementType.PossibleChildElements.Count);
            }

            [Fact]
            public void RootElementTypeAttributesCount()
            {
                var rootElementType = ParsedSchema.RootElements[0].Type as XmlComplexType;
                Assert.Equal(1, rootElementType.Attributes.Count);
            }

            [Fact]
            public void RootElementTypePropertyName1()
            {
                var expectedName = "GAEBInfo";
                var actualName = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[0].Name;
                Assert.Equal(expectedName, actualName);
            }

            [Fact]
            public void RootElementTypePropertyName2()
            {
                var expectedName = "PrjInfo";
                var actualName = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[1].Name;
                Assert.Equal(expectedName, actualName);
            }

            [Fact]
            public void RootElementTypePropertyName3()
            {
                var expectedName = "Award";
                var actualName = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[2].Name;
                Assert.Equal(expectedName, actualName);
            }

            [Fact]
            public void RootElementTypePropertyName4()
            {
                var expectedName = "AddText";
                var actualName = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[3].Name;
                Assert.Equal(expectedName, actualName);
            }

            [Fact]
            public void RootElementTypePropertyName5()
            {
                var actualName = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[4].Name;
                Assert.Equal("ds:Signature", actualName);
            }

            [Fact]
            public void RootElementTypeAttributeName()
            {
                var actualName = (ParsedSchema.RootElements[0].Type as XmlComplexType).Attributes[0].Name;
                Assert.Equal("xml:space", actualName);
            }

            [Fact]
            public void RootElementTypePropertyType1()
            {
                var rootElementTypePropertyType = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[0].Type;
                Assert.IsType(typeof(XmlComplexType), rootElementTypePropertyType);
            }

            [Fact]
            public void RootElementTypePropertyType2()
            {
                var rootElementTypePropertyType = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[1].Type;
                Assert.IsType(typeof(XmlComplexType), rootElementTypePropertyType);
            }

            [Fact]
            public void RootElementTypePropertyType3()
            {
                var rootElementTypePropertyType = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[2].Type;
                Assert.IsType(typeof(XmlComplexType), rootElementTypePropertyType);
            }

            [Fact]
            public void RootElementTypePropertyType4()
            {
                var rootElementTypePropertyType = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[3].Type;
                Assert.IsType(typeof(XmlComplexType), rootElementTypePropertyType);
            }

            [Fact]
            public void RootElementTypePropertyType5()
            {
                var rootElementTypePropertyType = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[4].Type;
                Assert.IsType(typeof(XmlUnknownType), rootElementTypePropertyType);
            }

            [Fact]
            public void RootElementTypeAttributeType()
            {
                var rootElementTypeAttributeType = (ParsedSchema.RootElements[0].Type as XmlComplexType).Attributes[0].Type;
                Assert.IsType(typeof(XmlUnknownSimpleType), rootElementTypeAttributeType);
            }

            [Fact]
            public void RootElementTypePropertyTypeName1()
            {
                var rootElementTypePropertyType = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[0].Type;
                Assert.Equal("tgGAEBInfo", rootElementTypePropertyType.Name);
            }

            [Fact]
            public void RootElementTypePropertyTypeName2()
            {
                var rootElementTypePropertyType = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[1].Type;
                Assert.Equal("tgPrjInfo", rootElementTypePropertyType.Name);
            }

            [Fact]
            public void RootElementTypePropertyTypeName3()
            {
                var rootElementTypePropertyType = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[2].Type;
                Assert.Equal("tgAward", rootElementTypePropertyType.Name);
            }

            [Fact]
            public void RootElementTypePropertyTypeName4()
            {
                var rootElementTypePropertyType = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[3].Type;
                Assert.Equal("tgAddText", rootElementTypePropertyType.Name);
            }

            [Fact]
            public void RootElementTypePropertyTypeName5()
            {
                var rootElementTypePropertyType = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[4].Type;
                Assert.Equal("ds:Signature", rootElementTypePropertyType.Name);
            }

            [Fact]
            public void RootElementIsNotExternalReference()
            {
                var rootElementIsExternalRef = ParsedSchema.RootElements[0].IsExternallyDeclared;
                Assert.False(rootElementIsExternalRef);
            }

            [Fact]
            public void RootElementChildIsNotExternalReference1()
            {
                var rootElementChildIsExternalRef = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[0].IsExternallyDeclared;
                Assert.False(rootElementChildIsExternalRef);
            }

            [Fact]
            public void RootElementChildIsNotExternalReference2()
            {
                var rootElementChildIsExternalRef = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[1].IsExternallyDeclared;
                Assert.False(rootElementChildIsExternalRef);
            }

            [Fact]
            public void RootElementChildIsNotExternalReference3()
            {
                var rootElementChildIsExternalRef = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[2].IsExternallyDeclared;
                Assert.False(rootElementChildIsExternalRef);
            }

            [Fact]
            public void RootElementChildIsNotExternalReference4()
            {
                var rootElementChildIsExternalRef = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[3].IsExternallyDeclared;
                Assert.False(rootElementChildIsExternalRef);
            }

            [Fact]
            public void RootElementChildIsExternalReference5()
            {
                var rootElementChildIsExternalRef = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[4].IsExternallyDeclared;
                Assert.True(rootElementChildIsExternalRef);
            }

            [Fact]
            public void RandomTypeIsPresent()
            {
                var complexType = GetAllTypesUsedInSchema().FirstOrDefault(t => t.Name == "tgArticle");
                Assert.NotNull(complexType);
            }

            [Fact]
            public void RandomTypeHasCorrectType()
            {
                var complexType = GetAllTypesUsedInSchema().FirstOrDefault(t => t.Name == "tgArticle");
                Assert.IsType(typeof(XmlComplexType), complexType);
            }

            [Fact]
            public void RandomTypeHasCorrectChildren()
            {
                var complexType = GetAllTypesUsedInSchema().FirstOrDefault(t => t.Name == "tgArticle") as XmlComplexType;
                var expectedChildren = new[]
                {
                    new {Name = "Brand", TypeName = "tgNormalizedString60", TypeType = typeof(XmlSimpleType)},
                    new {Name = "ArtNo", TypeName = "tgNormalizedString15", TypeType = typeof(XmlSimpleType)},
                    new {Name = "Qty", TypeName = "tgDecimal_11_3", TypeType = typeof(XmlSimpleType)},
                    new {Name = "QU", TypeName = "tgNormalizedString4", TypeType = typeof(XmlSimpleType)},
                    new {Name = "ArtOutline", TypeName = "tgMLText", TypeType = typeof(XmlComplexType)},
                    new {Name = "AddText", TypeName = "tgAddText", TypeType = typeof(XmlComplexType)}
                };
                Assert.Equal(expectedChildren.Length, complexType.PossibleChildElements.Count);
                foreach (var expectedChild in expectedChildren)
                {
                    var actualChild = complexType.PossibleChildElements.FirstOrDefault(e => e.Name == expectedChild.Name);
                    Assert.NotNull(actualChild);
                    Assert.Equal(expectedChild.TypeName, actualChild.Type.Name);
                    Assert.IsType(expectedChild.TypeType, actualChild.Type);
                }
            }

            [Fact]
            public void RandomEnumerationTypeIsPresent()
            {
                var enumerationType = GetAllTypesUsedInSchema().FirstOrDefault(t => t.Name == "tgProvis");
                Assert.NotNull(enumerationType);
                Assert.IsType(typeof(XmlEnumerationType), enumerationType);
            }

            [Fact]
            public void RandomEnumerationTypeHasCorrectRestrictions()
            {
                var enumerationType = GetAllTypesUsedInSchema().First(t => t.Name == "tgYesNo") as XmlEnumerationType;
                Assert.NotNull(enumerationType);
                var expectedValues = new[] { "Yes", "No" };
                Assert.Equal(expectedValues.Length, enumerationType.EnumerationValues.Count);
                var allExpectedValuesPresent = expectedValues.All(v => enumerationType.EnumerationValues.Any(e => e == v));
                Assert.True(allExpectedValuesPresent);
            }

            [Fact]
            public void ExtendedEnumerationTypeHasAllValues()
            {
                var extendedType = GetAllTypesUsedInSchema().First(t => t.Name == "tgKeyIt") as XmlEnumerationType;
                Assert.NotNull(extendedType);
                // Type has no enumeration defined itself but only extends tgYesNo -> "Yes" and "No"
                var expectedValues = new[] {"Yes", "No"};
                Assert.Equal(expectedValues.Length, extendedType.EnumerationValues.Count);
                var allExpectedValuesPresent = expectedValues.All(v => extendedType.EnumerationValues.Any(e => e == v));
                Assert.True(allExpectedValuesPresent);
            }

            [Fact]
            public void ExtendedComplexTypeWithAttributesIsPresentAndHasCorrectType()
            {
                var complexBaseType = GetAllTypesUsedInSchema().First(t => t.Name == "tgCashDiscount");
                Assert.NotNull(complexBaseType);
                Assert.IsType(typeof(XmlComplexType), complexBaseType);
                var elementWithExtendedTypeInComplexType = (complexBaseType as XmlComplexType).PossibleChildElements.First(c => c.Name == "CashDiscDays");
                Assert.False(elementWithExtendedTypeInComplexType.IsExternallyDeclared);
                Assert.IsType(typeof(XmlComplexType), elementWithExtendedTypeInComplexType.Type);
                Assert.True(elementWithExtendedTypeInComplexType.Type.Name.StartsWith("InlineComplexType_"));
            }

            [Fact]
            public void ExtendedComplexTypeWithAttributesHasCorrectChildren()
            {
                var complexBaseType = GetAllTypesUsedInSchema().First(t => t.Name == "tgCashDiscount") as XmlComplexType;
                var childElementExtendedType = complexBaseType.PossibleChildElements.First(c => c.Name == "CashDiscDays").Type as XmlComplexType;

                Assert.Equal(2, childElementExtendedType.Attributes.Count);
                Assert.Equal(0, childElementExtendedType.PossibleChildElements.Count);

                // Enumeration attribute
                var enumerationAttribute = childElementExtendedType.Attributes.FirstOrDefault(a => a.Name == "TypeOfDays");
                Assert.NotNull(enumerationAttribute);
                Assert.IsType(typeof(XmlEnumerationType), enumerationAttribute.Type);
                var attributeTypeAsEnumerationType = enumerationAttribute.Type as XmlEnumerationType;
                Assert.Equal(3, attributeTypeAsEnumerationType.EnumerationValues.Count);
                Assert.Contains("work days", attributeTypeAsEnumerationType.EnumerationValues);
                Assert.Contains("week days", attributeTypeAsEnumerationType.EnumerationValues);
                Assert.Contains("calendar days", attributeTypeAsEnumerationType.EnumerationValues);

                // Regular attribute
                var simpleAttribute = childElementExtendedType.Attributes.FirstOrDefault(a => a.Name == "Days");
                Assert.NotNull(simpleAttribute);
                Assert.IsType(typeof(XmlSimpleType), simpleAttribute.Type);
            }

            [Fact]
            public void SimpleContentComplexTypePresent()
            {
                var element = GetAllTypesUsedInSchema().FirstOrDefault(t => t.Name == "tgStLNo");
                Assert.NotNull(element);
            }

            [Fact]
            public void SimpleContentComplexTypeType()
            {
                var element = GetAllTypesUsedInSchema().First(t => t.Name == "tgStLNo");
                Assert.IsType(typeof(XmlSimpleContentComplexType), element);
            }

            [Fact]
            public void SimpleContentComplexTypeAttributes()
            {
                var element = GetAllTypesUsedInSchema().First(t => t.Name == "tgStLNo") as XmlSimpleContentComplexType;
                Assert.Equal(1, element.Attributes.Count);
                var attribute = element.Attributes[0];
                Assert.Equal("Type", attribute.Name);
                var attributeType = element.Attributes[0].Type as XmlEnumerationType;
                Assert.NotNull(attributeType);
                Assert.StartsWith("InlineSimpleType_", attributeType.Name);
                var expectedValues = new[] {"STLB-BauZ", "StLB", "StLK"};
                Assert.Equal(expectedValues.Length, attributeType.EnumerationValues.Count);
                var allValuesPresent = expectedValues.All(v => attributeType.EnumerationValues.Any(e => e == v));
                Assert.True(allValuesPresent);
            }
        }

        public class GreenBuildingXML_Ver6_01 : TestFileBase
        {
            public GreenBuildingXML_Ver6_01() : base(TestFilesFactory.GetStreamForTestFile(TestFile.GreenBuildingXML_Ver6_01)) { }

            [Fact]
            public void HasCorrectCountOfRootElements()
            {
                var expectedCountOfRootElements = 346;
                Assert.Equal(expectedCountOfRootElements, ParsedSchema.RootElements.Count);
            }

            [Fact]
            public void RootElementNames()
            {
                // Just check a few
                var valuesToCheck = new[] { "gbXML", "aecXML", "DeltaP", "ScheduleTypeLimits", "ZoneCoolingLoad" };
                var allValuesContained = valuesToCheck.All(v => ParsedSchema.RootElements.Any(r => r.Name == v));
                Assert.True(allValuesContained);
            }

            [Fact]
            public void RootElementTypeName()
            {
                var rootElementType = ParsedSchema.RootElements.First(e => e.Name == "gbXML").Type;
                Assert.StartsWith("InlineComplexType_", rootElementType.Name);
            }

            [Fact]
            public void RootElementTypeType()
            {
                var rootElementType = ParsedSchema.RootElements.First(e => e.Name == "gbXML").Type;
                Assert.IsType(typeof(XmlComplexType), rootElementType);
            }

            [Fact]
            public void RootElementTypePropertyNames()
            {
                var rootElementType = ParsedSchema.RootElements.First(e => e.Name == "gbXML").Type as XmlComplexType;
                var expectedPropertyNames = new[]
                {
                    "aecXML", "Campus", "LightingSystem", "LightingControl", "Construction", "Layer",
                    "Material", "WindowType", "Schedule", "WeekSchedule", "DaySchedule", "Zone", "AirLoop", "HydronicLoop", "IntEquip",
                    "ExtEquip", "Weather", "Meter", "Results", "DocumentHistory", "SimulationParameters"
                };
                Assert.Equal(expectedPropertyNames.Length, rootElementType.PossibleChildElements.Count);
                var allNamesPresent = expectedPropertyNames.All(v => rootElementType.PossibleChildElements.Any(c => c.Name == v));
                Assert.True(allNamesPresent);
            }

            [Fact]
            public void RootElementTypeAttributeNames()
            {
                var rootElementType = ParsedSchema.RootElements.First(e => e.Name == "gbXML").Type as XmlComplexType;
                var expectedAttributeNames = new[]
                {
                    "id", "engine", "temperatureUnit", "lengthUnit", "areaUnit", "volumeUnit", "useSIUnitsForResults", "version", "SurfaceReferenceLocation"
                };
                Assert.Equal(expectedAttributeNames.Length, rootElementType.Attributes.Count);
                var allNamesPresent = expectedAttributeNames.All(v => rootElementType.Attributes.Any(a => a.Name == v));
                Assert.True(allNamesPresent);
            }

            [Fact]
            public void RootElementEnumerationAttributeType()
            {
                var rootElementType = ParsedSchema.RootElements.First(e => e.Name == "gbXML").Type as XmlComplexType;
                var enumAttribute = rootElementType.Attributes.First(a => a.Name == "engine");
                Assert.IsType(typeof(XmlEnumerationType), enumAttribute.Type);
                var allowedValues = (enumAttribute.Type as XmlEnumerationType).EnumerationValues;
                var expectedValues = new[] {"DOE2.1e", "DOE2.2", "EnergyPlus"};
                Assert.Equal(expectedValues.Length, allowedValues.Count);
                var allValuesPresent = expectedValues.All(v => allowedValues.Any(a => a == v));
                Assert.True(allValuesPresent);

            }
        }
    }
}