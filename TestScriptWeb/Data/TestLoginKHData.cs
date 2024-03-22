using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OfficeOpenXml;
using System.IO;
using TestScriptWeb;
using System.Threading;
using TestScriptWeb.Data;

namespace TestScriptWeb.Data
{
    [TestFixture]
    [Parallelizable]
    public static class TestLoginKHData
    {
        static FileInfo excelFile = new FileInfo("D:\\1 BDCLPM\\ExcelFỏUnitTesting\\LoginKH.xlsx");
        static ExcelPackage packageExcel = new ExcelPackage(excelFile);
        static ExcelWorksheet worksheet = packageExcel.Workbook.Worksheets[0];

        public static object[] dataKH = GetDataLoginKH();

        public static object[] GetDataLoginKH()
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
