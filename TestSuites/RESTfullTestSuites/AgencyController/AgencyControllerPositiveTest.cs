using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction;
using System.Collections.Generic;
using System.Net;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Agency;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AgencyController
{
    [TestClass]
    public class AgencyControllerPositiveTest : RESTSuiteBase
    {
        //AccountControllerTest accountTest;
        AgencyActions agencyActions;

        #region Test Initial Data
        [TestInitialize]
        public void Initialize()
        {
            AutorizationType = AutorizationType.AllowAnonymous;
        }


        private void InitializeActions()
        {

            //accountTest = new AccountControllerTest();
            agencyActions = new AgencyActions();
            AutorizationCheck(AutorizationType);
            if (AutorizationType == AutorizationType.Authorize)
            {
                agencyActions.CreateHeaders(AutorizationType, LoginResult);
            }

        }
        #endregion
        [TestMethod]
        public void GETAgencies_PositiveTest()
        {
            AutorizationType = AutorizationType.Authorize;

            InitializeActions();

            Method = HttpVerbs.Get;
            Body = null;
            Route = "GetAgency";
            ExpectedResponseType = typeof(List<AgencyModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            agencyActions.ClearURLData();

            #region General Actions
            var agencies = agencyActions.RunAPI<List<AgencyModel>>(EndPoint, Route, Method, Body);
            #endregion

            Verification(agencyActions, agencies);
        }

        [TestMethod]
        public void GETAgencyByStatus_PositiveTest()
        {
            AutorizationType = AutorizationType.Authorize;

            InitializeActions();

            Method = HttpVerbs.Get;
            Body = null;
            Route = "GetAgencyByStatus";
            ExpectedResponseType = typeof(List<AgencyModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;
            
            //Need to Check
            agencyActions.ClearURLData();
            agencyActions.AddURLData("Status", TestsRunParams["TestAgencyStatus"]);

            var agency = agencyActions.RunAPI<List<AgencyModel>>(EndPoint, Route, Method, Body);

            Verification(agencyActions, agency);
        }

        [TestMethod]
        public void GETAgencyByID_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Body = null;
            Route = null;
            ExpectedResponseType = typeof(AgencyModel);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;
            
            agencyActions.ClearURLData();
            agencyActions.AddURLData("{id:int}", TestsRunParams["TestAgencyID"]);

            var agency = agencyActions.RunAPI<AgencyModel>(EndPoint, Route, Method, Body);

            Verification(agencyActions, agency);
        }

        [TestMethod]
        public void POSTAddAgency_PositiveTest()
        {

            InitializeActions();

            Method = HttpVerbs.Post;
            Entity = "AgencyModel";
            Route = "Add";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;
            Body = JSONData.GetEntityFromJSONFile(Entity);

            agencyActions.ClearURLData();

            #region General Actions
            var result = agencyActions.RunAPI<bool>(EndPoint, Route, Method, Body);
            #endregion

            Verification(agencyActions, result);
        }
        /*
        [TestMethod]
        public void POSTUpdateAgency_PositiveTest()
        {

        }
        */

        [TestMethod]
        public void POSTApproveAgency_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "ApproveAgency";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = JSONData.GetJsonFromObject(typeof(int), TestsRunParams["TestAgencyID"]);

            agencyActions.ClearURLData();

            #region General Actions
            var result = agencyActions.RunAPI<bool>(EndPoint, Route, Method, Body);
            #endregion

            Verification(agencyActions, result);
        }
        [TestMethod]
        public void POSTRejectAgency_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "RejectAgency";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = JSONData.GetJsonFromObject(typeof(int), TestsRunParams["TestAgencyID"]);

            agencyActions.ClearURLData();

            #region General Actions
            var result = agencyActions.RunAPI<bool>(EndPoint, Route, Method, Body);
            #endregion

            Verification(agencyActions, result);
        }


        [TestMethod]
        public void POSTApprove_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Entity = "AgencyModel";
            Route = "Approve";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = JSONData.GetEntityFromJSONFile(Entity);

            agencyActions.ClearURLData();

            #region General Actions
            var result = agencyActions.RunAPI<bool>(EndPoint, Route, Method, Body);
            #endregion

            Verification(agencyActions, result);
        }

        [TestMethod]
        public void PUTAgency_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Put;
            Entity = "AgencyModel";
            Route = null;
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = JSONData.GetEntityFromJSONFile(Entity);

            agencyActions.ClearURLData();
            agencyActions.AddURLData("{id:int}", TestsRunParams["TestAgencyID"]);

            #region General Actions
            var result = agencyActions.RunAPI<bool>(EndPoint, Route, Method, Body);
            #endregion

            Verification(agencyActions, result);
        }

        /*
        [TestMethod]
        public void DELETEAgency_PositiveTest()
        {
        }
        */
    }
}
