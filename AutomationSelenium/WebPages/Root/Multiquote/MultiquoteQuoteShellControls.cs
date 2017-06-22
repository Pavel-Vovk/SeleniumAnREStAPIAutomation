using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.WebElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.WebPages.Root
{
    public partial class Multiquote : PageBase
    {
        #region UI web Controls
        #region UI Images
        #endregion
        #region UI Labes
        private static readonly WebElement CensusTitle = new WebElement().ByNameData("census_enrollment_title");
        private static readonly WebElement QuoteTitle = new WebElement().ByNameData("quote_title");
        #endregion
        #region UI Text Fields
        #endregion
        #region UI Controls
        private static readonly WebElement CensusExpand = new WebElement().ByNameData("census_enrollment_expand");
        private static readonly WebElement QuoteExpand = new WebElement().ByNameData("quote_expand");
        #endregion
        #endregion

    }
}
