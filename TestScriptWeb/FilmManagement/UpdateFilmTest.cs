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
    class UpdateFilmTest : AFilm
    {
        private static IWebElement nameFilm, detailFilm, dateFilm, timesFilm, imgFilm, trailerFilm, pricesFilm, idAgeFilm;

        [Test]
        [TestCaseSource(typeof(TestFilmData), nameof(TestFilmData.dataPhim))]
        public void TestUpdate(Phim phim)
        {
            DNNV(driver);
            Thread.Sleep(1000);

            // Lấy nút chuyển trang quản lý phim
            OpenFilm(driver);

            // Kiểm tra mở trang quản lý phim
            if (driver.Url == "https://localhost:44324/AdminArea/Admin/Film")
            {
                // Lấy danh sách phim khi bấm mở danh sách
                ButtonShowList(driver);

                //Lấy các đối tượng
                nameFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[1]/input[1]"));
                detailFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[2]/input[1]"));
                dateFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[3]/input[1]"));
                timesFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[4]/input[1]"));
                imgFilm = driver.FindElement(By.Name("HinhAnhFiledetail1"));
                trailerFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[8]/input[1]"));
                pricesFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[9]/input[1]"));
                idAgeFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[10]/input[1]"));


                //Lấy danh sách trước khi cập nhật
                List<string> lsOldText = LayDSDT(driver, nameFilm, detailFilm, dateFilm, timesFilm, imgFilm, trailerFilm, pricesFilm, idAgeFilm);
                Phim oldP = layPhim(nameFilm, detailFilm, dateFilm, timesFilm, imgFilm, trailerFilm, pricesFilm, idAgeFilm);

                //Tên phim
                nameFilm.Clear();
                nameFilm.SendKeys(phim.TenPhim);
                Thread.Sleep(1000);

                //Chi tiết phim
                detailFilm.Clear();
                detailFilm.SendKeys(phim.TomTatP);
                Thread.Sleep(1000);

                //Ngày công chiếu
                dateFilm.Clear();
                dateFilm.SendKeys(phim.NgayCongChieu);
                Thread.Sleep(1000);

                //Thời lượng
                timesFilm.Clear();
                timesFilm.SendKeys(phim.ThoiLuongP);
                Thread.Sleep(1000);

                //Hình ảnh
                if (!string.IsNullOrEmpty(phim.HinhAnh))
                {
                    imgFilm.SendKeys(phim.HinhAnh);
                    Thread.Sleep(1000);
                }
                else
                {
                    driver.Navigate().GoToUrl("https://localhost:44324/Home/Logout");
                    Assert.Fail("Thêm thất bại!");
                }

                //Trailer
                trailerFilm.Clear();
                trailerFilm.SendKeys(phim.Trailer);
                Thread.Sleep(1000);

                //Gía
                pricesFilm.Clear();
                pricesFilm.SendKeys(phim.GiaPhim);
                Thread.Sleep(1000);

                //Mã GHT
                idAgeFilm.Clear();
                idAgeFilm.SendKeys(phim.MaGHT);
                Thread.Sleep(1000);

                // Nhấn nút cập nhật
                var updateBtn = driver.FindElement(By.XPath("//tbody/tr[1]/td[11]/button[1]"));
                updateBtn.Click();
                Thread.Sleep(1000);

                // Kiểm tra trang web còn ở phim không
                if (driver.Url.Contains("https://localhost:44324/AdminArea/Admin/Film"))
                {
                    //Bắt buộc mở danh sách nếu không phần tử bị null
                    ButtonShowList(driver);

                    //Lấy các đối tượng
                    nameFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[1]/input[1]"));
                    detailFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[2]/input[1]"));
                    dateFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[3]/input[1]"));
                    timesFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[4]/input[1]"));
                    imgFilm = driver.FindElement(By.Name("HinhAnhFiledetail1"));
                    trailerFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[8]/input[1]"));
                    pricesFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[9]/input[1]"));
                    idAgeFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[10]/input[1]"));


                    //Lấy danh sách sau khi cập nhật
                    List<string> lsNewText = LayDSDT(driver, nameFilm, detailFilm, dateFilm, timesFilm, imgFilm, trailerFilm, pricesFilm, idAgeFilm);
                    Phim newP = layPhim(nameFilm, detailFilm, dateFilm, timesFilm, imgFilm, trailerFilm, pricesFilm, idAgeFilm);

                    bool isCheck = false;

                    if (oldP.TenPhim != newP.TenPhim ||
                        oldP.TomTatP != newP.TomTatP ||
                        oldP.NgayCongChieu != newP.NgayCongChieu ||
                        oldP.ThoiLuongP != newP.ThoiLuongP ||
                        oldP.HinhAnh != newP.HinhAnh ||
                        oldP.Trailer != newP.Trailer ||
                        oldP.GiaPhim != newP.GiaPhim ||
                        oldP.MaGHT != newP.MaGHT)
                    {
                        // Nếu có ít nhất một thuộc tính khác nhau, trả về true
                        isCheck = true;
                    }
                    else
                    {
                        //Trường hợp giá trị nhập vào giống giá trị cũ
                        if (oldP.TenPhim != phim.TenPhim &&
                        oldP.TomTatP != phim.TomTatP &&
                        oldP.NgayCongChieu != phim.NgayCongChieu &&
                        oldP.ThoiLuongP != phim.ThoiLuongP &&
                        oldP.HinhAnh != phim.HinhAnh &&
                        oldP.Trailer != phim.Trailer &&
                        oldP.GiaPhim != phim.GiaPhim &&
                        oldP.MaGHT != phim.MaGHT)
                        {
                            //Do chỉ nhập 1 giá trị mỗi lần test nên nếu tất cả giống trả về true
                            isCheck = true;
                        }
                        else
                        {
                            isCheck = false;
                        }

                    }

                    if (isCheck)
                    {
                        QuitWeb(driver);
                        Assert.Pass();
                    }
                    else
                    {
                        QuitWeb(driver);
                        Assert.Fail("Cập nhật không thành công");
                    }

                }
                else
                {
                    QuitWeb(driver);
                    Assert.Fail("Không còn ở trang phim!");
                }
                // Kết thúc kiểm tra trang web phim 

            }
            else
            {
                QuitWeb(driver);
                Assert.Fail();
            }
            // Kết thúc kiểm tra mở trang quản lý phim
        }

        public void LayDT(IWebDriver driver, IWebElement nameFilm, IWebElement detailFilm, IWebElement dateFilm, IWebElement timesFilm, IWebElement imgFilm, IWebElement trailerFilm, IWebElement pricesFilm, IWebElement idAgeFilm)
        {
            //Lấy các đối tượng
            nameFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[1]/input[1]"));
            detailFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[2]/input[1]"));
            dateFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[3]/input[1]"));
            timesFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[4]/input[1]"));
            imgFilm = driver.FindElement(By.Name("HinhAnhFiledetail1"));
            trailerFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[8]/input[1]"));
            pricesFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[9]/input[1]"));
            idAgeFilm = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[10]/input[1]"));

        }

        public List<string> LayDSDT(IWebDriver driver, IWebElement nameFilm, IWebElement detailFilm, IWebElement dateFilm, IWebElement timesFilm, IWebElement imgFilm, IWebElement trailerFilm, IWebElement pricesFilm, IWebElement idAgeFilm)
        {
            List<string> lsText = new List<string>();
            lsText.Add(nameFilm.Text.ToString());
            lsText.Add(detailFilm.Text.ToString());
            lsText.Add(dateFilm.Text.ToString());
            lsText.Add(timesFilm.Text.ToString());
            lsText.Add(imgFilm.Text.ToString());
            lsText.Add(trailerFilm.Text.ToString());
            lsText.Add(pricesFilm.Text.ToString());
            lsText.Add(idAgeFilm.Text.ToString());

            return lsText;
        }

        public Phim layPhim(IWebElement nameFilm, IWebElement detailFilm, IWebElement dateFilm, IWebElement timesFilm, IWebElement imgFilm, IWebElement trailerFilm, IWebElement pricesFilm, IWebElement idAgeFilm)
        {
            Phim phim = new Phim();
            phim.TenPhim = nameFilm.Text.ToString();
            phim.TomTatP = detailFilm.Text.ToString();
            phim.NgayCongChieu = dateFilm.Text.ToString();
            phim.ThoiLuongP = timesFilm.Text.ToString();
            phim.HinhAnh = imgFilm.Text.ToString();
            phim.Trailer = trailerFilm.Text.ToString();
            phim.GiaPhim = pricesFilm.Text.ToString();
            phim.MaGHT = idAgeFilm.Text.ToString();

            return phim;
        }

        public bool CheckValue(string oldvl, string newvl)
        {
            if (oldvl != newvl) return true;
            else return false;
        }
    }
}
