using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.WebPages;
using TestSuites;
using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.TestData.MultiQuote;
using NUnit.Framework;
using System.Text.RegularExpressions;
using RevolutionInsure.EnrollmentPlatform.TestSuites.UISeleniumTestSuites.Login;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.MultiQuote
{
    [TestClass]
    public class FilMultiQuotelSteps : SeleniumUISuiteBase
    {
        private LoginUIPositiveTest loginUIPositiveTest = new LoginUIPositiveTest();
        private int stepNumber=0;
        [TestMethod]
        [Category("SeleniumUITest")]
        public void UIFillStep1ReviewQuotePositive()
        {
            /*
            #region Variable declaration and initialization
            stepNumber = 1;
            #endregion

            #region Test Data Preparation and Collecting
            FillFileldsStepsData stepsData = new FillFileldsStepsData(stepNumber);
            #endregion

            #region Navigation
            Pages.multiquotePage.Open();
            #endregion

            #region Navigation Loading checks
            Pages.multiquotePage.isCurrentStepLoaedCorrectly(stepNumber);
            #endregion

            #region Actions on Page
            Pages.multiquotePage.FillReviewQuoteFields(stepsData);
            #endregion

            #region Verification data input Validation
            Pages.multiquotePage.Step1DataInputValidation();
            #endregion

            #region After Validation Actions 
            Pages.multiquotePage.DoNext();
            #endregion

            #region Final Verification (Navigation, Submit, Responce)
            Pages.multiquotePage.isLoadedMultiQuotePersonalInfoStep();
            #endregion
            */
        }

        [TestMethod]
        [Category("SeleniumUITest")]
        public void MultiQuoteReviewQuoteFill_PositiveTest()
        {
            #region Variable declaration and initialization
            #endregion

            #region Test Data Preparation and Collecting
            #endregion
            #region Some Preparation actions
            loginUIPositiveTest.AgentLogin();
            #endregion
            #region Navigation
            Pages.Multiquote.Open();
            #endregion

            #region Navigation Loading checks
            Entity = "MultiquoteReviewQuote_Ind_Texts";
            //Pages.Multiquote.TitleValueValidation(Entity);
            #endregion

            #region Actions on Page
            Entity = "Quote_Data_Family";
            Pages.Multiquote.FillData(Entity);
            //Pages.multiquotePage.FillReviewQuoteFields(stepsData);
            #endregion

            #region Verification data input Validation
            
            #endregion

            #region After Validation Actions
            Pages.Multiquote.DoSearch();
            #endregion

            #region Final Verification (Navigation, Submit, Responce)
            Entity = "MIC_AEP_ProductOption";
            Pages.Multiquote.SelectMedicoAEP(Entity);
            Pages.Multiquote.DoBuyNow();
            Entity = "PersonalInfo_Family";
            Pages.Application.FindHeathInfoQuestions();
            //Pages.Application.FillPersonalInfo(Entity);
            Entity = "Application";
            Pages.Application.FillAllInputs(Entity);
            Pages.Application.FindHeathInfoQuestions();
            #endregion     
        }

        [TestMethod]
        [Category("SeleniumUITest")]
        public void UIFillStep1ReviewQuoteNegative()
        {
            //TODO Negative data verification
        }
    }
}
