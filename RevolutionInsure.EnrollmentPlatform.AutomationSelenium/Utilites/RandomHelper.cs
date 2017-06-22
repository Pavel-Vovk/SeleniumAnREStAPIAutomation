using System.IO;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites
{
    public static class RandomHelper
    {
        public static string RandomString
        {
            get { return Path.GetRandomFileName().Replace(".", string.Empty); }
        }
    }
}
