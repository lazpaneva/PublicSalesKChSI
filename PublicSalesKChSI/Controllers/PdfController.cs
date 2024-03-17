using Microsoft.AspNetCore.Mvc;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Models.HtmlPdf;
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
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await htmlPdfServices.FillTempPDfAsync();
                        
            if (!await htmlPdfServices.DownloadPdfFilesAsync(PathDownloadPdf))
            {
                return View("Index");
            }
            else
            {
                return RedirectToAction("AllTempPdfsDownloaded");
            }
        }

        [HttpGet]
        public IActionResult AllTempPdfsDownloaded()
        {
            var model = htmlPdfServices.ViewingPdfFilesIsDownloadingAsync();

            return View(model);
        }
    }
}
