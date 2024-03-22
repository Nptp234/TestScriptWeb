using NUnit.Framework;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using TestScriptWeb.Data;

namespace TestScriptWeb
{
    class DKTest : ASetUp
    {
        [Test]
        [TestCaseSource(typeof(TestLogupKHData), nameof(TestLogupKHData.dataKH))]
        public void TestLogup(User kh)
        {
            driver.Navigate().GoToUrl(url);

            IWebElement loginButton = null;
            try
            {
                loginButton = driver.FindElement(By.Name("loginbtn"));
                loginButton.Click();
            }
            catch
            {
                QuitWeb(driver);
                Assert.Fail("Không tìm thấy nút chuyển đăng nhập!");
            }

            IWebElement logupButton = null;
            try
            {
                logupButton = driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/header[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[4]/a[1]"));
                logupButton.Click();
            }
            catch
            {
                QuitWeb(driver);
                Assert.Fail("Không tìm thấy nút chuyển đăng ký!");
            }

            IWebElement name = null;
            try
            {
                name = driver.FindElement(By.Name("Username"));
                name.SendKeys(kh.Username);
            }
            catch
            {
                QuitWeb(driver);
                Assert.Fail("Không tìm thấy trường tên!");
            }

            IWebElement pass = null;
            try
            {
                pass = driver.FindElement(By.Name("Password"));
                pass.SendKeys(kh.Password);
            }
            catch
            {
                QuitWeb(driver);
                Assert.Fail("Không tìm thấy trường mật khẩu!");
            }

            IWebElement mail = null;
            try
            {
                mail = driver.FindElement(By.Name("Email"));
                mail.SendKeys(kh.Gmail);
            }
            catch
            {
                QuitWeb(driver);
                Assert.Fail("Không tìm thấy trường mail!");
            }

            IWebElement btn = null;
            try
            {
                btn = driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/header[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[4]/div[1]/input[1]"));
                btn.Click();
            }
            catch
            {
                QuitWeb(driver);
                Assert.Fail("Không tìm thấy nút đăng ký!");
            }

            Thread.Sleep(1000);

            if (!driver.Url.Contains("https://localhost:44324/Home/RegisterPage"))
            {
                QuitWeb(driver);
                driver.Navigate().GoToUrl("https://localhost:44324/Home/LoginPage");

                IWebElement name2 = null;
                try
                {
                    name2 = driver.FindElement(By.Name("Username"));
                    name2.SendKeys(kh.Username);
                }
                catch
                {
                    QuitWeb(driver);
                    Assert.Fail("Không tìm thấy trường tên!");
                }

                IWebElement pass2 = null;
                try
                {
                    pass2 = driver.FindElement(By.Name("Password"));
                    pass2.SendKeys(kh.Password);
                }
                catch
                {
                    QuitWeb(driver);
                    Assert.Fail("Không tìm thấy trường mật khẩu!");
                }

                IWebElement btn2 = null;
                try
                {
                    btn2 = driver.FindElement(By.Name("status"));
                    btn2.Click();
                }
                catch
                {
                    QuitWeb(driver);
                    Assert.Fail("Không tìm thấy nút đăng nhập!");
                }
                Thread.Sleep(1000);

                if (!driver.Url.Contains("https://localhost:44324/Home/LoginPage"))
                {
                    QuitWeb(driver);
                    Assert.Pass();
                }
                else
                {
                    QuitWeb(driver);
                    Assert.Fail("Đăng ký thành công nhưng đăng nhập thất bại!");
                }

            }
            else
            {
                QuitWeb(driver);
                Assert.Fail("Đăng ký thất bại!");
            }
        }
    }
}
