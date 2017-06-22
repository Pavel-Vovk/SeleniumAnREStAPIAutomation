using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AccountController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.PdfConversionController
{
    [TestClass]
    public class PdfConversionControllerPositiveTest : RESTSuiteBase
    {
        PdfConversionActions pdfConversionActions;
        [TestInitialize]
        public void Initialize()
        {
            AutorizationType = AutorizationType.AllowAnonymous;
        }

        private void InitializeActions()
        {
            AccountControllerTest accountTest = new AccountControllerTest();
            pdfConversionActions = new PdfConversionActions();
            AutorizationCheck(AutorizationType);
            if (AutorizationType == AutorizationType.Authorize)
            {
                pdfConversionActions.CreateHeaders(AutorizationType, LoginResult);
            }
        }

        [TestMethod]
        public void GETCreation_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = "creating";
            //Looks like the API Controller Method not finished (hard coded to many items)
        }

        [TestMethod]
        public void POSTPngCreation_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "PngCreation";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Entity = "TransferDetails";
            Body = JSONData.GetEntityFromJSONFile(Entity);

            pdfConversionActions.ClearURLData();

            var result = pdfConversionActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(pdfConversionActions, result);
        }

        [TestMethod]
        public void POSTtiffCreation_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "tiffCreation";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Entity = "TransferDetails";
            Body = JSONData.GetEntityFromJSONFile(Entity);

            pdfConversionActions.ClearURLData();

            var result = pdfConversionActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(pdfConversionActions, result);
        }

        [TestMethod]
        public void POSTBackgroundProcess_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "BackgroundProcess";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Entity = "TransferDetails";
            Body = JSONData.GetEntityFromJSONFile(Entity);

            pdfConversionActions.ClearURLData();

            var result = pdfConversionActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(pdfConversionActions, result);
        }
    }
}
