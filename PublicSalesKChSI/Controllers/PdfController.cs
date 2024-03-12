using Microsoft.AspNetCore.Mvc;
using PublicSalesKChSI.Core.Contracts;
using static PublicSalesKChSI.Core.DataConstantsCore;

namespace PublicSalesKChSI.Controllers
{
    public class PdfController : BaseController
    {
        private readonly IHtmlPdfService htmlPdfServices;
        public PdfController(IHtmlPdfService _htmlPdfServices)
        {
            htmlPdfServices = _htmlPdfServices;
        }

        public async Task<IActionResult> Index()
        {
            bool download = false;
            await htmlPdfServices.FillTempPDfAsync();

            download = await htmlPdfServices.DownloadPdfFilesAsync(PathDownloadPdf);
          
            if (!download)
            {
                return View();
            }
            else { return RedirectToAction("CreateBrsFile", "BrsFile"); }
        }
    }
}