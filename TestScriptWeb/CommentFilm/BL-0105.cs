using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using TestScriptWeb.Data;

namespace TestScriptWeb.CommentFilm
{
    class KiemThuBLDN : ASetUp
    {
        int rowIndex = 1;

        [Test]
        [TestCaseSource(typeof(TestDataComment), nameof(TestDataComment.dataBL))]
        public void KiemThuBLDaDN(string binhluan)
        {
            rowIndex++;
            driver.Navigate().GoToUrl(url);

            if (driver.Url.Contains("https://localhost:44324/"))
            {
                driver.Navigate().GoToUrl("https://localhost:44324/Home/LoginPage");

                driver.FindElement(By.Name("Username")).SendKeys("phuoc1");
                driver.FindElement(By.Name("Password")).SendKeys("12345678");
                driver.FindElement(By.Name("status")).Submit();
                Thread.Sleep(1000);

                driver.Navigate().GoToUrl(url);

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

                // Tìm phần tử chứa danh sách bình luận
                var oldCommentContainer = driver.FindElement(By.CssSelector(".comment-container"));

                // Tìm các phần tử chứa comment
                ReadOnlyCollection<IWebElement> oldComments = oldCommentContainer.FindElements(By.CssSelector(".comment"));

                var cmt = driver.FindElement(By.Name("GhiChu"));
                cmt.SendKeys(binhluan);

                var postcmt = driver.FindElement(By.XPath("/html[1]/body[1]/section[1]/div[1]/div[1]/div[1]/div[1]/div[2]/button[1]"));
                postcmt.Click();

                Thread.Sleep(2000);


                // Tìm phần tử chứa danh sách bình luận
                var newCommentContainer = driver.FindElement(By.CssSelector(".comment-container"));

                // Tìm các phần tử chứa comment
                ReadOnlyCollection<IWebElement> newComments = newCommentContainer.FindElements(By.CssSelector(".comment"));

                if (newComments.Count > oldComments.Count)
                {
                    driver.Navigate().GoToUrl(url);

                    QuitWeb(driver);

                    Thread.Sleep(2000);

                    TestDataComment.WriteEXBL("Pass", rowIndex);
                    Assert.Pass();
                }
                else
                {
                    TestDataComment.WriteEXBL("cmt khong thanh cong", rowIndex);
                    Assert.Fail("cmt khong thanh cong");
                }
            }
        }
    }
}
