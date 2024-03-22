using NUnit.Framework;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestScriptWeb
{
    public abstract class ASetUp
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected static string url = "https://localhost:44324/";


        [OneTimeSetUp]
        public void SetUp()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Quit();
        }


        public void QuitWeb(IWebDriver dri)
        {
            dri.Navigate().GoToUrl("https://localhost:44324/Home/Logout");
        }
    }
}
