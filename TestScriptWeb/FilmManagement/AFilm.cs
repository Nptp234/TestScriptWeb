using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestScriptWeb.FilmManagement
{
    public class AFilm : ASetUp
    {
        public void DNNV(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://localhost:44324/");
            driver.Manage().Window.Maximize();

            var loginbtn = driver.FindElement(By.Name("loginbtn"));
            loginbtn.Click();
            Thread.Sleep(1000);

            var dnnvlink = driver.FindElement(By.LinkText("Đăng nhập nhân viên?"));
            dnnvlink.Click();
            Thread.Sleep(1000);

            var username = driver.FindElement(By.Name("Username"));
            username.SendKeys("phuoc1@gmail.com");
            username.SendKeys(Keys.Enter);

            var password = driver.FindElement(By.Name("Password"));
            password.SendKeys("12345678");
            password.SendKeys(Keys.Enter);
        }

        public void OpenFilm(IWebDriver driver)
        {
            //Mở trang phim
            var film = driver.FindElement(By.LinkText("Film"));
            film.Click();
            Thread.Sleep(1000);
        }

        public void ButtonShowList(IWebDriver driver)
        {
            //Nhấn nút hiện danh sách
            var list = driver.FindElement(By.Id("button_showlist"));
            list.Click();
        }

        public IList<IWebElement> GetList(IWebDriver driver)
        {
            // Lấy danh sách các phần tử tr trong tbody
            IList<IWebElement> ls = null;
            try
            {
                ls = driver.FindElements(By.CssSelector("tbody tr"));
            }
            catch
            {
                ls = null;
            }
            return ls;
        }
    }
}
