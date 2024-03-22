using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Models.BrsFile;
using PublicSalesKChSI.Extensions;
using PublicSalesKChSI.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using PublicSalesKChSI.Core.Services;
using Microsoft.EntityFrameworkCore;
using PublicSalesKChSI.Infrastructure.Data;

namespace PublicSalesKChSI.Controllers
{
    public class BrsFileController : BaseController
    {
        private readonly IBrsFileService brsFileService;
        private readonly PublicSalesDbContext dbContext;
        public BrsFileController(IBrsFileService _brsFileService,
            PublicSalesDbContext _dbContext)   //в някои съобщения вериф. грешка, не мога да измисля как да ги върна отново в Services
        {                   //ето защо тук направо си инжектирам  dbContext
            brsFileService = _brsFileService;
            dbContext = _dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> CreateBrsFile()
        {
            IEnumerable<BrsFileValidationModel> model = await brsFileService.FillBrsFile(User.Id());
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateBrsFile(List<BrsFileValidationModel> files)
        {
            foreach (var file in files)
            {
                dbContext.BrsFiles.Add(new BrsFile
                {
                    Code = file.Code,
                    Klas = file.Klas,
                    Date = file.Date,
                    Dcng = file.Dcng,
                    Name = file.Name,
                    Text = file.Text,
                    IsFileReady = file.IsFileReady,
                    IsFindDeptor = file.IsFindDeptor,
                    UrlPdf = "Липсва pdf файл"
                });
            }

            dbContext.SaveChanges();

           return RedirectToAction("Index", "Home");
        }
    }
}
