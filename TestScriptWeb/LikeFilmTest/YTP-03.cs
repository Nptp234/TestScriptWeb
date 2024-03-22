using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestScriptWeb.LikeFilmTest
{
    class XoaYeuThich : ASetUp
    {
        [Test]
        public void XoaYT()
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

                //get list
                driver.Navigate().GoToUrl("https://localhost:44324/Liked");
                IWebElement oldDiv = driver.FindElement(By.Id("div2"));
                Assert.IsNotNull(oldDiv, "Danh sách không tồn tại.");

                //old list
                var products1 = oldDiv.FindElements(By.ClassName("product"));

                //delete
                if (products1.Count > 0)
                {
                    driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[4]/a[1]/button[1]")).Click();
                    Thread.Sleep(1000);
                }
                else Assert.Fail("Danh sách trống " + products1.Count);

                //get list
                IWebElement newDiv = driver.FindElement(By.Id("div2"));
                Assert.IsNotNull(newDiv, "Danh sách không tồn tại.");

                //new list
                var products2 = newDiv.FindElements(By.ClassName("product"));

                //check
                if (products2.Count < products1.Count)
                {
                    Assert.Pass("Success!");
                }
                else Assert.Fail(products1.Count + ", " + products2.Count);

            }
            else Assert.Fail(url);
        }
    }
}
