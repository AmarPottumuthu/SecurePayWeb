using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SecurePayWeb.BaseClass;
using SecurePayWeb.Extensions;

namespace SecurePayWeb.PageObjects
{
    public class GooglePage : BasePage
    {
        #region WebElements
        [FindsBy(How = How.XPath, Using = "//*[@id='tsf']/div[2]/div[1]/div[1]/div/div[2]/input")]
        IWebElement googleSearchTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='tsf']/div[2]/div[1]/div[2]/div[2]/div[2]/center/input[1]")]
        IWebElement googleSearchButton { get; set; }
        #endregion

        #region Actions
        internal ResultsPage GoogleSearch(string text)
        {
            googleSearchTextBox.SendKeys(text);
            WebDriverExtensions.WaitForElement(DriverContext.Driver, googleSearchButton, 30);
            googleSearchButton.Click();
            return GetInstance<ResultsPage>();
        }
        #endregion

    }
}
