
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Reflection;

namespace SeleniumCSharp.TestScripts.Sogeti
{
    public class SogetiDriver
    {
        protected IWebDriver driver;
        protected ExtentReports extent;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(@"/Users/apple/Downloads/Report" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);
        }

        [SetUp]
        public void Open()
        {
            driver = new ChromeDriver
            {
                Url = "https://www.sogeti.com/"
            };
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
    }
}

