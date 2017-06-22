using System;

namespace RevolutionInsure.EnrollmentPlatform.AutomationSelenium.Utilites.WebElement
{
    public class WebElementNotFoundException : Exception
    {
        public WebElementNotFoundException(string message) : base(message)
        {
        }
    }
}
