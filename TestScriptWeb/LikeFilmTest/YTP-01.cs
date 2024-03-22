using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestScriptWeb.LikeFilmTest
{
    class LikeBeforeLogin : ASetUp
    {
        [Test]
        public void TestLikeFilmBeforeLogin()
        {
            driver.Navigate().GoToUrl(url);
            QuitWeb(driver);

            if (driver.Url.Contains("https://localhost:44324/"))
            {
                IWebElement btn = null;
                try
                {
                    btn = driver.FindElement(By.XPath("/html[1]/body[1]/section[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/*[name()='svg'][1]"));
                    btn.Click();
                }
                catch
                {
                    btn = driver.FindElement(By.XPath("/html[1]/body[1]/section[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/*[name()='svg'][1]"));
                    btn.Click();
                };

                if (btn == null)
                {
                    Assert.Fail("Không tìm thấy icon yêu thích trống!");
                }
                Thread.Sleep(1000);

                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    Assert.Pass("Trang web hiển thị cảnh báo.");
                }
                catch (NoAlertPresentException)
                {
                    Assert.Fail("Trang web không hiển thị cảnh báo.");
                }
            }
            else Assert.Fail(url);
        }
    }
}
