using Microsoft.AspNetCore.Mvc;

namespace PublicSalesKChSI.Controllers
{
    public class StatisticsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
