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
    }
}
