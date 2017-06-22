using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.WebElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.WebPages.Root
{
    public partial class Application : PageBase
    {
        private static readonly WebElement PayIFNInput = new WebElement().ByNameData("payi_first_name_input");
        private static readonly WebElement PayILNInput = new WebElement().ByNameData("payi_last_name_input");
        private static readonly WebElement PayIAddrInput = new WebElement().ByNameData("payi_addr1_input");
        private static readonly WebElement PayICityInput = new WebElement().ByNameData("payi_city_input");
        private static readonly WebElement PayIStateInput = new WebElement().ByNameData("payi_state_select");
        private static readonly WebElement PayIEmailInput = new WebElement().ByNameData("payi_email_input");
        private static readonly WebElement PayIPostalCodeInput = new WebElement().ByNameData("payi_postalcode_input");
        private static readonly WebElement PayIPayFreInput = new WebElement().ByNameData("payi_payfre_select");
        private static readonly WebElement PayISignEmailRB = new WebElement().ByNameData("payi_sign_email_rb");
        private static readonly WebElement PayISignSmsRB = new WebElement().ByNameData("payi_sign_sms_rb");
        private static readonly WebElement PayISignPersonRB = new WebElement().ByNameData("payi_sign_singper_rb");
        private static readonly WebElement PayISignVVRB = new WebElement().ByNameData("payi_sign_vv_rb");

    }
}
