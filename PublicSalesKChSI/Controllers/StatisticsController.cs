using Microsoft.AspNetCore.Mvc;

namespace PublicSalesKChSI.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
