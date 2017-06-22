using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Agent;

namespace RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction
{
    public class AgentActions : GenericActions
    {
        public AgentModel Agent { get; private set; }

        public AgentActions()
        {
            Route = "Agent";
        }
    }
}
