using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SwagLabsPOM.Pages;

namespace SwagLabsPOM.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless"); 
            chromeOptions.AddArgument("no-sandbox");
            chromeOptions.AddArgument("disable-dev-shm-usage");
            chromeOptions.AddArgument("disable-gpu");
            chromeOptions.AddArgument("window-size=1920x1080");
            chromeOptions.AddArgument("disable-extensions");
            chromeOptions.AddArgument("remote-debugging-port=9222");

            driver = new ChromeDriver(chromeOptions);

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void Teardown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        protected void Login(string username, string password)
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var loginPage = new LoginPage(driver);
            loginPage.InputUsername(username);
            loginPage.InputPassword(password);
            loginPage.ClickLoginButton();
        }
    }
}