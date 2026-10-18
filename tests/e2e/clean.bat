@echo off
rem clean.bat - apaga os artefatos GERADOS do SDK dotnet (exemplos + logs)
del /f /q "D:\ProjetoFalaAI\FalaAI\FalaAI_api\sdks\dotnet\examples\*.cs" 2>nul
del /f /q "D:\ProjetoFalaAI\FalaAI\FalaAI_api\sdks\dotnet\examples\README.md" 2>nul
del /f /q "D:\ProjetoFalaAI\FalaAI\FalaAI_api\sdks\dotnet\tests\e2e\logs\dotnet_*.json" 2>nul
del /f /q "D:\ProjetoFalaAI\FalaAI\FalaAI_api\sdks\dotnet\tests\e2e\logs\dotnet_*.html" 2>nul
echo done
pause