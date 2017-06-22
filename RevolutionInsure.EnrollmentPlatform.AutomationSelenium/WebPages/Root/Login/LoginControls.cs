using Newtonsoft.Json.Linq;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.WebElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.WebPages.Root
{
    public partial class Login : PageBase
    {
        #region UI web Controls
        #region UI Images
        private static readonly WebElement LoginLogo = new WebElement().ByNameData("login_logo");
        #endregion
        #region UI Labes
        private static readonly WebElement LoginMessage = new WebElement().ByNameData("login_title");
        private static readonly WebElement RememberMeMessage = new WebElement().ByNameData("remember_me");
        private static readonly WebElement DontHaveAnAccountMeMessage = new WebElement().ByNameData("q_account_message");
        #endregion
        #region UI Text Fields
        private static readonly WebElement EmailText = new WebElement().ByNameData("email");
        private static readonly WebElement PasswordText = new WebElement().ByNameData("password");
        #endregion
        #region UI Controls
        private static readonly WebElement LoginButton = new WebElement().ByNameData("login");
        private static readonly WebElement RememberMeCheckBox = new WebElement().ByNameData("remember_me_box");
        private static readonly WebElement CreateAnAccountLink = new WebElement().ByNameData("create_acc_link");
        private static readonly WebElement ForgotPasswordLink = new WebElement().ByNameData("forgot_pass_link");
        #endregion
        #endregion

        public void DoLogin()
        {
            LoginButton.Click();
        }

        public void CreateAnAccount()
        {
            CreateAnAccountLink.Click();
        }

        public void ForgotPassword()
        {
            ForgotPasswordLink.Click();
        }

        public void RememberMe()
        {
            RememberMeCheckBox.Click();
        }

        public void FillData(string entity)
        {
            ClearFields();

            JObject obj = JObject.Parse(JsonHelper.GetEntityFromJSONFile(entity));
            EmailText.SendKeys(obj["Email"].ToString());
            PasswordText.SendKeys(obj["Password"].ToString());
        }

        public void ClearFields()
        {
            EmailText.SendKeys(String.Empty);
            PasswordText.SendKeys(String.Empty);
        }


    }

}
