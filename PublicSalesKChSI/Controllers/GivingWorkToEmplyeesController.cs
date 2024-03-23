using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static PublicSalesKChSI.Extensions.ClaimsPrincipalExtensions;
using PublicSalesKChSI.Extensions;
using PublicSalesKChSI.Infrastructure.Data;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Models.GivingWork;
using PublicSalesKChSI.Core.Models.WorkingOnFiles;

namespace PublicSalesKChSI.Controllers
{
    public class GivingWorkToEmplyeesController : BaseController
    {
        private readonly IGivingWorkService givingWorkService;
        private readonly IBrsFileService brsFileService;
        public GivingWorkToEmplyeesController(IGivingWorkService _givingWorkService, 
            IBrsFileService _brsFileService)
        {
            givingWorkService = _givingWorkService;
            brsFileService = _brsFileService;
        }

        [HttpGet]
        public IActionResult DistrubuteFiles()
        {
            DistributionWorkModel model = new DistributionWorkModel();
                       
             return View(model);
        }

        [HttpPost]
        public IActionResult DistrubuteFiles(DistributionWorkModel model)
        {
            givingWorkService.GetUsersAndNotReadyCountFiles(model);
            givingWorkService.FillEmployeeIdInBrsFiles(model);
            
            return RedirectToAction("Mine", "WorkingOnFiles");
        }

    }
}
