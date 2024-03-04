using Microsoft.AspNetCore.Mvc;

namespace PublicSalesKChSI.Controllers
{
    public class HtmlPdfController : Controller
    {
        public IActionResult LastNumbersToDown()
        {
            return View();
        }
    }
}
