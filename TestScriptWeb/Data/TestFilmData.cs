using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestScriptWeb.Models;

namespace TestScriptWeb.Data
{
    public static class TestFilmData
    {
        static FileInfo excelFile = new FileInfo("D:\\1 BDCLPM\\ExcelFỏUnitTesting\\FilmData.xlsx");
        static ExcelPackage packageExcel = new ExcelPackage(excelFile);
        static ExcelWorksheet worksheet = packageExcel.Workbook.Worksheets[0];
        static List<string> Result { get; set; }

        public static object[] dataPhim = GetDataPhim();

        public static object[] GetDataPhim()
        {
            int notCount = 1;
            int rowCount = worksheet.Dimension.Rows;
            Phim[] lsKH = new Phim[rowCount];

            for (int i = 2; i <= rowCount; i++)
            {
                var cell1 = worksheet.Cells[i, 1 + notCount].Value;
                var cell2 = worksheet.Cells[i, 2 + notCount].Value;
                var cell3 = worksheet.Cells[i, 3 + notCount].Value;
                var cell4 = worksheet.Cells[i, 4 + notCount].Value;
                var cell5 = worksheet.Cells[i, 5 + notCount].Value;
                var cell6 = worksheet.Cells[i, 6 + notCount].Value;
                var cell7 = worksheet.Cells[i, 7 + notCount].Value;
                var cell8 = worksheet.Cells[i, 8 + notCount].Value;
                var cell9 = worksheet.Cells[i, 9 + notCount].Value;

                string tenPhim = (cell1 != null) ? cell1.ToString() : "";
                string moTa = (cell2 != null) ? cell2.ToString() : "";
                string ngayCC = (cell3 != null) ? cell3.ToString() : "";
                string thoiLuong = (cell4 != null) ? cell4.ToString() : "";
                string hinhAnh = (cell5 != null) ? cell5.ToString() : "";
                string trailer = (cell6 != null) ? cell6.ToString() : "";
                string giaPhim = (cell7 != null) ? cell7.ToString() : "";
                string maGHT = (cell8 != null) ? cell8.ToString() : "";
                string tenGHT = (cell9 != null) ? cell9.ToString() : "";

                lsKH[i - 2] = new Phim(tenPhim, moTa, ngayCC, thoiLuong, hinhAnh, trailer, giaPhim, maGHT, tenGHT);
            }

            return lsKH;
        }

        public static void WriteResultToEX(List<string> _result)
        {
            for (int i = 2; i < _result.Count; i++)
            {
                var cell13 = worksheet.Cells[13, i];
                cell13.Value = _result[i-2];
            }
        }
    }
}
