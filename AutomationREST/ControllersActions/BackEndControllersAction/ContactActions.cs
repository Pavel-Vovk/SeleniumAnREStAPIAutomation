using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Agency;

namespace RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction
{
    public class ContactActions : GenericActions
    {
        public ContactModel ContactModel { get; private set; }

        public ContactActions()
        {
            Route = "Contact";
        }
    }
}
