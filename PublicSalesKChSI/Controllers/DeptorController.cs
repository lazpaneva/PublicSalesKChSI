using Microsoft.AspNetCore.Mvc;

namespace PublicSalesKChSI.Controllers
{
    public class DeptorController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
