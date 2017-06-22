using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites
{
    public static class JsonHelper
    {
        private static string Path;
        static JsonHelper()
        {
            ApplicationConfiguration appconfig = new ApplicationConfiguration("GeneralConfiguration", "Paths");
            Path = appconfig.GetConfig()["JSONUITestDataFilesPath"];
        }

        public static string GetEntityFromJSONFile(string entityName)
        {
            return File.ReadAllText(Path + entityName + @".json"); 
        }

        public static string ClearString(string str)
        {
            Regex.Replace(str, @"\/r|\/n", String.Empty);
            return str.Trim();
        }
    }
}
