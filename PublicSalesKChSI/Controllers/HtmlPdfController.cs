using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Models.HtmlPdf;

namespace PublicSalesKChSI.Controllers
{
    [Authorize]
    public class HtmlPdfController : Controller
    {
        private readonly IHtmlPdfService htmlPdfService;
        public HtmlPdfController(IHtmlPdfService _htmlPdfService)
        {
            htmlPdfService = _htmlPdfService;
        }
        [HttpGet]
        public IActionResult DownHtml()
        {
            LastNumbersHtmlFormModel model = new LastNumbersHtmlFormModel();
            var LastNumbers = htmlPdfService.GetLastNumbers();

            model.BeforeLastNumberAsset = LastNumbers.Result[0];
            model.BeforeLastNumberVechicle = LastNumbers.Result[1];
            model.BeforeLastNumberProperties = LastNumbers.Result[2];

            return View(model);
        }

        [HttpPost]
        public IActionResult DownHtml(LastNumbersHtmlFormModel model)
        {
            
            //var LastNumbers = htmlPdfService.GetLastNumbers();

            //model.BeforeLastNumberAsset = LastNumbers.Result[0];
            //model.BeforeLastNumberVechicle = LastNumbers.Result[1];
            //model.BeforeLastNumberProperties = LastNumbers.Result[2];
            return View(model);
        }
    }
}
