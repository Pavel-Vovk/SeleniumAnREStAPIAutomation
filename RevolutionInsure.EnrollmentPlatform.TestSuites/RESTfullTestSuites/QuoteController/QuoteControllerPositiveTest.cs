using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AccountController;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction;
using System.Web.Mvc;
using System.Net;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.QuoteEngine;
using RevolutionInsure.EmrollmentPlatform.Common.Enum;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.QuoteController
{
    [TestClass]
    public class QuoteControllerPositiveTest : RESTSuiteBase
    {
        QuoteActions quoteActions;

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
            quoteActions = new QuoteActions();
            AutorizationCheck(AutorizationType);
            if (AutorizationType == AutorizationType.Authorize)
            {
                quoteActions.CreateHeaders(AutorizationType, LoginResult);
            }
        }
        [TestMethod]
        public void POSTGetProducts_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "Products";
            //N/A Response
            ExpectedResponseType = typeof(QuoteViewModel);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Entity = "QuoteRequest";

            //quote request creation
            //QuoteRequestJson();
            Body = JSONData.GetEntityFromJSONFile(Entity);

            quoteActions.ClearURLData();
            

            var result = quoteActions.RunAPI<QuoteViewModel>(EndPoint, Route, Method, Body);

            Verification(quoteActions, result);
        }

        [TestMethod]
        public void POSTGetPremiums_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "Premiums";
            
            ExpectedResponseType = typeof(PremiumViewModel);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Entity = "OptionValueChangeRequest";
            Body = JSONData.GetEntityFromJSONFile(Entity);

            quoteActions.ClearURLData();

            var result = quoteActions.RunAPI<PremiumViewModel>(EndPoint, Route, Method, Body);

            Verification(quoteActions, result);
        }

        [TestMethod]
        public void POSTGetProductOptions_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "ProductOptions";
            
            ExpectedResponseType = typeof(ProductOptionValueViewModel);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Entity = "OptionValueChangeRequest";
            Body = JSONData.GetEntityFromJSONFile(Entity);

            quoteActions.ClearURLData();

            var result = quoteActions.RunAPI<ProductOptionValueViewModel>(EndPoint, Route, Method, Body);

            Verification(quoteActions, result);
        }

        /*
        [TestMethod]
        public void GETStates_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = "States";
            
            ExpectedResponseType = typeof(List<StateViewModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            quoteActions.ClearURLData();

            var result = quoteActions.RunAPI<List<StateViewModel>>(EndPoint, Route, Method, Body);

            Verification(quoteActions, result);
        }
        */
        /*
        [TestMethod]
        public void GETGetStateByZip_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = "States";
            
            ExpectedResponseType = typeof(StateViewModel);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            quoteActions.ClearURLData();
            quoteActions.AddURLData("zipcode", TestsRunParams["TestZipCode"]);

            var result = quoteActions.RunAPI<StateViewModel>(EndPoint, Route, Method, Body);

            Verification(quoteActions, result);
        }
        */

        private void QuoteRequestJson()
        {
            QuoteRequest qr = new QuoteRequest();
            qr.Coverage = CoverageType.IndividualSpouse;
            qr.Primary = new PersonInfo { BirthDate = DateTime.Parse("1983/1/1"), Gender = "Male", State = "AZ" };
            qr.Spouse = new PersonInfo { BirthDate = DateTime.Parse("1987/3/3"), Gender = "Female", State = "AZ" };
            JSONData.LoadJSONDataToFile<QuoteRequest>(qr);
        }
    }
}
