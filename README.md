# DocumentFormat.OpenXml.NativeAOT

A demonstration project for using DocumentFormat.OpenXml with .NET 9 Native AOT compilation.

## Overview

This project demonstrates how to use the DocumentFormat.OpenXml library to create and modify Excel (.xlsx) files in a .NET 9 application compiled with Native AOT (Ahead-of-Time compilation). Native AOT compilation produces a self-contained executable with faster startup time and lower memory usage.

## Features

- ✅ Create Excel (.xlsx) files programmatically
- ✅ Modify existing Excel files
- ✅ Read and display Excel file contents
- ✅ Fully compatible with .NET 9 Native AOT
- ✅ No .NET runtime required for deployment

## Project Structure

```
OpenXmlAotTest/
├── OpenXmlAotTest.csproj  # Project file with Native AOT enabled
└── Program.cs              # Main application demonstrating Excel operations
```

## Requirements

- .NET 9 SDK or later
- Linux, macOS, or Windows operating system

## Building the Project

### Standard Build

```bash
cd OpenXmlAotTest
dotnet build
```

### Running with .NET Runtime

```bash
cd OpenXmlAotTest
dotnet run
```

### Native AOT Compilation

To compile the application with Native AOT:

```bash
cd OpenXmlAotTest
dotnet publish -c Release
```

The compiled executable will be located at:
- Linux: `bin/Release/net9.0/linux-x64/publish/OpenXmlAotTest`
- Windows: `bin/Release/net9.0/win-x64/publish/OpenXmlAotTest.exe`
- macOS: `bin/Release/net9.0/osx-x64/publish/OpenXmlAotTest`

### Running the Native AOT Executable

```bash
cd OpenXmlAotTest/bin/Release/net9.0/linux-x64/publish
./OpenXmlAotTest
```

## What the Application Does

The application demonstrates three main operations:

1. **Create**: Creates a new Excel file (`sample.xlsx`) with a simple table containing headers and data
2. **Modify**: Modifies the existing file by:
   - Updating cell values
   - Adding new rows
3. **Read**: Reads and displays all cell values from the modified file

## Native AOT Configuration

The project is configured for Native AOT in `OpenXmlAotTest.csproj`:

```xml
<PropertyGroup>
    <PublishAot>true</PublishAot>
    <InvariantGlobalization>false</InvariantGlobalization>
</PropertyGroup>
```

- `PublishAot`: Enables Native AOT compilation
- `InvariantGlobalization`: Disabled to support culture-specific operations

## Package Dependencies

- **DocumentFormat.OpenXml** (v3.2.0): Library for working with Office Open XML documents

## Performance Benefits

Native AOT compilation provides several benefits:

- **Faster Startup**: No JIT compilation required at runtime
- **Lower Memory Usage**: Smaller memory footprint
- **Self-Contained**: No .NET runtime installation required
- **Smaller Deployment**: Single executable file (approximately 25MB)

## Notes

- This project works with **.xlsx** files (Office Open XML format), not **.xls** files (legacy binary format)
- The DocumentFormat.OpenXml library is fully compatible with Native AOT in .NET 9
- Generated Excel files are compatible with Microsoft Excel, LibreOffice Calc, and other spreadsheet applications

## License

This is a demonstration project for educational purposes.

## 中文说明

这是一个演示项目，展示如何在 .NET 9 Native AOT 编译环境中使用 DocumentFormat.OpenXml 库来创建和修改 Excel 文件。

### 构建和运行

```bash
# 标准编译
cd OpenXmlAotTest
dotnet build

# 运行
dotnet run

# Native AOT 编译
dotnet publish -c Release

# 运行 AOT 编译后的可执行文件
cd bin/Release/net9.0/linux-x64/publish
./OpenXmlAotTest
```

### 功能特性

- 创建 Excel 文件
- 修改现有 Excel 文件
- 读取并显示 Excel 文件内容
- 完全支持 .NET 9 Native AOT 编译
- 无需 .NET 运行时即可部署