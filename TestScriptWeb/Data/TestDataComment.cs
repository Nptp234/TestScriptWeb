using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestScriptWeb.Data
{
    class TestDataComment
    {
        // Đường dẫn tới thư mục chứa tệp Excel trong dự án
        static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        static string excelFilePath = Path.Combine(projectDirectory, "Data", "DataExcel", "bldatafile.xlsx");

        static FileInfo excelFile = new FileInfo(excelFilePath);
        static ExcelPackage packageExcel = new ExcelPackage(excelFile);
        static ExcelWorksheet worksheet = packageExcel.Workbook.Worksheets[0];

        public static object[] dataBL = GetDataBL();

        public static object[] GetDataBL()
        {
            int rowCount = worksheet.Dimension.Rows;

            string[] lsBL = new string[rowCount];

            for (int i = 2; i <= rowCount; i++)
            {
                var cell1 = worksheet.Cells[i, 1].Value;

                string binhluan = "";

                if (cell1 != null)
                {
                    binhluan = cell1.ToString();
                }
                else
                {
                    binhluan = "";
                }

                lsBL[i - 2] = binhluan;
            }

            return lsBL;
        }
    }
}
