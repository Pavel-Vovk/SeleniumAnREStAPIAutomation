using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction;
using RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AccountController;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.DashboardController
{
    [TestClass]
    public class DashboardControllerPositiveTest : RESTSuiteBase
    {
        DashboardActions dashboardActions;

        #region Additional test attributes

        [TestInitialize]
        public void Initialize()
        {   
            AutorizationType = AutorizationType.Authorize;
        }
        #endregion

        private void InitializeActions()
        {
            AccountControllerTest accountTest = new AccountControllerTest();
            dashboardActions = new DashboardActions();
            AutorizationCheck(AutorizationType);
            if (AutorizationType == AutorizationType.Authorize)
            {
                dashboardActions.CreateHeaders(AutorizationType, LoginResult);
            }
        }
        //Unclear what models will be used - the Tests will be updated after clarification
        [TestMethod]
        public void GETDashboard_PositiveTest()
        {
        }
    }
}
