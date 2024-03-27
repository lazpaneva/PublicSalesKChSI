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
        public async Task<IActionResult> DistrubuteFiles()
        {
            DistributionWorkModel model = new DistributionWorkModel();
            model.NotReadyFilesCount = await givingWorkService.GetNotReadyCountFiles();
            model.usersInfo = await givingWorkService.GetFullUsers();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DistrubuteFiles(DistributionWorkModel model)
        {
            model.NotReadyFilesCount = await givingWorkService.GetNotReadyCountFiles(); //нещо не се получава с проверката !!!TO DO
            if (!ModelState.IsValid)
            {
                model.usersInfo = await givingWorkService.GetFullUsers();
                return View(model);
            }

            model.usersInfo = await givingWorkService.GetFullUsers();
            await givingWorkService.FillEmployeeIdInBrsFiles(model);
            model.NotReadyFilesCount = await givingWorkService.GetNotReadyCountFiles();


            return View(model);
        }

    }
}
