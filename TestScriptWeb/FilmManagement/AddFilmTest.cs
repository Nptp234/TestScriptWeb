using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TestScriptWeb.Data;
using TestScriptWeb.Models;

namespace TestScriptWeb.FilmManagement
{
    [TestFixture]
    class AddFilmTest : AFilm
    {
        public static List<string> result = new List<string>();

        [Test]
        [TestCaseSource(typeof(TestFilmData), nameof(TestFilmData.dataPhim))]
        public void AddFilmTest2(Phim phim)
        {
            //Đăng nhập nhân viên
            DNNV(driver);
            Thread.Sleep(1000);

            //Mở quản lý phim
            OpenFilm(driver);

            //Lấy danh sách phim trước khi thêm
            ButtonShowList(driver);
            IList<IWebElement> ls1 = GetList(driver);

            //Mở form thêm
            var addfilm = driver.FindElement(By.Id("addnewphim"));
            addfilm.Click();

            //Nhập tên
            var tenF = driver.FindElement(By.Name("TenF"));
            tenF.Click();
            tenF.SendKeys(phim.TenPhim);
            Thread.Sleep(1000);

            //Nhập mô tả
            var mota = driver.FindElement(By.Name("MoTaF"));
            mota.Click();
            mota.SendKeys(phim.TomTatP);
            Thread.Sleep(1000);

            //Nhập ngày công chiếu
            var ngaycc = driver.FindElement(By.Name("NgayCC"));
            ngaycc.Click();
            ngaycc.SendKeys(phim.NgayCongChieu);
            Thread.Sleep(1000);

            //Nhập thời lượng
            var thoiluong = driver.FindElement(By.Name("ThoiLuongP"));
            thoiluong.Click();
            thoiluong.SendKeys(phim.ThoiLuongP);
            Thread.Sleep(1000);

            //Nhập hình ảnh
            IWebElement imgFilm = null;
            try
            {
                imgFilm = driver.FindElement(By.Name("HinhAnhFile"));
            }
            catch
            {
                Assert.Fail("Không tìm thấy phần tử ảnh!");
            }

            if (!string.IsNullOrEmpty(phim.HinhAnh))
            {
                imgFilm.SendKeys(phim.HinhAnh);
                Thread.Sleep(1000);
            }
            else
            {
                driver.Navigate().GoToUrl("https://localhost:44324/Home/Logout");
                result.Add("Fail");
                Assert.Fail("Thêm thất bại!");
            }

            //Nhập trailer
            var trailer = driver.FindElement(By.Name("TrailerP"));
            trailer.Click();
            trailer.SendKeys(phim.Trailer);
            Thread.Sleep(1000);

            //Nhập giá phim
            var giap = driver.FindElement(By.Name("GiaP"));
            giap.Click();
            giap.SendKeys(phim.GiaPhim);
            Thread.Sleep(1000);

            //Nhập giới hạn tuổi
            var ght = driver.FindElement(By.Name("GHTP"));
            // Sử dụng JavaScript Executor để ghi giá trị vào trường input readonly
            string script = "arguments[0].removeAttribute('readonly')";
            ((IJavaScriptExecutor)driver).ExecuteScript(script, ght);
            ght.Clear();
            ght.SendKeys(phim.TenGHT);
            Thread.Sleep(1000);

            //Nhấn nút thêm
            driver.FindElement(By.Name("status")).Click();
            Thread.Sleep(1000);

            //Kiểm tra sau khi thêm (nếu lỗi sẽ kiểm tra địa chỉ)
            if (driver.Url.Contains("https://localhost:44324/AdminArea/Admin/Film"))
            {
                //Lấy danh sách phim sau khi thêm
                IList<IWebElement> ls2 = GetList(driver);

                // Kiểm tra danh sách còn mở không
                if (ls2 == null)
                {
                    //Mở form thêm
                    ButtonShowList(driver);
                    ls2 = GetList(driver);
                }

                //So sánh: ls2>ls1 => Pass
                if (ls2.Count > ls1.Count && ls1 != null && ls2 != null)
                {
                    QuitWeb(driver);
                    result.Add("Pass");
                    Assert.Pass("Thêm thành công!");
                }
                else
                {
                    QuitWeb(driver);
                    result.Add("Fail");
                    Assert.Fail("Thêm thất bại!");
                }
            }
            else
            {
                QuitWeb(driver);
                Assert.Fail("Not in film management!");
            }

            //Thoát trang
            QuitWeb(driver);
        }
    }
}