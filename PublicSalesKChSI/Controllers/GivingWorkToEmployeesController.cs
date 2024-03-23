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
    public class GivingWorkToEmployeesController : BaseController
    {
        private readonly IGivingWorkService givingWorkService;
        public GivingWorkToEmployeesController(IGivingWorkService _givingWorkService)
        {
            givingWorkService = _givingWorkService;
        }

        [HttpGet]
        public IActionResult DistrubuteFiles()
        {
             DistributionWorkModel model = new DistributionWorkModel();
             model = givingWorkService.GetUsersAndNotReadyCountFiles();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DistrubuteFiles(DistributionWorkModel model)
        {
            var userFileCount = givingWorkService.GetUsersAndNotReadyCountFiles();

            foreach (var item in model.EmployesNumbFiles)
            {
                userFileCount.EmployesNumbFiles.Where(en => en.EmplUserId == item.EmplUserId)
                    .First().NumbFiles = item.NumbFiles;
            }

            await givingWorkService.FillEmployeeIdInBrsFiles(userFileCount);
            
            return RedirectToAction("Mine", "WorkingOnFiles");
        }

    }
}
