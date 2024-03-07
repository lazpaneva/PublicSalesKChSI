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
        public async Task <IActionResult> DownHtml()
        {
            LastNumbersHtmlFormModel model = new LastNumbersHtmlFormModel();
            var LastNumbers = await htmlPdfService.GetLastNumbers();

            model.BeforeLastNumberAsset = LastNumbers[0];
            model.BeforeLastNumberVechicle = LastNumbers[1];
            model.BeforeLastNumberProperties = LastNumbers[2];

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DownHtml(LastNumbersHtmlFormModel model)
        {
            var LastNumbers = await htmlPdfService.GetLastNumbers();
            bool lastDownloading = false;

            model.BeforeLastNumberAsset = LastNumbers[0];
            model.BeforeLastNumberVechicle = LastNumbers[1];
            model.BeforeLastNumberProperties = LastNumbers[2];
            //todo some проверки, ако LastNumber е преди Before

            await htmlPdfService.DownloadHtmlFiles(model.BeforeLastNumberAsset + 1, model.LastNumberAsset, "Asset");
            await htmlPdfService.DownloadHtmlFiles(model.BeforeLastNumberVechicle + 1, model.LastNumberVechicle, "Vechicle");
            lastDownloading = await htmlPdfService.DownloadHtmlFiles(model.BeforeLastNumberProperties + 1, model.LastNumberProperties, "Property");
            //if (lastDownloading)
            //{
            //    return RedirectToAction(nameof(Index), nameof(HomeController));
            //}
            //else
            //{
                return View(model);
            //}
            
        }


        
    }

}
