using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using System.Web.Mvc;
using System.Net;
using RevolutionInsure.EmrollmentPlatform.Common.Security;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Account;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions;
using RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AccountController;
using RevolutionInsure.EnrollmentPlatform.Api.Security;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites
{
    public abstract class RESTSuiteBase
    {
        public Dictionary<string, string> ErrorDictionary { get; private set; }
        private string defaultError = "Unexpected error appeared";

        public Dictionary<string, string> TestsRunParams { get; private set; }
       
        public Type ExpectedResponseType { get; set; }

        public HttpStatusCode ExpectedResponseHttpStatusCode { get; set; }

        public HttpVerbs Method { get; set; }

        public  SystemRoles[] AccessedSystemRoles { get; set; }

        public LoginResultModel LoginResult { get; set; }

        protected AutorizationType AutorizationType { get; set; }

        public string Agent { get; set; }

        public string EndPoint { get; set; }

        public string Route { get; set; }

        public string JsonData { get; set; }

        public string Entity { get; set; }

        public int? IntParameter { get; set; }

        public string Body { get; set; }



        public string GetTypeOfVerificationErrorMessage()
        {
            if (ErrorDictionary != null)
                return ErrorDictionary["TypeOfVerification"];
            else return defaultError;

        }

        protected void AutorizationCheck(AutorizationType autorizationType)
        {
            AutorizationType = autorizationType;
            if (autorizationType == AutorizationType.AllowAnonymous)
            {

            }else if (autorizationType == AutorizationType.Authorize)
            {
                AccountControllerTest accountTest = new AccountControllerTest();
                LoginResult = accountTest.POSTAccountLogin();
            }
        }

        protected void Verification(GenericActions genActions, object result)
        {
            #region Verification General Actions
            //First level verification - No errors during running
            Assert.IsNull(genActions.Errors, genActions.Errors);
            //Second level Verification - HttpStatusCode verification on expected value
            Assert.AreEqual(ExpectedResponseHttpStatusCode, genActions.GetResponceStatusCode(), GetStatusCodeVerificationErrorMessage() + (int)ExpectedResponseHttpStatusCode + ": " + ExpectedResponseHttpStatusCode);
            //Third level Verirication - Type of the responce value verification
            Assert.IsInstanceOfType(result, ExpectedResponseType, genActions.Errors);
            #endregion
        }

        public string GetContentVerificationErrorMessage()
        {
            if (ErrorDictionary != null)
                return ErrorDictionary["ContentVerification"];
            else return defaultError;
        }
        public string GetStatusCodeVerificationErrorMessage()
        {
            if (ErrorDictionary != null)
                return ErrorDictionary["StatusCodeVerification"];
            else return defaultError;
        }

        [TestInitialize]
        public void TestInitialize()

        {
            ApplicationConfiguration appconfig = new ApplicationConfiguration("APIConfiguration", "ErrorMessages");
            ErrorDictionary = appconfig.GetConfig();
            TestsRunParams = appconfig.GetConfig("APIConfiguration", "TestsConfig");
            EndPoint = appconfig.GetConfig("GeneralConfiguration", "RunConfig")["RunLocation"];

        }
        [TestCleanup]
        public void TestCleanUp()
        {

        }
        /*
        public int GetInt(String param)
        {
            int i;
            if (int.TryParse(param, out i))
                return i;
            else return default(int);
        }
        */

    }
}
