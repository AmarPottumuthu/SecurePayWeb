using System;
using System.Xml.XPath;
using System.IO;
using SecurePayWeb.BaseClass;

namespace SecurePayWeb.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            XPathItem searchengine;
            XPathItem aut;
            XPathItem timeout;
            XPathItem browser;
            string strBrowser;

            string strFilename = "C:\\SecurePayWeb\\SecurePayWeb\\Config\\GlobalConfig.xml";
            //string strFilename = Environment.CurrentDirectory.ToString() + "\\Config\\GlobalConfig.xml";
            FileStream stream = new FileStream(strFilename, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            //Get XML Details and pass it in XPathItem type variables
            searchengine = navigator.SelectSingleNode("SecurePayWeb/RunSettings/SearchEngine");
            aut = navigator.SelectSingleNode("SecurePayWeb/RunSettings/AUT");
            timeout = navigator.SelectSingleNode("SecurePayWeb/RunSettings/Timeout");
            browser = navigator.SelectSingleNode("SecurePayWeb/RunSettings/Browser");

            strBrowser = browser.Value.ToString();
            //Set XML Details in the property to be used accross framework
            Settings.SearchEngine = searchengine.Value.ToString();
            Settings.AUT = aut.Value.ToString();
            Settings.Timeout = Int32.Parse(timeout.Value);
            Settings.BrowserType = (BrowserTypes)Enum.Parse(typeof(BrowserTypes), strBrowser);

        }


    }
}
