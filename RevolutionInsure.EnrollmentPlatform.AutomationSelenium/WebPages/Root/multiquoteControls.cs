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

        #region UI web Controls
        private static readonly WebElement NextButton = new WebElement().ById("multiquote_Next_Button");
        private static readonly WebElement BackButton = new WebElement().ById("multiquote_Back_Button");
        private static readonly WebElement SubmitButton = new WebElement().ById("multiquote_Submit_Button");
        #endregion

        private bool isLoadedMultiQuoteNBControls()
        {
            if (
                (NextButton.Exists()) &&
                BackButton.Exists() &&
                NextButton.Displayed &&
                BackButton.Displayed &&
                ! BackButton.Enabled &&
                ! NextButton.Enabled 
                )
                return true;
            return false;
        }

        private bool isLoadedMultiQuoteNBSControls()
        {
            if (
                isLoadedMultiQuoteNBControls() &&
                SubmitButton.Exists() &&
                SubmitButton.Displayed &&
                ! SubmitButton.Enabled
                )
                return true;
            return false;
        }
        public void DoNext()
        {
            NextButton.Click();
        }
        public void DoBack()
        {
            BackButton.Click();
        }

        public void DoSubmit()
        {
            SubmitButton.Click();
        }

        public void Natigate()
        {
            //TODO Navigation using horisontal pane
        }

        public bool NextVerificatoin()
        {

            return false;
        }

    }
}
