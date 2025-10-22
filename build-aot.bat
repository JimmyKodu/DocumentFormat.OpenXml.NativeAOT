@echo off
REM Build script for DocumentFormat.OpenXml Native AOT project (Windows)

echo ==================================
echo DocumentFormat.OpenXml Native AOT
echo Build and Test Script (Windows)
echo ==================================
echo.

REM Navigate to project directory
cd OpenXmlAotTest

REM Check .NET version
echo Checking .NET SDK version...
dotnet --version
echo.

REM Restore packages
echo Restoring NuGet packages...
dotnet restore
if errorlevel 1 (
    echo Package restore failed!
    exit /b 1
)
echo.

REM Build project
echo Building project...
dotnet build -c Release
if errorlevel 1 (
    echo Build failed!
    exit /b 1
)
echo.

REM Run standard version
echo Running standard .NET version...
dotnet run -c Release
if errorlevel 1 (
    echo Run failed!
    exit /b 1
)
echo.

REM Publish with Native AOT
echo Publishing with Native AOT compilation...
echo This may take a few minutes...
dotnet publish -c Release
if errorlevel 1 (
    echo Native AOT publish failed!
    exit /b 1
)
echo.

REM Run AOT version
echo Running Native AOT compiled version...
bin\Release\net9.0\win-x64\publish\OpenXmlAotTest.exe
if errorlevel 1 (
    echo AOT executable run failed!
    exit /b 1
)
echo.

REM Show binary size
echo ==================================
echo Native AOT Binary Information:
echo ==================================
dir bin\Release\net9.0\win-x64\publish\OpenXmlAotTest.exe
echo.

echo ==================================
echo Build and test completed successfully!
echo ==================================
