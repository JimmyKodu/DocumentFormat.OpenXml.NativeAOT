#!/bin/bash

# Build script for DocumentFormat.OpenXml Native AOT project

echo "=================================="
echo "DocumentFormat.OpenXml Native AOT"
echo "Build and Test Script"
echo "=================================="
echo ""

# Navigate to project directory
cd OpenXmlAotTest

# Check .NET version
echo "Checking .NET SDK version..."
dotnet --version
echo ""

# Restore packages
echo "Restoring NuGet packages..."
dotnet restore
echo ""

# Build project
echo "Building project..."
dotnet build -c Release
if [ $? -ne 0 ]; then
    echo "Build failed!"
    exit 1
fi
echo ""

# Run standard version
echo "Running standard .NET version..."
dotnet run -c Release
if [ $? -ne 0 ]; then
    echo "Run failed!"
    exit 1
fi
echo ""

# Publish with Native AOT
echo "Publishing with Native AOT compilation..."
echo "This may take a few minutes..."
dotnet publish -c Release
if [ $? -ne 0 ]; then
    echo "Native AOT publish failed!"
    exit 1
fi
echo ""

# Run AOT version
echo "Running Native AOT compiled version..."
./bin/Release/net9.0/linux-x64/publish/OpenXmlAotTest
if [ $? -ne 0 ]; then
    echo "AOT executable run failed!"
    exit 1
fi
echo ""

# Show binary size
echo "=================================="
echo "Native AOT Binary Information:"
echo "=================================="
ls -lh bin/Release/net9.0/linux-x64/publish/OpenXmlAotTest
file bin/Release/net9.0/linux-x64/publish/OpenXmlAotTest
echo ""

echo "=================================="
echo "Build and test completed successfully!"
echo "=================================="
