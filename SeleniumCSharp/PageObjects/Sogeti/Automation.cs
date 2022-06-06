using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using SeleniumCSharp.Utilities;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharp.PageObjects.Sogeti
{
    public class Automation
    {
        private readonly IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//span[text()='Automation']")]
        public IWebElement? AutomationText { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Services']")]
        public IWebElement? ServiceMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Automation' and @class='subMenuLink']")]
        public IWebElement? AutomationMenu { get; set; }

        [FindsBy(How = How.Id, Using = "4ff2ed4d-4861-4914-86eb-87dfa65876d8")]
        public IWebElement? FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "11ce8b49-5298-491a-aebe-d0900d6f49a7")]
        public IWebElement? LastName { get; set; }

        [FindsBy(How = How.Id, Using = "056d8435-4d06-44f3-896a-d7b0bf4d37b2")]
        public IWebElement? Email { get; set; }

        [FindsBy(How = How.Id, Using = "755aa064-7be2-432b-b8a2-805b5f4f9384")]
        public IWebElement? Phone { get; set; }

        [FindsBy(How = How.Id, Using = "703dedb1-a413-4e71-9785-586d609def60")]
        public IWebElement? Company { get; set; }

        [FindsBy(How = How.Id, Using = "e74d82fb-949d-40e5-8fd2-4a876319c45a")]
        public IWebElement? Country { get; set; }

        [FindsBy(How = How.Id, Using = "88459d00-b812-459a-99e4-5dc6eff2aa19")]
        public IWebElement? Message { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@for='__field_1239350']")]
        public IWebElement? AgreeChkBox { get; set; }

        [FindsBy(How = How.Id, Using = "b35711ee-b569-48b4-8ec4-6476dbf61ef8")]
        public IWebElement? SubmitBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[text()='Thank you for contacting us.']")]
        public IWebElement? ThankYouMsg { get; set; }

        public Automation(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string GetServiceMenuColor()
        {
            return ServiceMenu!.GetCssValue("color");
        }

        public void HoverServiceMenu()
        {
            new Actions(driver).MoveToElement(ServiceMenu).Perform();
        }

        public string GetAutomationMenuColor()
        {
            return AutomationMenu!.GetCssValue("color");
        }

        public void FillForm()
        {
            FirstName?.SendKeys(TestUtilities.GenerateRandomString());
            LastName?.SendKeys(TestUtilities.GenerateRandomString());
            Email?.SendKeys(TestUtilities.GenerateRandomEmail());
            Phone?.SendKeys(TestUtilities.GenerateRandomString());
            Company?.SendKeys(TestUtilities.GenerateRandomString());
            new SelectElement(Country).SelectByValue("Germany");
            Message?.SendKeys(TestUtilities.GenerateRandomString());
            AgreeChkBox?.Click();
        }

        public void SubmitForm()
        {
            SubmitBtn?.Click();
        }
    }
}

