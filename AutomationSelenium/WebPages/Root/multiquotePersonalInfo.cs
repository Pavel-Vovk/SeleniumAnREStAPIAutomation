using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.TestData.MultiQuote;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.WebElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.WebPages.Root
{
    public partial class multiquote : PageBase
    {
        #region UI Web Elements

        #region UI web labels
        private static readonly WebElement PersonalInfoLabel = new WebElement().ById("multiquote_step2PI_PPI_Label");
        private static readonly WebElement HWLabel = new WebElement().ById("multiquote_step2PI_WH_Label");
        #endregion

        # region UI web Input fields

        #endregion
        private static readonly WebElement Step2PIFirstNameText = new WebElement().ById("multiquote_step2PI_FirstName_Text");
        private static readonly WebElement Step2PIMiddleNameText = new WebElement().ById("multiquote_step2PI_MiddleName_Text");
        private static readonly WebElement Step2PILastNameText = new WebElement().ById("multiquote_step2PI_LastName_Text");
        private static readonly WebElement Step2PIAddress1Text = new WebElement().ById("multiquote_step2PI_Adress1_Text");
        private static readonly WebElement Step2PIAddress2Text = new WebElement().ById("multiquote_step2PI_Adress2_Text");
        private static readonly WebElement Step2PICityText = new WebElement().ById("multiquote_step2PI_City_Text");
        private static readonly WebElement Step2PIStateText = new WebElement().ById("multiquote_step2PI_State_DropDownList");
        private static readonly WebElement Step2PIEmailText = new WebElement().ById("multiquote_step2PI_Email_Text");
        private static readonly WebElement Step2PIHeightText = new WebElement().ById("multiquote_step2PI_Height_Text");
        private static readonly WebElement Step2PIWeightText = new WebElement().ById("multiquote_step2PI_Weight_Text");
        #endregion
        private void ClearPersonalInfoFields()
        {
            Step2PIFirstNameText.Text = "";
            Step2PIMiddleNameText.Text = "";
            Step2PILastNameText.Text = "";
            Step2PIAddress1Text.Text = "";
            Step2PIAddress2Text.Text = "";
            Step2PICityText.Text = "";
            //TODO Step2PIStateText
            Step2PIEmailText.Text = "";
            Step2PIHeightText.Text = "";
            Step2PIWeightText.Text = "";

        }

        public bool isLoadedMultiQuotePersonalInfoStep()
        {
            //TODO Check that all componenets of Step are loaded correctly
            if (true)//TODO Check that all componenets of Step are loaded correctly
            {
                return true;
            }
            return false;
        }
        private void FillPersonalInfoFields(FillFileldsStepsData stepsData)
        {
            ClearPersonalInfoFields();
            Step1RQFirstNameText.SendKeys(stepsData.testDataDictionalty["FirstName"]);
            Step1RQFirstNameText.SendKeys(stepsData.testDataDictionalty["MiddleName"]);
            Step1RQFirstNameText.SendKeys(stepsData.testDataDictionalty["LastName"]);
            Step1RQFirstNameText.SendKeys(stepsData.testDataDictionalty["Address1"]);
            Step1RQFirstNameText.SendKeys(stepsData.testDataDictionalty["Address2"]);
            Step1RQFirstNameText.SendKeys(stepsData.testDataDictionalty["City"]);
            //TODO Step1RQFirstNameText.SendKeys(stepsData.testDataDictionalty["State"]);
            Step1RQFirstNameText.SendKeys(stepsData.testDataDictionalty["PostalCode"]);
            Step1RQFirstNameText.SendKeys(stepsData.testDataDictionalty["Email"]);
            Step1RQFirstNameText.SendKeys(stepsData.testDataDictionalty["Height"]);
            Step1RQFirstNameText.SendKeys(stepsData.testDataDictionalty["Weight"]);

        }

        public void Step2DataInputValidation()
        {

            //TODO Validation checks

        }


    }
}
