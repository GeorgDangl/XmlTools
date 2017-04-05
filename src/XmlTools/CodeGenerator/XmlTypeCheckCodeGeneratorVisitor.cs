using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlTools.CodeGenerator
{
    public class XmlTypeCheckCodeGeneratorVisitor
    {
        public XmlTypeCheckCodeGeneratorVisitor(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
            SetupXmlTypeCheckMethodGenerators();
        }

        private readonly StringBuilder _stringBuilder;
        private List<IXmlTypeCheckMethodGenerator> _xmlTypeCheckMethodGenerators;

        private void SetupXmlTypeCheckMethodGenerators()
        {
            _xmlTypeCheckMethodGenerators = new List<IXmlTypeCheckMethodGenerator>();
            _xmlTypeCheckMethodGenerators.Add(new XmlUnknownTypeCheckMethodGenerator(_stringBuilder));
            _xmlTypeCheckMethodGenerators.Add(new XmlSimpleTypeCheckMethodGenerator(_stringBuilder));
            _xmlTypeCheckMethodGenerators.Add(new XmlComplexTypeCheckMethodGenerator(_stringBuilder));
            _xmlTypeCheckMethodGenerators.Add(new XmlEnumerationTypeCheckMethodGenerator(_stringBuilder));
            _xmlTypeCheckMethodGenerators.Add(new XmlSimpleContentComplexTypeCheckMethodGenerator(_stringBuilder));
            _xmlTypeCheckMethodGenerators.Add(new XmlSimpleContentEnumerationComplexTypeCheckMethodGenerator(_stringBuilder));
        }

        public void GenerateTypeCheckingMethod(XmlType xmlType)
        {
            var checkMethodName = XmlCodeGeneratorMethodNameProvider.GetNameForElementTypeCheckMethod(xmlType);
            _stringBuilder.AppendLine($"private void {checkMethodName}(XElement {CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME})");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                GenerateCheckMethodBody(xmlType);
            }
        }

        private void GenerateCheckMethodBody(XmlType xmlType)
        {
            var generatorToUse = _xmlTypeCheckMethodGenerators.Single(g => g.CanGenerateCodeForType(xmlType));
            generatorToUse.GenerateCheckMethodBody(xmlType);
        }
    }
}