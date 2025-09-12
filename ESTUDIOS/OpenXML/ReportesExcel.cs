using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ESTUDIOS.OpenXML
{
    public static class ReportesExcel
    {
        public static void UpdateNom35PieChart(Stream workbookStream, DTONom35CategoryDomain pieChartData)
        {
            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(workbookStream, true))
            {
                WorksheetPart worksheetPart = RetrieveSheetPartByName(spreadSheet, "Hoja1");
                Worksheet worksheet = worksheetPart.Worksheet;
                SheetData sheetData = worksheet.GetFirstChild<SheetData>();
                Cell cellNulo = sheetData.Descendants<Cell>().FirstOrDefault(c => c.CellReference.Value == "B2");
                Cell cellBajo = sheetData.Descendants<Cell>().FirstOrDefault(c => c.CellReference.Value == "B3");
                Cell cellMedio = sheetData.Descendants<Cell>().FirstOrDefault(c => c.CellReference.Value == "B4");
                Cell cellAlto = sheetData.Descendants<Cell>().FirstOrDefault(c => c.CellReference.Value == "B5");
                Cell cellMuyAlto = sheetData.Descendants<Cell>().FirstOrDefault(c => c.CellReference.Value == "B6");
                
                SetDecimalCell(cellNulo, pieChartData.NuloPorcentaje);
                SetDecimalCell(cellBajo, pieChartData.BajoPorcentaje);
                SetDecimalCell(cellMedio, pieChartData.MedioPorcentaje);
                SetDecimalCell(cellAlto, pieChartData.AltoPorcentaje);
                SetDecimalCell(cellMuyAlto, pieChartData.MuyAltoPorcentaje);
                worksheet.Save();
            }
        }

        public static void UpdateNom35ChartAcontecimientosTraumaticos(Stream workbookStream, DTOAcontecimientosTraumaticos acontTraumaticosData)
        {
            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(workbookStream, true))
            {
                WorksheetPart worksheetPart = RetrieveSheetPartByName(spreadSheet, "Hoja1");
                Worksheet worksheet = worksheetPart.Worksheet;
                SheetData sheetData = worksheet.GetFirstChild<SheetData>();
                Cell cellNoRequiereAtencion = sheetData.Descendants<Cell>().FirstOrDefault(c => c.CellReference.Value == "B2");
                Cell cellRequiereAtencion = sheetData.Descendants<Cell>().FirstOrDefault(c => c.CellReference.Value == "B3");

                SetDecimalCell(cellNoRequiereAtencion, acontTraumaticosData.PorcentajeNoRequiereAtencionClinica);
                SetDecimalCell(cellRequiereAtencion, acontTraumaticosData.PorcentajeRequiereAtencionClinica);
                
                worksheet.Save();
            }
        }

        public static WorksheetPart RetrieveSheetPartByName(SpreadsheetDocument spreadSheet, string sheetName)
        {
            IEnumerable<Sheet> sheets =
             spreadSheet.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().Where(s => s.Name == sheetName);

            if (sheets.Count() == 0)
                return null;

            string relationshipId = sheets.First().Id.Value;
            WorksheetPart worksheetPart = (WorksheetPart)
            spreadSheet.WorkbookPart.GetPartById(relationshipId);
            return worksheetPart;
        }

        public static void SetStringCell(Cell cell, string value)
        {
            cell.CellValue = new CellValue(value);
            cell.DataType = new EnumValue<CellValues>(CellValues.String);
        }

        public static void SetIntCell(Cell cell, int value)
        {
            cell.CellValue = new CellValue(value);
            cell.DataType = new EnumValue<CellValues>(CellValues.Number);
        }

        public static void SetDecimalCell(Cell cell, double value)
        {
            cell.CellValue = new CellValue(value);
            cell.DataType = new EnumValue<CellValues>(CellValues.Number);
        }

        public static void SetDatetimeCell(Cell cell, DateTime value)
        {
            cell.CellValue = new CellValue(value);
            cell.DataType = new EnumValue<CellValues>(CellValues.Date);
        }
    }
}
