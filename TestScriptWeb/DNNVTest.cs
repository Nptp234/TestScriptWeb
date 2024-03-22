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
    class DNNVTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private List<User> lsKH;
        private string url = "https://localhost:44324/";

        //private static object[] DataLoginKH;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            lsKH = new List<User>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //DataLoginKH = TestLoginData.GetDataLoginKH(worksheet);
        }

        [Test]
        [TestCaseSource(typeof(TestLoginNVData), nameof(TestLoginNVData.dataNV))]
        public void TestLogin(User nv)
        {
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(3000);

            IWebElement loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("loginbtn")));
            loginButton.Click();
            Thread.Sleep(2000);

            IWebElement nvLink = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='/Home/LoginPageNV']")));
            nvLink.Click();
            Thread.Sleep(2000);

            IWebElement name = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("Username")));
            name.SendKeys(nv.Username);
            Thread.Sleep(1000);

            IWebElement pass = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("Password")));
            pass.SendKeys(nv.Password);
            Thread.Sleep(1000);

            IWebElement btn = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("status")));
            btn.Submit();
            Thread.Sleep(5000);

            var isHome = driver.Url;

            if (isHome.Contains("https://localhost:44324/Home/LoginPageNV"))
            {
                Assert.Fail();
            }
            else
            {
                var exit = driver.FindElement(By.XPath("//a[normalize-space()='Thoát']"));
                exit.Click();
                Thread.Sleep(1000);

                Assert.Pass();
            }
        }


        [OneTimeTearDown]
        public void Quit()
        {
            driver.Quit();
        }
    }
}
