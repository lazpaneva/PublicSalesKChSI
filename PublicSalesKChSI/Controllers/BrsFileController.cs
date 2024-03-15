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
            IEnumerable<BrsFileValidationModel> model = await brsFileService.FillBrsFile(User.Id());
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrsFile(IEnumerable<BrsFileValidationModel> model)
        {
            
            return View(model);
        }
        //[HttpPost]
        //public async Task<IActionResult> Add(BrsFile model)
        //{
        //    if ((await agentService.ExistsById(User.Id())) == false)
        //    {
        //        return RedirectToAction(nameof(AgentController.Become), "Agent");
        //    }

        //    if ((await houseService.CategoryExists(model.CategoryId)) == false)
        //    {
        //        ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        model.HouseCategories = await houseService.AllCategories();

        //        return View(model);
        //    }

        //    int agentId = await agentService.GetAgentId(User.Id());

        //    int id = await houseService.Create(model, agentId);

        //    return RedirectToAction(nameof(Details), new { id = id, information = model.GetInformation() });
        //}
    }
}
