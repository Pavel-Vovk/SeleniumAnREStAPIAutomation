using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;

namespace RevolutionInsure.EnrollmentPlatform.TestSuites.RESTfullTestSuites.LogController
{
    [TestClass]
    public class LogControllerPositiveTest : RESTSuiteBase
    {
        #region Additional test attributes
        [TestInitialize]
        public void Initialize()
        {
            AutorizationType = AutorizationType.AllowAnonymous;
        }
        #endregion

        [TestMethod]
        public void GETAzureDirectoryFileList_PositiveTest()
        {
            //Need to clarify how to define as URL Params
            //string targetName, bool showCurrentLogFolder, string folderName
        }

        [TestMethod]
        public void GetAzureLogFile_PositiveTest()
        {
            //Need to clarify how to define as URL Params
            //string targetName, string fileName
        }
    }
}
