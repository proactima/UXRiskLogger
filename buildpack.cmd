mkdir release

@call msbuild UXRiskLogger\UXRiskLogger.csproj /t:clean
@call msbuild UXRiskLogger\UXRiskLogger.csproj /p:Configuration=Release

.nuget\NuGet.exe pack -sym UXRiskLogger\UXRiskLogger.csproj -OutputDirectory release