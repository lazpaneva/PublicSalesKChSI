using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Models.BrsFile;

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
            List<BrsOnlyContent> model = brsFileService.FillBrsFile();
            return View(model);
        }
    }
}
