using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace pr5_okfks
{
    public class StartTest : IDisposable
    {
        IWebDriver _webDriver = new ChromeDriver();

        public void Dispose()
        {
            _webDriver.Quit();
        }

        [Fact]
        public void CorrectTitleTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";
            string expectedTitle = "Сервис заметок";

            Assert.Equal(expectedTitle, _webDriver.Title);
            _webDriver.Close();
        }

        [Theory]
        [InlineData("//*[@id=\"loginTab\"]")]
        [InlineData("//*[@id=\"registerTab\"]")]
        [InlineData("//*[@id=\"authUsername\"]")]
        [InlineData("//*[@id=\"authPassword\"]")]
        [InlineData("//*[@id=\"authSubmit\"]")]
        public void MainElementsAccessTest(string xPath)
        {
            _webDriver.Url = "https://test.webmx.ru/";
            IWebElement element = _webDriver.FindElement(By.XPath(xPath));

            Assert.True(element.Displayed);
            _webDriver.Close();
        }

        [Theory]
        [InlineData("//*[@id=\"registerTab\"]")]
        [InlineData("//*[@id=\"loginTab\"]")]
        public void UnauthUserActionsTest(string xPath)
        {
            _webDriver.Url = "https://test.webmx.ru/";
            string expectedClass = "tab active";
            IWebElement element = _webDriver.FindElement(By.XPath(xPath));

            element.Click();
            string actualClass = element.GetAttribute("class");

            Assert.Equal(expectedClass, actualClass);
            _webDriver.Close();
        }

        [Fact]
        public void CorrectActionsTest()
        {
            _webDriver.Url = "https://test.webmx.ru/";

            string loginTBox = "//*[@id=\"authUsername\"]";
            string passTBox = "//*[@id=\"authPassword\"]";
            string submitBtn = "//*[@id=\"authSubmit\"]";
            string snackbar = "//*[@id=\"message\"]";

            string loginInput = "testUser1";
            string passInput = "testUser1";

            IWebElement loginElement = _webDriver.FindElement(By.XPath(loginTBox));
            IWebElement passElement = _webDriver.FindElement(By.XPath(passTBox));
            IWebElement btnElement = _webDriver.FindElement(By.XPath(submitBtn));

            loginElement.SendKeys(loginInput);
            passElement.SendKeys(passInput);
            btnElement.Click();

            Thread.Sleep(1000);
            IWebElement message = _webDriver.FindElement(By.XPath(snackbar));

            Assert.False(message.Displayed);
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
    }
}