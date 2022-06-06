using SeleniumCSharp.TestScripts.Sogeti;
using SeleniumCSharp.Utilities;
using SeleniumCSharp.PageObjects.Sogeti;

namespace SeleniumCSharp;

public class Sogeti : SogetiDriver
{
    [Test]
    [Author("Ali Akbar", "officialakbarali@gmail.com")]
    [Category("UI Testing")]
    [Description("After selecting 'Automation' option from menu, verify that the Services and Automation are selected, verify 'Automation' page is displayed,  and “Automation” text is visible in Page.")]
    public void Test1()
    {
        var homePage = new Home(driver);
        homePage.AcceptCookies();

        homePage.HoverServiceMenu();

        var automationPage = homePage.GoToAutomationPage();

        //Verifying that successfully naviagated to 'Automation' page
        Assert.That(driver.Url, Is.EqualTo("https://www.sogeti.com/services/automation/"));

        //Verifying 'Automation' title is exist
        var _ = automationPage.AutomationText;

        const string selectedTextColor = "rgba(255, 48, 76, 1)";

        //Verifying 'Service' is selected by checking it's color
        Assert.That(automationPage.GetServiceMenuColor(), Is.EqualTo(selectedTextColor));

        automationPage.HoverServiceMenu();

        //Verifying 'Automation' is selected by checking it's color
        Assert.That(automationPage.GetAutomationMenuColor(), Is.EqualTo(selectedTextColor));
    }

    [Test]
    [Author("Ali Akbar", "officialakbarali@gmail.com")]
    [Category("UI Testing")]
    [Description("On Automation Page, fill and submit 'Contact us' Form.")]
    public void Test2()
    {
        var homePage = new Home(driver);
        homePage.AcceptCookies();

        homePage.HoverServiceMenu();

        var automationPage = homePage.GoToAutomationPage();
        automationPage.FillForm();

        // Captcha need to solve manually within 10 seconds
        Thread.Sleep(TimeSpan.FromSeconds(10));

        automationPage.SubmitForm();

        //Verifying Thank you message
        var _ = automationPage.ThankYouMsg;
    }

    [Test]
    [Author("Ali Akbar", "officialakbarali@gmail.com")]
    [Category("UI Testing")]
    [Description("Verify all country link in worldwide dropdown are working.")]
    public void Test3()
    {
        var homePage = new Home(driver);
        homePage.AcceptCookies();

        homePage.SelectWorldwide();

        var countryUrlsv = homePage.GetCountryUrls();
        foreach (var url in countryUrlsv)
        {
            Assert.That(TestUtilities.GetHttpStatus(url), Is.EqualTo("OK"));
        }
    }
}
