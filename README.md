# DocumentFormat.OpenXml.NativeAOT

## Important Note About File Formats / 关于文件格式的重要说明

**English:**

This repository is specifically for working with **Office Open XML formats** (.xlsx, .docx, .pptx) using the DocumentFormat.OpenXml library with .NET 9 Native AOT compilation.

### .xlsx vs .xls: What's the Difference?

- **.xlsx** (Office Open XML): Modern Excel format introduced in 2007, based on XML and ZIP compression. **Supported by DocumentFormat.OpenXml**
- **.xls** (BIFF): Legacy Excel binary format used in Excel 97-2003. **NOT supported by DocumentFormat.OpenXml**

### Why DocumentFormat.OpenXml Cannot Handle .xls Files

DocumentFormat.OpenXml is designed exclusively for the Office Open XML standard. It cannot read or write .xls files because:
1. .xls uses a proprietary binary format (BIFF - Binary Interchange File Format)
2. .xlsx uses an open standard XML-based format (Office Open XML)

### Alternative Solutions for .xls Files

If you need to work with .xls files in .NET, consider these libraries:
- **NPOI**: Open-source library that supports both .xls and .xlsx formats
- **ExcelDataReader**: Lightweight library for reading Excel files (both .xls and .xlsx)
- **EPPlus**: Supports .xlsx format with a different API

---

**中文:**

本仓库专门用于使用 DocumentFormat.OpenXml 库和 .NET 9 Native AOT 编译来处理 **Office Open XML 格式** (.xlsx, .docx, .pptx)。

### .xlsx 与 .xls：有什么区别？

- **.xlsx** (Office Open XML)：2007 年引入的现代 Excel 格式，基于 XML 和 ZIP 压缩。**DocumentFormat.OpenXml 支持此格式**
- **.xls** (BIFF)：Excel 97-2003 使用的旧版 Excel 二进制格式。**DocumentFormat.OpenXml 不支持此格式**

### 为什么 DocumentFormat.OpenXml 无法处理 .xls 文件

DocumentFormat.OpenXml 专门为 Office Open XML 标准设计。它无法读取或写入 .xls 文件，因为：
1. .xls 使用专有的二进制格式（BIFF - Binary Interchange File Format）
2. .xlsx 使用开放标准的 XML 格式（Office Open XML）

### .xls 文件的替代解决方案

如果您需要在 .NET 中处理 .xls 文件，请考虑以下库：
- **NPOI**：开源库，同时支持 .xls 和 .xlsx 格式
- **ExcelDataReader**：用于读取 Excel 文件的轻量级库（支持 .xls 和 .xlsx）
- **EPPlus**：支持 .xlsx 格式，使用不同的 API

---

## Project Purpose / 项目目的

This project demonstrates that DocumentFormat.OpenXml is fully compatible with .NET 9 Native AOT compilation for **.xlsx file operations**.

本项目演示 DocumentFormat.OpenXml 与 .NET 9 Native AOT 编译完全兼容，用于 **.xlsx 文件操作**。