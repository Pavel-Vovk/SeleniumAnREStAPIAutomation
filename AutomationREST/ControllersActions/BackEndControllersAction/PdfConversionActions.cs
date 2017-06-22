using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.FileTransfer;

namespace RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions.BackEndControllersAction
{
    public class PdfConversionActions : GenericActions
    {

        public TransferDetails TranferDetails { get; set; }

        public PdfConversionActions()
        {
            Route = "PDFConversion";
        }
    }
}
