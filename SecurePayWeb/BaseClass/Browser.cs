using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePayWeb.BaseClass
{
    public class Browser
    {
        private readonly IWebDriver Driver;

        public Browser(IWebDriver driver)
        {
            Driver = driver;
        }

        //public BrowserTypes Type { get; set; }

        public void GotoUrl(string url)
        {
            DriverContext.Driver.Url = url;
        }
    }

    public enum BrowserTypes
    {
        Chrome,
        InternetExplorer,
        Firefox
    }
}
