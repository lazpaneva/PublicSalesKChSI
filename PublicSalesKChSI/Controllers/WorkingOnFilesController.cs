using Microsoft.AspNetCore.Mvc;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Models.WorkingOnFiles;
using PublicSalesKChSI.Extensions;
using PublicSalesKChSI.Infrastructure.Data.Models;
using PublicSalesKChSI.Models.WorkingOnFiles;

namespace PublicSalesKChSI.Controllers
{
    public class WorkingOnFilesController : BaseController
    {
        private readonly IWorkingOnFilesService _files;
        public WorkingOnFilesController(IWorkingOnFilesService files)
        {
            _files = files;
        }
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllFilesQueryModel query)
        {
            var queryResult = await _files.AllAsync(
                query.Court,
                query.SearchFirstTermName,
                query.SearchSecondTermName,
                query.SearchThirdTermName,
                query.Sorting,
                query.CurrentPage,
                AllFilesQueryModel.FilesPerPage,
                query.NotReady);

            query.TotalFilesCount = queryResult.TotalFilesCount;
            query.Files = queryResult.Files;

            var courtCategories = await _files.AllCourtsTownAsync();
            query.Courts = (IEnumerable<string>)courtCategories;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await _files.ExistsAsyncBrsFile(id) == false)
            {
                return BadRequest();
            }
            var model = await _files.FileDetailsByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var brsFileExists = await _files.ExistsAsyncBrsFile(id);
            if (brsFileExists == false)
            {
                return BadRequest();
            }

            //string currUser = User.Id(); //!!!TO DO - да го направя с роля АДМИНИСТРАТОР
            //if (await _files.ExistsEmployeeIdWitrhIdAsync(id) != currUser)
            //{
            //    return Unauthorized();
            //}

            var modelDetails = await _files.FileDetailsByIdAsync(id);

            FileFormModel model = new FileFormModel();
            model.Klas = modelDetails.Klas;
            model.Dcng = modelDetails.Dcng;
            model.Date = modelDetails.Date;
            model.Name = modelDetails.Name;
            model.Text = modelDetails.Text;
            model.Lica = modelDetails.Lica;
            model.Scre = modelDetails.Scre;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, FileFormModel model)
        {
            if (await _files.ExistsAsyncBrsFile(id) == false)
            {
                return this.View();
            }

            //string currUser = User.Id(); !!!TO DO - да го направя с роля АДМИНИСТРАТОР
            //if (await _files.ExistsEmployeeIdWitrhIdAsync(id) != currUser)
            //{
            //    return Unauthorized();
            //}

            if (ModelState.IsValid == false)
            {
                return this.View();
            }
            
            await _files.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new {id = id});
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _files.ExistsAsyncBrsFile(id) == false)
            {
                return BadRequest();
            }

            string currUser = User.Id();
            if (await _files.ExistsEmployeeIdWitrhIdAsync(id) != currUser)
            {
                return Unauthorized();
            }

            var modelDetails = await _files.FileDetailsByIdAsync(id);

            var model = new FileDetailsServiceModel()
            {
                Code = modelDetails.Code,
                Name = modelDetails.Name,
                Dcng = modelDetails.Dcng,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(FileDetailsServiceModel file)
        {
            if (await _files.ExistsAsyncBrsFile(file.Id) == false)
            {
                return BadRequest();
            }

            string currUser = User.Id();
            if (await _files.ExistsEmployeeIdWitrhIdAsync(file.Id) != currUser)
            {
                return Unauthorized();
            }

            await _files.DeleteTempHtmlByBrsFileIdAsync(file.Id);

            await _files.DeleteBrsFileAsync(file.Id);

            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult> ShortEdit(int id)
        {
            var brsFileExists = await _files.ExistsAsyncBrsFile(id);
            if (brsFileExists == false)
            {
                return BadRequest();
            }

            string currUser = User.Id();
            if (await _files.ExistsEmployeeIdWitrhIdAsync(id) != currUser)
            {
                return Unauthorized();
            }

            var modelDetails = await _files.FileDetailsByIdAsync(id);

            FileFormModel model = new FileFormModel();
            model.Id = id;
            model.Klas = modelDetails.Klas;
            model.Dcng = modelDetails.Dcng;
            model.Date = modelDetails.Date;
            model.Name = modelDetails.Name;
            model.Text = modelDetails.Text;
            model.Lica = modelDetails.Lica;
            model.Scre = modelDetails.Scre;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ShortEdit(int id, FileFormModel model)
        {
            if (await _files.ExistsAsyncBrsFile(id) == false)
            {
                return this.View();
            }

            string currUser = User.Id();
            if (await _files.ExistsEmployeeIdWitrhIdAsync(id) != currUser)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid == false)
            {
                return this.View();
            }

            await _files.EditAsync(id, model);

            return RedirectToAction("Mine");
        }

        [HttpGet]
        public async Task<IActionResult> Mine([FromQuery] AllFilesQueryModel query)
        {
            var queryResult = await _files.AllAsync(
                query.Court,
                query.SearchFirstTermName,
                query.SearchSecondTermName,
                query.SearchThirdTermName,
                query.Sorting,
                query.CurrentPage,
                AllFilesQueryModel.FilesPerPage,
                true);

            query.Files = queryResult.Files.Where(f => f.EmployeeId == User.Id());
            query.TotalFilesCount = query.Files.Count();
            //query.TotalFilesCount = queryResult.TotalFilesCount;


            var courtCategories = await _files.AllCourtsTownAsync();
            query.Courts = (IEnumerable<string>)courtCategories;

            return View(query);
        }
    }
}
