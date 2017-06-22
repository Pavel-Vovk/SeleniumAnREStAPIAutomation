using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction;
using RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AccountController;
using System.Web.Mvc;
using System.Net;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Dashboard;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.DashboardChartController
{

    [TestClass]
    public class DashboardChartControllerPositiveTest : RESTSuiteBase
    {

        DashboardChartActions dashboardChartActions;
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
            dashboardChartActions = new DashboardChartActions();
            AutorizationCheck(AutorizationType);
            if (AutorizationType == AutorizationType.Authorize)
            {
                dashboardChartActions.CreateHeaders(AutorizationType, LoginResult);
            }
        }

        [TestMethod]
        public void GETGenerateByAgent_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = "Agent";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode =HttpStatusCode.OK;

            Body = null;

            dashboardChartActions.ClearURLData();
            dashboardChartActions.AddURLData("{agentid:int}", TestsRunParams["TestAgentID"]);

            var result = dashboardChartActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(dashboardChartActions, result);
        }

        [TestMethod]
        public void GETGenerateByAgency_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = "Agency";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            dashboardChartActions.ClearURLData();
            dashboardChartActions.AddURLData("{agencyid:int}", TestsRunParams["TestAgencyID"]);

            var result = dashboardChartActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(dashboardChartActions, result);
        }

        [TestMethod]
        public void GETByAgent_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = "Agent";
            ExpectedResponseType = typeof(LoadChartModel);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Entity = "LoadChartModel";
            Body = JSONData.GetEntityFromJSONFile(Entity);

            dashboardChartActions.ClearURLData();
            dashboardChartActions.AddURLData("{agentid:int}", TestsRunParams["TestAgentID"]);

            var result = dashboardChartActions.RunAPI<LoadChartModel>(EndPoint, Route, Method, Body);

            Verification(dashboardChartActions, result);
        }

        [TestMethod]
        public void GETByAgecy_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = "Agency";
            ExpectedResponseType = typeof(LoadChartModel);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Entity = "LoadChartModel";
            Body = JSONData.GetEntityFromJSONFile(Entity);
            Body = null;

            dashboardChartActions.ClearURLData();
            dashboardChartActions.AddURLData("{agencyid:int}", TestsRunParams["TestAgencyID"]);

            var result = dashboardChartActions.RunAPI<LoadChartModel>(EndPoint, Route, Method, Body);

            Verification(dashboardChartActions, result);
        }
    }
}
