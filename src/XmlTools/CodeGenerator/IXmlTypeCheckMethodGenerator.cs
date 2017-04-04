namespace XmlTools.CodeGenerator
{
    public interface IXmlTypeCheckMethodGenerator
    {
        bool CanGenerateCodeForType(XmlType xmlType);
        void GenerateCheckMethodBody(XmlType xmlType);
    }
}