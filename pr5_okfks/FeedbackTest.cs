using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            string saveNoteText = "Заметка создана.";
            string editNoteText = "Заметка обновлена.";
            string deleteNoteText = "Заметка удалена.";

            IWebElement loginElement = _webDriver.FindElement(By.XPath(loginTBox));
            IWebElement passElement = _webDriver.FindElement(By.XPath(passTBox));
            IWebElement btnElement = _webDriver.FindElement(By.XPath(submitBtn));

            loginElement.SendKeys(falseLoginInput);
            passElement.SendKeys(falsePassInput);
            btnElement.Click();

            Thread.Sleep(1000);
            string loginMessage = "//*[@id=\"message\"]/span";
            IWebElement loginMessageElement = _webDriver.FindElement(By.XPath(loginMessage));

            Assert.Equal(falseLoginText, loginMessageElement.Text);

            loginElement.Clear();
            passElement.Clear();
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

            Thread.Sleep(1000);

            string saveNoteMessage = "//*[@id=\"message\"]/span";
            IWebElement saveNoteElement = _webDriver.FindElement(By.XPath(saveNoteMessage));

            Assert.Equal(saveNoteText, saveNoteElement.Text);

            titleElement.SendKeys(newTitleInput);
            contentElement.SendKeys(contentInput);
            saveElement.Click();

            Thread.Sleep(1000);

            string editNoteMessage = "//*[@id=\"message\"]/span";
            IWebElement editNoteElement = _webDriver.FindElement(By.XPath(editNoteMessage));

            Assert.Equal(editNoteText, editNoteElement.Text);

            Thread.Sleep(1000);

            IWebElement deleteElement = _webDriver.FindElement(By.XPath(deleteBtn));
            deleteElement.Click();
            _webDriver.SwitchTo().Alert().Accept();

            Thread.Sleep(1000);

            string deleteMessage = "//*[@id=\"message\"]/span";
            IWebElement deleteNoteElement = _webDriver.FindElement(By.XPath(deleteMessage));
            Assert.Equal(deleteNoteText, deleteNoteElement.Text);
            _webDriver.Close();
        }
    }
}
