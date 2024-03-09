using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicSalesKChSI.Core.Contracts;

namespace PublicSalesKChSI.Controllers
{
    [Authorize]
    public class BrsFileController : Controller
    {
        private readonly IBrsFileService brsFileService;
        public BrsFileController(IBrsFileService _brsFileService)
        {
            brsFileService = _brsFileService;
        }
        [HttpGet]
        public IActionResult CreateBrsFile()
        {
            var model = brsFileService.FillBrsFile();
            return View(model);
        }
    }
}
