using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace pr5_okfks
{
    public class DataSearchTest : IDisposable
    {
        IWebDriver _webDriver = new ChromeDriver();

        public void Dispose()
        {
            _webDriver.Quit();
        }

        [Fact]
        public void NoteSearchingViaContentTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";

            string loginInput = "testUser88889999123";
            string passInput = "testUser88889999123";
            string titleInput = "title";
            string contentInput = "content";
            string secondTitleInput = "title1";
            string secondContentInput = "text";
            string noteInfo = "//*[@id=\"notesList\"]/li/strong";

            string searchTBox = "//*[@id=\"searchInput\"]";
            string titleTBox = "//*[@id=\"noteTitle\"]";
            string contentTBox = "//*[@id=\"noteContent\"]";
            string saveBtn = "//*[@id=\"saveBtn\"]";
            string newNoteBtn = "//*[@id=\"newNoteBtn\"]";

            char[] letters = { 't', 'e', 'x', 't' };

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
            IWebElement newNoteElement = _webDriver.FindElement(By.XPath(newNoteBtn));
            newNoteElement.Click();

            Thread.Sleep(1000);
            titleElement.SendKeys(secondTitleInput);
            contentElement.SendKeys(secondContentInput);
            saveElement.Click();

            Thread.Sleep(3000);
            IWebElement searchElement = _webDriver.FindElement(By.XPath(searchTBox));

            for (int i = 0; i < letters.Length; i++)
            {
                searchElement.SendKeys($"{letters[i]}");
                Thread.Sleep(500);
            }

            IWebElement noteElement = _webDriver.FindElement(By.XPath(noteInfo));

            Assert.Equal(secondTitleInput, noteElement.Text);
            _webDriver.Close();
        }

        [Fact]
        public void NoteSearchingViaTitleTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";

            string loginInput = "testUser88889999123";
            string passInput = "testUser88889999123";
            string titleInput = "title";
            string contentInput = "content";
            string secondTitleInput = "text";
            string secondContentInput = "lolakoka";
            string noteInfo = "//*[@id=\"notesList\"]/li/strong";

            string searchTBox = "//*[@id=\"searchInput\"]";
            string titleTBox = "//*[@id=\"noteTitle\"]";
            string contentTBox = "//*[@id=\"noteContent\"]";
            string saveBtn = "//*[@id=\"saveBtn\"]";
            string newNoteBtn = "//*[@id=\"newNoteBtn\"]";

            char[] letters = { 't', 'e', 'x', 't' };

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
            IWebElement newNoteElement = _webDriver.FindElement(By.XPath(newNoteBtn));
            newNoteElement.Click();

            Thread.Sleep(1000);
            titleElement.SendKeys(secondTitleInput);
            contentElement.SendKeys(secondContentInput);
            saveElement.Click();

            Thread.Sleep(3000);
            IWebElement searchElement = _webDriver.FindElement(By.XPath(searchTBox));

            for (int i = 0; i < letters.Length; i++)
            {
                searchElement.SendKeys($"{letters[i]}");
                Thread.Sleep(500);
            }

            IWebElement noteElement = _webDriver.FindElement(By.XPath(noteInfo));

            Assert.Equal(secondTitleInput, noteElement.Text);
            _webDriver.Close();
        }

        [Fact]
        public void NoteSearchingInvalidTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";

            string loginInput = "testUser88889999123";
            string passInput = "testUser88889999123";
            char[] letters = { 'k', 'l', 'a', 'v', 'a', 'k', 'o', 'k', 'a' };

            string searchTBox = "//*[@id=\"searchInput\"]";

            string expected = "empty";

            IWebElement loginElement = _webDriver.FindElement(By.XPath(loginTBox));
            IWebElement passElement = _webDriver.FindElement(By.XPath(passTBox));
            IWebElement btnElement = _webDriver.FindElement(By.XPath(submitBtn));

            loginElement.SendKeys(loginInput);
            passElement.SendKeys(passInput);
            btnElement.Click();

            Thread.Sleep(3000);
            IWebElement searchElement = _webDriver.FindElement(By.XPath(searchTBox));

            for (int i = 0; i < letters.Length; i++)
            {
                searchElement.SendKeys($"{letters[i]}");
                Thread.Sleep(300);
            }

            string emptyList = "//*[@id=\"notesList\"]/li";
            IWebElement emptyElement = _webDriver.FindElement(By.XPath(emptyList));

            string actualClass = emptyElement.GetAttribute("class");

            Assert.Equal(expected, actualClass);
            _webDriver.Close();
        }
    }
}
