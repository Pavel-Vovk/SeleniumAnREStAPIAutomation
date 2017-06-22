using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AccountController;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction;
using System.Web.Mvc;
using System.Net;
using RevolutionInsure.EmrollmentPlatform.Common.Models.Json.Application;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Application;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.PolicyNumberController
{
    [TestClass]
    public class PolicyNumberControllerPositiveTest : RESTSuiteBase
    {

        PolicyNumberActions policyNumberActions;
        #region Additional test attributes
        [TestInitialize]
        public void Initialize()
        {
            //Need to Clarify - in the controller class any info about it
            AutorizationType = AutorizationType.AllowAnonymous;
        }
        #endregion
        private void InitializeActions()
        {
            AccountControllerTest accountTest = new AccountControllerTest();
            policyNumberActions = new PolicyNumberActions();
            AutorizationCheck(AutorizationType);
            if (AutorizationType == AutorizationType.Authorize)
            {
                policyNumberActions.CreateHeaders(AutorizationType, LoginResult);
            }
        }
        /*
        [TestMethod]
        public void GETPolicyNumber_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = "PolicyNumber";
            //typeof N/A in controller class
            ExpectedResponseType = typeof(PolicyNumberBlockModel);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            policyNumberActions.ClearURLData();
            policyNumberActions.AddURLData("applicationId", TestsRunParams["TestApplicationID"]);

            //typeof N/A in controller class
            var result = policyNumberActions.RunAPI<PolicyNumberBlockModel>(EndPoint, Route, Method, Body);

            Verification(policyNumberActions, result);

        }

        */
        [TestMethod]
        public void POSTPolicyNumber_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "PolicyBlock/Create";
            //typeof N/A in controller class
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Entity = "PolicyNumberBlockModel";
            Body = JSONData.GetEntityFromJSONFile(Entity);

            policyNumberActions.ClearURLData();
            policyNumberActions.AddURLData("policyNumberBlock", TestsRunParams["TestpolicyNumberBlock"]);

            //typeof N/A in controller class
            var result = policyNumberActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(policyNumberActions, result);

        }
    }
}
