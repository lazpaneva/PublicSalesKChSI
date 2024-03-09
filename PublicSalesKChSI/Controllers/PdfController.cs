using Microsoft.AspNetCore.Mvc;
using PublicSalesKChSI.Core.Contracts;
using static PublicSalesKChSI.Core.DataConstantsCore;

namespace PublicSalesKChSI.Controllers
{
    public class PdfController : Controller
    {
        private readonly IHtmlPdfService htmlPdfServices;
        public PdfController(IHtmlPdfService _htmlPdfServices)
        {
                htmlPdfServices = _htmlPdfServices;
        }

        public async Task<IActionResult> Index()
        {
           await htmlPdfServices.FillTempPDfAsync();
           // await htmlPdfServices.DownloadPdfFilesAsync(PathDownloadPdf);
           return View();
        }
    }
}
