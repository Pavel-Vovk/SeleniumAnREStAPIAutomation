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
        //UI Inputs
        //Primary
        private static readonly WebElement PerIPFNInput = new WebElement().ByNameData("peri_primary_firstname_input");
        private static readonly WebElement PerIPMNInput = new WebElement().ByNameData("peri_primary_middlename_input");
        private static readonly WebElement PerIPLNInput = new WebElement().ByNameData("peri_primary_lastname_input");
        private static readonly WebElement PerIPAddrInput = new WebElement().ByNameData("peri_primary_address1_input");
        private static readonly WebElement PerIPCityInput = new WebElement().ByNameData("peri_primary_city_input");
        private static readonly WebElement PerIPStateInput = new WebElement().ByNameData("peri_primary_state_input");
        private static readonly WebElement PerIPPCInput = new WebElement().ByNameData("peri_primary_postalcode_input");
        private static readonly WebElement PerIPSSNInput = new WebElement().ByNameData("peri_primary_ssn_input");
        private static readonly WebElement PerIPEmailInput = new WebElement().ByNameData("peri_primary_email_input");
        private static readonly WebElement PerIPPhNInput = new WebElement().ByNameData("peri_primary_phn_input");
        private static readonly WebElement PerIPAPhNInput = new WebElement().ByNameData("peri_primary_aphn_input");
        private static readonly WebElement PerIPWeightInput = new WebElement().ByNameData("peri_primary_weight_input");
        private static readonly WebElement PerIPHeightFInput = new WebElement().ByNameData("peri_primary_height_f_input");
        private static readonly WebElement PerIPHeightIInput = new WebElement().ByNameData("peri_primary_height_i_input");
        private static readonly WebElement PerIPGenderInput = new WebElement().ByNameData("peri_primary_gender_input");
        private static readonly WebElement PerIPDOBInput = new WebElement().ByNameData("peri_primary_DOB_input");
        private static readonly WebElement PerIPCitizenY = new WebElement().ByNameData("peri_primary_citizen_yes_rb");
        private static readonly WebElement PerIPCitizenN = new WebElement().ByNameData("peri_primary_citizen_no_rb");
        private static readonly WebElement PerIPBSInput = new WebElement().ByNameData("peri_primary_bs_select");

        //Spouse
        private static readonly WebElement PerISFNInput = new WebElement().ByNameData("peri_spouse_firstname_input");
        private static readonly WebElement PerISMNInput = new WebElement().ByNameData("peri_spouse_middlename_input");
        private static readonly WebElement PerISLNInput = new WebElement().ByNameData("peri_spouse_lastname_input");
        private static readonly WebElement PerISAddrInput = new WebElement().ByNameData("peri_spouse_addr1_input");
        private static readonly WebElement PerISCityInput = new WebElement().ByNameData("peri_spouse_city_input");
        private static readonly WebElement PerISStateInput = new WebElement().ByNameData("peri_spouse_state_input");
        private static readonly WebElement PerISPCInput = new WebElement().ByNameData("peri_spouse_postalcode_input");
        private static readonly WebElement PerISSSNInput = new WebElement().ByNameData("peri_spouse_ssn_input");
        private static readonly WebElement PerISEmailInput = new WebElement().ByNameData("peri_spouse_email_input");
        private static readonly WebElement PerISPhNInput = new WebElement().ByNameData("peri_spouse_phn_input");
        private static readonly WebElement PerISAPhNInput = new WebElement().ByNameData("peri_spouse_aphn_input");
        private static readonly WebElement PerISWeightInput = new WebElement().ByNameData("peri_spouse_weight_input");
        private static readonly WebElement PerISHeightFInput = new WebElement().ByNameData("peri_spouse_height_f_input");
        private static readonly WebElement PerISHeightIInput = new WebElement().ByNameData("peri_spouse_height_i_input");
        private static readonly WebElement PerISGenderInput = new WebElement().ByNameData("peri_spouse_gender_input");
        private static readonly WebElement PerISDOBInput = new WebElement().ByNameData("peri_spouse_DOB_input");
        private static readonly WebElement PerISCitizenY = new WebElement().ByNameData("peri_spouse_citizen_yes_rb");
        private static readonly WebElement PerISCitizenN = new WebElement().ByNameData("peri_spouse_citizen_no_rb");
        private static readonly WebElement PerISBSInput = new WebElement().ByNameData("peri_spouse_bs_select");

    }
}
