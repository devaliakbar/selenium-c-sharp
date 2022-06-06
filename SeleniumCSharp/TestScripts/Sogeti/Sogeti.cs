
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumCSharp.TestScripts.Sogeti;

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

        //Verifying Service is selected by checking it's color
        var automationText = driver.FindElement(By.XPath("//a[text()='Automation' and @class='subMenuLink']"));
        Assert.That(serviceText.GetCssValue("color"), Is.EqualTo(selectedTextColor));
    }
}
