using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestScriptWeb.BookingTicket
{
    class DatVeDaDN : ASetUp
    {
        [Test]
        public void KiemThuDatVeThanhCongDaDN()
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
                    var ls = dsCaChieu.FindElements(By.TagName("a"));
                    foreach (var ca in ls)
                    {
                        ca.Click();
                        Thread.Sleep(1000);
                        break;
                    }

                    //Chọn ghế
                    List<IWebElement> gheTheoHang = null;
                    try
                    {
                        IReadOnlyCollection<IWebElement> gheTemp = driver.FindElements(By.CssSelector("div.listchair"));
                        gheTheoHang = new List<IWebElement>(gheTemp);
                    }
                    catch
                    {
                        Assert.Fail("Không tìm thấy ghế nào theo hàng!");
                    }

                    int count = 0;
                    foreach (var ghe in gheTheoHang)
                    {
                        var gheBtn = ghe.FindElements(By.CssSelector("button.chair"));

                        foreach (var tenGhe in gheBtn)
                        {
                            tenGhe.Click();
                            count++;
                            Thread.Sleep(1000);

                            if (count == 7) break;
                        }
                        break;
                    }

                    //Bấm đặt vé
                    try
                    {
                        driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[3]")).Click();
                        Thread.Sleep(1000);
                    }
                    catch
                    {
                        Assert.Fail("Không thể tìm thấy nút đặt vé!");
                    }

                    //Xác nhận vé
                    try
                    {
                        driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/div[3]/button[1]")).Click();
                        Thread.Sleep(1000);
                    }
                    catch
                    {
                        Assert.Fail("Không thể tìm thấy nút xác nhận vé!");
                    }

                    //Chuyển trang cảm ơn
                    if (driver.Url.Contains("https://localhost:44324/Booking/ThankYouPage"))
                    {
                        driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/a[1]")).Click();
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Assert.Fail("Lỗi chuyển trang cảm ơn!");
                    }

                    driver.Navigate().GoToUrl(url);
                    //Kiểm tra giỏ hàng
                    if (driver.Url.Contains(url))
                    {
                        try
                        {
                            driver.FindElement(By.XPath("/html[1]/body[1]/nav[1]/div[1]/div[1]/ul[1]/li[5]/a[3]/*[name()='svg'][1]/*[name()='path'][1]")).Click();
                        }
                        catch
                        {
                            Assert.Fail("Không tìm thấy giỏ hàng!");
                        }

                        //Kiểm tra có phim vừa thanh toán không
                        List<IWebElement> dsPhim = null;
                        try
                        {
                            IReadOnlyCollection<IWebElement> dsPhim2 = driver.FindElements(By.CssSelector("form[action='/Store']"));
                            dsPhim = new List<IWebElement>(dsPhim2);
                        }
                        catch
                        {
                            Assert.Fail("Giỏ hàng trống sau khi đặt vé!");
                        }

                        count = 0;
                        foreach (var phim in dsPhim)
                        {
                            count++;
                            var tenPhim = phim.FindElement(By.XPath($"/html[1]/body[1]/div[1]/div[1]/div[1]/form[{count}]/div[1]/div[1]/div[3]/div[2]"));
                            string filmName2 = tenPhim.Text.ToString().ToLower().Trim();

                            if (filmName1.Contains(filmName2)) { Assert.Pass(); }
                            else Assert.Fail("Không tìm thấy phim đã đặt vé: " + filmName1 + ", " + filmName2);
                        }

                    }
                    else Assert.Fail("Không chuyển trang chủ!");

                }
                else Assert.Fail("Không chuyển trang chọn suất chiếu!");
            }
        }
    }
}
