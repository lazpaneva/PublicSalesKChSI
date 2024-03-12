using Microsoft.AspNetCore.Mvc;

namespace PublicSalesKChSI.Controllers
{
    public class SaleController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
