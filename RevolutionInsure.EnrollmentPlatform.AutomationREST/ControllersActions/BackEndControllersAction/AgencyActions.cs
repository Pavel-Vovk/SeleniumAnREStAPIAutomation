using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Agency;

namespace RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction
{
    public class AgencyActions : GenericActions
    {
        public AgencyModel Agency { get; private set; }

        public AgencyActions()
        {
            Route = "Agency";
        }
    }
}
