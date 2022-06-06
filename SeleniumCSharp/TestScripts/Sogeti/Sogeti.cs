
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumCSharp.TestScripts.Sogeti;
using SeleniumCSharp.Utilities;

namespace SeleniumCSharp;

public class Sogeti : SogetiDriver
{
    [Test]
    public void Test1()
    {
        driver.FindElement(By.ClassName("acceptCookie")).Click();

        var element = driver.FindElement(By.ClassName("level2"));
        new Actions(driver).MoveToElement(element).Perform();

        driver.FindElement(By.XPath("//a[text()='Automation' and @class='subMenuLink']")).Click();

        //Verifying successfully naviagted to automation page
        Assert.That(driver.Url, Is.EqualTo("https://www.sogeti.com/services/automation/"));


        const string selectedTextColor = "rgba(255, 48, 76, 1)";

        //Verifying Service is selected by checking it's color
        var serviceText = driver.FindElement(By.XPath("//span[text()='Services']"));
        Assert.That(serviceText.GetCssValue("color"), Is.EqualTo(selectedTextColor));

        new Actions(driver).MoveToElement(serviceText).Perform();

        //Verifying Automation is selected by checking it's color
        var automationText = driver.FindElement(By.XPath("//a[text()='Automation' and @class='subMenuLink']"));
        Assert.That(automationText.GetCssValue("color"), Is.EqualTo(selectedTextColor));
    }

    [Test]
    public void Test2()
    {
        driver.FindElement(By.ClassName("acceptCookie")).Click();

        var element = driver.FindElement(By.ClassName("level2"));
        new Actions(driver).MoveToElement(element).Perform();

        driver.FindElement(By.XPath("//a[text()='Automation' and @class='subMenuLink']")).Click();

        driver.FindElement(By.Id("4ff2ed4d-4861-4914-86eb-87dfa65876d8")).SendKeys(TestUtilities.GenerateRandomString());

        driver.FindElement(By.Id("11ce8b49-5298-491a-aebe-d0900d6f49a7")).SendKeys(TestUtilities.GenerateRandomString());

        driver.FindElement(By.Id("056d8435-4d06-44f3-896a-d7b0bf4d37b2")).SendKeys(TestUtilities.GenerateRandomEmail());

        driver.FindElement(By.Id("755aa064-7be2-432b-b8a2-805b5f4f9384")).SendKeys(TestUtilities.GenerateRandomString());

        driver.FindElement(By.Id("703dedb1-a413-4e71-9785-586d609def60")).SendKeys(TestUtilities.GenerateRandomString());

        new SelectElement(driver.FindElement(By.Id("e74d82fb-949d-40e5-8fd2-4a876319c45a"))).SelectByValue("Germany");

        driver.FindElement(By.Id("88459d00-b812-459a-99e4-5dc6eff2aa19")).SendKeys(TestUtilities.GenerateRandomString());

        driver.FindElement(By.XPath("//label[@for='__field_1239350']")).Click();

        // Here captcha need to solve manually within 10 seconds
        // driver.FindElement(By.XPath(".//*[@class='rc-anchor-content']")).Click();
        Thread.Sleep(TimeSpan.FromSeconds(10));

        driver.FindElement(By.Id("b35711ee-b569-48b4-8ec4-6476dbf61ef8")).Click();


        driver.FindElement(By.XPath("//p[text()='Thank you for contacting us.']"));
    }

    [Test]
    public void Test3()
    {
        driver.FindElement(By.ClassName("acceptCookie")).Click();

        driver.FindElement(By.XPath(".//*[@aria-controls='country-list-id']")).Click();

        IList<IWebElement> countries = driver.FindElement(By.Id("country-list-id")).FindElements(By.TagName("li"));

        foreach (var country in countries)
        {
            string url = country.FindElement(By.TagName("a")).GetAttribute("href");
            Assert.That(TestUtilities.GetHttpStatus(url), Is.EqualTo("OK"));
        }
    }
}
