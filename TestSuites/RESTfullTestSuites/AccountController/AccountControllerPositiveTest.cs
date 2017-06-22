using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction;
using System.Web.Mvc;
using Auth0.Core;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using RevolutionInsure.EmrollmentPlatform.Common.Models;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using RevolutionInsure.EmrollmentPlatform.Common.Security;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Account;
using RevolutionInsure.EnrollmentPlatform.Api.Security;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AccountController
{
    [TestClass]

    public class AccountControllerTest : RESTSuiteBase
    {

        AccountActions accountActions;
        //InviteUserModel InviteUser;

        private void InitializeActions()
        {
            accountActions = new AccountActions();
            AutorizationCheck(AutorizationType);
            if (AutorizationType == AutorizationType.Authorize)
            {
                accountActions.CreateHeaders(AutorizationType, LoginResult);
            }
        }

        [TestInitialize]
        public void Initialize()
        {
            AutorizationType = AutorizationType.AllowAnonymous;
        }

        public LoginResultModel POSTAccountLogin()
        {
            InitializeActions();
            Route = "Login";
            Method = HttpVerbs.Post;
//            Agent = "Lisa";

            ExpectedResponseType = typeof(LoginResultModel);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Entity = "LiginModel_Lisa";
            Body = JSONData.GetEntityFromJSONFile(Entity);

            accountActions.ClearURLData();

            #region General Actions
            var loginResult = accountActions.RunAPI<LoginResultModel>(EndPoint, Route, Method, Body);
            #endregion

            Verification(accountActions, loginResult);

            LoginResult = loginResult;
            return loginResult;
        }

        [TestMethod]
        public void POSTAccountLogin_PositiveTest()
        {

            POSTAccountLogin();
        }
        [TestMethod]
        public void POSTGetUserProfile()
        {

            AutorizationType = AutorizationType.Authorize;
            InitializeActions();

            Route = "GetUserProfile";
            Method = HttpVerbs.Post;

            ExpectedResponseType = typeof(User);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            var value = new UserProfileModel();
            value.Accesstoken = LoginResult.AccessToken;
            Body = JsonConvert.SerializeObject(value);

            var result = accountActions.RunAPI<User>(EndPoint, Route, Method, Body);
            //IsUserInRole(SystemRoles.Agent);
            Verification(accountActions, result);

        }

        public bool IsUserInRole(SystemRoles role)
        {
            AutorizationType = AutorizationType.Authorize;
            InitializeActions();

            Route = "GetUserProfile";
            Method = HttpVerbs.Post;

            ExpectedResponseType = typeof(User);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            var value = new UserProfileModel();
            value.Accesstoken = LoginResult.AccessToken;
            Body = JsonConvert.SerializeObject(value);

            var result = accountActions.RunAPI<User>(EndPoint, Route, Method, Body);

            Verification(accountActions, result);

            JToken res = null;
            if (result.ProviderAttributes.TryGetValue("roles", out res))
            {
                var jValues= res.Cast<JValue>().ToArray();
                var test = jValues.Any(i => i.Value.ToString() == role.ToString());
                return test; 
            }
            return false;
        }
    }
}

