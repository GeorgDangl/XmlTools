using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace XmlTools.Tests.GroupFlattener
{
    public class FlattenerTests
    {
        [Fact]
        public void CanFlattenGroup()
        {
            var inputXml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<xs:schema xmlns:xs=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://www.oenorm.at/schema/A2063/2015-07-15"" 
           xmlns:on=""http://www.oenorm.at/schema/A2063/2015-07-15"" 
           targetNamespace=""http://www.oenorm.at/schema/A2063/2015-07-15""
           elementFormDefault=""qualified"" attributeFormDefault=""unqualified"">
  <xs:complexType name=""ontext.Luecke.type"" mixed=""true"">
    <xs:group ref=""ontext.Luecke.content""/>
  </xs:complexType>
  <xs:group name=""ontext.Luecke.content"">
    <xs:sequence>
      <xs:element name=""al"" type=""ontext.Luecke.type"">
      </xs:element>
    </xs:sequence>
  </xs:group>
</xs:schema>";
            var expected = @"<?xml version=""1.0"" encoding=""utf-8""?>
<xs:schema xmlns:xs=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://www.oenorm.at/schema/A2063/2015-07-15"" xmlns:on=""http://www.oenorm.at/schema/A2063/2015-07-15"" targetNamespace=""http://www.oenorm.at/schema/A2063/2015-07-15"" elementFormDefault=""qualified"" attributeFormDefault=""unqualified"">
  <xs:complexType name=""ontext.Luecke.type"" mixed=""true"">
    <xs:sequence>
      <xs:element name=""al"" type=""ontext.Luecke.type""></xs:element>
    </xs:sequence>
  </xs:complexType>
</xs:schema>";
            var actual = RunXmlStreamThroughGroupFlattener(inputXml);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanFlattenAttributeGroup()
        {
            var inputXml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<xs:schema xmlns:xs=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://www.oenorm.at/schema/A2063/2015-07-15"" xmlns:on=""http://www.oenorm.at/schema/A2063/2015-07-15"" targetNamespace=""http://www.oenorm.at/schema/A2063/2015-07-15"" elementFormDefault=""qualified"" attributeFormDefault=""unqualified"">
  <xs:complexType name=""ontext.Luecke.type"" mixed=""true"">
    <xs:attributeGroup ref=""ontext.Luecke.attlist""/>
  </xs:complexType>
  <xs:attributeGroup name=""ontext.Luecke.attlist"">
    <xs:attribute name=""kennung"" type=""ontext.Lueckenkennung.type""/>
  </xs:attributeGroup>
</xs:schema>";
            var expected = @"<?xml version=""1.0"" encoding=""utf-8""?>
<xs:schema xmlns:xs=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://www.oenorm.at/schema/A2063/2015-07-15"" xmlns:on=""http://www.oenorm.at/schema/A2063/2015-07-15"" targetNamespace=""http://www.oenorm.at/schema/A2063/2015-07-15"" elementFormDefault=""qualified"" attributeFormDefault=""unqualified"">
  <xs:complexType name=""ontext.Luecke.type"" mixed=""true"">
    <xs:attribute name=""kennung"" type=""ontext.Lueckenkennung.type"" />
  </xs:complexType>
</xs:schema>";
            var actual = RunXmlStreamThroughGroupFlattener(inputXml);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanFlattenNestedGroup()
        {
            var inputXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<xs:schema xmlns:xs=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://www.oenorm.at/schema/A2063/2015-07-15"" 
           xmlns:on=""http://www.oenorm.at/schema/A2063/2015-07-15"" 
           targetNamespace=""http://www.oenorm.at/schema/A2063/2015-07-15""
           elementFormDefault=""qualified"" attributeFormDefault=""unqualified"">
  <xs:complexType name=""ontext.Luecke.type"" mixed=""true"">
    <xs:group ref=""ontext.Luecke.content""/>
    <xs:attributeGroup ref=""ontext.Luecke.attlist""/>
  </xs:complexType>
  <xs:group name=""ontext.Luecke.content"">
    <xs:sequence>
      <xs:group ref=""ontext.Luecke.class"" minOccurs=""0"" maxOccurs=""unbounded""/>
    </xs:sequence>
  </xs:group>
  <xs:group name=""ontext.Luecke.class"">
    <xs:choice>
      <xs:element name=""al"" type=""ontext.Luecke.type""></xs:element>
      <xs:element name=""bl"" type=""ontext.Luecke.type""></xs:element>
      <xs:element name=""blo"" type=""ontext.Luecke.type""></xs:element>
      <xs:element name=""rw"" type=""ontext.Luecke.type""></xs:element>
    </xs:choice>
  </xs:group>
  <xs:attributeGroup name=""ontext.Luecke.attlist"">
    <xs:attribute name=""kennung"" type=""ontext.Lueckenkennung.type"" />
  </xs:attributeGroup>
</xs:schema>";
            var expected = @"<?xml version=""1.0"" encoding=""utf-8""?>
<xs:schema xmlns:xs=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://www.oenorm.at/schema/A2063/2015-07-15"" xmlns:on=""http://www.oenorm.at/schema/A2063/2015-07-15"" targetNamespace=""http://www.oenorm.at/schema/A2063/2015-07-15"" elementFormDefault=""qualified"" attributeFormDefault=""unqualified"">
  <xs:complexType name=""ontext.Luecke.type"" mixed=""true"">
    <xs:sequence>
      <xs:choice>
        <xs:element name=""al"" type=""ontext.Luecke.type""></xs:element>
        <xs:element name=""bl"" type=""ontext.Luecke.type""></xs:element>
        <xs:element name=""blo"" type=""ontext.Luecke.type""></xs:element>
        <xs:element name=""rw"" type=""ontext.Luecke.type""></xs:element>
      </xs:choice>
    </xs:sequence>
    <xs:attribute name=""kennung"" type=""ontext.Lueckenkennung.type"" />
  </xs:complexType>
</xs:schema>";
            var actual = RunXmlStreamThroughGroupFlattener(inputXml);
            Assert.Equal(expected, actual);
        }

        private string RunXmlStreamThroughGroupFlattener(string xmlString)
        {
            var memStream = new MemoryStream();
            using (var sw = new StreamWriter(memStream))
            {
                sw.Write(xmlString);
                sw.Flush();
                memStream.Position = 0;
                using (var flattenedStream = new XmlTools.GroupFlattener.Flattener(memStream).FlattenGroups())
                {
                    using (var sr = new StreamReader(flattenedStream))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }

        [Theory]
        [InlineData(GroupFlattenerTestFile.onformel)]
        [InlineData(GroupFlattenerTestFile.onlb)]
        [InlineData(GroupFlattenerTestFile.onlv)]
        [InlineData(GroupFlattenerTestFile.ontext)]
        [InlineData(GroupFlattenerTestFile.ontypdef)]
        public void CanTransformRealWorldFile(GroupFlattenerTestFile testFile)
        {
            using (var inputStream = TestFilesFactory.GetStreamForTestFile(testFile))
            {
                using (var resStrm = new XmlTools.GroupFlattener.Flattener(inputStream).FlattenGroups())
                {
                    using (var strmRdr = new StreamReader(resStrm))
                    {
                        var text = strmRdr.ReadToEnd();
                        Assert.DoesNotContain(":group", text);
                        Assert.DoesNotContain(":attributeGroup", text);
                    }
                }
            }
        }

        public class FlattenOnlySpecificGroups
        {
            [Fact]
            public void FlattenOnlyGivenGroups()
            {
                var groupTypesToFlatten = new List<string>
                {
                    "ontext.Inline.mix"
                };

                var xmlStream = new MemoryStream();
                using (var streamWriter = new StreamWriter(xmlStream))
                {
                    streamWriter.Write(XsdSchema);
                    streamWriter.Flush();
                    xmlStream.Position = 0;
                    using (var flattened = new XmlTools.GroupFlattener.Flattener(xmlStream).FlattenGroups(groupTypesToFlatten))
                    {
                        using (var streamReader = new StreamReader(flattened))
                        {
                            var text = streamReader.ReadToEnd();
                            Assert.DoesNotContain(@"ref=""ontext.Inline.mix""", text);
                            Assert.Contains(@"ref=""ontext.InlPres.class""", text);
                        }
                    }
                }
            }

            private static string XsdSchema => @"<?xml version=""1.0"" encoding=""utf-8""?>
<xs:schema id=""testschema""
    targetNamespace=""http://tempuri.org/testschema.xsd""
    elementFormDefault=""qualified""
    xmlns=""http://tempuri.org/testschema.xsd""
    xmlns:mstns=""http://tempuri.org/testschema.xsd""
    xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""testroot"">
    <xs:complexType>
      <xs:group ref=""ontext.Inline.mix"" />
    </xs:complexType>
  </xs:element>
  <xs:group name=""ontext.Inline.mix"">
    <xs:choice>
      <xs:group ref=""ontext.Inline.class"" />
    </xs:choice>
  </xs:group>
  <xs:group name=""ontext.Inline.class"">
    <xs:choice>
      <xs:group ref=""ontext.InlPres.class"" />
    </xs:choice>
  </xs:group>
  <xs:group name=""ontext.InlPres.class"">
    <xs:choice>
      <xs:element name=""tt"" type=""ontext.InlPres.type"" />
      <xs:element name=""i"" type=""ontext.InlPres.type"" />
      <xs:element name=""b"" type=""ontext.InlPres.type"" />
      <xs:element name=""sub"" type=""ontext.InlPres.type"" />
      <xs:element name=""sup"" type=""ontext.InlPres.type"" />
      <xs:element name=""u"" type=""ontext.InlPres.type"" />
    </xs:choice>
  </xs:group>
  <xs:complexType name=""ontext.InlPres.type"" mixed=""true"">
    <xs:group ref=""ontext.InlPres.content"" />
  </xs:complexType>
  <xs:group name=""ontext.InlPres.content"">
    <xs:sequence>
      <!-- HERE HE IS THE LITTLE GUY -->
      <xs:group ref=""ontext.Inline.mix"" minOccurs=""0"" maxOccurs=""unbounded"" />
    </xs:sequence>
  </xs:group>
</xs:schema>
";
        }
    }
}
