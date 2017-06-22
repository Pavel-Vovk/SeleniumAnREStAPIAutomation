using Newtonsoft.Json;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Account;

namespace RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData
{
    public class AgentLoginTestData : LoginModel
    {
        public AgentLoginTestData()
        {
            ApplicationConfiguration appconf = new ApplicationConfiguration("GeneralConfiguration/AgentsLogin", "Lisa");
            appconf.GetConfig();
            Email = appconf.GetConfig()["Email"];
            Password = appconf.GetConfig()["Password"];
        }

        public AgentLoginTestData(string agentName)
        {
            ApplicationConfiguration appconf = new ApplicationConfiguration("GeneralConfiguration/AgentsLogin", agentName);
            //appconf.GetConfig()["Email"];
            Email = appconf.GetConfig()["Email"];
            Password = appconf.GetConfig()["Password"];
        }

        public string GetJSON()
        {
           return JsonConvert.SerializeObject(this);
        }

    
    }
}
