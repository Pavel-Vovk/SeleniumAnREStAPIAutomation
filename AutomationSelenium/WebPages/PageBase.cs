using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.WebElement;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Properties;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Linq;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.Tags;
using Newtonsoft.Json.Linq;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.WebPages
{
    public abstract class PageBase
    {
        protected Dictionary<string, WebElement> WebElements;
        public Uri BaseUrl
        {
            get
            {
                Browser.WaitAjax();

                return GetUriByRelativePath(RelativePath);
            }
        }

        public void Open()
        {
            Contract.Requires(BaseUrl != null);
            Contract.Ensures(Browser.Url == BaseUrl);

            Browser.WaitAjax();

            if (Browser.Url == BaseUrl)
                return;
            if (BaseUrl.AbsoluteUri.Contains("application"))
            {
                //TODO the restart application logic flow to restore the URI
            }
            Browser.Navigate(BaseUrl);

            Contract.Assert(Browser.Url == BaseUrl, string.Format("{0} != {1}", Browser.Url, BaseUrl));
        }

        public Type PageName()
        {
            return GetType();
        }

        public bool TextExists(string text, bool exactMach = true, int timeout = 5)
        {
            return new WebElement().ByText(text, exactMach).Exists(timeout);
        }

        protected void Navigate(Uri url)
        {
            Contract.Requires(url != null);

            Browser.Navigate(url);
        }

        protected static Uri GetUriByRelativePath(string relativePath)
        {
            relativePath = Regex.Replace(relativePath, "Page", "", RegexOptions.IgnoreCase);
            ApplicationConfiguration appconf = new ApplicationConfiguration("GeneralConfiguration", "RunConfig");
            string endPoint = appconf.GetConfig()["RunLocation"];
            appconf = new ApplicationConfiguration("UISeleniumConfiguration", "EndPoint");
            endPoint = appconf.GetConfig()[endPoint];
            endPoint = Regex.Replace(endPoint, @"\/$", String.Empty);
            return new Uri(string.Format("{0}{1}", endPoint, relativePath).ToLower());
            //return new Uri(string.Format("{0}{1}", Settings.Default.TestEnvironment, relativePath).ToLower());
        }

        private string RelativePath
        {
            get
            {
                const string rootNamespaceName = "RevolutionInsure.EnrollmentPlatform.AutomationSelenium.WebPages.Root";
                var className = GetType().FullName;

                Contract.Assume(className != null);

                var path = className
                    .Replace(rootNamespaceName, string.Empty)
                    .Replace(".", "/");

                path = Regex.Replace(path, "/Index$", "");

                return path;
            }
        }

        public bool AreExistsAllElemts()
        {
            
            foreach(KeyValuePair<string, WebElement> entry in WebElements)
            {
                if (!entry.Value.Exists())
                    return false;
            }
            return true;
        }


        public List<IWebElement> FindAllElementsByStringValueAttribute(string attributeName,  string startValue, string endValue)
        {
            string selectorStr = $@"//div[contains(@{attributeName}, ""{startValue}"") and contains(@{attributeName}, ""{endValue}"")]";
            List<IWebElement> elements = new List<IWebElement>();
            elements = Browser.FindElements(By.XPath(selectorStr)).Cast<IWebElement>().ToList();
            return elements;
        }

        public void ClearAllInpunts()
        {
            List<IWebElement> elements = Browser.FindElements(By.XPath(@"//input | //textarea")).Cast<IWebElement>().ToList();
            foreach (IWebElement element in elements)
            {
                Browser.ScrollToElement(element);
                if (element.Enabled && element.Displayed && element.Text != String.Empty && ((element.GetAttribute("type") == "text") || element.GetAttribute("rows") != null) )
                {
                    element.Clear();
                }
            }
        }

        public List<IWebElement> FindElementsByTag(TagNames tagName)
        {
            List<IWebElement> elements = new List<IWebElement>();
            elements = Browser.FindElements(By.TagName(tagName.ToString())).Cast<IWebElement>().ToList();
            return elements;
        }
        /*
        public void FillPersonalAllInputs(string entity)
        {

            JObject obj = JObject.Parse(JsonHelper.GetEntityFromJSONFile(entity));

            List<IWebElement> elements = Browser.FindElements(By.XPath(@"//input | //textarea")).Cast<IWebElement>().ToList();
            foreach (IWebElement element in elements)
            {
                Browser.ScrollToElement(element);
                if (element.Enabled && element.Displayed && ((element.GetAttribute("type") == "text") || element.GetAttribute("rows") != null))
                {
                    string identity = element.GetAttribute("ng-model");
                    if (identity.Contains("primaryPersonalInfo"))
                    {

                    }else if()
                    


                    element.SendKeys()
                }
            }
            //Primary 
            //PerIPFNInput.SendKeys(obj["Primary"]["FirstName"].ToString());

        }
        */

    }
}
