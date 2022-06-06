
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;

namespace SeleniumCSharp.PageObjects.Sogeti
{
    public class Home
    {
        private readonly IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "acceptCookie")]
        public IWebElement? AcceptCookieBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "level2")]
        public IWebElement? ServiceMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Automation' and @class='subMenuLink']")]
        public IWebElement? AutomationLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@aria-controls='country-list-id']")]
        public IWebElement? WorldwideDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "country-list-id")]
        public IWebElement? CountriesDiv { get; set; }

        public Home(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void AcceptCookies()
        {
            AcceptCookieBtn?.Click();
        }

        public void HoverServiceMenu()
        {
            new Actions(driver).MoveToElement(ServiceMenu).Perform();
        }

        public Automation GoToAutomationPage()
        {
            AutomationLink?.Click();
            return new Automation(driver);
        }

        public void SelectWorldwide()
        {
            WorldwideDropDown?.Click();
        }

        public List<string> GetCountryUrls()
        {
            var urls = new List<string>();

            IList<IWebElement> countries = CountriesDiv!.FindElements(By.TagName("li"));
            foreach (var country in countries)
            {
                urls.Add(country.FindElement(By.TagName("a")).GetAttribute("href"));
            }

            return urls;
        }
    }
}

