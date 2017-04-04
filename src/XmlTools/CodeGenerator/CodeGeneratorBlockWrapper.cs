using System;
using System.Text;

namespace XmlTools.CodeGenerator
{
    public class CodeGeneratorBlockWrapper : IDisposable
    {
        public CodeGeneratorBlockWrapper(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
            _stringBuilder.AppendLine("{");
        }

        private readonly StringBuilder _stringBuilder;

        public void Dispose()
        {
            _stringBuilder.AppendLine("}");
        }
    }
}