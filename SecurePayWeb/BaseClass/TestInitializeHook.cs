using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using SecurePayWeb.Config;
using System;
using OpenQA.Selenium.Remote;

namespace SecurePayWeb.BaseClass
{
    public abstract class TestInitializeHook : Base
    {
        public readonly BrowserTypes Browser;

        public void InitializeSettings()
        {
            ConfigReader.SetFrameworkSettings();
            OpenBrowser(Browser);
        }
        
        public TestInitializeHook(BrowserTypes browser)
        {
            Browser = Settings.BrowserType;
        }

        [Obsolete]
        private void OpenBrowser(BrowserTypes browserType)
        {
            switch (Settings.BrowserType)
            {
                case BrowserTypes.InternetExplorer:
                    var options = new InternetExplorerOptions();
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true; 
                    DriverContext.Driver = new InternetExplorerDriver(); 
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserTypes.Firefox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserTypes.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }

        public virtual void NavigateToSite()
        {
            DriverContext.Browser.GotoUrl(Settings.SearchEngine);
        }
    }
}
