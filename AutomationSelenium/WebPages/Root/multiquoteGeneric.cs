using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.WebPages.Root
{
    public partial class multiquote : PageBase
    {

        public bool isCurrentStepLoaedCorrectly(int stepNumber)
        {
            switch (stepNumber)
            {
                case 1:
                    
                    if ((isLoadedMultiQuoteHorisontal()) && (isLoadedMultiQuoteReviewQuoteStep()) && (isLoadedMultiQuoteNBControls()) && (isLoadedMultiQuoteFotter()))
                        return true;
                    break;

                case 2:
                    if ((isLoadedMultiQuoteHorisontal()) || (isLoadedMultiQuotePersonalInfoStep()) || (isLoadedMultiQuoteNBControls()))
                        return true;
                    break;
                //TODO add all left steps
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 7:
                    break;
            }
            return false;
        }

    }
}
