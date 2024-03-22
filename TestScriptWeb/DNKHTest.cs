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

namespace TestScriptWeb
{
    [TestFixture]
    public class DNKHTest : ASetUp
    {
        [Test]
        [TestCaseSource(typeof(TestLoginKHData), nameof(TestLoginKHData.dataKH))]
        public void TestLogin(User kh)
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

            IWebElement btn = null;
            try
            {
                btn = driver.FindElement(By.Name("status"));
                btn.Click();
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
                Assert.Fail("Đăng nhập thất bại!");
            }
        }
    }
}
