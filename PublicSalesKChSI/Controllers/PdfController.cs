using Microsoft.AspNetCore.Mvc;
using PublicSalesKChSI.Core.Contracts;

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
           await htmlPdfServices.FillTempPDf();
           return View();
        }
    }
}
