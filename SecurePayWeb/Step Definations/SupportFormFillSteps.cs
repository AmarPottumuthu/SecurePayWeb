using TechTalk.SpecFlow;
using SecurePayWeb.BaseClass;
using SecurePayWeb.PageObjects;
using TechTalk.SpecFlow.Assist;

namespace SecurePayWeb.Step_Definations
{
    [Binding]
    public class SupportFormFillSteps : BaseStep
    {

        [Given(@"I am on SecurePay website ""(.*)""")]
        public void GivenIAmOnSecurePayWebsite(string title)
        {
            CurrentPage.As<SecurePayHomePage>().VerifyTitle(title);
        }

        
        [When(@"I click on Contact Us")]
        public void WhenIClickOnContactUs()
        {
            CurrentPage = CurrentPage.As<SecurePayHomePage>().NavigateToContactUs();
        }
        
        [Then(@"the Contact Us page should be displayed with ""(.*)"" heading")]
        public void ThenTheContactUsPageShouldBeDisplayedWithHeading(string heading)
        {
            CurrentPage.As<ContactUsPage>().VerifyContactUsPageHeading(heading);
        }

        
        [Then(@"Support Form is displayed")]
        public void ThenSupportFormIsDisplayed()
        {
            CurrentPage.As<ContactUsPage>().VerifySupportForm(); 
        }
        
        [Then(@"Support form should accept Data")]
        public void ThenSupportFormShouldAcceptData()
        {
            CurrentPage.As<ContactUsPage>().FillSupportForm();
        }
    }
}
