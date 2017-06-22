using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction;
using RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AccountController;
using RevolutionInsure.EnrollmentPlatform.Api.Security;
using System.Web.Mvc;
using System.Net;
using RevolutionInsure.EmrollmentPlatform.Common.Security;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Careington;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.HealthGuardController
{

    [TestClass]
    public class CareigntonControllerPositiveTest : RESTSuiteBase
    {

        CareingtonActions careingtonActions;


        #region Additional test attributes
        [TestInitialize]
        public void Initialize()
        {
            AutorizationType = AutorizationType.Authorize;
            AccessedSystemRoles = new SystemRoles[] {SystemRoles.AgencyAdmin, SystemRoles.Administrator, SystemRoles.Agent};
        }
        #endregion


        private void InitializeActions()
        {
            AccountControllerTest accountTest = new AccountControllerTest();
            careingtonActions = new CareingtonActions();
            AutorizationCheck(AutorizationType);
            if (AutorizationType == AutorizationType.Authorize)
            {
                careingtonActions.CreateHeaders(AutorizationType, LoginResult);
            }
        }

        [TestMethod]
        public void POSTCreateApplication_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "Application";
            ExpectedResponseType = typeof(CareingtonResponse);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Entity = "CareingtonApplicationContent";
            Body = JSONData.GetEntityFromJSONFile(Entity);

            careingtonActions.ClearURLData();

            var result = careingtonActions.RunAPI<CareingtonResponse>(EndPoint, Route, Method, Body);

            Verification(careingtonActions, result);
        }

        [TestMethod]
        public void POSTFillTemplate_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "FillTemplate";
            ExpectedResponseType = typeof(CareingtonResponse);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            careingtonActions.ClearURLData();

            var result = careingtonActions.RunAPI<CareingtonResponse>(EndPoint, Route, Method, Body);

            Verification(careingtonActions, result);
        }

        [TestMethod]
        public void POSTSignApplication_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "SignApplication";
            ExpectedResponseType = typeof(CareingtonResponse);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            careingtonActions.ClearURLData();


            var result = careingtonActions.RunAPI<CareingtonResponse>(EndPoint, Route, Method, Body);

            Verification(careingtonActions, result);
        }

        [TestMethod]
        public void POSTApproveApplication_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "ApproveApplication";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = JSONData.GetJsonFromObject(typeof(string), TestsRunParams["TestAgentCode"]);

            careingtonActions.ClearURLData();

            var result = careingtonActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(careingtonActions, result);
        }

        [TestMethod]
        public void GETApplication_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = "Application";
            ExpectedResponseType = typeof(CareingtonApplication);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            careingtonActions.ClearURLData();

            var result = careingtonActions.RunAPI<CareingtonApplication>(EndPoint, Route, Method, Body);

            Verification(careingtonActions, result);
        }

        [TestMethod]
        public void GETFilledPdf_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = "FilledPdf";
            ExpectedResponseType = typeof(CareingtonResponse);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            careingtonActions.ClearURLData();

            var result = careingtonActions.RunAPI<CareingtonResponse>(EndPoint, Route, Method, Body);

            Verification(careingtonActions, result);
        }


        [TestMethod]

        public void POSTIsFileExists_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "FileExists";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = JSONData.GetJsonFromObject(typeof(string), TestsRunParams["TestBlobFileName"]);

            careingtonActions.ClearURLData();

            var result = careingtonActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(careingtonActions, result);
        }
    }
}
