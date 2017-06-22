using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites
{
    class UriResult
    {
        public String ErrorMessage { get; private set; }
        public Uri Url {get; private set;}
        public UriResult(string message)
        {
            ErrorMessage = message;
        }

        public UriResult(Uri uri)
        {
            Url = uri;
        }
    }
}
