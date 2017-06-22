using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Account;

namespace RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction
{
    public class AccountActions : GenericActions

    {

        public InviteUserModel InviteUser { get; private set; }
        public LoginModel Login { get; private set; }

        public AccountActions()
        {
            Route = "Account";
        }
     }
}
