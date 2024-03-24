using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicSalesKChSI.Models;
using System.Diagnostics;

namespace PublicSalesKChSI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //евентуално да махна logger-a
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("DownHtml", "Html");
            }

            return View();
        }

        [AllowAnonymous]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }
            if (statusCode == 401)
            {
                return View("Error400");
            }
            if (statusCode == 500)
            {
                return View("Error500");
            }
            if (statusCode == 404)
            {
                return View("Error404");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}