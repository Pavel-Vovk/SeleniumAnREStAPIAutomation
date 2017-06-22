using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.TestData.MultiQuote
{
    public class LabelValues
    {
        public string GetExpectedFooterText()
        {
            string str=null;
            string sectionPath = "UISeleniumConfiguration/MultiQuoteSteps/";
            string section = "Footer";

            NameValueCollection ai = (NameValueCollection)ConfigurationManager.GetSection(sectionPath + section);
            str = ai["FooterText"];
            return str;
        }

        public string GetExpectedFooterDetails()
        {
            string str=null;
            return str;
        }
    }
}
