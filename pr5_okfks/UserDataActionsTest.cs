using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr5_okfks
{
    public class UserDataActionsTest : IDisposable
    {
        WebDriver _webDriver = new ChromeDriver();

        public void Dispose()
        {
            _webDriver.Quit();
        }

        [Fact]
        public void NoteCreationTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";

            string loginInput = "testUser1";
            string passInput = "testUser1";
            string titleInput = "title";
            string contentInput = "content";

            string titleTBox = "//*[@id=\"noteTitle\"]";
            string contentTBox = "//*[@id=\"noteContent\"]";
            string saveBtn = "//*[@id=\"saveBtn\"]";
            string messageInfo = "//*[@id=\"message\"]/span";

            string expected = "Заметка создана.";

            IWebElement loginElement = _webDriver.FindElement(By.XPath(loginTBox));
            IWebElement passElement = _webDriver.FindElement(By.XPath(passTBox));
            IWebElement btnElement = _webDriver.FindElement(By.XPath(submitBtn));

            loginElement.SendKeys(loginInput);
            passElement.SendKeys(passInput);
            btnElement.Click();

            Thread.Sleep(1000);
            IWebElement titleElement = _webDriver.FindElement(By.XPath(titleTBox));
            IWebElement contentElement = _webDriver.FindElement(By.XPath(contentTBox));
            IWebElement saveElement = _webDriver.FindElement(By.XPath(saveBtn));

            titleElement.SendKeys(titleInput);
            contentElement.SendKeys(contentInput);
            saveElement.Click();

            Thread.Sleep(3000);
            IWebElement messageElement = _webDriver.FindElement(By.XPath(messageInfo));

            Assert.Equal(expected, messageElement.Text);
            _webDriver.Close();
        }

        [Fact]
        public void NoteCreationBadTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";

            string loginInput = "testUser1";
            string passInput = "testUser1";
            string titleInput = "";
            string contentInput = "";

            string titleTBox = "//*[@id=\"noteTitle\"]";
            string contentTBox = "//*[@id=\"noteContent\"]";
            string saveBtn = "//*[@id=\"saveBtn\"]";
            string message = "//*[@id=\"message\"]";

            IWebElement loginElement = _webDriver.FindElement(By.XPath(loginTBox));
            IWebElement passElement = _webDriver.FindElement(By.XPath(passTBox));
            IWebElement btnElement = _webDriver.FindElement(By.XPath(submitBtn));

            loginElement.SendKeys(loginInput);
            passElement.SendKeys(passInput);
            btnElement.Click();

            Thread.Sleep(1000);
            IWebElement titleElement = _webDriver.FindElement(By.XPath(titleTBox));
            IWebElement contentElement = _webDriver.FindElement(By.XPath(contentTBox));
            IWebElement saveElement = _webDriver.FindElement(By.XPath(saveBtn));

            titleElement.SendKeys(titleInput);
            contentElement.SendKeys(contentInput);
            saveElement.Click();

            Thread.Sleep(1000);
            IWebElement messageElement = _webDriver.FindElement(By.XPath(message));

            Assert.False(messageElement.Displayed);
            _webDriver.Close();
        }

        [Fact]
        public void NoteDeletionTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";

            string loginInput = "testUser88889999123";
            string passInput = "testUser88889999123";
            string titleInput = "title";
            string contentInput = "content";

            string titleTBox = "//*[@id=\"noteTitle\"]";
            string contentTBox = "//*[@id=\"noteContent\"]";
            string saveBtn = "//*[@id=\"saveBtn\"]";
            string deleteBtn = "//*[@id=\"deleteBtn\"]";
            string messageInfo = "//*[@id=\"message\"]/span";

            string expected = "Заметка удалена.";

            IWebElement loginElement = _webDriver.FindElement(By.XPath(loginTBox));
            IWebElement passElement = _webDriver.FindElement(By.XPath(passTBox));
            IWebElement btnElement = _webDriver.FindElement(By.XPath(submitBtn));

            loginElement.SendKeys(loginInput);
            passElement.SendKeys(passInput);
            btnElement.Click();

            Thread.Sleep(1000);
            IWebElement titleElement = _webDriver.FindElement(By.XPath(titleTBox));
            IWebElement contentElement = _webDriver.FindElement(By.XPath(contentTBox));
            IWebElement saveElement = _webDriver.FindElement(By.XPath(saveBtn));

            titleElement.SendKeys(titleInput);
            contentElement.SendKeys(contentInput);
            saveElement.Click();

            Thread.Sleep(3000);
            IWebElement deleteElement = _webDriver.FindElement(By.XPath(deleteBtn));

            deleteElement.Click();
            _webDriver.SwitchTo().Alert().Accept();

            Thread.Sleep(3000);
            IWebElement messageElement = _webDriver.FindElement(By.XPath(messageInfo));

            Assert.Equal(expected, messageElement.Text);
            _webDriver.Close();
        }
        [Fact]
        public void NoteEditTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";

            string loginInput = "testUser88889999123";
            string passInput = "testUser88889999123";
            string titleInput = "title";
            string contentInput = "content";
            string newTitleInput = "titleee";
            string newContentInput = "contenteee";
            string messageInfo = "//*[@id=\"message\"]/span";

            string titleTBox = "//*[@id=\"noteTitle\"]";
            string contentTBox = "//*[@id=\"noteContent\"]";
            string saveBtn = "//*[@id=\"saveBtn\"]";

            string expected = "Заметка обновлена.";

            IWebElement loginElement = _webDriver.FindElement(By.XPath(loginTBox));
            IWebElement passElement = _webDriver.FindElement(By.XPath(passTBox));
            IWebElement btnElement = _webDriver.FindElement(By.XPath(submitBtn));

            loginElement.SendKeys(loginInput);
            passElement.SendKeys(passInput);
            btnElement.Click();

            Thread.Sleep(1000);
            IWebElement titleElement = _webDriver.FindElement(By.XPath(titleTBox));
            IWebElement contentElement = _webDriver.FindElement(By.XPath(contentTBox));
            IWebElement saveElement = _webDriver.FindElement(By.XPath(saveBtn));

            titleElement.SendKeys(titleInput);
            contentElement.SendKeys(contentInput);
            saveElement.Click();

            Thread.Sleep(3000);
            titleElement.SendKeys(newTitleInput);
            contentElement.SendKeys(newContentInput);
            saveElement.Click();

            Thread.Sleep(3000);
            IWebElement messageElement = _webDriver.FindElement(By.XPath(messageInfo));

            Assert.Equal(expected, messageElement.Text);
            _webDriver.Close();
        }
    }
}
