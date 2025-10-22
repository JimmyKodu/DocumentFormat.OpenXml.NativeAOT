using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

Console.WriteLine("DocumentFormat.OpenXml Native AOT Test");
Console.WriteLine("=======================================");

// Create a sample Excel file
string filePath = "sample.xlsx";
CreateSampleExcelFile(filePath);
Console.WriteLine($"Created sample file: {filePath}");

// Modify the Excel file
ModifyExcelFile(filePath);
Console.WriteLine($"Modified file: {filePath}");

// Read and display the modified content
ReadExcelFile(filePath);
Console.WriteLine("\nTest completed successfully!");

static void CreateSampleExcelFile(string filePath)
{
    // Delete if exists
    if (File.Exists(filePath))
    {
        File.Delete(filePath);
    }

    using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
    {
        // Add a WorkbookPart to the document
        WorkbookPart workbookPart = document.AddWorkbookPart();
        workbookPart.Workbook = new Workbook();

        // Add a WorksheetPart to the WorkbookPart
        WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        worksheetPart.Worksheet = new Worksheet(new SheetData());

        // Add Sheets to the Workbook
        Sheets sheets = document.WorkbookPart!.Workbook.AppendChild(new Sheets());

        // Append a new worksheet and associate it with the workbook
        Sheet sheet = new Sheet()
        {
            Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
            SheetId = 1,
            Name = "Sheet1"
        };
        sheets.Append(sheet);

        // Get the sheetData cell table
        SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>()!;

        // Add some data to the worksheet
        Row row1 = new Row() { RowIndex = 1 };
        sheetData.Append(row1);

        Cell cell1 = new Cell() { CellReference = "A1" };
        cell1.CellValue = new CellValue("Name");
        cell1.DataType = new EnumValue<CellValues>(CellValues.String);
        row1.Append(cell1);

        Cell cell2 = new Cell() { CellReference = "B1" };
        cell2.CellValue = new CellValue("Value");
        cell2.DataType = new EnumValue<CellValues>(CellValues.String);
        row1.Append(cell2);

        Row row2 = new Row() { RowIndex = 2 };
        sheetData.Append(row2);

        Cell cell3 = new Cell() { CellReference = "A2" };
        cell3.CellValue = new CellValue("Original");
        cell3.DataType = new EnumValue<CellValues>(CellValues.String);
        row2.Append(cell3);

        Cell cell4 = new Cell() { CellReference = "B2" };
        cell4.CellValue = new CellValue("100");
        cell4.DataType = new EnumValue<CellValues>(CellValues.Number);
        row2.Append(cell4);

        workbookPart.Workbook.Save();
    }
}

static void ModifyExcelFile(string filePath)
{
    using (SpreadsheetDocument document = SpreadsheetDocument.Open(filePath, true))
    {
        WorkbookPart? workbookPart = document.WorkbookPart;
        WorksheetPart? worksheetPart = workbookPart?.WorksheetParts.First();
        SheetData? sheetData = worksheetPart?.Worksheet.GetFirstChild<SheetData>();

        if (sheetData != null)
        {
            // Modify cell A2
            Row? row2 = sheetData.Elements<Row>().FirstOrDefault(r => r.RowIndex?.Value == 2);
            if (row2 != null)
            {
                Cell? cellA2 = row2.Elements<Cell>().FirstOrDefault(c => c.CellReference == "A2");
                if (cellA2 != null)
                {
                    cellA2.CellValue = new CellValue("Modified");
                    cellA2.DataType = new EnumValue<CellValues>(CellValues.String);
                }

                Cell? cellB2 = row2.Elements<Cell>().FirstOrDefault(c => c.CellReference == "B2");
                if (cellB2 != null)
                {
                    cellB2.CellValue = new CellValue("200");
                    cellB2.DataType = new EnumValue<CellValues>(CellValues.Number);
                }
            }

            // Add a new row
            Row row3 = new Row() { RowIndex = 3 };
            sheetData.Append(row3);

            Cell cellA3 = new Cell() { CellReference = "A3" };
            cellA3.CellValue = new CellValue("New Row");
            cellA3.DataType = new EnumValue<CellValues>(CellValues.String);
            row3.Append(cellA3);

            Cell cellB3 = new Cell() { CellReference = "B3" };
            cellB3.CellValue = new CellValue("300");
            cellB3.DataType = new EnumValue<CellValues>(CellValues.Number);
            row3.Append(cellB3);

            worksheetPart?.Worksheet.Save();
        }
    }
}

static void ReadExcelFile(string filePath)
{
    Console.WriteLine("\nReading modified Excel file:");
    Console.WriteLine("----------------------------");

    using (SpreadsheetDocument document = SpreadsheetDocument.Open(filePath, false))
    {
        WorkbookPart? workbookPart = document.WorkbookPart;
        WorksheetPart? worksheetPart = workbookPart?.WorksheetParts.First();
        SheetData? sheetData = worksheetPart?.Worksheet.GetFirstChild<SheetData>();

        if (sheetData != null)
        {
            foreach (Row row in sheetData.Elements<Row>())
            {
                foreach (Cell cell in row.Elements<Cell>())
                {
                    string? value = cell.CellValue?.Text;
                    Console.WriteLine($"Cell {cell.CellReference}: {value}");
                }
            }
        }
    }
}
