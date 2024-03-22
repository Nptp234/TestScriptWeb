using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestScriptWeb.LikeFilmTest
{
    class LikeAfterLogin : ASetUp
    {
        [Test]
        public void TestLikeFilmAfterLogin()
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

                //get old list
                driver.Navigate().GoToUrl("https://localhost:44324/Liked");
                // check list div2
                IWebElement oldDiv = driver.FindElement(By.Id("div2"));
                Assert.IsNotNull(oldDiv, "Danh sách không tồn tại.");

                var products1 = oldDiv.FindElements(By.ClassName("product"));

                driver.Navigate().GoToUrl(url);

                IWebElement btn = null;
                try
                {
                    btn = driver.FindElement(By.XPath("/html[1]/body[1]/section[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/*[name()='svg'][1]"));
                }
                catch
                {
                    btn = driver.FindElement(By.XPath("/html[1]/body[1]/section[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/*[name()='svg'][1]"));
                };

                if (btn == null)
                {
                    Assert.Fail("Không thể yêu thích phim đã có trong danh sách!");
                }
                btn.Click();
                Thread.Sleep(1000);

                driver.FindElement(By.XPath("/html[1]/body[1]/nav[1]/div[1]/div[1]/ul[1]/li[5]/a[4]/*[name()='svg'][1]/*[name()='path'][1]")).Click();

                if (driver.Url.Contains("https://localhost:44324/Liked"))
                {
                    // check list div2
                    IWebElement newDiv = driver.FindElement(By.Id("div2"));
                    Assert.IsNotNull(newDiv, "Danh sách không tồn tại.");

                    var products2 = newDiv.FindElements(By.ClassName("product"));
                    if (products2.Count > products1.Count)
                    {
                        Assert.Pass();
                    }
                    else Assert.Fail(products1.Count + ", " + products2.Count);

                }
                else Assert.Fail(url);
            }
            else Assert.Fail(url);
        }
    }
}
