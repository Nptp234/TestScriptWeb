using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestScriptWeb.BookingTicket
{
    class DatVeChonGioChieuDaQua : ASetUp
    {
        [Test]
        public void KiemThuDatVeChonQuaNhieuGhe()
        {
            driver.Navigate().GoToUrl(url);

            if (driver.Url.Contains("https://localhost:44324/"))
            {
                driver.Navigate().GoToUrl("https://localhost:44324/Home/LoginPage");

                // Đăng nhập kh
                driver.FindElement(By.Name("Username")).SendKeys("phuoc1");
                driver.FindElement(By.Name("Password")).SendKeys("12345678");
                driver.FindElement(By.Name("status")).Submit();
                Thread.Sleep(1000);

                driver.Navigate().GoToUrl(url);

                //Kiếm phim và bấm vào
                IWebElement btn = null;
                try
                {
                    btn = driver.FindElement(By.XPath("/html[1]/body[1]/section[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/a[1]/figure[1]"));
                    btn.Click();
                }
                catch
                {
                    try
                    {
                        btn = driver.FindElement(By.XPath("/html[1]/body[1]/section[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/div[1]/a[1]/figure[1]"));
                        btn.Click();
                    }
                    catch
                    {
                        try
                        {
                            btn = driver.FindElement(By.XPath("/html[1]/body[1]/section[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[1]/a[1]/figure[1]"));
                            btn.Click();
                        }
                        catch
                        {
                            Assert.Fail("Không tìm thấy phim!");
                        }
                    }
                };
                Thread.Sleep(1000);

                //Lấy tên phim đặt vé
                var filmN = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/h2[1]"));
                string filmName1 = filmN.Text.ToString().ToLower().Trim();

                string urlnow = driver.Url;

                //Bấm vào mua ngay
                driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/a[1]")).Click();
                Thread.Sleep(1000);

                if (!driver.Url.Contains(urlnow))
                {
                    //Lấy danh sách suất chiếu
                    IWebElement dsCaChieu = null;
                    try
                    {
                        dsCaChieu = driver.FindElement(By.XPath("/html[1]/body[1]/div[4]/div[3]/div[2]"));
                    }
                    catch
                    {
                        try
                        {
                            dsCaChieu = driver.FindElement(By.XPath("/html[1]/body[1]/div[4]/div[4]/div[2]"));
                        }
                        catch
                        {
                            Assert.Fail("Không tìm thấy ca chiếu!");
                        }
                    }

                    //Lấy danh sách ca chiếu của suất chiếu đã lấy và bấm vào
                    DateTime now = DateTime.Now;
                    var hour = now.Hour;
                    var minute = now.Minute;

                    var ls = dsCaChieu.FindElements(By.TagName("a"));
                    string url123 = driver.Url;
                    foreach (var ca in ls)
                    {
                        string cachieu = ca.Text.ToString();

                        string[] times = cachieu.Split(':');

                        // Lấy phần tử đầu tiên (7) và chuyển đổi thành số nguyên
                        int gio = int.Parse(times[0]);

                        if (hour < gio)
                        {
                            ca.Click();
                            Thread.Sleep(1000);

                            if (url123.Contains(driver.Url))
                            {
                                Assert.Pass();
                            }
                            else
                            {
                                Assert.Fail("Chọn được ca chiếu quá giờ xem hiện tại!");
                            }

                            break;
                        }
                    }
                }
                else Assert.Fail("Không chuyển trang chọn suất chiếu!");
            }
        }
    }
}
