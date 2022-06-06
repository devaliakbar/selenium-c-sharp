
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCSharp.TestScripts.Sogeti
{
    public class SogetiDriver
    {
        public IWebDriver driver;

        [SetUp]
        public void Open()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.sogeti.com/";
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}

