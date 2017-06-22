using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.AccountController;
using System.Web.Mvc;
using System.Net;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Agency;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.ContactController
{
    /// <summary>
    /// Summary description for ContactControllerPositiveTest
    /// </summary>
    [TestClass]
    public class ContactControllerPositiveTest : RESTSuiteBase
    {
        ContactActions contactActions; 
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
            contactActions = new ContactActions();
            AutorizationCheck(AutorizationType);
            if (AutorizationType == AutorizationType.Authorize)
            {
                contactActions.CreateHeaders(AutorizationType, LoginResult);
            }

        }
        [TestMethod]
        public void GETAllContacts_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = "GetAllContacts";
            ExpectedResponseType = typeof(List<ContactModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            contactActions.ClearURLData();

            var contacts = contactActions.RunAPI<List<ContactModel>>(EndPoint, Route, Method, Body);

            Verification(contactActions, contacts);

        }

        [TestMethod]
        public void GETContactByID_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Get;
            Route = null;
            ExpectedResponseType = typeof(ContactModel);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            contactActions.ClearURLData();
            contactActions.AddURLData("{id:int}", TestsRunParams["TestContactID"]);

            var contact = contactActions.RunAPI<ContactModel>(EndPoint, Route, Method, Body);

            Verification(contactActions, contact);
        }

        [TestMethod]
        public void POSTAddContact_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Post;
            Route = "Add";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;
            Entity = "ContactModel";

            Body = JSONData.GetEntityFromJSONFile(Entity);

            contactActions.ClearURLData();

            var result = contactActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(contactActions, result);
        }

        [TestMethod]
        public void PUTContact_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Put;
            Route = null;
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;
            Entity = "ContactModel";

            Body = JSONData.GetEntityFromJSONFile(Entity);

            contactActions.ClearURLData();
            contactActions.AddURLData("{id:int}", TestsRunParams["TestContactID"]);

            var result = contactActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(contactActions, result);
        }

        [TestMethod]
        public void DELETEContacts_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Delete;
            Route = "DeleteList";
            ExpectedResponseType = typeof(bool);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            contactActions.ClearURLData();
            contactActions.AddURLData("List<int> ids", TestsRunParams["TestContactIDs"]);

            var result = contactActions.RunAPI<bool>(EndPoint, Route, Method, Body);

            Verification(contactActions, result);
        }

        public void DELETEContactsInAgency_PositiveTest()
        {
            InitializeActions();

            Method = HttpVerbs.Delete;
            Route = "DeleteContactsInAgency";
            //ExpectedResponseType = typeof(bool);
            ExpectedResponseType = typeof(List<ContactsToDeleteModel>);
            ExpectedResponseHttpStatusCode = HttpStatusCode.OK;

            Body = null;

            //Need to clarify what exactly type should be in URL
            contactActions.ClearURLData();
            contactActions.AddURLData("", TestsRunParams[""]);

            var result = contactActions.RunAPI<List<ContactsToDeleteModel>>(EndPoint, Route, Method, Body);

            Verification(contactActions, result);
        }
    }
}
