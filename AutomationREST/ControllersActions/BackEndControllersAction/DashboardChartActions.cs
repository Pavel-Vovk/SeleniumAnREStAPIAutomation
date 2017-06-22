using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Dashboard;

namespace RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction
{
    public class DashboardChartActions : GenericActions
    {
        public LoadChartModel LoadChartModel { get; private set; }

        public DashboardChartActions()
        {
            Route = "DashboardChart";
        }
    }
}
