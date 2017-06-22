using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction;
using System.Collections.Generic;
using RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AccountController;
using System.Web.Mvc;
using RevolutionInsure.EmrollmentPlatform.Common.Models.Json.Application;
using System.Net;
using System;
using System.Linq;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Application;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.ApplicationController
{
    [TestClass]
    public class ApplicationControllerPositiveTest : RESTSuiteBase
    {
        ApplicationActions applicationActions;
        
        [TestInitialize]
        public void Initialize()
        {
            AutorizationType = AutorizationType.Authorize;
        }
        
        private void InitializeActions()
        {
            AccountControllerTest accountTest = new AccountControllerTest();
            applicationActions = new ApplicationActions();
            AutorizationCheck(AutorizationType);
            if (AutorizationType == AutorizationType.Authorize)
            {
                applicationActions.CreateHeaders(AutorizationType, LoginResult);
            }
        }

        [TestMethod]
        public void GETApplications_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Body = null;
            Route = null;
            ExpectedResponseType = typeof(List<ApplicationModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            applicationActions.ClearURLData();

            var applications = applicationActions.RunAPI<List<ApplicationModel>>(EndPoint, Route, Method, Body);

            Verification(applicationActions, applications);
        }

        [TestMethod]
        public void GETApplicationByID_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Body = null;
            Route = null;
            ExpectedResponseType = typeof(ApplicationModel);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            applicationActions.ClearURLData();
            applicationActions.AddURLData("{id:int}", TestsRunParams["TestApplicationID"]);

            var application = applicationActions.RunAPI<ApplicationModel>(EndPoint, Route, Method, Body);

            Verification(applicationActions, application);

        }

        [TestMethod]
        public void GETCarriers_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Body = null;
            Route = "GetCarriers";
            ExpectedResponseType = typeof(List<CarrierModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            applicationActions.ClearURLData();
            applicationActions.AddURLData("{stateId:int}", TestsRunParams["TestStateID"]);
            applicationActions.AddURLData("{coveragetype:int}", TestsRunParams["TestCoverageType"]);

            var carriers = applicationActions.RunAPI<List<CarrierModel>>(EndPoint, Route, Method, Body);

            Verification(applicationActions, carriers);
        }

        [TestMethod]
        public void GETProducts_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Body = null;
            Route = "Products";
            ExpectedResponseType = typeof(List<ProductModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            applicationActions.ClearURLData();
            applicationActions.AddURLData("{carrierId:int}", TestsRunParams["TestCarrierID"]);
            applicationActions.AddURLData("{stateId:int}", TestsRunParams["TestStateID"]);

            var products = applicationActions.RunAPI<List<ProductModel>>(EndPoint, Route, Method, Body);

            Verification(applicationActions, products);
        }

        [TestMethod]
        public void GETApplicationStages_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Body = null;
            Route="Stage";

            ExpectedResponseType = typeof(List<ApplicationStageModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            applicationActions.ClearURLData();

            var applicationStages = applicationActions.RunAPI<List<ApplicationStageModel>>(EndPoint, Route, Method, Body);

            Verification(applicationActions, applicationStages);
        }

        [TestMethod]
        public void GETGetProductOptions_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Body = null;
            Route = "GetProductOptions";

            ExpectedResponseType = typeof(List<ProductOptionModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            applicationActions.ClearURLData();
            applicationActions.AddURLData("{coveragetype:int}", TestsRunParams["TestCoverageType"]);
            applicationActions.AddURLData("{productId:int}", TestsRunParams["TestProductID"]);
            applicationActions.AddURLData("{stateId:int}", TestsRunParams["TestStateID"]);

            var productOptions = applicationActions.RunAPI<List<ProductOptionModel>>(EndPoint, Route, Method, Body);

            Verification(applicationActions, productOptions);
        }

        [TestMethod]
        public void POSTApplication_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = null;
            Entity = "ApplicationModel";
            Body = JSONData.GetEntityFromJSONFile(Entity);

            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            applicationActions.ClearURLData();

            var result = applicationActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(applicationActions, result);
        }


        [TestMethod]
        public void PUTApplication_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Put;
            Route = null;
            Entity = "ApplicationModel";
            Body = JSONData.GetEntityFromJSONFile(Entity);

            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            applicationActions.ClearURLData();
            applicationActions.AddURLData("{id:int}", TestsRunParams["TestApplicationID"]);

            var result = applicationActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(applicationActions, result);

        }
        [TestMethod]
        public void DELETEApplication_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Delete;
            Route = null;
            Body = null;

            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            applicationActions.ClearURLData();
            applicationActions.AddURLData("{id:int}", TestsRunParams["TestApplicationID"]);

            var result = applicationActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(applicationActions, result);
        }

        [TestMethod]
        public void POSTSendSms_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = null;
            Entity = "SmsModel";
            Body = JSONData.GetEntityFromJSONFile(Entity);

            //Need to check
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            applicationActions.ClearURLData();

            var result = applicationActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(applicationActions, result);
        }

        [TestMethod]
        public void POSTSendEmail_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = null;
            Entity = "EmailModel";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = JSONData.GetEntityFromJSONFile(Entity);

            //Need to check

            applicationActions.ClearURLData();

            var result = applicationActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(applicationActions, result);
        }



    }
}
