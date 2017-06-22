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
        //Medico AEP
        private static readonly WebElement MicAepCheckbox           = new WebElement().ByNameData("mic_aep_checkbox");
        private static readonly WebElement MicAepTitle              = new WebElement().ByNameData("mic_aep_title");
        private static readonly WebElement MicAepPriceTitle         = new WebElement().ByNameData("mic_aep_price_title");
        private static readonly WebElement MicAepExpandBtn          = new WebElement().ByNameData("mic_aep_expand_btn");
        private static readonly WebElement MicAepOptionTitle        = new WebElement().ByNameData("MIC_AEP_option_title");
        private static readonly WebElement MicAepOptionDeductible   = new WebElement().ByNameData("MIC_AEP_Deductible_mdselect");
        private static readonly WebElement MicAepOptionBenAm        = new WebElement().ByNameData("MIC_AEP_Benefit Amount_mdselect");
        //private static readonly WebElement MicAepOptionDeductible   = new WebElement().ByXPath(@".//*[@name-data=""MIC_AEP_Deductible_mdselect""]/md-select-value");
        //private static readonly WebElement MicAepOptionBenAm        = new WebElement().ByXPath(@".//*[@name-data=""MIC_AEP_Benefit Amount_mdselect""]/md-select-value");
        private static readonly WebElement MicAepCostTitle          = new WebElement().ByNameData("MIC_AEP_cost_title");
        private static readonly WebElement MicAepCostM              = new WebElement().ByNameData("MIC_AEP_cost_m");
        private static readonly WebElement MicAepCostQ              = new WebElement().ByNameData("MIC_AEP_cost_q");
        private static readonly WebElement MicAepCostSA             = new WebElement().ByNameData("MIC_AEP_cost_sa");
        private static readonly WebElement MicAepCostY              = new WebElement().ByNameData("MIC_AEP_cost_y");
    }
}
