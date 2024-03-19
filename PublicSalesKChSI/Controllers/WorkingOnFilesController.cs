using Microsoft.AspNetCore.Mvc;
using PublicSalesKChSI.Core.Contracts;
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
                AllFilesQueryModel.FilesPerPage
                );

            query.TotalFilesCount = queryResult.TotalFilesCount;
            query.Files = queryResult.Files;

            var courtCategories = await _files.AllCourtsTownAsync();
            query.Courts = (IEnumerable<string>)courtCategories;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await _files.ExistsAsync(id) == false)
            {
                return BadRequest();
            }
            var model = await _files.FileDetailsByIdAsync(id);

            return View(model);
        }
    }
}
