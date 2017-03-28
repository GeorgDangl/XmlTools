using System.IO;
using System.Linq;
using System.Reflection;

namespace XmlTools.Tests
{
    // TODO MAKE SURE THERE IS A TEST CLASS FOR EVERY XSD SCHEMA DEFINED HERE
    // TODO MAKE A TEST CASE WITH AN EXTENDED ATTRIBUTE

    public static class TestFilesFactory
    {
        public static Stream GetStreamForTestFile(TestFile file)
        {
            var resourceNameStart = $"XmlTools.Tests.Testfiles.{file}";
            var assembly = typeof(TestFilesFactory).GetTypeInfo().Assembly;
            var exactResourceNames = assembly.GetManifestResourceNames()
                .Where(name => name.StartsWith(resourceNameStart))
                .ToList();
            if (exactResourceNames.Count != 1)
            {
                throw new FileNotFoundException($"Resource name ambigious or file not found, was looking for testfiles that start with \"{resourceNameStart}\"");
            }
            return assembly.GetManifestResourceStream(exactResourceNames.First());
        }

        public static Stream GetStreamOfMinimumValidSchemaFile()
        {
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                      + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                                      + "<xs:element name=\"Order\" type=\"FoodOrder\" />"
                                      + "<xs:complexType name=\"FoodOrder\">"
                                      + "</xs:complexType>"
                                      + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfSchemaWithEnumerationType()
        {
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                      + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                                      + "<xs:element name=\"WeatherForecast\" type=\"WeatherPrediction\" />"
                                      + "<xs:simpleType name=\"WeatherPrediction\">"
                                      + "<xs:restriction>"
                                      + "<xs:enumeration value=\"Rainy\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Cloudy\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Sunny\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Misty\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Probability of raining meatballs\"></xs:enumeration>"
                                      + "</xs:restriction>"
                                      + "</xs:simpleType>"
                                      + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfSchemaWithComplexType()
        {
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                      + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                                      + "<xs:element name=\"Issue\" type=\"BugReport\" />"
                                      + "<xs:complexType name=\"BugReport\">"
                                      + "<xs:element name=\"Message\" type=\"xs:string\" />"
                                      + "<xs:element name=\"IntroducedInCommit\" type=\"xs:string\" />"
                                      + "<xs:sequence>"
                                      + "<xs:element name=\"Priority\" type=\"xs:string\" />"
                                      + "</xs:sequence>"
                                      + "<xs:choice>"
                                      + "<xs:element name=\"PersonToBlame\" >"
                                      + "<xs:complexType>"
                                      + "<xs:element name=\"Email\" type=\"xs:string\" />"
                                      + "<xs:element name=\"Name\" type=\"xs:string\" />"
                                      + "</xs:complexType>"
                                      + "</xs:element>"
                                      + "</xs:choice>"
                                      + "<xs:attribute name=\"IsResolved\" type=\"xs:boolean\"/>"
                                      + "</xs:complexType>"
                                      + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfSchemaWithEnumerationAttribute()
        {
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                      + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                                      + "<xs:element name=\"Author\" type=\"Person\" />"
                                      + "<xs:complexType name=\"Person\">"
                                        + "<xs:element name=\"Email\" type=\"xs:string\" />"
                                        + "<xs:element name=\"Name\" type=\"xs:string\" />"
                                        + "<xs:attribute name=\"Gender\">"
                                            + "<xs:simpleType>"
                                                + "<xs:restriction>"
                                                    + "<xs:enumeration value=\"Female\" />"
                                                    + "<xs:enumeration value=\"Male\" />"
                                                + "</xs:restriction>"
                                            + "</xs:simpleType>"
                                        + "</xs:attribute>"
                                      + "</xs:complexType>"
                                      + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfSchemaWithRestrictionButNotEnumerationType()
        {
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                      + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                                      + "<xs:element name=\"OperatingTemperature\" type=\"OperatingTemperatureRange\" />"
                                      + "<xs:simpleType name=\"OperatingTemperatureRange\">"
                                      + "<xs:restriction>"
                                      + "<xs:maxInclusive value=\"60\" />"
                                      + "</xs:restriction>"
                                      + "</xs:simpleType>"
                                      + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfSchemaWithExtendedEnumerationType()
        {
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                      + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                                      + "<xs:element name=\"WeatherForecast\" type=\"WeatherPrediction\" />"
                                      + "<xs:simpleType name=\"WeatherPrediction\">"
                                      + "<xs:restriction base=\"EnglishWeather\">"
                                      + "<xs:enumeration value=\"Sunny\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Probability of raining meatballs\"></xs:enumeration>"
                                      + "</xs:restriction>"
                                      + "</xs:simpleType>"
                                      + "<xs:simpleType name=\"EnglishWeather\">"
                                      + "<xs:restriction>"
                                      + "<xs:enumeration value=\"Rainy\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Cloudy\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Misty\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Raining cats and dogs\"></xs:enumeration>"
                                      + "</xs:restriction>"
                                      + "</xs:simpleType>"
                                      + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfSchemaWithExtendedComplexType()
        {
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                      + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                                      + "<xs:element name=\"Issue\" type=\"BugReport\" />"
                                      + "<xs:complexType name=\"Report\">"
                                      + "<xs:element name=\"Message\" type=\"xs:string\" />"
                                      + "<xs:attribute name=\"IsResolved\" type=\"xs:boolean\"/>"
                                      + "</xs:complexType>"
                                      + "<xs:complexType name=\"BugReport\">"
                                      + "<xs:complexContent>"
                                      + "<xs:extension base=\"Report\">"
                                      + "<xs:element name=\"IntroducedInCommit\" type=\"xs:string\" />"
                                      + "<xs:attribute name=\"IsCritical\" type=\"xs:boolean\"/>"
                                      + "</xs:extension>"
                                      + "</xs:complexContent>"
                                      + "</xs:complexType>"
                                      + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfSchemaWithComplexTypeWithSimpleContent()
        {
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                      + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                                      + "<xs:element name=\"Temperature\" >"
                                      + "<xs:complexType>"
                                      + "<xs:simpleContent>"
                                      + "<xs:attribute name=\"IsFahrenheit\" type=\"xs:boolean\"/>"
                                      + "</xs:simpleContent>"
                                      + "</xs:complexType>"
                                      + "</xs:element>"
                                      + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfSchemaWithComplexTypeWithSimpleContentButAlsoElementDefinition()
        {
            // This is not allowed by the schema and should result in an exception
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                          + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                          + "<xs:element name=\"Temperature\" >"
                          + "<xs:complexType>"
                          + "<xs:simpleContent>"
                          + "<xs:element name=\"MaxTemperature\" type=\"xs:integer\" />" // This line is invalid
                          + "<xs:attribute name=\"IsFahrenheit\" type=\"xs:boolean\"/>"
                          + "</xs:simpleContent>"
                          + "</xs:complexType>"
                          + "</xs:element>"
                          + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfSchemaWithExtendedComplexTypeWithSimpleContent()
        {
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                          + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                          + "<xs:element name=\"Commit\" type=\"CommitHash\" />"
                          + "<xs:complexType name=\"Hash\">"
                          + "<xs:attribute name=\"Algorithm\" type=\"xs:string\"/>"
                          + "</xs:complexType>"
                          + "<xs:complexType name=\"CommitHash\">"
                          + "<xs:simpleContent>"
                          + "<xs:extension base=\"Hash\">"
                          + "<xs:attribute name=\"AuthorEmail\" type=\"xs:string\"/>"
                          + "</xs:extension>"
                          + "</xs:simpleContent>"
                          + "</xs:complexType>"
                          + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfSchemaWithComplexTypeWithSimpleContentWithEnumeration()
        {
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                      + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                                      + "<xs:element name=\"Commit\">"
                                      + "<xs:complexType>"
                                      + "<xs:simpleContent>"
                                      + "<xs:attribute name=\"AuthorEmail\" type=\"xs:string\"/>"
                                      + "<xs:attribute name=\"Algorithm\">"
                                      + "<xs:simpleType>"
                                      + "<xs:restriction>"
                                      + "<xs:enumeration value=\"MD5\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"SHA1\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"SHA256\"></xs:enumeration>"
                                      + "</xs:restriction>"
                                      + "</xs:simpleType>"
                                      + "</xs:attribute>"
                                      + "</xs:simpleContent>"
                                      + "</xs:complexType>"
                                      + "</xs:element>"
                                      + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfSchemaWithComplexTypeWithSimpleContentWithEnumerationAsExtension()
        {
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                      + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                                      + "<xs:element name=\"Commit\">"
                                      + "<xs:complexType>"
                                      + "<xs:simpleContent>"
                                      + "<xs:attribute name=\"AuthorEmail\" type=\"xs:string\"/>"
                                      + "<xs:attribute name=\"Algorithm\" type=\"HashAlgorithms\"/>"
                                      + "</xs:simpleContent>"
                                      + "</xs:complexType>"
                                      + "</xs:element>"
                                      + "<xs:simpleType name=\"HashAlgorithms\">"
                                      + "<xs:restriction>"
                                      + "<xs:enumeration value=\"MD5\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"SHA1\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"SHA256\"></xs:enumeration>"
                                      + "</xs:restriction>"
                                      + "</xs:simpleType>"
                                      + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfSchemaWithEnumerationTypeNestedInComplexType()
        {
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                      + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                                      + "<xs:element name=\"WeatherForecast\" type=\"WeatherReport\" />"
                                      + "<xs:complexType name=\"WeatherReport\">"
                                      + "<xs:element name=\"Temperature\" type=\"xs:integer\" />"
                                      + "<xs:element name=\"Forecast\" type=\"WeatherPrediction\" />"
                                      + "</xs:complexType>"
                                      + "<xs:simpleType name=\"WeatherPrediction\">"
                                      + "<xs:restriction>"
                                      + "<xs:enumeration value=\"Rainy\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Cloudy\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Sunny\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Misty\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Probability of raining meatballs\"></xs:enumeration>"
                                      + "</xs:restriction>"
                                      + "</xs:simpleType>"
                                      + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfSchemaWithInlineSimpleType()
        {
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                      + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                                      + "<xs:element name=\"WeatherForecast\">"
                                      + "<xs:simpleType>"
                                      + "<xs:restriction>"
                                      + "<xs:enumeration value=\"Rainy\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Cloudy\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Sunny\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Misty\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Probability of raining meatballs\"></xs:enumeration>"
                                      + "</xs:restriction>"
                                      + "</xs:simpleType>"
                                      + "</xs:element>"
                                      + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfSchemaWithUnknownSimpleType()
        {
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                      + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                                      + "<xs:element name=\"Message\" type=\"xs:string\"/>"
                                      + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfSchemaWithInlineComplexType()
        {
            // TODO HAVE ATTRIBUTES IN BOTH DEFINITIONS
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                      + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                                      + "<xs:element name=\"WeatherForecast\">"
                                      + "<xs:complexType >"
                                      + "</xs:complexType>"
                                      + "</xs:element>"
                                      + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfFileWithoutRootElement()
        {
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                      + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                                      + "<xs:complexType name=\"FoodOrder\">"
                                      + "</xs:complexType>"
                                      + "</xs:schema>";
            return minimumXsd.ToStream();
        }

        public static Stream GetStreamOfFileWithTwoPossibleRootElements()
        {
            const string minimumXsd = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                      + "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">"
                                      + "<xs:element name=\"WeatherForecast\" type=\"WeatherPrediction\" />"
                                      + "<xs:element name=\"Order\" type=\"FoodOrder\" />"
                                      + "<xs:simpleType name=\"WeatherPrediction\">"
                                      + "<xs:restriction>"
                                      + "<xs:enumeration value=\"Rainy\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Cloudy\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Sunny\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Misty\"></xs:enumeration>"
                                      + "<xs:enumeration value=\"Probability of raining meatballs\"></xs:enumeration>"
                                      + "</xs:restriction>"
                                      + "</xs:simpleType>"
                                      + "<xs:complexType name=\"FoodOrder\">"
                                      + "</xs:complexType>"
                                      + "</xs:schema>";
            return minimumXsd.ToStream();
        }
    }
}
