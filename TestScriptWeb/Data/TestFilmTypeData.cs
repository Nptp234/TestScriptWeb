using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestScriptWeb.Models;

namespace TestScriptWeb.Data
{
    public static class TestFilmTypeData
    {
        static FileInfo excelFile = new FileInfo("D:\\1 BDCLPM\\ExcelFỏUnitTesting\\AddFilmTypeData.xlsx");
        static ExcelPackage packageExcel = new ExcelPackage(excelFile);
        static ExcelWorksheet worksheet = packageExcel.Workbook.Worksheets[0];

        public static object[] dataPhim = GetDataPhim();

        public static object[] GetDataPhim()
        {
            int rowCount = worksheet.Dimension.Rows;
            LoaiPhim[] lsKH = new LoaiPhim[rowCount];

            for (int i = 2; i <= rowCount; i++)
            {
                var cell1 = worksheet.Cells[i, 1].Value;
                var cell2 = worksheet.Cells[i, 2].Value;

                string tenPhim = (cell1 != null) ? cell1.ToString() : "";
                string moTa = (cell2 != null) ? cell2.ToString() : "";

                lsKH[i - 2] = new LoaiPhim(tenPhim, moTa);
            }

            return lsKH;
        }
    }
}
