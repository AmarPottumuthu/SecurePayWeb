using TechTalk.SpecFlow;
using SecurePayWeb.BaseClass;
using SecurePayWeb.PageObjects;

namespace EAEmployeeTest.Steps
{
    [Binding]
    internal class ExtendedSteps : BaseStep
    {
        [Given(@"I have searched for ""(.*)"" on the Google website")]
        public void GivenIHaveSearchedForOnTheGoogleWebsite(string text)
        {
            NavigateToSite();
            CurrentPage = GetInstance<GooglePage>();
            CurrentPage = CurrentPage.As<GooglePage>().GoogleSearch(text);
            
        }

        [Given(@"I have clicked on SecurePay website")]
        public void GivenIHaveClickedOnSecurePayWebsite()
        {

            CurrentPage = CurrentPage.As<ResultsPage>().SearchResultClick();
                      
        }


    }
}
