using RevolutionInsure.EmrollmentPlatform.Common.Models.Json.Application;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Application;

namespace RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction
{
    public class ApplicationActions : GenericActions
    {

        public ApplicationModel Application { get; set; }

        public ApplicationActions()
        {
            Route = "Application";
        }
    }
}
