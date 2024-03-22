using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestScriptWeb.BookingTicket
{
    class DatVe0DN : ASetUp
    {
        [Test]
        public void DatVeChuaDN()
        {
            driver.Navigate().GoToUrl(url);

            if (driver.Url.Contains(url))
            {
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

                driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/a[1]")).Click();
                Thread.Sleep(1000);

                if (driver.Url.Contains("https://localhost:44324/Home/LoginPage"))
                {
                    Assert.Pass();
                }
                else Assert.Fail("Đặt vé khi chưa đăng nhập!");

            }
        }
    }
}
