using System.Text;

namespace XmlTools.CodeGenerator
{
    public class XmlDateTimeTypeCheckMethodGenerator : IXmlTypeCheckMethodGenerator
    {
        public XmlDateTimeTypeCheckMethodGenerator(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }

        private readonly StringBuilder _stringBuilder;

        public bool CanGenerateCodeForType(XmlType xmlType)
        {
            return xmlType.GetType() == typeof(XmlDateTimeType);
        }

        public void GenerateCheckMethodBody(XmlType xmlType)
        {
            _stringBuilder.AppendLine($"var elementDateValue = {CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME}.Value;");
            _stringBuilder.AppendLine("string regexPattern = @\"^([\\d]{2}[^\\d][\\d]{2}[^\\d][\\d]{4})$\";");
            _stringBuilder.AppendLine("if (Regex.IsMatch(elementDateValue, regexPattern))");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                _stringBuilder.AppendLine("// Replaces dates in a XML file that are not correctly formatted according to the XML specification.");
                _stringBuilder.AppendLine("// Use case: Sometimes a date is given in an European format, e.g. \"12.02.2015\" or \"12/02/2015\". This will be");
                _stringBuilder.AppendLine("// transformed to \"2015-02-15\" to comply with the XML Date specification.");
                _stringBuilder.AppendLine($"{CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME}.Value = elementDateValue.Substring(6, 4) + \"-\" + elementDateValue.Substring(3, 2) + \"-\" + elementDateValue.Substring(0, 2);");
            }
            _stringBuilder.AppendLine("else");
            using (new CodeGeneratorBlockWrapper(_stringBuilder))
            {
                _stringBuilder.AppendLine("try");
                using (new CodeGeneratorBlockWrapper(_stringBuilder))
                {
                    _stringBuilder.AppendLine("XmlConvert.ToDateTime(elementDateValue, XmlDateTimeSerializationMode.RoundtripKind);");
                }
                _stringBuilder.AppendLine("catch (FormatException)");
                using (new CodeGeneratorBlockWrapper(_stringBuilder))
                {
                    _stringBuilder.AppendLine($"{CodeGeneratorConstants.ELEMENT_CHECK_METHOD_ELEMENT_VARIABLE_NAME}.Remove();");
                }
            }
        }
    }
}
