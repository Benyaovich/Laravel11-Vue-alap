using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTests;

[TestClass]
public class Test
{
    // private ChromeDriver _webDriver = null!;
    //
    // [TestInitialize]
    // public void InitializeWebDriver()
    // {
    //     ChromeOptions options = new ChromeOptions();
    //     options.AddArgument("--window-size=1440,1080");
    //     _webDriver = new ChromeDriver(options);
    //     _webDriver.Url = "http://localhost";
    // }
    private RemoteWebDriver _webDriver = null!;
    
    [TestInitialize]
    public void InitializeWebDriver()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--window-size=1440,1080");
        _webDriver = new RemoteWebDriver(new Uri("http://hub:4444"), options);
        _webDriver.Url = "http://proxy:80";
    }

    [TestCleanup]
    public void TearDownWebDriver()
    {
        _webDriver.Quit();
    }
    

    private void WaitUntilWebElementIsVisible(By by)
    {
        WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(2));
        wait.Until(ExpectedConditions.ElementIsVisible(by));
    }

    [TestMethod]
    public void CheckTitle()
    {
        By navbarTitle = By.ClassName("navbar-brand");
        WaitUntilWebElementIsVisible(navbarTitle);
        Assert.AreEqual("Navbar",_webDriver.FindElement(navbarTitle).Text);
    }
}