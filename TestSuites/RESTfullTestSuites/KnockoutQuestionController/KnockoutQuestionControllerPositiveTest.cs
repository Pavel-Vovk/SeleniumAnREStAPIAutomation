using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction;
using RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AccountController;
using RevolutionInsure.EnrollmentPlatform.Api.Security;
using System.Web.Mvc;
using System.Net;
using RevolutionInsure.EmrollmentPlatform.Common.Security;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Application;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.KnockoutQuestionController
{
    [TestClass]
    public class KnockoutQuestionControllerPositiveTest : RESTSuiteBase
    {

        KnockoutQuestionActions knockoutQuestionActions;

        #region Additional test attributes
        [TestInitialize]
        public void Initialize()
        {
            //Need to change the Autorization logic in order to check the Role
            AutorizationType = AutorizationType.Authorize;
            AccessedSystemRoles = new SystemRoles[3] {SystemRoles.AgencyAdmin, SystemRoles.Administrator, SystemRoles.Agent };
        }
        #endregion
        private void InitializeActions()
        {
            AccountControllerTest accountTest = new AccountControllerTest();
            knockoutQuestionActions = new KnockoutQuestionActions();
            AutorizationCheck(AutorizationType);
            if (AutorizationType == AutorizationType.Authorize)
            {
                knockoutQuestionActions.CreateHeaders(AutorizationType, LoginResult);
            }
        }

        [TestMethod]
        public void GETKnockoutQuestionsByState_positiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = null;
            ExpectedResponseType = typeof(List<KnockOutQuestionModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            knockoutQuestionActions.ClearURLData();
            knockoutQuestionActions.AddURLData("PrefixParam{productid:int}", TestsRunParams["TestProductID"]);
            knockoutQuestionActions.AddURLData("{state:int}", TestsRunParams["TestStateID"]);

            var knockoutQuestions = knockoutQuestionActions.RunAPI<List<KnockOutQuestionModel>>(EndPoint, Route, Method, Body);

            Verification(knockoutQuestionActions, knockoutQuestions);
        }
    }
}
