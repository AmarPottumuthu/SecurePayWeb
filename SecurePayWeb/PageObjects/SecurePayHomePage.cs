using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SecurePayWeb.BaseClass;
using SecurePayWeb.Extensions;
using System;

namespace SecurePayWeb.PageObjects
{
    public class SecurePayHomePage : BasePage
    {
        #region WebElement
        
        [FindsBy (How = How.LinkText, Using = ("Support"))]
        IWebElement SecurepaySupport { get; set; }

        [FindsBy (How = How.LinkText, Using = ("Contact Us"))]
        IWebElement SecurepayContactUs { get; set; }

        #endregion

        #region Navigate

        internal void VerifyTitle(string expectedTitle)
        {
            WebDriverExtensions.WaitForPageLoaded(DriverContext.Driver);
            WebElementExtensions.VerifyTitle(expectedTitle);
        }

        internal ContactUsPage NavigateToContactUs()
        {
            WebElementExtensions.MoveToElement(SecurepaySupport);
            WebDriverExtensions.WaitForElement(DriverContext.Driver, SecurepayContactUs, 10);
            SecurepayContactUs.Click();
            return GetInstance<ContactUsPage>();
        }

        #endregion
    }
}
