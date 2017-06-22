using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.WebElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.WebPages.Root
{
    public partial class Application : PageBase

    {

        public void FillAllInputs(string entity)
        {

            ClearAllInpunts();
            JObject obj = JObject.Parse(JsonHelper.GetEntityFromJSONFile(entity));

            List<IWebElement> elements = Browser.FindElements(By.XPath(@"//input | //textarea")).Cast<IWebElement>().ToList();
            foreach (IWebElement element in elements)
            {
                Browser.ScrollToElement(element);
                if (element.Enabled && element.Displayed && element.Text == String.Empty && ((element.GetAttribute("type") == "text") || element.GetAttribute("rows") != null))
                {
                    string identity = element.GetAttribute("ng-model");
                    string[] modelArray = identity.Split('.');
                    element.SendKeys(obj[modelArray[modelArray.Length - 2]][modelArray[modelArray.Length - 1]].ToString());
                }
            }
        }



        public void FillPersonalInfo(string entity)
        {
            ClearAllInpunts();
            JObject obj = JObject.Parse(JsonHelper.GetEntityFromJSONFile(entity));
            
            //Primary 
            PerIPFNInput.SendKeys(obj["Primary"]["FirstName"].ToString());
            PerIPMNInput.SendKeys(obj["Primary"]["MiddleName"].ToString());
            PerIPLNInput.SendKeys(obj["Primary"]["LastName"].ToString());
            PerIPAddrInput.SendKeys(obj["Primary"]["Address1"].ToString());
            PerIPCityInput.SendKeys(obj["Primary"]["City"].ToString());
            //PerIPStateInput.SendKeys(obj["Primary"]["State"].ToString());
            PerIPPCInput.SendKeys(obj["Primary"]["PostalCode"].ToString());
            PerIPSSNInput.SendKeys(obj["Primary"]["SSN"].ToString());
            PerIPEmailInput.SendKeys(obj["Primary"]["Email"].ToString());
            PerIPPhNInput.SendKeys(obj["Primary"]["Phone"].ToString());
            PerIPAPhNInput.SendKeys(obj["Primary"]["AlPhone"].ToString());
            PerIPWeightInput.SendKeys(obj["Primary"]["Weight"].ToString());
            PerIPHeightFInput.SendKeys(obj["Primary"]["HeightInFeet"].ToString());
            PerIPHeightIInput.SendKeys(obj["Primary"]["HeightInInches"].ToString());
            //PerIPGenderInput.SendKeys(obj["Primary"]["Gender"].ToString());
            //PerIPDOBInput.SendKeys(obj["Primary"]["DateOfBirth"].ToString());
            //PerIPCitizenY.SendKeys(obj["Primary"]["CitizenRB"].ToString());
            //PerIPCitizenN.SendKeys(obj["Primary"][""].ToString());
            //PerIPBSInput.SendKeys(obj["Primary"]["BirthState"].ToString());

            if (obj["Primary"]["BirthState"].ToString() == null)
            {
                return;
            }

            //Spouse
            PerISFNInput.SendKeys(obj["Spouse"]["FirstName"].ToString());
            PerISMNInput.SendKeys(obj["Spouse"]["MiddleName"].ToString());
            PerISLNInput.SendKeys(obj["Spouse"]["LastName"].ToString());
            PerISAddrInput.SendKeys(obj["Spouse"]["Address1"].ToString());
            PerISCityInput.SendKeys(obj["Spouse"]["City"].ToString());
            //PerISStateInput.SendKeys(obj["Spouse"]["State"].ToString());
            PerISPCInput.SendKeys(obj["Spouse"]["PostalCode"].ToString());
            PerISSSNInput.SendKeys(obj["Spouse"]["SSN"].ToString());
            PerISEmailInput.SendKeys(obj["Spouse"]["Email"].ToString());
            PerISPhNInput.SendKeys(obj["Spouse"]["Phone"].ToString());
            PerISAPhNInput.SendKeys(obj["Spouse"]["AlPhone"].ToString());
            PerISWeightInput.SendKeys(obj["Spouse"]["Weight"].ToString());
            PerISHeightFInput.SendKeys(obj["Spouse"]["HeightInFeet"].ToString());
            PerISHeightIInput.SendKeys(obj["Spouse"]["HeightInInches"].ToString());
            //PerISGenderInput.SendKeys(obj["Spouse"]["Gender"].ToString());
            //PerISDOBInput.SendKeys(obj["Spouse"]["DateOfBirth"].ToString());
            //PerISCitizenY.SendKeys(obj["Spouse"]["CitizenRB"].ToString());
            //PerISCitizenN.SendKeys(obj["Spouse"][""].ToString());
            //PerISBSInput.SendKeys(obj["Spouse"]["BirthState"].ToString());
        }

        public void FillPaymentInfo(string entity)
        {
            ClearData();
            JObject obj = JObject.Parse(JsonHelper.GetEntityFromJSONFile(entity));

            PayIFNInput.SendKeys(obj["FirstName"].ToString());
            PayILNInput.SendKeys(obj["LastName"].ToString());
            PayIAddrInput.SendKeys(obj["Address1"].ToString());
            PayICityInput.SendKeys(obj["City"].ToString());
            PayIStateInput.SendKeys(obj["State"].ToString());
            PayIEmailInput.SendKeys(obj["Email"].ToString());
            PayIPostalCodeInput.SendKeys(obj["PostalCode"].ToString());
            PayIPayFreInput.SendKeys(obj["Frequency"].ToString());
            string sign = obj["SignMethod"].ToString();
            switch (sign)
            {
                case "Email":
                    PayISignEmailRB.Click();
                    break;
                case "Sms":
                    PayISignSmsRB.Click();
                    break;
                case "SignPerson":
                    PayISignPersonRB.Click();
                    break;
                case "Voice":
                    PayISignVVRB.Click();
                    break;
            }
                 
        }

        public void FindHeathInfoQuestions()
        {
            QuestionElements = FindAllElementsByStringValueAttribute("name-data", "app_hi_q_", "_title");
        }

        public void FindAllRadioButtons()
        {

        }

        public void FillHeathInfo_AllYes()
        {
            //Create a method to fill all Q as Yes
        }

        public bool DataValidation()
        {
            return true;
        }

        public void DoPerINext()
        {

        }

        public void DoPerIBack()
        {

        }

        public void DoHINext()
        {

        }

        public void DoHIBack()
        {

        }

        public void DoSubmit()
        {

        }

        public void DoPayIBack()
        {

        }

        public void ClearData()
        {

        }

    }
}
