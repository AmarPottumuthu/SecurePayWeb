using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SecurePayWeb.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePayWeb.Extensions
{
    public static class WebElementExtensions
    {
        public static void HoverToElement(this IWebElement element)
        {
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(element).Perform();
        }

        public static void MoveToElement(this IWebElement element)
        {
            Actions builder = new Actions(DriverContext.Driver);
            builder.MoveToElement(element).Build().Perform();
        }

        public static void MoveToElementAndClick(this IWebElement element)
        {
            Actions builder = new Actions(DriverContext.Driver);
            builder.MoveToElement(element).Click().Build().Perform();
        }

        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new Exception(string.Format("Element Not Present Exception"));
        }

        public static void VerifyTitle(String expectedTitle)
        {
            if (!DriverContext.Driver.Title.Equals(expectedTitle))
                throw new Exception(string.Format("Title does not match"));
        }

        private static bool IsElementPresent(this IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal static void VerifyPageHeading(this IWebElement element,string expectedHeading)
        {
            string actualHeading = element.Text;
            if (!actualHeading.Equals(expectedHeading))
                throw new Exception(string.Format("Heading does not match"));
        }

        private static bool IsTitlePresent(this IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
