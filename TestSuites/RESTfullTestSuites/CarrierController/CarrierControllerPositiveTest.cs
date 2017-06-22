using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction;
using System.Web.Mvc;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AccountController;
using System.Collections.Generic;
using System.Net;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Carrier;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.CarrierController
{
    [TestClass]
    public class CarrierControllerPositiveTest : RESTSuiteBase
    {
        CarrierActions carrierActions;
        [TestInitialize]
        public void Initialize()
        {
            AutorizationType = AutorizationType.AllowAnonymous;
        }
        private void InitializeActions()
        {
            AccountControllerTest accountTest = new AccountControllerTest();
            carrierActions = new CarrierActions();
            AutorizationCheck(AutorizationType);
            if (AutorizationType == AutorizationType.Authorize)
            {
                carrierActions.CreateHeaders(AutorizationType, LoginResult);
            }

        }

        [TestMethod]
        public void GETAllCarriers_PositiveTest()
        {

            InitializeActions();

            Method = HttpVerbs.Get;
            Route = "GetAllCarriers";
            ExpectedResponseType = typeof(List<CarrierModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            carrierActions.ClearURLData();

            var carriers = carrierActions.RunAPI<List<CarrierModel>>(EndPoint, Route, Method, Body);

            Verification(carrierActions, carriers);
        }

        [TestMethod]
        public void GETCarrier_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = null;
            ExpectedResponseType = typeof(CarrierModel);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            carrierActions.ClearURLData();
            carrierActions.AddURLData("{id:int}", TestsRunParams["TestCarrierID"]);

            var carrier = carrierActions.RunAPI<CarrierModel>(EndPoint, Route, Method, Body);

            Verification(carrierActions, carrier);
        }

        [TestMethod]
        public void POSTAddCarrier_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "Add";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;
            Entity = "CarrierModel";

            Body = JSONData.GetEntityFromJSONFile(Entity);

            carrierActions.ClearURLData();

            var result = carrierActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(carrierActions, result);
        }

        [TestMethod]
        public void PUTCarrier_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Put;
            Route = null;
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;
            Entity = "CarrierModel";

            Body = JSONData.GetEntityFromJSONFile(Entity);

            carrierActions.ClearURLData();
            carrierActions.AddURLData("{id:int}", TestsRunParams["TestCarrierID"]);

            var result = carrierActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(carrierActions, result);
        }
        /*
        [TestMethod]
        public void DELETECarrier_PositiveTest()
        {

        }
        */
    }
}
