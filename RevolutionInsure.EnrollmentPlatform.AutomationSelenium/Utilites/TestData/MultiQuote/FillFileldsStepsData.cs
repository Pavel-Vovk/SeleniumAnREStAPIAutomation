using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Configuration;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.TestData.MultiQuote
{
    public class FillFileldsStepsData
    {
        public bool isValueExist { get; private set; }

        private NameValueCollection nameValueCollection;
        public Dictionary<string, string> testDataDictionalty { get; private set; }

        public FillFileldsStepsData(int stepNumber)
        {
            isValueExist = false;
            testDataDictionalty = new Dictionary<string, string>();
            string sectionPath = "UISeleniumConfiguration/MultiQuoteSteps/";
            string section = "Step" + stepNumber.ToString();

            testDataDictionalty.Clear();
            try
            {
                nameValueCollection = (NameValueCollection)ConfigurationManager.GetSection(sectionPath + section);
                isValueExist = true;
            }
            catch(System.SystemException e)
            {
                Console.WriteLine(e);
            }
            foreach (String valueName in nameValueCollection.AllKeys)
            {
                testDataDictionalty.Add(valueName, nameValueCollection[valueName]);
            }
        }
    }
}
