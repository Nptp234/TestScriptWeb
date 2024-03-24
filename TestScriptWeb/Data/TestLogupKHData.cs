using NUnit.Framework;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestScriptWeb.Data
{
    [TestFixture]
    [Parallelizable]
    class TestLogupKHData
    {
        // Đường dẫn tới thư mục chứa tệp Excel trong dự án
        static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        static string excelFilePath = Path.Combine(projectDirectory, "Data", "DataExcel", "LogupKH.xlsx");

        static FileInfo excelFile = new FileInfo(excelFilePath);
        static ExcelPackage packageExcel = new ExcelPackage(excelFile);
        static ExcelWorksheet worksheet = packageExcel.Workbook.Worksheets[0];

        public static object[] dataKH = GetDataLogupKH();

        public static object[] GetDataLogupKH()
        {
            // Lấy dữ liệu từ tệp Excel và trả về danh sách KhachHang
            int rowCount = worksheet.Dimension.Rows;
            User[] lsKH = new User[rowCount];

            for (int i = 2; i <= rowCount; i++)
            {
                var cell1 = worksheet.Cells[i, 1].Value;
                var cell2 = worksheet.Cells[i, 2].Value;
                var cell3 = worksheet.Cells[i, 3].Value;

                string username = (cell1 != null) ? cell1.ToString() : "";
                string password = (cell2 != null) ? cell2.ToString() : "";
                string gmail = (cell3 != null) ? cell3.ToString() : "";

                lsKH[i - 1] = new User(username, password, gmail);
            }

            return lsKH;
        }
    }
}
