using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Models.BrsFile;
using PublicSalesKChSI.Extensions;
using PublicSalesKChSI.Infrastructure.Data.Models;

namespace PublicSalesKChSI.Controllers
{
    public class BrsFileController : BaseController
    {
        private readonly IBrsFileService brsFileService;
        public BrsFileController(IBrsFileService _brsFileService)
        {
            brsFileService = _brsFileService;
        }
        [HttpGet]
        public async Task<IActionResult> CreateBrsFile()
        {
            //List<BrsOnlyContent> model = await brsFileService.FillBrsFile(User.Id());
            BrsFile model = await brsFileService.FillBrsFile(User.Id());
            return View(model);
        }
    }
}
