echo Build XmlTools.Console
dotnet build ..\XmlTools.Console -c Release
echo Create NuGet package
dotnet pack -c Release -o .\