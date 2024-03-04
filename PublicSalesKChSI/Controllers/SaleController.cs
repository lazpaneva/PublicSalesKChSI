using Microsoft.AspNetCore.Mvc;

namespace PublicSalesKChSI.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
