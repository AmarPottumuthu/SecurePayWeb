using SecurePayWeb.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SecurePayWeb.BaseClass
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        public HookInitialize() : base(Settings.BrowserType)
        {
            InitializeSettings();
        }

        [BeforeFeature]
        public static void TestStart()
        {
            HookInitialize init = new HookInitialize();
        }

        //Commented this so that the test can be viewed before it closes
        /*
        [AfterFeature]
        public static void TearDown()
        {
            DriverContext.Driver.Quit();

        }
        */
    }
}
