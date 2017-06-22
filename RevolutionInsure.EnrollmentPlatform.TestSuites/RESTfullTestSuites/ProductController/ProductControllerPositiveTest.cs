using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AccountController;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction;
using System.Web.Mvc;
using System.Net;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Product;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.ProductController
{
    [TestClass]
    public class ProductControllerPositiveTest : RESTSuiteBase
    {
        ProductActions productActions;

        [TestInitialize]
        public void Initialize()
        {
            AutorizationType = AutorizationType.AllowAnonymous;
        }

        private void InitializeActions()
        {
            AccountControllerTest accountTest = new AccountControllerTest();
            productActions = new ProductActions();
            AutorizationCheck(AutorizationType);
            if (AutorizationType == AutorizationType.Authorize)
            {
                productActions.CreateHeaders(AutorizationType, LoginResult);
            }
        }


        [TestMethod]
        public void GETProduct_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = null;
            ExpectedResponseType = typeof(List<ProductModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            productActions.ClearURLData();

            var result = productActions.RunAPI<List<ProductModel>>(EndPoint, Route, Method, Body);

            Verification(productActions, result);
        }

        [TestMethod]
        public void GETProductByID_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = null;
            ExpectedResponseType = typeof(ProductModel);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            productActions.ClearURLData();
            productActions.AddURLData("{id:int}", TestsRunParams["TestProductID"]);

            var result = productActions.RunAPI<ProductModel>(EndPoint, Route, Method, Body);

            Verification(productActions, result);
        }

        [TestMethod]
        public void POSTAddProduct_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "Add";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Entity = "ProductModel";
            Body = JSONData.GetEntityFromJSONFile(Entity);

            productActions.ClearURLData();

            var result = productActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(productActions, result);
        }

        [TestMethod]
        public void PUTProduct_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Put;
            Route = null;
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Entity = "ProductModel";
            Body = JSONData.GetEntityFromJSONFile(Entity);

            productActions.ClearURLData();
            productActions.AddURLData("{id:int}", TestsRunParams["TestProductID"]);

            var result = productActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(productActions, result);
        }
        /*
        [TestMethod]
        public void DELETEProduct_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Delete;
            Route = null;
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            productActions.ClearURLData();
            productActions.AddURLData("{id:int}", TestsRumParams["TestProductID"]);

            var result = productActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(productActions, result);
        }
        */
    }
}
