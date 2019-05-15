using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using testCS.Models;

namespace testCS
{
    abstract class DbProcess
    {
        protected Dictionary<string, Guid> GuidMap = new Dictionary<string, Guid>();

        public void LoadGuidMap(ExcelPackage package)
        {
            //get the second worksheet in the workbook
            ExcelWorksheet worksheet = GetWorksheet(package);
            int colCount = worksheet.Dimension.End.Column;  //get Column Count
            int rowCount = worksheet.Dimension.End.Row;     //get row count
            for (int row = 2; row < rowCount + 1; row++)
            {
                Guid value = Guid.NewGuid();
                string key = worksheet.Cells[row, 1].Value.ToString().Trim();
                GuidMap.Add(key, value);
            }
        }

        ExcelWorksheet GetWorksheet(ExcelPackage package)
        {
            return package.Workbook.Worksheets[GetWorksheetName()];
        }

        public abstract string GetWorksheetName();

        public abstract void InsertToDb(DemoContext context);

        public void DoTheProcess(DemoContext context, ExcelPackage excelPackage)
        {
            LoadGuidMap(excelPackage);
            InitList();
            InsertToDb(context);
        }

        public abstract void InitList();
    }
}
