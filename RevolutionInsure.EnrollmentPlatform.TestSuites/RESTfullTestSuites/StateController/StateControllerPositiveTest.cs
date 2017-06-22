using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction;
using RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AccountController;
using System.Web.Mvc;
using System.Net;
using RevolutionInsure.EmrollmentPlatform.Common.Models;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.State;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.StateController
{
    [TestClass]
    public class StateControllerPositiveTest : RESTSuiteBase
    {
        StateActions stateActions;
        #region Additional test attributes
        [TestInitialize]
        public void Initialize()
        {
            AutorizationType = AutorizationType.AllowAnonymous;
        }
        #endregion

        private void InitializeActions()
        {
            AccountControllerTest accountTest = new AccountControllerTest();
            stateActions = new StateActions();
            AutorizationCheck(AutorizationType);
            if (AutorizationType == AutorizationType.Authorize)
            {
                stateActions.CreateHeaders(AutorizationType, LoginResult);
            }
        }

        [TestMethod]
        public void GETAllStates_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = "GetAllStates";
            ExpectedResponseType = typeof(List<StateModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            stateActions.ClearURLData();

            var result = stateActions.RunAPI<List<StateModel>>(EndPoint, Route, Method, Body);

            Verification(stateActions, result);
        }

        [TestMethod]
        public void GETState_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = null;
            ExpectedResponseType = typeof(StateModel);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            stateActions.ClearURLData();
            stateActions.AddURLData("{id:int}", TestsRunParams["TestStateID"]);

            var result = stateActions.RunAPI<StateModel>(EndPoint, Route, Method, Body);

            Verification(stateActions, result);
        }

        [TestMethod]
        public void POSTAddState_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "Add";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Entity = "StateModel";
            Body = JSONData.GetEntityFromJSONFile(Entity);

            stateActions.ClearURLData();

            var result = stateActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(stateActions, result);
        }

        [TestMethod]
        public void PUTState_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Put;
            Route = null;
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Entity = "StateModel";
            Body = JSONData.GetEntityFromJSONFile(Entity);

            stateActions.ClearURLData();
            stateActions.AddURLData("{id:int}", TestsRunParams["TestStateID"]);

            var result = stateActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(stateActions, result);
        }

        [TestMethod]
        public void GETValidateZipAndGetState_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = "ValidateZipcode";
            ExpectedResponseType = typeof(ZipCodeData);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            stateActions.ClearURLData();
            stateActions.AddURLData("{zipcode:int}", TestsRunParams["TestZipCode"]);

            var result = stateActions.RunAPI<ZipCodeData>(EndPoint, Route, Method, Body);

            Verification(stateActions, result);
        }

        [TestMethod]
        public void GETStateFromZipcode_PositiveTest()
        {
            //What about multiple states?
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = "GetStateFromZipcode";
            ExpectedResponseType = typeof(string);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            stateActions.ClearURLData();
            stateActions.AddURLData("{zipcode:int}", TestsRunParams["TestZipCode"]);

            var result = stateActions.RunAPI<string>(EndPoint, Route, Method, Body);

            Verification(stateActions, result);
        }
    }
}
