using Newtonsoft.Json.Linq;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.WebPages.Root
{
    public partial class Multiquote : PageBase
    {

        public void ExpandCensus()
        {

        }

        public void ExpandQuote()
        {

        }

        public void DoSearch()
        {
            SearchBtn.Click();
        }

        public void ClearData()
        {

        }
        public void FillData(string entity)
        {
            if (!ReviewQuoteTitle.Exists())
            {
                QuoteExpand.Click();
            }
            ClearData();
            JObject obj = JObject.Parse(JsonHelper.GetEntityFromJSONFile(entity));
            string coverage = obj["Coverage"].ToString();
            CoverageTypeSelect.SendKeys(coverage);
            PostalCodeInput.SendKeys(obj["Primary"]["zipcode"].ToString());
            GenderSelect.SendKeys(obj["Primary"]["gender"].ToString());
            isTobaccoUserSelect.SendKeys(obj["Primary"]["isTobaccoUser"].ToString());
            BirthdateDP.SendKeys(String.Empty);
            ReviewQuoteTitle.Click();
            BirthdateDP.SendKeys(obj["Primary"]["birthDate"].ToString());
            if (String.Equals(coverage, "Family") || String.Equals(coverage, "Individual & Spouse"))
            {
                SpousePostalCodeInput.SendKeys(obj["Spouse"]["zipcode"].ToString());
                SpouseGenderSelect.SendKeys(obj["Spouse"]["gender"].ToString());
                SpouseisTobaccoUserSelect.SendKeys(obj["Spouse"]["isTobaccoUser"].ToString());
                SpouseBirthdateDP.SendKeys(String.Empty);
                ReviewQuoteTitle.Click();
                SpouseBirthdateDP.SendKeys(obj["Spouse"]["birthDate"].ToString());
            }
        }

        public bool TitleValueValidation(string entity)
        {
            if (!ReviewQuoteTitle.Exists())
            {
                QuoteExpand.Click();
            }
            JObject obj = JObject.Parse(JsonHelper.GetEntityFromJSONFile(entity));//"MultiquoteReviewQuote_Texts"));
            FieldInfo[] fieldInfos = this.GetType().GetFields(BindingFlags.Static | BindingFlags.NonPublic);
            foreach (var element in obj)
            {
                string nameOfElement = element.Key.ToString();
                var fieldInfo = fieldInfos.FirstOrDefault(x => x.Name == nameOfElement);
                var webElement = fieldInfo?.GetValue(null);
                PropertyInfo propInfo = fieldInfo.FieldType.GetProperty("Text", BindingFlags.Public | BindingFlags.Instance);
                string jsonData = element.Value.ToString();
                string pageData = (String)propInfo.GetValue(webElement);
                if (!String.Equals(jsonData, pageData))
                {
                    pageData = JsonHelper.ClearString(pageData);
                    if (!String.Equals(jsonData, pageData))
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public bool CarriersExist()
        {
            return true;
        }

        public void DoBuyNow()
        {
            //BuyNowUpBtn.Click();
            BuyNowDownBtn.Click();
        }

        public void SelectMedicoAEP(string entity)
        {
            
            if (!MicAepOptionTitle.Exists())
            {
                MicAepExpandBtn.Click();
            }
            JObject obj = JObject.Parse(JsonHelper.GetEntityFromJSONFile(entity));//"MIC_AEP_ProductOption"));
            //MicAepOptionDeductible.Click();
            //MicAepOptionTitle.Click();
            //MicAepTitle.Click();
            //MicAepOptionDeductible.SendKeys(obj["Deductible"].ToString());

            //MicAepOptionDeductible.Text = obj["Deductible"].ToString();
            //MicAepOptionBenAm.Text = obj["BenAm"].ToString();
            //MicAepOptionDeductible.SendKeys(obj["Deductible"].ToString());
            //MicAepOptionBenAm.SendKeys(obj["BenAm"].ToString());
            MicAepCheckbox.Click();
        }
    }
}
