using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser.FileTests
{
    public class GAEB_XML_3_1_Schema : TestFileBase
    {
        public GAEB_XML_3_1_Schema() : base(ParserTestFile.GAEB_XML_3_1_Schema) { }

        [Fact]
        public void HasOnlySingleRootElement()
        {
            Assert.Single(ParsedSchema.RootElements);
        }

        [Fact]
        public void CountOfAttributeTypes()
        {
            var expectedCountOfAttributeTypes = 27;
            var attributeTypes = ParsedSchema.GetAllDeclaredAttributeTypes().ToList();
            Assert.Equal(expectedCountOfAttributeTypes, attributeTypes.Count);
        }

        [Fact]
        public void CountOfTypes()
        {
            var expectedCountOfTypes = 151;
            var types = ParsedSchema.GetAllDeclaredElementTypes().ToList();
            Assert.Equal(expectedCountOfTypes, types.Count);
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
            Assert.IsType<XmlComplexType>(rootElementType);
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
            Assert.Single(rootElementType.Attributes);
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
            Assert.IsType<XmlComplexType>(rootElementTypePropertyType);
        }

        [Fact]
        public void RootElementTypePropertyType2()
        {
            var rootElementTypePropertyType = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[1].Type;
            Assert.IsType<XmlComplexType>(rootElementTypePropertyType);
        }

        [Fact]
        public void RootElementTypePropertyType3()
        {
            var rootElementTypePropertyType = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[2].Type;
            Assert.IsType<XmlComplexType>(rootElementTypePropertyType);
        }

        [Fact]
        public void RootElementTypePropertyType4()
        {
            var rootElementTypePropertyType = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[3].Type;
            Assert.IsType<XmlComplexType>(rootElementTypePropertyType);
        }

        [Fact]
        public void RootElementTypePropertyType5()
        {
            var rootElementTypePropertyType = (ParsedSchema.RootElements[0].Type as XmlComplexType).PossibleChildElements[4].Type;
            Assert.IsType<XmlUnknownType>(rootElementTypePropertyType);
        }

        [Fact]
        public void RootElementTypeAttributeType()
        {
            var rootElementTypeAttributeType = (ParsedSchema.RootElements[0].Type as XmlComplexType).Attributes[0].Type;
            Assert.IsType<XmlUnknownType>(rootElementTypeAttributeType);
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
            var complexType = GetAllElementTypesUsedInSchema().FirstOrDefault(t => t.Name == "tgArticle");
            Assert.NotNull(complexType);
        }

        [Fact]
        public void RandomTypeHasCorrectType()
        {
            var complexType = GetAllElementTypesUsedInSchema().FirstOrDefault(t => t.Name == "tgArticle");
            Assert.IsType<XmlComplexType>(complexType);
        }

        [Fact]
        public void RandomTypeHasCorrectChildren()
        {
            var complexType = GetAllElementTypesUsedInSchema().FirstOrDefault(t => t.Name == "tgArticle") as XmlComplexType;
            var expectedChildren = new[]
            {
                new {Name = "Brand", TypeName = "tgNormalizedString60", TypeType = typeof(XmlSimpleType)},
                new {Name = "ArtNo", TypeName = "tgNormalizedString15", TypeType = typeof(XmlSimpleType)},
                new {Name = "Qty", TypeName = "tgDecimal_11_3", TypeType = typeof(XmlDecimalType)},
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
            var enumerationType = GetAllElementTypesUsedInSchema().FirstOrDefault(t => t.Name == "tgProvis");
            Assert.NotNull(enumerationType);
            Assert.IsType<XmlEnumerationType>(enumerationType);
        }

        [Fact]
        public void RandomEnumerationTypeHasCorrectRestrictions()
        {
            var enumerationType = GetAllElementTypesUsedInSchema().First(t => t.Name == "tgYesNo") as XmlEnumerationType;
            Assert.NotNull(enumerationType);
            var expectedValues = new[] { "Yes", "No" };
            Assert.Equal(expectedValues.Length, enumerationType.EnumerationValues.Count);
            var allExpectedValuesPresent = expectedValues.All(v => enumerationType.EnumerationValues.Any(e => e == v));
            Assert.True(allExpectedValuesPresent);
        }

        [Fact]
        public void ExtendedEnumerationTypeHasAllValues()
        {
            var extendedType = GetAllElementTypesUsedInSchema().First(t => t.Name == "tgKeyIt") as XmlEnumerationType;
            Assert.NotNull(extendedType);
            // Type has no enumeration defined itself but only extends tgYesNo -> "Yes" and "No"
            var expectedValues = new[] { "Yes", "No" };
            Assert.Equal(expectedValues.Length, extendedType.EnumerationValues.Count);
            var allExpectedValuesPresent = expectedValues.All(v => extendedType.EnumerationValues.Any(e => e == v));
            Assert.True(allExpectedValuesPresent);
        }

        [Fact]
        public void ExtendedComplexTypeWithAttributesIsPresentAndHasCorrectType()
        {
            var complexBaseType = GetAllElementTypesUsedInSchema().First(t => t.Name == "tgCashDiscount");
            Assert.NotNull(complexBaseType);
            Assert.IsType<XmlComplexType>(complexBaseType);
            var elementWithExtendedTypeInComplexType = (complexBaseType as XmlComplexType).PossibleChildElements.First(c => c.Name == "CashDiscDays");
            Assert.False(elementWithExtendedTypeInComplexType.IsExternallyDeclared);
            Assert.IsType<XmlComplexType>(elementWithExtendedTypeInComplexType.Type);
            Assert.StartsWith("InlineComplexType_", elementWithExtendedTypeInComplexType.Type.Name);
        }

        [Fact]
        public void ExtendedComplexTypeWithAttributesHasCorrectChildren()
        {
            var complexBaseType = GetAllElementTypesUsedInSchema().First(t => t.Name == "tgCashDiscount") as XmlComplexType;
            var childElementExtendedType = complexBaseType.PossibleChildElements.First(c => c.Name == "CashDiscDays").Type as XmlComplexType;

            Assert.Equal(2, childElementExtendedType.Attributes.Count);
            Assert.Empty(childElementExtendedType.PossibleChildElements);

            // Enumeration attribute
            var enumerationAttribute = childElementExtendedType.Attributes.FirstOrDefault(a => a.Name == "TypeOfDays");
            Assert.NotNull(enumerationAttribute);
            Assert.IsType<XmlEnumerationType>(enumerationAttribute.Type);
            var attributeTypeAsEnumerationType = enumerationAttribute.Type as XmlEnumerationType;
            Assert.Equal(3, attributeTypeAsEnumerationType.EnumerationValues.Count);
            Assert.Contains("work days", attributeTypeAsEnumerationType.EnumerationValues);
            Assert.Contains("week days", attributeTypeAsEnumerationType.EnumerationValues);
            Assert.Contains("calendar days", attributeTypeAsEnumerationType.EnumerationValues);

            // Regular attribute
            var simpleAttribute = childElementExtendedType.Attributes.FirstOrDefault(a => a.Name == "Days");
            Assert.NotNull(simpleAttribute);
            Assert.IsType<XmlSimpleType>(simpleAttribute.Type);
        }

        [Fact]
        public void DetectTgYesNoEnumerationCorrectly()
        {
            var actual = GetAllElementTypesUsedInSchema()
                .Single(t => t.Name == "tgYesNo")
                as XmlEnumerationType;
            Assert.Equal(2, actual.EnumerationValues.Count);
            Assert.Contains("Yes", actual.EnumerationValues);
            Assert.Contains("No", actual.EnumerationValues);
        }

        [Fact]
        public void DetectTgYesEnumerationCorrectly()
        {
            var actual = GetAllElementTypesUsedInSchema()
                .Single(t => t.Name == "tgYes")
                as XmlEnumerationType;
            Assert.Single(actual.EnumerationValues);
            Assert.Contains("Yes", actual.EnumerationValues);
        }

        [Fact]
        public void SimpleContentComplexTypePresent()
        {
            var element = GetAllElementTypesUsedInSchema().FirstOrDefault(t => t.Name == "tgStLNo");
            Assert.NotNull(element);
        }

        [Fact]
        public void SimpleContentComplexTypeType()
        {
            var element = GetAllElementTypesUsedInSchema().First(t => t.Name == "tgStLNo");
            Assert.IsType<XmlSimpleContentComplexType>(element);
        }

        [Fact]
        public void SimpleContentComplexTypeAttributes()
        {
            var element = GetAllElementTypesUsedInSchema().First(t => t.Name == "tgStLNo") as XmlSimpleContentComplexType;
            Assert.Single(element.Attributes);
            var attribute = element.Attributes[0];
            Assert.Equal("Type", attribute.Name);
            var attributeType = element.Attributes[0].Type as XmlEnumerationType;
            Assert.NotNull(attributeType);
            Assert.StartsWith("InlineSimpleType_", attributeType.Name);
            var expectedValues = new[] { "STLB-BauZ", "StLB", "StLK" };
            Assert.Equal(expectedValues.Length, attributeType.EnumerationValues.Count);
            var allValuesPresent = expectedValues.All(v => attributeType.EnumerationValues.Any(e => e == v));
            Assert.True(allValuesPresent);
        }

        [Fact]
        public void DetectAllXmlDateTimeTypes()
        {
            var expectedDateTimeTypes = new[]
            {
                "tgDate"
            };

            foreach (var xmlType in GetAllElementTypesUsedInSchema())
            {
                if (expectedDateTimeTypes.Contains(xmlType.Name))
                {
                    Assert.True(xmlType.GetType().IsAssignableFrom(typeof(XmlDateTimeType)), $"Did expect {xmlType.Name} to be a DateTime type");
                }
                else
                {
                    Assert.False(xmlType.GetType().IsAssignableFrom(typeof(XmlDateTimeType)), $"Did not expect {xmlType.Name} to be a DateTime type");
                }
            }
        }

        [Fact]
        public void DetectAllXmlDecimalTypes()
        {
            var expectedDateTimeTypes = new[]
            {
                "tgDecimal_5_2",
                "tgDecimal_13_2",
                "tgDecimal_13_3",
                "tgDecimal_11_3",
                "tgDecimal_6_4",
            };

            foreach (var xmlType in GetAllElementTypesUsedInSchema())
            {
                if (expectedDateTimeTypes.Contains(xmlType.Name))
                {
                    Assert.True(xmlType.GetType().IsAssignableFrom(typeof(XmlDecimalType)), $"Did expect {xmlType.Name} to be a decimal type");
                }
                else
                {
                    Assert.False(xmlType.GetType().IsAssignableFrom(typeof(XmlDecimalType)), $"Did not expect {xmlType.Name} to be a decimal type");
                }
            }
        }
    }
}