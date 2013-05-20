using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using Lsi.Libs.LsiNLogger;
using SmartXLS;
using Spire.Xls;
using Syncfusion.XlsIO;
using ExcelVersion = Syncfusion.XlsIO.ExcelVersion;

namespace ConApp_VS2k8
{
    public class ExcelTest
    {
        private const string NameKey = "#NAME#";
        private static readonly string FileName = string.Format("{0}_{1}.xlsx", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"), NameKey);

        private static void SaveFile(Byte[] fileBytes, string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            fileStream.Write(fileBytes, 0, fileBytes.Length);
            fileStream.Close();
        }

        public static void SaveSmartXLS(bool isXlsx, bool withFilter, DataTable data, string dir)
        {
            string filePath = Path.Combine(dir, FileName.Replace(NameKey, isXlsx ? "SmartXLSX" : "SmartXLS"));
            DateTime begin = DateTime.Now;
            //LsiLogger.Trace("Begin of SaveSmartXLS(...)");
            WorkBook xls = new WorkBook();
            xls.ImportDataTable(data, true, 0, 0, data.Rows.Count, data.Columns.Count);
            //xls.write(filePath);

            if (withFilter)
                xls.autoFilter();

            byte[] xlsData;
            using (MemoryStream output = new MemoryStream())
            {
                if (!isXlsx)
                    xls.write(output);
                else
                    xls.writeXLSX(output);

                xlsData = output.ToArray();
            }
            SaveFile(xlsData, filePath);
            //LsiLogger.Trace("End of SaveSmartXLS(...)");
            DateTime end = DateTime.Now;
            LsiLogger.Trace(string.Format("Duration of SaveSmartXLS(...) - {0},{1}", Path.GetFileName(filePath), (end - begin)));
        }

        public static void CreateSurveyExcelSyncfusion0 (DataTable table, string dir)
        {
            DateTime begin = DateTime.Now;

            ArrayList messages = new ArrayList();
            string filePath = Path.Combine(dir, FileName.Replace(NameKey, "Syncfusion"));
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2010;

            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet worksheet = workbook.Worksheets[0];
            

            //GlobalStyles
            
            
            
            DateTime beginDateTimeFormat = DateTime.Now;
            IRanges dateTimeColl = worksheet.CreateRangesCollection();
            dateTimeColl.Add(worksheet.Range[1, 5, table.Rows.Count + 1, 5]);
            //dateTimeColl.NumberFormat = "mm/dd/yyyy h:mm tt";
            dateTimeColl.NumberFormat = "mm/dd/yyyy hh:m am/pm";
            messages.Add(string.Format("DateTimeFormat:\t{0}", (DateTime.Now - beginDateTimeFormat)));

            //Header
            DateTime beginHeaderFormat = DateTime.Now;
            IRanges header = worksheet.CreateRangesCollection();
            header.Add(worksheet.Range[1, 1, 1, table.Columns.Count]);
            header.VerticalAlignment = ExcelVAlign.VAlignCenter;
            header.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            header.CellStyle.Font.Bold = true;
            header.CellStyle.Font.Size = 12;
            header.CellStyle.Font.FontName = "Arial";
            header.CellStyle.Font.RGBColor = Color.Black;
            header.CellStyle.Color = Color.FromArgb(192, 192, 192);
            header.CellStyle.Locked = true;
            header.RowHeight = 36.75;
            header.CellStyle.Borders.LineStyle = ExcelLineStyle.Thin;
            header.CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            header.CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;
            messages.Add(string.Format("HeaderFormat:\t{0}\n", (DateTime.Now - beginHeaderFormat)));

            //Body
            DateTime beginBodyFormat = DateTime.Now;
            IRanges data = worksheet.CreateRangesCollection();
            data.Add(worksheet.Range[2, 1, table.Rows.Count + 1, table.Columns.Count]);
            data.CellStyle.Font.Size = 10;
            data.RowHeight = 31.50;
            data.CellStyle.Color = Color.FromArgb(255, 255, 204);
            data.VerticalAlignment = ExcelVAlign.VAlignCenter;
            data.CellStyle.Font.FontName = "Arial";
            data.CellStyle.Font.RGBColor = Color.Black;
            data.CellStyle.Borders.LineStyle = ExcelLineStyle.Thin;
            data.CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            data.CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;
            messages.Add(string.Format("BodyFormat:\t{0}\n", (DateTime.Now - beginBodyFormat)));

            DateTime beginAutoFilters = DateTime.Now;
            IRanges rangesOne = worksheet.CreateRangesCollection();
            rangesOne.Add(worksheet.Range[1, 1, table.Rows.Count, table.Columns.Count]);
            worksheet.AutoFilters.FilterRange = rangesOne;
            messages.Add(string.Format("AutoFilters:\t{0}", (DateTime.Now - beginAutoFilters)));
            
            DateTime beginImport = DateTime.Now;
            worksheet.ImportDataTable(table, true, 1, 1, -1, -1, true);
            messages.Add(string.Format("Import:\t{0}", (DateTime.Now - beginImport)));

            DateTime beginAutofitColumn = DateTime.Now;
            for (int i = 1; i <= table.Columns.Count; i++)
                worksheet.AutofitColumn(i);
            messages.Add(string.Format("AutofitColumn:\t{0}", (DateTime.Now - beginAutofitColumn)));


            MemoryStream ms = new MemoryStream();
            DateTime beginSaveAsMemoryStream = DateTime.Now;
            workbook.SaveAs(ms);
            DateTime endSaveAsMemoryStream = DateTime.Now;
            messages.Add(string.Format("SaveAsMemoryStream:\t{0}", (endSaveAsMemoryStream - beginSaveAsMemoryStream)));

            //workbook.Close();
            //excelEngine.ThrowNotSavedOnDestroy = false;
            //excelEngine.Dispose();

            DateTime beginSaveFile = DateTime.Now;
            byte[] xlsData = ms.ToArray();
            SaveFile(xlsData, filePath);
            DateTime endSaveFile = DateTime.Now;
            messages.Add(string.Format("SaveFile:\t{0}", (endSaveFile - beginSaveFile)));

            //LsiLogger.Trace("End of CreateSurveyExcelSyncfusion(...)");
            DateTime end = DateTime.Now;
            messages.Add(string.Format("Total time:\t{0}", (end - begin)));
            LsiLogger.Trace(string.Format("Duration of CreateSurveyExcelSyncfusion(...) - {0},{1}", Path.GetFileName(filePath), (end - begin)));
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            foreach (string message in messages)
                sb.AppendLine(message);

            LsiLogger.Trace(string.Format("CreateSurveyExcelSyncfusion steps\n{0}", sb));
        }

        public static void CreateSurveyExcelSyncfusion(ExcelVersion version, bool withFilter, DataTable table, string dir)
        {
            LsiLogger.Trace("Memory 1:" + GC.GetTotalMemory(false) / 1024);
            ArrayList messages = new ArrayList();
            string filePath = Path.Combine(dir, FileName.Replace(NameKey, string.Format("Syncfusion_{0}", version)));
            DateTime begin = DateTime.Now;
            //LsiLogger.Trace("Begin of CreateSurveyExcelSyncfusion(...)");
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;

            application.DefaultVersion = version;

            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet worksheet = workbook.Worksheets[0];

            LsiLogger.Trace("Memory 2:" + GC.GetTotalMemory(false) / 1024);
            //GlobalStyles
            DateTime beginGlobalStyles = DateTime.Now;

            DateTime beginGlobalRange = DateTime.Now;
            IRanges all = worksheet.CreateRangesCollection();
            all.Add(worksheet.Range[1, 1, table.Rows.Count + 1, table.Columns.Count]);
            DateTime endGlobalRange = DateTime.Now;
            messages.Add(string.Format("\tGlobalRange:\t{0}", (endGlobalRange - beginGlobalRange)));

            DateTime beginVerticalAlignment = DateTime.Now;
            all.VerticalAlignment = ExcelVAlign.VAlignCenter;
            DateTime endVerticalAlignment = DateTime.Now;
            messages.Add(string.Format("\tVerticalAlignment:\t{0}", (endVerticalAlignment - beginVerticalAlignment)));

            DateTime beginFontName = DateTime.Now;
            all.CellStyle.Font.FontName = "Arial";
            DateTime endFontName = DateTime.Now;
            messages.Add(string.Format("\tFontName:\t{0}", (endFontName - beginFontName)));

            DateTime beginFontRGBColor = DateTime.Now;
            all.CellStyle.Font.RGBColor = Color.Black;
            DateTime endFontRGBColor = DateTime.Now;
            messages.Add(string.Format("\tFontRGBColor:\t{0}", (endFontRGBColor - beginFontRGBColor)));

            DateTime beginLineStyle = DateTime.Now;
            all.CellStyle.Borders.LineStyle = ExcelLineStyle.Thin;
            DateTime endLineStyle = DateTime.Now;
            messages.Add(string.Format("\tLineStyle:\t{0}", (endLineStyle - beginLineStyle)));

            DateTime beginDiagonalDown = DateTime.Now;
            all.CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            DateTime endDiagonalDown = DateTime.Now;
            messages.Add(string.Format("\tDiagonalDown:\t{0}", (endDiagonalDown - beginDiagonalDown)));

            DateTime beginDiagonalUp = DateTime.Now;
            all.CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;
            DateTime endDiagonalUp = DateTime.Now;
            messages.Add(string.Format("\tDiagonalUp:\t{0}", (endDiagonalUp - beginDiagonalUp)));


            DateTime endGlobalStyles = DateTime.Now;
            messages.Add(string.Format("GlobalStyles:\t{0}\n", (endGlobalStyles - beginGlobalStyles)));

            DateTime beginColumnNames = DateTime.Now;
            worksheet.Range["A1"].Text = "Uid";
            worksheet.Range["B1"].Text = "Suid";
            worksheet.Range["C1"].Text = "Survey";
            worksheet.Range["D1"].Text = "Location";
            worksheet.Range["E1"].Text = "Date / Time	Name";
            worksheet.Range["F1"].Text = "Prompt 1";
            worksheet.Range["G1"].Text = "Prompt 2";
            worksheet.Range["H1"].Text = "Prompt 3";
            worksheet.Range["I1"].Text = "Prompt 4";
            worksheet.Range["J1"].Text = "Prompt 5";
            worksheet.Range["K1"].Text = "Duration (sec)";
            worksheet.Range["L1"].Text = "Expired";
            DateTime endColumnNames = DateTime.Now;
            messages.Add(string.Format("ColumnNames:\t{0}", (endColumnNames - beginColumnNames)));

            DateTime beginDateTimeFormat = DateTime.Now;
            IRanges dateTimeColl = worksheet.CreateRangesCollection();
            dateTimeColl.Add(worksheet.Range[1, 5, table.Rows.Count + 1, 5]);
            //dateTimeColl.NumberFormat = "mm/dd/yyyy h:mm tt";
            dateTimeColl.NumberFormat = "mm/dd/yyyy hh:mm";
            DateTime endDateTimeFormat = DateTime.Now;
            messages.Add(string.Format("DateTimeFormat:\t{0}", (endDateTimeFormat - beginDateTimeFormat)));

            LsiLogger.Trace("Memory 3:" + GC.GetTotalMemory(false) / 1024);
            //Header
            DateTime beginHeaderFormat = DateTime.Now;
            IRanges header = worksheet.CreateRangesCollection();
            header.Add(worksheet.Range[1, 1, 1, table.Columns.Count]);
            header.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            header.CellStyle.Font.Bold = true;
            header.CellStyle.Font.Size = 12;
            header.RowHeight = 36.75;
            header.CellStyle.Color = Color.FromArgb(192, 192, 192);
            header.CellStyle.Locked = true;
            DateTime endHeaderFormat = DateTime.Now;
            messages.Add(string.Format("HeaderFormat:\t{0}\n", (endHeaderFormat - beginHeaderFormat)));

            LsiLogger.Trace("Memory 4:" + GC.GetTotalMemory(false) / 1024);
            //Body
            DateTime beginBodyFormat = DateTime.Now;
            IRanges data = worksheet.CreateRangesCollection();
            data.Add(worksheet.Range[2, 1, table.Rows.Count + 1, table.Columns.Count]);

            DateTime beginFontSize = DateTime.Now;
            data.CellStyle.Font.Size = 10;
            DateTime endFontSize = DateTime.Now;
            messages.Add(string.Format("\tFontSize:\t{0}", (endFontSize - beginFontSize)));

            DateTime beginRowHeight = DateTime.Now;
            data.RowHeight = 31.50;
            DateTime endRowHeight = DateTime.Now;
            messages.Add(string.Format("\tRowHeight:\t{0}", (endRowHeight - beginRowHeight)));


            DateTime beginColor = DateTime.Now;
            data.CellStyle.Color = Color.FromArgb(255, 255, 204);
            DateTime endColor = DateTime.Now;
            messages.Add(string.Format("\tColor:\t{0}", (endColor - beginColor)));



            DateTime endBodyFormat = DateTime.Now;
            messages.Add("\t---------------------------");
            messages.Add(string.Format("BodyFormat:\t{0}\n", (endBodyFormat - beginBodyFormat)));

            if (withFilter)
            {
                LsiLogger.Trace("Memory 5:" + GC.GetTotalMemory(false) / 1024);
                DateTime beginAutoFilters = DateTime.Now;
                IRanges rangesOne = worksheet.CreateRangesCollection();
                rangesOne.Add(worksheet.Range[1, 1, table.Rows.Count, table.Columns.Count]);
                worksheet.AutoFilters.FilterRange = rangesOne;
                DateTime endAutoFilters = DateTime.Now;
                messages.Add(string.Format("AutoFilters:\t{0}", (endAutoFilters - beginAutoFilters)));
            }

            LsiLogger.Trace("Memory 6:" + GC.GetTotalMemory(false) / 1024);
            DateTime beginImport = DateTime.Now;
            worksheet.ImportDataTable(table, true, 1, 1, -1, -1, true);
            DateTime endImport = DateTime.Now;
            messages.Add(string.Format("Import:\t{0}", (endImport - beginImport)));

            LsiLogger.Trace("Memory 7:" + GC.GetTotalMemory(false) / 1024);
            DateTime beginAutofitColumn = DateTime.Now;
            for (int i = 1; i <= table.Columns.Count; i++)
                worksheet.AutofitColumn(i); //10000-7sec.
            DateTime endAutofitColumn = DateTime.Now;
            messages.Add(string.Format("AutofitColumn:\t{0}", (endAutofitColumn - beginAutofitColumn)));

            LsiLogger.Trace("Memory 8:" + GC.GetTotalMemory(false) / 1024);
            MemoryStream ms = new MemoryStream();
            DateTime beginSaveAsMemoryStream = DateTime.Now;
            workbook.SaveAs(ms);
            DateTime endSaveAsMemoryStream = DateTime.Now;
            messages.Add(string.Format("SaveAsMemoryStream:\t{0}", (endSaveAsMemoryStream - beginSaveAsMemoryStream)));

            //workbook.Close();
            //excelEngine.ThrowNotSavedOnDestroy = false;
            //excelEngine.Dispose();

            DateTime beginSaveFile = DateTime.Now;
            byte[] xlsData = ms.ToArray();
            SaveFile(xlsData, filePath);
            DateTime endSaveFile = DateTime.Now;
            messages.Add(string.Format("SaveFile:\t{0}", (endSaveFile - beginSaveFile)));

            //LsiLogger.Trace("End of CreateSurveyExcelSyncfusion(...)");
            DateTime end = DateTime.Now;
            messages.Add(string.Format("Total time:\t{0}", (end - begin)));
            LsiLogger.Trace(string.Format("Duration of CreateSurveyExcelSyncfusion(...) - {0},{1}", Path.GetFileName(filePath), (end - begin)));
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            foreach (string message in messages)
                sb.AppendLine(message);

            LsiLogger.Trace(string.Format("CreateSurveyExcelSyncfusion steps\n{0}", sb));
        }

        public static void CreateSurveyExcelSyncfusion1(ExcelVersion version, bool withFilter, DataTable table, string dir)
        {
            ArrayList messages = new ArrayList();
            string filePath = Path.Combine(dir, FileName.Replace(NameKey, string.Format("Syncfusion_{0}", version)));
            DateTime begin = DateTime.Now;
            //LsiLogger.Trace("Begin of CreateSurveyExcelSyncfusion(...)");
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;

            application.DefaultVersion = version;

            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet worksheet = workbook.Worksheets[0];

            DateTime beginColumnNames = DateTime.Now;
            worksheet.Range["A1"].Text = "Uid";
            worksheet.Range["B1"].Text = "Suid";
            worksheet.Range["C1"].Text = "Survey";
            worksheet.Range["D1"].Text = "Location";
            worksheet.Range["E1"].Text = "Date / Time	Name";
            worksheet.Range["F1"].Text = "Prompt 1";
            worksheet.Range["G1"].Text = "Prompt 2";
            worksheet.Range["H1"].Text = "Prompt 3";
            worksheet.Range["I1"].Text = "Prompt 4";
            worksheet.Range["J1"].Text = "Prompt 5";
            worksheet.Range["K1"].Text = "Duration (sec)";
            worksheet.Range["L1"].Text = "Expired";
            DateTime endColumnNames = DateTime.Now;
            messages.Add(string.Format("ColumnNames:\t{0}", (endColumnNames - beginColumnNames)));

            DateTime beginDateTimeFormat = DateTime.Now;
            IRanges dateTimeColl = worksheet.CreateRangesCollection();
            dateTimeColl.Add(worksheet.Range[1, 5, table.Rows.Count + 1, 5]);
            //dateTimeColl.NumberFormat = "mm/dd/yyyy h:mm tt";
            dateTimeColl.NumberFormat = "mm/dd/yyyy hh:mm";
            DateTime endDateTimeFormat = DateTime.Now;
            messages.Add(string.Format("DateTimeFormat:\t{0}", (endDateTimeFormat - beginDateTimeFormat)));

            //Header
            DateTime beginHeaderFormat = DateTime.Now;
            IRanges header = worksheet.CreateRangesCollection();
            header.Add(worksheet.Range[1, 1, 1, table.Columns.Count]);
            header.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            header.CellStyle.Font.Bold = true;
            header.CellStyle.Font.Size = 12;
            header.RowHeight = 36.75;
            header.CellStyle.Color = Color.FromArgb(192, 192, 192);
            header.CellStyle.Locked = true;
            header.VerticalAlignment = ExcelVAlign.VAlignCenter;
            header.CellStyle.Font.FontName = "Arial";
            header.CellStyle.Font.RGBColor = Color.Black;
            header.CellStyle.Borders.LineStyle = ExcelLineStyle.Thin;
            header.CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            header.CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;
            DateTime endHeaderFormat = DateTime.Now;
            messages.Add(string.Format("HeaderFormat:\t{0}\n", (endHeaderFormat - beginHeaderFormat)));

            //Body
            DateTime beginBodyFormat = DateTime.Now;
            IRanges data = worksheet.CreateRangesCollection();
            data.Add(worksheet.Range[2, 1, table.Rows.Count + 1, table.Columns.Count]);

            DateTime beginLineStyle = DateTime.Now;
            data.CellStyle.Borders.LineStyle = ExcelLineStyle.Thin;
            DateTime endLineStyle = DateTime.Now;
            messages.Add(string.Format("\tLineStyle:\t{0}", (endLineStyle - beginLineStyle)));

            DateTime beginDiagonalDown = DateTime.Now;
            data.CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            DateTime endDiagonalDown = DateTime.Now;
            messages.Add(string.Format("\tDiagonalDown:\t{0}", (endDiagonalDown - beginDiagonalDown)));

            DateTime beginDiagonalUp = DateTime.Now;
            data.CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;
            DateTime endDiagonalUp = DateTime.Now;
            messages.Add(string.Format("\tDiagonalUp:\t{0}", (endDiagonalUp - beginDiagonalUp)));


            IFont font = data.CellStyle.Font;

            DateTime beginFontName = DateTime.Now;
            //data.CellStyle.Font.FontName = "Arial";
            font.FontName = "Arial";
            DateTime endFontName = DateTime.Now;
            messages.Add(string.Format("\tFontName:\t{0}", (endFontName - beginFontName)));

            DateTime beginFontSize = DateTime.Now;
            //data.CellStyle.Font.Size = 10;
            font.Size = 10;
            DateTime endFontSize = DateTime.Now;
            messages.Add(string.Format("\tFontSize:\t{0}", (endFontSize - beginFontSize)));

            DateTime beginFontRGBColor = DateTime.Now;
            //data.CellStyle.Font.RGBColor = Color.Black;
            font.Color = ExcelKnownColors.Black;
            DateTime endFontRGBColor = DateTime.Now;
            messages.Add(string.Format("\tFontRGBColor:\t{0}", (endFontRGBColor - beginFontRGBColor)));

            DateTime beginVerticalAlignment = DateTime.Now;
            data.VerticalAlignment = ExcelVAlign.VAlignCenter;
            DateTime endVerticalAlignment = DateTime.Now;
            messages.Add(string.Format("\tVerticalAlignment:\t{0}", (endVerticalAlignment - beginVerticalAlignment)));

            DateTime beginFillPattern = DateTime.Now;
            data.CellStyle.FillPattern = ExcelPattern.Solid;
            DateTime endFillPattern = DateTime.Now;
            messages.Add(string.Format("\tFillPattern:\t{0}", (endFillPattern - beginFillPattern)));

            DateTime beginRowHeight = DateTime.Now;
            data.RowHeight = 31.50;
            DateTime endRowHeight = DateTime.Now;
            messages.Add(string.Format("\tRowHeight:\t{0}", (endRowHeight - beginRowHeight)));


            DateTime beginColor = DateTime.Now;
            data.CellStyle.Color = Color.FromArgb(255, 255, 204);
            DateTime endColor = DateTime.Now;
            messages.Add(string.Format("\tColor:\t{0}", (endColor - beginColor)));



            DateTime endBodyFormat = DateTime.Now;
            messages.Add("\t---------------------------");
            messages.Add(string.Format("BodyFormat:\t{0}\n", (endBodyFormat - beginBodyFormat)));

            if (withFilter)
            {
                DateTime beginAutoFilters = DateTime.Now;
                IRanges rangesOne = worksheet.CreateRangesCollection();
                rangesOne.Add(worksheet.Range[1, 1, table.Rows.Count, table.Columns.Count]);
                worksheet.AutoFilters.FilterRange = rangesOne;
                DateTime endAutoFilters = DateTime.Now;
                messages.Add(string.Format("AutoFilters:\t{0}", (endAutoFilters - beginAutoFilters)));
            }

            DateTime beginImport = DateTime.Now;
            worksheet.ImportDataTable(table, true, 1, 1, -1, -1, true);
            DateTime endImport = DateTime.Now;
            messages.Add(string.Format("Import:\t{0}", (endImport - beginImport)));

            DateTime beginAutofitColumn = DateTime.Now;
            for (int i = 1; i <= table.Columns.Count; i++)
                worksheet.AutofitColumn(i); //10000-7sec.
            DateTime endAutofitColumn = DateTime.Now;
            messages.Add(string.Format("AutofitColumn:\t{0}", (endAutofitColumn - beginAutofitColumn)));


            MemoryStream ms = new MemoryStream();
            DateTime beginSaveAsMemoryStream = DateTime.Now;
            workbook.SaveAs(ms);
            DateTime endSaveAsMemoryStream = DateTime.Now;
            messages.Add(string.Format("SaveAsMemoryStream:\t{0}", (endSaveAsMemoryStream - beginSaveAsMemoryStream)));

            //workbook.Close();
            //excelEngine.ThrowNotSavedOnDestroy = false;
            //excelEngine.Dispose();

            DateTime beginSaveFile = DateTime.Now;
            byte[] xlsData = ms.ToArray();
            SaveFile(xlsData, filePath);
            DateTime endSaveFile = DateTime.Now;
            messages.Add(string.Format("SaveFile:\t{0}", (endSaveFile - beginSaveFile)));

            //LsiLogger.Trace("End of CreateSurveyExcelSyncfusion(...)");
            DateTime end = DateTime.Now;
            messages.Add(string.Format("Total time:\t{0}", (end - begin)));
            LsiLogger.Trace(string.Format("Duration of CreateSurveyExcelSyncfusion1(...) - {0},{1}", Path.GetFileName(filePath), (end - begin)));
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            foreach (string message in messages)
                sb.AppendLine(message);

            LsiLogger.Trace(string.Format("CreateSurveyExcelSyncfusion1 steps\n{0}", sb));
        }

        public static void CreateSurveyExcelSyncfusion2(ExcelVersion version, bool withFilter, DataTable table, string dir)
        {
            ArrayList messages = new ArrayList();
            string filePath = Path.Combine(dir, FileName.Replace(NameKey, string.Format("Syncfusion_{0}", version)));
            DateTime begin = DateTime.Now;
            //LsiLogger.Trace("Begin of CreateSurveyExcelSyncfusion(...)");
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;

            application.DefaultVersion = version;

            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet worksheet = workbook.Worksheets[0];

            DateTime beginColumnNames = DateTime.Now;
            worksheet.Range["A1"].Text = "Uid";
            worksheet.Range["B1"].Text = "Suid";
            worksheet.Range["C1"].Text = "Survey";
            worksheet.Range["D1"].Text = "Location";
            worksheet.Range["E1"].Text = "Date / Time	Name";
            worksheet.Range["F1"].Text = "Prompt 1";
            worksheet.Range["G1"].Text = "Prompt 2";
            worksheet.Range["H1"].Text = "Prompt 3";
            worksheet.Range["I1"].Text = "Prompt 4";
            worksheet.Range["J1"].Text = "Prompt 5";
            worksheet.Range["K1"].Text = "Duration (sec)";
            worksheet.Range["L1"].Text = "Expired";
            DateTime endColumnNames = DateTime.Now;
            messages.Add(string.Format("ColumnNames:\t{0}", (endColumnNames - beginColumnNames)));

            DateTime beginDateTimeFormat = DateTime.Now;
            IRanges dateTimeColl = worksheet.CreateRangesCollection();
            dateTimeColl.Add(worksheet.Range[1, 5, table.Rows.Count + 1, 5]);
            //dateTimeColl.NumberFormat = "mm/dd/yyyy h:mm tt";
            dateTimeColl.NumberFormat = "mm/dd/yyyy hh:mm";
            DateTime endDateTimeFormat = DateTime.Now;
            messages.Add(string.Format("DateTimeFormat:\t{0}", (endDateTimeFormat - beginDateTimeFormat)));

            //Header
            DateTime beginHeaderFormat = DateTime.Now;
            IRanges header = worksheet.CreateRangesCollection();
            header.Add(worksheet.Range[1, 1, 1, table.Columns.Count]);
            header.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            header.CellStyle.Font.Bold = true;
            header.CellStyle.Font.Size = 12;
            header.RowHeight = 36.75;
            header.CellStyle.Color = Color.FromArgb(192, 192, 192);
            header.CellStyle.Locked = true;
            header.VerticalAlignment = ExcelVAlign.VAlignCenter;
            header.CellStyle.Font.FontName = "Arial";
            header.CellStyle.Font.RGBColor = Color.Black;
            header.CellStyle.Borders.LineStyle = ExcelLineStyle.Thin;
            header.CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            header.CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;
            DateTime endHeaderFormat = DateTime.Now;
            messages.Add(string.Format("HeaderFormat:\t{0}\n", (endHeaderFormat - beginHeaderFormat)));

            //Body
            DateTime beginBodyFormat = DateTime.Now;
            for (int i = 0; i < table.Rows.Count + 1; i++)
            {
                IRanges data = worksheet.CreateRangesCollection();
                data.Add(worksheet.Range[2 + i, 1, 2 + i, table.Columns.Count]);

                //IRanges data = worksheet.CreateRangesCollection();
                //data.Add(worksheet.Range[2, 1, table.Rows.Count + 1, table.Columns.Count]);

                DateTime beginLineStyle = DateTime.Now;
                data.CellStyle.Borders.LineStyle = ExcelLineStyle.Thin;
                DateTime endLineStyle = DateTime.Now;
                messages.Add(string.Format("\tLineStyle:\t{0}", (endLineStyle - beginLineStyle)));

                DateTime beginDiagonalDown = DateTime.Now;
                data.CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
                DateTime endDiagonalDown = DateTime.Now;
                messages.Add(string.Format("\tDiagonalDown:\t{0}", (endDiagonalDown - beginDiagonalDown)));

                DateTime beginDiagonalUp = DateTime.Now;
                data.CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;
                DateTime endDiagonalUp = DateTime.Now;
                messages.Add(string.Format("\tDiagonalUp:\t{0}", (endDiagonalUp - beginDiagonalUp)));


                IFont font = data.CellStyle.Font;

                DateTime beginFontName = DateTime.Now;
                //data.CellStyle.Font.FontName = "Arial";
                font.FontName = "Arial";
                DateTime endFontName = DateTime.Now;
                messages.Add(string.Format("\tFontName:\t{0}", (endFontName - beginFontName)));

                DateTime beginFontSize = DateTime.Now;
                //data.CellStyle.Font.Size = 10;
                font.Size = 10;
                DateTime endFontSize = DateTime.Now;
                messages.Add(string.Format("\tFontSize:\t{0}", (endFontSize - beginFontSize)));

                DateTime beginFontRGBColor = DateTime.Now;
                //data.CellStyle.Font.RGBColor = Color.Black;
                font.Color = ExcelKnownColors.Black;
                DateTime endFontRGBColor = DateTime.Now;
                messages.Add(string.Format("\tFontRGBColor:\t{0}", (endFontRGBColor - beginFontRGBColor)));

                DateTime beginVerticalAlignment = DateTime.Now;
                data.VerticalAlignment = ExcelVAlign.VAlignCenter;
                DateTime endVerticalAlignment = DateTime.Now;
                messages.Add(string.Format("\tVerticalAlignment:\t{0}", (endVerticalAlignment - beginVerticalAlignment)));

                DateTime beginFillPattern = DateTime.Now;
                data.CellStyle.FillPattern = ExcelPattern.Solid;
                DateTime endFillPattern = DateTime.Now;
                messages.Add(string.Format("\tFillPattern:\t{0}", (endFillPattern - beginFillPattern)));

                DateTime beginRowHeight = DateTime.Now;
                //data.RowHeight = 31.50;
                worksheet.SetRowHeight(i + 2, 31.5);
                DateTime endRowHeight = DateTime.Now;
                messages.Add(string.Format("\tRowHeight:\t{0}", (endRowHeight - beginRowHeight)));


                DateTime beginColor = DateTime.Now;
                data.CellStyle.Color = Color.FromArgb(255, 255, 204);
                DateTime endColor = DateTime.Now;
                messages.Add(string.Format("\tColor:\t{0}", (endColor - beginColor)));
            }


            DateTime endBodyFormat = DateTime.Now;
            messages.Add("\t---------------------------");
            messages.Add(string.Format("BodyFormat:\t{0}\n", (endBodyFormat - beginBodyFormat)));

            if (withFilter)
            {
                DateTime beginAutoFilters = DateTime.Now;
                IRanges rangesOne = worksheet.CreateRangesCollection();
                rangesOne.Add(worksheet.Range[1, 1, table.Rows.Count, table.Columns.Count]);
                worksheet.AutoFilters.FilterRange = rangesOne;
                DateTime endAutoFilters = DateTime.Now;
                messages.Add(string.Format("AutoFilters:\t{0}", (endAutoFilters - beginAutoFilters)));
            }

            DateTime beginImport = DateTime.Now;
            worksheet.ImportDataTable(table, true, 1, 1, -1, -1, true);
            DateTime endImport = DateTime.Now;
            messages.Add(string.Format("Import:\t{0}", (endImport - beginImport)));

            DateTime beginAutofitColumn = DateTime.Now;
            for (int i = 1; i <= table.Columns.Count; i++)
                worksheet.AutofitColumn(i); //10000-7sec.
            DateTime endAutofitColumn = DateTime.Now;
            messages.Add(string.Format("AutofitColumn:\t{0}", (endAutofitColumn - beginAutofitColumn)));


            MemoryStream ms = new MemoryStream();
            DateTime beginSaveAsMemoryStream = DateTime.Now;
            workbook.SaveAs(ms);
            DateTime endSaveAsMemoryStream = DateTime.Now;
            messages.Add(string.Format("SaveAsMemoryStream:\t{0}", (endSaveAsMemoryStream - beginSaveAsMemoryStream)));

            //workbook.Close();
            //excelEngine.ThrowNotSavedOnDestroy = false;
            //excelEngine.Dispose();

            DateTime beginSaveFile = DateTime.Now;
            byte[] xlsData = ms.ToArray();
            SaveFile(xlsData, filePath);
            DateTime endSaveFile = DateTime.Now;
            messages.Add(string.Format("SaveFile:\t{0}", (endSaveFile - beginSaveFile)));

            //LsiLogger.Trace("End of CreateSurveyExcelSyncfusion(...)");
            DateTime end = DateTime.Now;
            messages.Add(string.Format("Total time:\t{0}", (end - begin)));
            LsiLogger.Trace(string.Format("Duration of CreateSurveyExcelSyncfusion2(...) - {0},{1}", Path.GetFileName(filePath), (end - begin)));
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            foreach (string message in messages)
                sb.AppendLine(message);

            LsiLogger.Trace(string.Format("CreateSurveyExcelSyncfusion2 steps\n{0}", sb));
        }

        public static void CreateSurveyExcelSyncfusion3(ExcelVersion version, bool withFilter, DataTable table, string dir)
        {
            ArrayList messages = new ArrayList();
            string filePath = Path.Combine(dir, FileName.Replace(NameKey, string.Format("Syncfusion_{0}", version)));
            DateTime begin = DateTime.Now;
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;

            application.DefaultVersion = version;

            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet worksheet = workbook.Worksheets[0];

            //Header
            IStyle headerStyle = workbook.Styles.Add("HeaderStyle");
            headerStyle.BeginUpdate();
            workbook.SetPaletteColor(9, Color.FromArgb(239, 243, 247));
            headerStyle.Color = Color.FromArgb(239, 243, 247);
            //headerStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
            //headerStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
            headerStyle.Font.Bold = true;
            headerStyle.Font.Size = 12;
            headerStyle.Color = Color.FromArgb(192, 192, 192);
            headerStyle.Locked = true;
            headerStyle.Font.FontName = "Arial";
            headerStyle.Font.Color = ExcelKnownColors.Black;
            headerStyle.Borders.LineStyle = ExcelLineStyle.Thin;
            headerStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            headerStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;
            headerStyle.EndUpdate();
            worksheet.SetDefaultRowStyle(1, headerStyle);

            IRanges header = worksheet.CreateRangesCollection();
            header.Add(worksheet.Range[1, 1, 1, table.Columns.Count]);
            header.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            header.RowHeight = 36.75;
            header.VerticalAlignment = ExcelVAlign.VAlignCenter;
            
            //Body
            IStyle bodyStyle = workbook.Styles.Add("BodyStyle");
            bodyStyle.BeginUpdate();
            workbook.SetPaletteColor(10, Color.FromArgb(255, 255, 204));
            bodyStyle.Color = Color.FromArgb(255, 255, 204);
            bodyStyle.Font.Size = 10;
            bodyStyle.Font.Color = ExcelKnownColors.Black;
            bodyStyle.Font.FontName = "Arial";
            bodyStyle.Font.Bold = false;
            bodyStyle.Font.Color = ExcelKnownColors.Black;
            bodyStyle.Borders.LineStyle = ExcelLineStyle.Thin;
            bodyStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            bodyStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;
            
            //bodyStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
            //bodyStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
            bodyStyle.EndUpdate();
            worksheet.SetDefaultRowStyle(2, table.Rows.Count + 1, bodyStyle);

            IRanges data = worksheet.CreateRangesCollection();
            data.Add(worksheet.Range[2, 1, table.Rows.Count + 1, table.Columns.Count]);
            data.RowHeight = 31.50;

            //IStyle bodyStyle = worksheet.CreateRangesCollection().CellStyle;
            //DateTime beginFillPattern = DateTime.Now;
            //data.CellStyle.FillPattern = ExcelPattern.Solid;
            //DateTime endFillPattern = DateTime.Now;
            //messages.Add(string.Format("\tFillPattern:\t{0}", (endFillPattern - beginFillPattern)));
            
            //worksheet.SetDefaultRowStyle(2, table.Rows.Count + 1, bodyStyle);

            IRanges rangesOne = worksheet.CreateRangesCollection();
            rangesOne.Add(worksheet.Range[1, 1, table.Rows.Count, table.Columns.Count]);
            worksheet.AutoFilters.FilterRange = rangesOne;

            worksheet.ImportDataTable(table, true, 1, 1, -1, -1, true);

            IRanges dateTimeColl = worksheet.CreateRangesCollection();
            dateTimeColl.Add(worksheet.Range[1, 5, table.Rows.Count + 1, 5]);
            dateTimeColl.NumberFormat = "MM/DD/YYYY h:mm am/pm";
            
            for (int i = 1; i <= table.Columns.Count; i++)
                worksheet.AutofitColumn(i);

            worksheet.SetColumnWidth(5, 18.00);

            MemoryStream ms = new MemoryStream();
            workbook.SaveAs(ms);

            workbook.Close();
            excelEngine.ThrowNotSavedOnDestroy = false;
            excelEngine.Dispose();

            byte[] xlsData = ms.ToArray();
            SaveFile(xlsData, filePath);
            
            DateTime end = DateTime.Now;
            messages.Add(string.Format("Total time:\t{0}", (end - begin)));
            LsiLogger.Trace(string.Format("Duration of CreateSurveyExcelSyncfusion3(...) - {0},{1}", Path.GetFileName(filePath), (end - begin)));
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            foreach (string message in messages)
                sb.AppendLine(message);

            LsiLogger.Trace(string.Format("CreateSurveyExcelSyncfusion3 steps\n{0}", sb));
        }

        public static void CreateSpierXls(Spire.Xls.ExcelVersion version, bool withFilter,
            DataTable table, string dir)
        {
            string filePath = Path.Combine(dir, FileName.Replace(NameKey, string.Format("SpierXls_{0}", version)));
            DateTime begin = DateTime.Now;
            Workbook workbook = new Workbook();
            workbook.Version = version;

            Worksheet sheet = workbook.Worksheets[0];
            sheet.InsertDataTable(table, true, 1, 1, -1, -1);
            if (withFilter)
                sheet.AutoFilters.Range = sheet.Range[1, 1, table.Rows.Count, table.Columns.Count];

            MemoryStream ms = new MemoryStream();
            workbook.SaveToStream(ms);
            byte[] xlsData = ms.ToArray();
            SaveFile(xlsData, filePath);

            DateTime end = DateTime.Now;
            LsiLogger.Trace(string.Format("Duration of CreateSpierXls(...) - {0},{1}", Path.GetFileName(filePath), (end - begin)));
        }
    }
}
