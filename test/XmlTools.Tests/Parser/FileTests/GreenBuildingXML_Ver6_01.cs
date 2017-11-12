using System.Linq;
using Xunit;

namespace XmlTools.Tests.Parser.FileTests
{
    public class GreenBuildingXML_Ver6_01 : TestFileBase
    {
        public GreenBuildingXML_Ver6_01() : base(ParserTestFile.GreenBuildingXML_Ver6_01) { }

        [Fact]
        public void HasCorrectCountOfRootElements()
        {
            var expectedCountOfRootElements = 346;
            Assert.Equal(expectedCountOfRootElements, ParsedSchema.RootElements.Count);
        }

        [Fact]
        public void CountOfAttributeTypes()
        {
            var expectedCountOfAttributeTypes = 151;
            var attributeTypes = ParsedSchema.GetAllDeclaredAttributeTypes().ToList();
            Assert.Equal(expectedCountOfAttributeTypes, attributeTypes.Count);
        }

        [Fact]
        public void CountOfTypes()
        {
            var expectedCountOfTypes = 1811;
            var types = ParsedSchema.GetAllDeclaredElementTypes().ToList();
            Assert.Equal(expectedCountOfTypes, types.Count);
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
            Assert.IsType<XmlComplexType>(rootElementType);
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
            Assert.IsType<XmlEnumerationType>(enumAttribute.Type);
            var allowedValues = (enumAttribute.Type as XmlEnumerationType).EnumerationValues;
            var expectedValues = new[] { "DOE2.1e", "DOE2.2", "EnergyPlus" };
            Assert.Equal(expectedValues.Length, allowedValues.Count);
            var allValuesPresent = expectedValues.All(v => allowedValues.Any(a => a == v));
            Assert.True(allValuesPresent);

        }
    }
}