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

        public IActionResult Index()
        {
            var listSth = htmlPdfServices.DownLoadPdfFiles();
            return View();
        }
    }
}
