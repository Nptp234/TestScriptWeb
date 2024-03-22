using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestScriptWeb.CommentFilm
{
    class KiemThuBL0DN : ASetUp
    {
        [Test]
        public void KiemThuBLChuaDN()
        {
            driver.Navigate().GoToUrl(url);

            if (driver.Url.Contains("https://localhost:44324/"))
            {

                IWebElement btn = null;
                try
                {
                    btn = driver.FindElement(By.XPath("/html[1]/body[1]/section[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/a[1]"));
                    btn.Click();
                }
                catch
                {
                    btn = driver.FindElement(By.XPath("/html[1]/body[1]/section[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/div[1]/a[1]"));
                    btn.Click();
                };

                if (btn == null)
                {
                    Assert.Fail("Không tìm thấy phim!");
                }
                Thread.Sleep(1000);

                var cmt = driver.FindElement(By.Name("GhiChu"));
                string isRead = cmt.GetAttribute("readonly");
                string isDis = cmt.GetAttribute("disabled");

                if (isRead != null || isDis != null)
                {
                    Assert.Pass();
                }
                else
                {
                    var cmtBtn = driver.FindElement(By.Name("status"));
                    isRead = cmtBtn.GetAttribute("readonly");
                    isDis = cmtBtn.GetAttribute("disabled");

                    if (isRead != null || isDis != null) { Assert.Pass(); }
                    else Assert.Fail("Bình luận không bị tắt!");
                }
            }
        }
    }
}
