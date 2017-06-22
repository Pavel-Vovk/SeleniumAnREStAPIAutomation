using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.WebElement;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.WebPages.Root
{
    public partial class multiquote : PageBase
    {
        #region UI Web Elements

        #region UI web labels
        private static readonly WebElement ReviewQuoteHorisontalLabel = new WebElement().ById("multiquote_horisontal_step1_Title");
        
        
        #endregion

        #region UI web Markes
        private static readonly WebElement ReviewQuoteCurrentMark = new WebElement().ById("multiquote_horisontal_step1_current_Mark");
        private static readonly WebElement ReviewQuotePassedMark = new WebElement().ById("multiquote_horisontal_step1_passed_Mark");


        #endregion

        #region UI web Controls
        private static readonly WebElement ReviewQuoteButton = new WebElement().ById("multiquote_horisontal_step1_Button");
        private static readonly WebElement PersonalInfoButton = new WebElement().ById("multiquote_horisontal_step2_Button");
        private static readonly WebElement HealthInfoButton = new WebElement().ById("multiquote_horisontal_step3_Button");
        private static readonly WebElement PaymentInfoButton = new WebElement().ById("multiquote_horisontal_step4_Button");
        private static readonly WebElement AgreementsButton = new WebElement().ById("multiquote_horisontal_step5_Button");
        private static readonly WebElement ReviewAndSingButton = new WebElement().ById("multiquote_horisontal_step6_Button");
        private static readonly WebElement ThankYouButton = new WebElement().ById("multiquote_horisontal_step7_Button");
        #endregion

        #endregion

        private bool isLoadedMultiQuoteHorisontal()
        {
            if (ReviewQuoteHorisontalLabel.Exists() &&
                ReviewQuoteHorisontalLabel.Displayed &&
                ReviewQuoteHorisontalLabel.Enabled
                )
                return true;
            
            //TODO Check that all componenets of Horisontal Menu are loaded correctly

            return false;
        }

    }
}
