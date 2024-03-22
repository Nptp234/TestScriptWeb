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
    class DNNVTest : ASetUp
    {
        [Test]
        [TestCaseSource(typeof(TestLoginNVData), nameof(TestLoginNVData.dataNV))]
        public void TestLogin(User nv)
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

            IWebElement loginNVButton = null;
            try
            {
                loginNVButton = driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/header[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/form[1]/div[5]/a[1]"));
                loginNVButton.Click();
            }
            catch
            {
                QuitWeb(driver);
                Assert.Fail("Không tìm thấy nút chuyển đăng nhập NV!");
            }

            IWebElement name = null;
            try
            {
                name = driver.FindElement(By.Name("Username"));
                name.SendKeys(nv.Username);
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
                pass.SendKeys(nv.Password);
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

            if (!driver.Url.Contains("https://localhost:44324/Home/LoginPageNV"))
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
