using RevolutionInsure.EmrollmentPlatform.Common.Models.Json.Application;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Application;

namespace RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction
{
    public class CountryActions : GenericActions
    {
        public CountryModel CountryModel { get; private set; }

        public CountryActions()
        {
            Route = "Country";
        }

    }

}
