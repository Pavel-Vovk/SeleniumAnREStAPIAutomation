using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData
{
    public class ApplicationConfiguration
    {
        public bool isValueExist { get; private set; }

        private NameValueCollection nameValueCollection;
        //public Dictionary<string, string> testDataDictionalty { get; private set; }

        public string SectionPath { get; private set; }
        public string Section { get; private set; }

        public ApplicationConfiguration(string sectionPath, string section)
        {
            isValueExist = false;
            //testDataDictionalty = new Dictionary<string, string>();
            SectionPath = sectionPath;
            Section = section;
        }

        public Dictionary<string, string> GetConfig()
        {
            Dictionary<string, string> testDataDictionalty = new Dictionary<string, string>();
            try
            {
                nameValueCollection = (NameValueCollection)ConfigurationManager.GetSection(SectionPath + "/" + Section);
                isValueExist = true;
            }
            catch (System.SystemException e)
            {
                Console.WriteLine(e);
                isValueExist = false;
            }
            foreach (String valueName in nameValueCollection.AllKeys)
            {
                testDataDictionalty.Add(valueName, nameValueCollection[valueName]);
            }
            return testDataDictionalty;
        }

        public Dictionary<string, string> GetConfig(string sectionPath, string section)
        {
            SectionPath = sectionPath;
            Section = section;
            return GetConfig();
        }
    }
}
