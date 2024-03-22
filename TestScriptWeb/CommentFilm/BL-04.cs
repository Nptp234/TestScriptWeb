using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace TestScriptWeb.CommentFilm
{
    class XoaBLPhaiCuaTK : ASetUp
    {
        [Test]
        public void XoaBLPhaiCuaKH()
        {
            driver.Navigate().GoToUrl(url);

            if (driver.Url.Contains("https://localhost:44324/"))
            {
                driver.Navigate().GoToUrl("https://localhost:44324/Home/LoginPage");

                string name = "phuoc1", pass = "12345678";

                driver.FindElement(By.Name("Username")).SendKeys(name);
                driver.FindElement(By.Name("Password")).SendKeys(pass);
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

                if (oldComments.Count > 0)
                {
                    foreach (var comment in oldComments)
                    {
                        string  blUsername = comment.FindElement(By.TagName("h4")).Text.Trim().ToLower();

                        if (name.Trim().ToLower().Equals(blUsername))
                        {
                            IWebElement deleteBtn = null;
                            try
                            {
                                deleteBtn = comment.FindElement(By.XPath(".//a[contains(text(), 'Xoá bình luận')]"));
                                deleteBtn.Click();
                            }
                            catch
                            {
                                Assert.Fail("Không tìm thấy nút xóa!");
                            }

                            // Tìm phần tử chứa danh sách bình luận
                            var newCommentContainer = driver.FindElement(By.CssSelector(".comment-container"));

                            // Tìm các phần tử chứa comment
                            ReadOnlyCollection<IWebElement> newComments = newCommentContainer.FindElements(By.CssSelector(".comment"));

                            if (oldComments.Count > newComments.Count)
                            {
                                Assert.Pass("Có thể xóa bình luận!");
                            }
                            else
                            {
                                Assert.Fail("Xóa không thành công!");
                            }

                        }
                    }
                }
                else Assert.Fail("Danh sách bình luận trống!");
            }
        }
    }
}
