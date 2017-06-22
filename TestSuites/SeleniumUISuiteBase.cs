using RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace TestSuites
{
    [TestClass]
    public abstract class SeleniumUISuiteBase
    {
        public string Entity;
        public TestContext TestContext { get; set; }

        [TestInitialize]

        public void TestInitialize()
        {
            Browser.Start();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            Browser.Quit();
        }

    }
}
