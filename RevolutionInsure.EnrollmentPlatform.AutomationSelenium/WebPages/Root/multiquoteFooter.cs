using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.TestData.MultiQuote;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.WebElement;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.WebPages.Root
{
    public partial class multiquote : PageBase
    {
        #region UI Web Elements

        #region UI WebLabels
        private static readonly WebElement InfoFooterLabel = new WebElement().ById("multiquote_Footer_Label");
        #endregion

        #endregion

        private bool isLoadedMultiQuoteFotter()
        {
            //TODO Check that all componenets of Footer are loaded correctly
            LabelValues lableValues = new LabelValues();
            if (
                (InfoFooterLabel.Exists()) &&
                (InfoFooterLabel.Displayed) &&
                (Equals(InfoFooterLabel.Text, lableValues.GetExpectedFooterText()))
                )
                return true;

            return false;
        }
    }

}
