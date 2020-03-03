using SecurePayWeb.Config;
using System;


namespace SecurePayWeb.BaseClass
{
    public abstract class BaseStep : Base
    {
        public virtual void NavigateToSite()
        {
            DriverContext.Browser.GotoUrl(Settings.SearchEngine);
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Settings.Timeout);
            DriverContext.Driver.Manage().Window.Maximize();
        }

    }
}
