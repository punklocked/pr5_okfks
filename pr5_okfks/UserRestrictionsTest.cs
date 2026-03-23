using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr5_okfks
{
    public class UserRestrictionsTest : IDisposable
    {
        IWebDriver _webDriver = new ChromeDriver();

        public void Dispose()
        {
            _webDriver.Quit();
        }

        [Fact]
        public void CreatedNoteActionsTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";
            string deleteBtn = "//*[@id=\"deleteBtn\"]";
            string exitBtn = "//*[@id=\"logoutBtn\"]";

            string loginInput = "testUser88889999123";
            string passInput = "testUser88889999123";
            string loginSecondInput = "testUser99998888123";
            string passSecondInput = "testUser99998888123";
            string titleInput = "title";
            string contentInput = "content";
            string newTitleInput = "newTitle";

            string titleTBox = "//*[@id=\"noteTitle\"]";
            string contentTBox = "//*[@id=\"noteContent\"]";
            string saveBtn = "//*[@id=\"saveBtn\"]";

            string expected = "newTitle";

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
            IWebElement exitElement = _webDriver.FindElement(By.XPath(exitBtn));

            titleElement.SendKeys(titleInput);
            contentElement.SendKeys(contentInput);
            saveElement.Click();

            Thread.Sleep(1000);

            string shareTBox = "//*[@id=\"shareUsername\"]";
            string shareBtn = "//*[@id=\"shareBtn\"]";

            IWebElement shareBoxElement = _webDriver.FindElement(By.XPath(shareTBox));
            IWebElement shareBtnElement = _webDriver.FindElement(By.XPath(shareBtn));

            shareBoxElement.SendKeys(loginSecondInput);
            shareBtnElement.Click();

            Thread.Sleep(1000);
            string removeBtn = "//*[@id=\"sharedUsersList\"]/li/button";
            IWebElement removeBtnElement = _webDriver.FindElement(By.XPath(removeBtn));
            Assert.True(removeBtnElement.Displayed);

            Thread.Sleep(1000);
            exitElement.Click();

            Thread.Sleep(1000);
            loginElement.Clear();
            passElement.Clear();
            loginElement.SendKeys(loginSecondInput);
            passElement.SendKeys(passSecondInput);
            btnElement.Click();

            Thread.Sleep(1000);
            string listItem = "//*[@id=\"notesList\"]/li";

            IWebElement listElement = _webDriver.FindElement(By.XPath(listItem));
            listElement.Click();

            IWebElement deleteElement = _webDriver.FindElement(By.XPath(deleteBtn));
            Assert.False(deleteElement.Enabled);

            titleElement.Clear();
            titleElement.SendKeys(newTitleInput);
            saveElement.Click();

            Thread.Sleep(1000);
            exitElement.Click();

            Thread.Sleep(1000);
            loginElement.Clear();
            passElement.Clear();
            loginElement.SendKeys(loginInput);
            passElement.SendKeys(passInput);
            btnElement.Click();

            Thread.Sleep(1000);
            string newListItem = "//*[@id=\"notesList\"]/li/strong";

            IWebElement newItemElement = _webDriver.FindElement(By.XPath(newListItem));

            Assert.Equal(expected, newItemElement.Text);
            _webDriver.Close();
        }
    }
}
