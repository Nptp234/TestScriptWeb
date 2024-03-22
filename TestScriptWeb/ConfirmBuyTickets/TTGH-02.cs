using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestScriptWeb.ConfirmBuyTickets
{
    class ThanhToanGioHangTrong : ASetUp
    {
        [Test]
        public void ThanhToanGHTrong()
        {
            driver.Navigate().GoToUrl(url);

            if (driver.Url.Contains("https://localhost:44324/"))
            {
                driver.Navigate().GoToUrl("https://localhost:44324/Home/LoginPage");

                driver.FindElement(By.Name("Username")).SendKeys("phuoc1");
                driver.FindElement(By.Name("Password")).SendKeys("12345678");
                driver.FindElement(By.Name("status")).Submit();
                Thread.Sleep(1000);

                driver.Navigate().GoToUrl(url);

                try
                {
                    driver.FindElement(By.XPath("/html[1]/body[1]/nav[1]/div[1]/div[1]/ul[1]/li[5]/a[3]/*[name()='svg'][1]/*[name()='path'][1]")).Click();
                }
                catch
                {
                    Assert.Fail("Không tìm thấy giỏ hàng!");
                }

                //Kiểm tra số lượng vé trong giỏ hàng
                //Nếu trống nhấn thanh toán
                //Ngược lại trả về giỏ hàng không trống
                IWebElement isClean = null;
                try
                {
                    isClean = driver.FindElement(By.XPath("(//form[action='/Store'][method='post'])[1]"));
                }
                catch
                {
                    isClean = null;
                }
                var amountTK = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]"));
                string amount = amountTK.Text.Substring(0, 1);
                if (amount.Equals("0"))
                {
                    driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/form[2]/button[1]")).Click();
                    Thread.Sleep(1000);

                    if (!driver.Url.Contains("https://localhost:44324/Booking/ThankYouPage"))
                    {
                        QuitWeb(driver);
                        Assert.Pass(amount);
                    }
                    else Assert.Fail("Thanh toán giỏ hàng trống lỗi!");
                }
                else Assert.Fail("Giỏ hàng không trống!");

            }
        }
    }
}
