using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr5_okfks
{
    public class UserProfileTest : IDisposable
    {
        IWebDriver _webDriver = new ChromeDriver();
        public void Dispose()
        {
            _webDriver.Quit();
        }

        [Fact]
        public void LoginTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";
            string loginText = "//*[@id=\"welcomeText\"]";

            string loginInput = "testUser1";
            string passInput = "testUser1";

            IWebElement loginElement = _webDriver.FindElement(By.XPath(loginTBox));
            IWebElement passElement = _webDriver.FindElement(By.XPath(passTBox));
            IWebElement btnElement = _webDriver.FindElement(By.XPath(submitBtn));

            loginElement.SendKeys(loginInput);
            passElement.SendKeys(passInput);
            btnElement.Click();

            Thread.Sleep(1000);
            IWebElement welcome = _webDriver.FindElement(By.XPath(loginText));

            Assert.True(welcome.Displayed);
            _webDriver.Close();
        }

        [Fact]
        public void LogoutTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";

            string loginInput = "testUser1";
            string passInput = "testUser1";

            string logoutBtn = "//*[@id=\"logoutBtn\"]";
            string logoutSnackbar = "//*[@id=\"message\"]";

            IWebElement loginElement = _webDriver.FindElement(By.XPath(loginTBox));
            IWebElement passElement = _webDriver.FindElement(By.XPath(passTBox));
            IWebElement btnElement = _webDriver.FindElement(By.XPath(submitBtn));

            loginElement.SendKeys(loginInput);
            passElement.SendKeys(passInput);
            btnElement.Click();

            Thread.Sleep(1000);
            IWebElement logoutElement = _webDriver.FindElement(By.XPath(logoutBtn));
            logoutElement.Click();

            Thread.Sleep(1000);
            IWebElement message = _webDriver.FindElement(By.XPath(logoutSnackbar));

            Assert.True(message.Displayed);
            _webDriver.Close();
        }

        [Fact]
        public void IncorrectActionsTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";
            string snackbar = "//*[@id=\"message\"]";

            string loginInput = "incorrectInput";
            string passInput = "qwerty123";

            IWebElement loginElement = _webDriver.FindElement(By.XPath(loginTBox));
            IWebElement passElement = _webDriver.FindElement(By.XPath(passTBox));
            IWebElement btnElement = _webDriver.FindElement(By.XPath(submitBtn));

            loginElement.SendKeys(loginInput);
            passElement.SendKeys(passInput);
            btnElement.Click();

            Thread.Sleep(1000);
            IWebElement message = _webDriver.FindElement(By.XPath(snackbar));

            Assert.True(message.Displayed);
            _webDriver.Close();
        }

        [Fact]
        public void ConditionAfterLoginTest()
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
            Assert.False(loginElement.Displayed);
            Assert.False(passElement.Displayed);
            Assert.False(btnElement.Displayed);
            _webDriver.Close();
        }
    }
}
