using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Carrier;

namespace RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction
{
    public class CarrierActions : GenericActions

    {

        public CarrierModel CarrierModel { get; private set; }

        public CarrierActions()
        {
            Route = "Carrier";
        }
    }
}
