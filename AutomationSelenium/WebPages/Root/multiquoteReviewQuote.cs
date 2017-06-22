using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.WebElement;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.TestData.MultiQuote;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.WebPages.Root
{
    public partial class multiquote : PageBase
    {

        #region UI Web Elements

        # region UI web labels
        private static readonly WebElement ReviewQuoteLabel= new WebElement().ById("multiquote_step1RQ_ReviewQuote_Label");
        #endregion

        # region UI web Input fields

        #endregion
        private static readonly WebElement Step1RQFirstNameText = new WebElement().ById("multiquote_step1RQ_FirstName_Text");
        private static readonly WebElement Step1RQLastNameText = new WebElement().ById("multiquote_step1RQ_LastName_Text");
        #endregion

        private void ClearReviewQuoteFields()
        {
            Step1RQFirstNameText.Text = "";
            Step1RQLastNameText.Text = "";
        }

        private bool isLoadedMultiQuoteReviewQuoteStep()
        {
            if (Step1RQFirstNameText.Exists() &&
                Step1RQLastNameText.Exists() &&
                Step1RQFirstNameText.Displayed &&
                Step1RQLastNameText.Displayed &&
                Step1RQFirstNameText.Enabled &&
                Step1RQLastNameText.Enabled
                )
                return true;
            //TODO Check that all componenets of Step are loaded correctly
            return false;
        }

        public void FillReviewQuoteFields(FillFileldsStepsData stepsData)
        {

            ClearReviewQuoteFields();
            Step1RQFirstNameText.SendKeys(stepsData.testDataDictionalty["FirstName"]);
            Step1RQLastNameText.SendKeys(stepsData.testDataDictionalty["LastName"]);
            var a = 1;
        }

        public void Step1DataInputValidation()
        {

            //TODO Validation checks
        }

    }
}
