using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SecurePayWeb.BaseClass;

namespace SecurePayWeb.PageObjects
{
    class ResultsPage : BasePage
    {
        //static string aut = Settings.AUT;
        #region WebElements
        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'https://www.securepay.com.au/')]/h3")]
        IWebElement resultSecurePay { get; set; }
        #endregion

        #region Actions
        internal SecurePayHomePage SearchResultClick()
        {
            resultSecurePay.Click();
            return GetInstance<SecurePayHomePage>();
        }
        #endregion
    }
}
