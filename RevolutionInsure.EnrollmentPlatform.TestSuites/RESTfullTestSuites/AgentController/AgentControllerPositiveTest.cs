using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AccountController;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction;
using System.Web.Mvc;
using System.Net;
using System.Linq;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Agent;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AgentController
{
    /// <summary>
    /// Summary description for AgentControllerPositiveTest
    /// </summary>
    [TestClass]
    public class AgentControllerPositiveTest : RESTSuiteBase
    {
        #region Test Initial Data
        AgentActions agentActions;
        #endregion
        [TestInitialize]
        public void Initialize()
        {
            AutorizationType = AutorizationType.AllowAnonymous;
        }


        private void InitializeActions()
        {
            AccountControllerTest accountTest = new AccountControllerTest();
            agentActions = new AgentActions();
            AutorizationCheck(AutorizationType);
            if (AutorizationType == AutorizationType.Authorize)
            {
                agentActions.CreateHeaders(AutorizationType, LoginResult);
            }

        }

        [TestMethod]
        public void GETAgents_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Body = null;
            Route = "GetAgents";
            ExpectedResponseType = typeof(List<AgentModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            agentActions.ClearURLData();

            #region General Actions
            var agents = agentActions.RunAPI<List<AgentModel>>(EndPoint, Route, Method, Body);
            #endregion

            Verification(agentActions, agents);
        }

        [TestMethod]
        public void GETAgentByStatus_PositiveTest()
        {
            AutorizationType = AutorizationType.Authorize;
            InitializeActions();

            Method = HttpVerbs.Get;
            Body = null;
            Route = "GetAgentByStatus";
            ExpectedResponseType = typeof(List<AgentModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            //Need to Verify
            agentActions.ClearURLData();
            agentActions.AddURLData("List<int> status", TestsRunParams["TestAgentStatuses"]);

            var agents = agentActions.RunAPI<List<AgentModel>>(EndPoint, Route, Method, Body);

            Verification(agentActions, agents);
        }

        [TestMethod]
        public void GETAgentByID_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Body = null;
            Route = null;
            ExpectedResponseType = typeof(AgentModel);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            agentActions.ClearURLData();
            agentActions.AddURLData("{id:int}", TestsRunParams["TestAgentID"]);

            var agent = agentActions.RunAPI<AgentModel>(EndPoint, Route, Method, Body);

            Verification(agentActions, agent);
        }
        /*
        [TestMethod]
        public void GETAgentEdit_PositiveTest()
        {

        }
        */
        /*
        [TestMethod]
        public void GETStatesForProduct_PositiveTest()
        {

            //Check the Data D:\Repositories\TFS\EnrollmentPlatform\Development\RevolutionInsure.EnrollmentPlatform.Api\Controllers\AgentController.cs
            //row: 103 GetStatesForProduct
            InitializeActions(AutorizationType.Authorize);

            Method = HttpVerbs.Get;
            Body = null;
            Route = "GetStatesForProduct";
            ExpectedResponseType = typeof(List<AgentModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            agentActions.ClearURLData();
            agentActions.AddURLData("productId", TestsRumParams["TestProductID"]);

            var agents = agentActions.RunAPI<List<AgentModel>>(EndPoint, Route, Method, Body);

            Verification(agentActions, agents);
        }
        */

        [TestMethod]
        public void POSTAddAgent_Positivetest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Entity = "AgentModelPost";
            Route = "Add";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = JSONData.GetEntityFromJSONFile(Entity);

            agentActions.ClearURLData();

            var result = agentActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(agentActions, result);
        }

        [TestMethod]
        public void POSTApproveAgent_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "ApproveAgent";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = JSONData.GetJsonFromObject(typeof(int), TestsRunParams["TestAgentID"]);

            agentActions.ClearURLData();

            var result = agentActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(agentActions, result);
        }
        [TestMethod]
        public void POSTRejectAgent_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "RejectAgent";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = JSONData.GetJsonFromObject(typeof(int), TestsRunParams["TestAgentID"]);

            agentActions.ClearURLData();

            var result = agentActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(agentActions, result);
        }


        [TestMethod]
        public void PUTAgent_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Put;
            Entity = "AgentModel";
            Route = null;
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = JSONData.GetEntityFromJSONFile(Entity);

            agentActions.ClearURLData();
            agentActions.AddURLData("{id:int}", TestsRunParams["TestAgentID"]);

            var result = agentActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(agentActions, result);
        }


        /*
        [TestMethod]
        public void DELETEAgent_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Delete;
            Route = null;
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            agentActions.ClearURLData();
            agentActions.AddURLData("{id:int}", TestsRumParams["TestAgentID"]);

            var result = agentActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(agentActions, result);
        }
        */

        protected void GetConnectedSystemRole()
        {

        }

    }
}
