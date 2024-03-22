﻿using NUnit.Framework;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestScriptWeb.Data
{
    [TestFixture]
    [Parallelizable]
    public static class TestLoginNVData
    {
        static FileInfo excelFile = new FileInfo("D:\\1 BDCLPM\\TestScriptWeb\\TestScriptWeb\\Data\\DataExcel\\LoginNV.xlsx");
        static ExcelPackage packageExcel = new ExcelPackage(excelFile);
        static ExcelWorksheet worksheet = packageExcel.Workbook.Worksheets[0];

        public static object[] dataNV = GetDataLoginNV();

        public static object[] GetDataLoginNV()
        {
            // Lấy dữ liệu từ tệp Excel và trả về danh sách KhachHang
            int rowCount = worksheet.Dimension.Rows;
            User[] lsKH = new User[rowCount];

            for (int i = 1; i <= rowCount; i++)
            {
                var cell1 = worksheet.Cells[i, 1].Value;
                var cell2 = worksheet.Cells[i, 2].Value;

                string username = (cell1 != null) ? cell1.ToString() : "";
                string password = (cell2 != null) ? cell2.ToString() : "";

                lsKH[i - 1] = new User(username, password);
            }

            return lsKH;
        }
    }
}
