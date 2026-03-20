using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr5_okfks
{
    public class MainPageTest : IDisposable
    {
        IWebDriver _webDriver = new ChromeDriver();

        public void Dispose()
        {
            _webDriver.Quit();
        }

        [Fact]
        public void MainPageAccessTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";

            string loginInput = "testUser1";
            string passInput = "testUser1";

            IWebElement loginElement = _webDriver.FindElement(By.XPath(loginTBox));
            IWebElement passElement = _webDriver.FindElement(By.XPath(passTBox));
            IWebElement btnElement = _webDriver.FindElement(By.XPath(submitBtn));

            loginElement.SendKeys(loginInput);
            passElement.SendKeys(passInput);
            btnElement.Click();

            Thread.Sleep(1000);
            string noteSection = "//*[@id=\"notesSection\"]";
            IWebElement sectionElement = _webDriver.FindElement(By.XPath(noteSection));

            Assert.True(sectionElement.Displayed);
            _webDriver.Close();
        }

        [Fact]
        public void MainElementsAccessTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";

            string loginInput = "testUser1";
            string passInput = "testUser1";

            IWebElement loginElement = _webDriver.FindElement(By.XPath(loginTBox));
            IWebElement passElement = _webDriver.FindElement(By.XPath(passTBox));
            IWebElement btnElement = _webDriver.FindElement(By.XPath(submitBtn));

            loginElement.SendKeys(loginInput);
            passElement.SendKeys(passInput);
            btnElement.Click();

            Thread.Sleep(1000);

            string searchInput = "//*[@id=\"searchInput\"]";
            string filter = "//*[@id=\"noteScopeFilter\"]";
            string newNoteBtn = "//*[@id=\"newNoteBtn\"]";

            string titleInput = "//*[@id=\"noteTitle\"]";
            string contentInput = "//*[@id=\"noteContent\"]";
            string saveBtn = "//*[@id=\"saveBtn\"]";
            string deleteBtn = "//*[@id=\"deleteBtn\"]";

            IWebElement searchElement = _webDriver.FindElement(By.XPath(searchInput));
            IWebElement filterElement = _webDriver.FindElement(By.XPath(filter));
            IWebElement newNoteElement = _webDriver.FindElement(By.XPath(newNoteBtn));

            IWebElement titleElement = _webDriver.FindElement(By.XPath(titleInput));
            IWebElement contentElement = _webDriver.FindElement(By.XPath(contentInput));
            IWebElement saveElement = _webDriver.FindElement(By.XPath(saveBtn));
            IWebElement deleteElement = _webDriver.FindElement(By.XPath(deleteBtn));

            Assert.True(searchElement.Displayed);
            Assert.True(filterElement.Displayed);
            Assert.True(newNoteElement.Displayed);
            Assert.True(titleElement.Displayed);
            Assert.True(contentElement.Displayed);
            Assert.True(saveElement.Displayed);
            Assert.True(deleteElement.Displayed);
            _webDriver.Close();
        }

        [Fact]
        public void WorkStateChangeTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";

            string loginInput = "testUser1";
            string passInput = "testUser1";

            string logoutBtn = "//*[@id=\"logoutBtn\"]";

            string authSection = "//*[@id=\"authSection\"]";
            string mainSection = "//*[@id=\"notesSection\"]                      ";

            IWebElement loginElement = _webDriver.FindElement(By.XPath(loginTBox));
            IWebElement passElement = _webDriver.FindElement(By.XPath(passTBox));
            IWebElement btnElement = _webDriver.FindElement(By.XPath(submitBtn));

            loginElement.SendKeys(loginInput);
            passElement.SendKeys(passInput);
            btnElement.Click();

            Thread.Sleep(1000);
            IWebElement mainElement = _webDriver.FindElement(By.XPath(mainSection));
            IWebElement authElement = _webDriver.FindElement(By.XPath(authSection));

            Assert.True(mainElement.Displayed);
            Assert.False(authElement.Displayed);

            IWebElement logoutElement = _webDriver.FindElement(By.XPath(logoutBtn));
            logoutElement.Click();

            Thread.Sleep(1000);
            Assert.True(authElement.Displayed);
            Assert.False(mainElement.Displayed);
            _webDriver.Close();
        }

        [Fact]
        public void PageContentChangeUponInteractionTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";

            string loginInput = "testUser1";
            string passInput = "testUser1";
            string titleInput = "title";
            string contentInput = "content";

            string titleBox = "//*[@id=\"noteTitle\"]";
            string contentBox = "//*[@id=\"noteContent\"]";
            string saveBtn = "//*[@id=\"saveBtn\"]";

            string editBlock = "//*[@id=\"shareBlock\"]";

            IWebElement loginElement = _webDriver.FindElement(By.XPath(loginTBox));
            IWebElement passElement = _webDriver.FindElement(By.XPath(passTBox));
            IWebElement btnElement = _webDriver.FindElement(By.XPath(submitBtn));

            loginElement.SendKeys(loginInput);
            passElement.SendKeys(passInput);
            btnElement.Click();

            Thread.Sleep(1000);
            IWebElement titleElement = _webDriver.FindElement(By.XPath(titleBox));
            IWebElement contentElement = _webDriver.FindElement(By.XPath(contentBox));
            IWebElement saveElement = _webDriver.FindElement(By.XPath(saveBtn));

            titleElement.SendKeys(titleInput);
            contentElement.SendKeys(contentInput);
            saveElement.Click();

            Thread.Sleep(3000);
            IWebElement editElement = _webDriver.FindElement(By.XPath(editBlock));

            Assert.True(editElement.Displayed);
            _webDriver.Close();
        }
    }
}
