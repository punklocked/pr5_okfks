using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr5_okfks
{
    public class FeedbackTest : IDisposable
    {
        IWebDriver _webDriver = new ChromeDriver();

        public void Dispose()
        {
            _webDriver.Quit();
        }

        [Fact]
        public void ActionsFeedbackTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";
            string deleteBtn = "//*[@id=\"deleteBtn\"]";
            string exitBtn = "//*[@id=\"logoutBtn\"]";

            string loginInput = "testUser88889999123";
            string passInput = "testUser88889999123";
            string falseLoginInput = "hhfhdfhd";
            string falsePassInput = "hfghghyrrrr";
            string titleInput = "title";
            string contentInput = "content";
            string newTitleInput = "newTitle";

            string titleTBox = "//*[@id=\"noteTitle\"]";
            string contentTBox = "//*[@id=\"noteContent\"]";
            string saveBtn = "//*[@id=\"saveBtn\"]";

            string falseLoginText = "Неверный логин или пароль.";

            IWebElement loginElement = _webDriver.FindElement(By.XPath(loginTBox));
            IWebElement passElement = _webDriver.FindElement(By.XPath(passTBox));
            IWebElement btnElement = _webDriver.FindElement(By.XPath(submitBtn));

            loginElement.SendKeys(falseLoginInput);
            passElement.SendKeys(falsePassInput);
            btnElement.Click();

            Thread.Sleep(1000);
            string loginMessage = "//*[@id=\"message\"]/span";
            IWebElement loginMessageElement = _webDriver.FindElement(By.XPath(loginMessage));

        }
    }
}
