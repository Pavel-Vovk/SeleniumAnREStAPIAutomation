using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.WebPages;
using TestSuites;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.UISeleniumTestSuites.Login
{
    /// <summary>
    /// Summary description for LoginUIPositiveTest
    /// </summary>
    [TestClass]
    public class LoginUIPositiveTest : SeleniumUISuiteBase
    {

        public LoginUIPositiveTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void LoginAsJSONAgent_Test()
        {
            AgentLogin();  
        }

        public void AgentLogin()
        {
            #region Variable declaration and initialization
            #endregion

            #region Test Data Preparation and Collecting

            //FillFileldsStepsData stepsData = new FillFileldsStepsData(stepNumber);
            #endregion

            #region Navigation
            Pages.Login.Open();
            #endregion

            #region Navigation Loading checks
            //Pages.multiquotePage.isCurrentStepLoaedCorrectly(stepNumber);
            #endregion

            #region Actions on Page
            Entity = "LiginModel_Lisa";
            Pages.Login.FillData(Entity);
            //Pages.multiquotePage.FillReviewQuoteFields(stepsData);
            #endregion

            #region Verification data input Validation
            //Pages.multiquotePage.Step1DataInputValidation();
            #endregion

            #region After Validation Actions 
            Pages.Login.DoLogin();
            #endregion

            #region Final Verification (Navigation, Submit, Responce)
            //Pages.multiquotePage.isLoadedMultiQuotePersonalInfoStep();
            #endregion        

        }
    }
}