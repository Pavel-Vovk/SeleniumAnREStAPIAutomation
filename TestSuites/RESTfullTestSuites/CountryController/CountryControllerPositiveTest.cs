using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction;
using RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AccountController;
using System.Web.Mvc;
using RevolutionInsure.EmrollmentPlatform.Common.Models.Json.Application;
using System.Net;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Application;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.CountryController
{
    /// <summary>
    /// Summary description for CountryControllerPositiveTest
    /// </summary>
    [TestClass]
    public class CountryControllerPositiveTest : RESTSuiteBase
    {

        CountryActions countryActions;
        #region Additional test attributes
        [TestInitialize]
        public void Initialize()
        {
            AutorizationType = AutorizationType.Authorize;
        }
        #endregion
        private void InitializeActions()
        {
            AccountControllerTest accountTest = new AccountControllerTest();
            countryActions = new CountryActions();
            AutorizationCheck(AutorizationType);
            if (AutorizationType == AutorizationType.Authorize)
            {
                countryActions.CreateHeaders(AutorizationType, LoginResult);
            }

        }

        [TestMethod]
        public void GETAllCountries_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = "GetAllCountries";
            ExpectedResponseType = typeof(List<CountryModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            countryActions.ClearURLData();

            var countries = countryActions.RunAPI<List<CountryModel>>(EndPoint, Route, Method, Body);

            Verification(countryActions, countries);
        }
    }
}
