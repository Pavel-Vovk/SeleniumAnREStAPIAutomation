using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.WebElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.WebPages.Root
{
    public partial class Multiquote : PageBase
    {
        //List<WebElement> Web_Titiles = new List<WebElement>();
        Dictionary<string, WebElement> WebElements = new Dictionary<string, WebElement>();

        #region UI web Components
        #region UI Images
        #endregion
        #region UI Labes
        private static readonly WebElement ReviewQuoteTitle = new WebElement().ByNameData("review_quote_title");

        private static readonly WebElement TotalTitle = new WebElement().ByNameData("total_title");

        private static readonly WebElement MonthlyValue = new WebElement().ByNameData("monthly_value");
        private static readonly WebElement MonthlyTitle = new WebElement().ByNameData("monthly_title");

        private static readonly WebElement QuarterlyValue = new WebElement().ByNameData("quarterly_value");
        private static readonly WebElement QuarterlyTitle = new WebElement().ByNameData("quarterly_title");

        private static readonly WebElement SemiannValue = new WebElement().ByNameData("semiann_value");
        private static readonly WebElement SemiannTitle = new WebElement().ByNameData("semiann_title");

        private static readonly WebElement YearlyValue = new WebElement().ByNameData("yearly_value");
        private static readonly WebElement YearlyTitle = new WebElement().ByNameData("yearly_title");

        private static readonly WebElement EnrollfeeValue = new WebElement().ByNameData("enrollfee_value");
        private static readonly WebElement EnrollfeeTitle = new WebElement().ByNameData("enrollfee_title");

        private static readonly WebElement QuoteSettingTitle = new WebElement().ByNameData("quote_setting");
        private static readonly WebElement SpouseInformationTitle = new WebElement().ByNameData("spouse_information");

        //Primary insured
        private static readonly WebElement CoverageTypeLabel = new WebElement().ByNameData("coverageType_label");
        private static readonly WebElement CoverageTypeMes = new WebElement().ByNameData("coverageType_mes");

        private static readonly WebElement PostalCodeLabel = new WebElement().ByNameData("postalCode_label");
        private static readonly WebElement PostalCodeMesSup = new WebElement().ByNameData("postalCode_mes_sup");
        private static readonly WebElement PostalCodeMes5ch = new WebElement().ByNameData("postalCode_mes_5ch");
        private static readonly WebElement PostalCodeMesVal = new WebElement().ByNameData("postalCode_mes_val");

        private static readonly WebElement GenderLabel = new WebElement().ByNameData("gender_label");
        private static readonly WebElement GenderMes = new WebElement().ByNameData("gender_mes");

        private static readonly WebElement isTobaccoUserLabel = new WebElement().ByNameData("isTobaccoUser_label");
        private static readonly WebElement isTobaccoUserMes = new WebElement().ByNameData("isTobaccoUser_mes");

        private static readonly WebElement BirthdateLabel = new WebElement().ByNameData("birthdate_label");
        private static readonly WebElement BirthdateMes = new WebElement().ByNameData("birthdate_mes");
        //spouse
        private static readonly WebElement SpousePostalCodeLabel = new WebElement().ByNameData("spousePostalCode_label");
        private static readonly WebElement SpousePostalCodeMesSup = new WebElement().ByNameData("spousePostalCode_mes_sup");
        private static readonly WebElement SpousePostalCodeMes5ch = new WebElement().ByNameData("spousePostalCode_mes_5ch");
        private static readonly WebElement SpousePostalCodeMesVal = new WebElement().ByNameData("spousePostalCode_mes_val");

        private static readonly WebElement SpouseGenderLabel = new WebElement().ByNameData("spouseGender_label");
        private static readonly WebElement SpouseGenderMes = new WebElement().ByNameData("spouseGender_mes");

        private static readonly WebElement SpouseisTobaccoUserLabel = new WebElement().ByNameData("spouseIsTobaccoUser_label");
        private static readonly WebElement SpouseisTobaccoUserMes = new WebElement().ByNameData("spouseIsTobaccoUser_mes");

        private static readonly WebElement SpouseBirthdateLabel = new WebElement().ByNameData("spouseBirthDay_label");
        private static readonly WebElement SpouseBirthdateMes = new WebElement().ByNameData("spouseBirthDay_mes");
        
        //footer message
        private static readonly WebElement PleaseCheckLabel = new WebElement().ByNameData("pleasecheck_label");

        #endregion
        #region UI Text Fields
        //primary insured
        private static readonly WebElement CoverageTypeSelect = new WebElement().ByNameData("coverageType_select");
        private static readonly WebElement PostalCodeInput = new WebElement().ByNameData("postalCode_input");
        private static readonly WebElement GenderSelect = new WebElement().ByNameData("gender_select");
        private static readonly WebElement isTobaccoUserSelect = new WebElement().ByNameData("isTobaccoUser_select");
        private static readonly WebElement BirthdateDP = new WebElement().ByXPath(@".//*[@name-data=""birthdate_dp""]/div/input");
        //private static readonly WebElement BirthdateDP = new WebElement().ByNameData("birthdate_dp");
        //.//*[@name-data='birthdate_dp']/div/input
        //spouse insured
        private static readonly WebElement SpousePostalCodeInput = new WebElement().ByNameData("spousePostalCode_input");
        private static readonly WebElement SpouseGenderSelect = new WebElement().ByNameData("spouseGender_select");
        private static readonly WebElement SpouseisTobaccoUserSelect = new WebElement().ByNameData("spouseIsTobaccoUser_select");
        private static readonly WebElement SpouseBirthdateDP = new WebElement().ByXPath(@".//*[@name-data=""spouseBirthDay_dp""]/div/input");

        #endregion
        #region UI Controls
        private static readonly WebElement SendSmsUpBtn = new WebElement().ByNameData("send_sms_up_btn");
        private static readonly WebElement SendMailUpBtn = new WebElement().ByNameData("send_mail_up_btn");
        private static readonly WebElement SummaryUpBtn = new WebElement().ByNameData("summary_up_btn");
        private static readonly WebElement BuyNowUpBtn = new WebElement().ByNameData("buy_now_up_btn");

        private static readonly WebElement SearchBtn = new WebElement().ByNameData("search_btn");


        private static readonly WebElement SendSmsDownBtn = new WebElement().ByNameData("send_sms_down_btn");
        private static readonly WebElement SendMailDownBtn = new WebElement().ByNameData("send_mail_down_btn");
        private static readonly WebElement SummaryDownBtn = new WebElement().ByNameData("summary_down_btn");
        private static readonly WebElement BuyNowDownBtn = new WebElement().ByNameData("buy_now_down_btn");
        #endregion
        #endregion

        public Multiquote()
        {
            /*
            QuoteTitle.NewText = "some add test";
            FieldInfo[] fieldInfos = this.GetType().GetFields(BindingFlags.Static|BindingFlags.NonPublic);
            var some = fieldInfos[1].GetValue(null);
            PropertyInfo test = fieldInfos[1].FieldType.GetProperty("NewText", BindingFlags.Public| BindingFlags.Instance);
            string somestr = (String)test.GetValue(some);
            */
        }

        public bool TitleValueVerification()
        {
            
            FieldInfo[] fieldInfos = this.GetType().GetFields(BindingFlags.Static | BindingFlags.NonPublic);
            foreach (var webElemet in fieldInfos)
            {
                webElemet.GetValue(null);
                PropertyInfo propInfo = webElemet.FieldType.GetProperty("Text", BindingFlags.Public | BindingFlags.Instance);
            }
            
            return false;
        }
        
    }
}
