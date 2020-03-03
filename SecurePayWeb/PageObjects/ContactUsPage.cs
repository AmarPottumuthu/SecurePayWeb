using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SecurePayWeb.BaseClass;
using SecurePayWeb.DataGenerator;
using SecurePayWeb.Extensions;

namespace SecurePayWeb.PageObjects 
{
    public class ContactUsPage : BasePage
    {
        #region WebElements
        [FindsBy (How = How.XPath, Using = "//*[@id='section-heading']/div/h1")]
        IWebElement ContactUsHeading { get; set; }

        [FindsBy (How = How.XPath, Using = "//*[@id='wpcf7-f3455-p95-o1']")]
        IWebElement SupportForm { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='wpcf7-f3455-p95-o1']/form/p[1]/label/span/input")]
        IWebElement FirstNameTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='wpcf7-f3455-p95-o1']/form/p[2]/label/span/input")]
        IWebElement LastNameTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='wpcf7-f3455-p95-o1']/form/p[3]/label/span/input")]
        IWebElement EmailAddressTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='wpcf7-f3455-p95-o1']/form/p[4]/label/span/input")]
        IWebElement PhoneNumberTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='wpcf7-f3455-p95-o1']/form/p[5]/label/span/input")]
        IWebElement WebsiteUrlTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='wpcf7-f3455-p95-o1']/form/p[6]/label/span/input")]
        IWebElement CompanyTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='wpcf7-f3455-p95-o1']/form/p[7]/label/span/select")]
        IWebElement EnquiryReasonDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='wpcf7-f3455-p95-o1']/form/p[8]/label/span/textarea")]
        IWebElement MessageTextBox { get; set; }

        #endregion

        #region Actions

        internal void VerifyContactUsPageHeading(string expectedHeading)
        {
            WebDriverExtensions.WaitForPageLoaded(DriverContext.Driver);
            WebElementExtensions.VerifyPageHeading(ContactUsHeading,expectedHeading);
        }

        internal void VerifySupportForm()
        {
            WebElementExtensions.AssertElementPresent(SupportForm);
        }

        public enum Reason
        {
            Support,
            Accounts
        }
        public void FillSupportForm()
        {
            //ComboBoxHelper.SelectElement(EnquiryReasonDropDown, value);
            var modelFaker = new Faker<DataModel>()
                .RuleFor(o => o.firstName, f => f.Name.FirstName())
                .RuleFor(o => o.lastName, f => f.Name.LastName())
                .RuleFor(o => o.emailAddress, f => f.Internet.Email())
                .RuleFor(o => o.phoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(o => o.websiteUrl, f => f.Internet.Url())
                .RuleFor(o => o.company, f => f.Company.CompanyName())
                .RuleFor(o => o.reason, f => f.PickRandom<Reason>())
                .RuleFor(o => o.message, f => f.Lorem.Sentence());


            var dataModel = modelFaker.Generate();
            string firstName = dataModel.firstName;
            string lastName = dataModel.lastName;
            string emailAddress = dataModel.emailAddress;
            string phoneNumber = dataModel.phoneNumber;
            string websiteurl = dataModel.websiteUrl;
            string company = dataModel.company;
            string reason = dataModel.reason.ToString();
            string message = dataModel.message;

            FirstNameTextBox.SendKeys(firstName);
            LastNameTextBox.SendKeys(lastName);
            EmailAddressTextBox.SendKeys(emailAddress); 
            PhoneNumberTextBox.SendKeys(phoneNumber);
            WebsiteUrlTextBox.SendKeys(websiteurl);
            CompanyTextBox.SendKeys(company);
            EnquiryReasonDropDown.SendKeys(reason);
            MessageTextBox.SendKeys(message);

        }

        #endregion
    }
}
