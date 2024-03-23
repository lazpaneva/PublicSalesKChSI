using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Models.HtmlPdf;

namespace PublicSalesKChSI.Controllers
{
    public class HtmlController : BaseController
    {
        private readonly IHtmlPdfService htmlPdfService;
        public HtmlController(IHtmlPdfService _htmlPdfService)
        {
            htmlPdfService = _htmlPdfService;
        }
        
        [HttpGet]
        public async Task <IActionResult> DownHtml()
        {
            var LastNumbers = await htmlPdfService.GetLastNumbersAsync();

            LastNumbersHtmlFormModel model = new LastNumbersHtmlFormModel();
            model.BeforeLastNumberAsset = LastNumbers[0];
            model.BeforeLastNumberVechicle = LastNumbers[1];
            model.BeforeLastNumberProperties = LastNumbers[2];

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DownHtml(LastNumbersHtmlFormModel model)
        {
            var LastNumbers = await htmlPdfService.GetLastNumbersAsync();
                                                
            model.BeforeLastNumberAsset = LastNumbers[0];
            model.BeforeLastNumberVechicle = LastNumbers[1];
            model.BeforeLastNumberProperties = LastNumbers[2];

            //проверки дали въведения номер е по-голям от предишния последен номер, който е свалян
            if (model.BeforeLastNumberAsset >= model.LastNumberAsset)
            {
                ModelState.AddModelError(nameof(model.LastNumberAsset), "Въведеният номер трябва да бъде по-голям от последно сваления номер за Имущество!");
            }
            if (model.BeforeLastNumberVechicle >= model.LastNumberVechicle)
            {
                ModelState.AddModelError(nameof(model.LastNumberVechicle), "Въведеният номер трябва да бъде по-голям от последно сваления номер за Коли!");
            }
            if (model.BeforeLastNumberProperties >= model.LastNumberProperties)
            {
                ModelState.AddModelError(nameof(model.LastNumberProperties), "Въведеният номер трябва да бъде по-голям от последно сваления номер за Имоти!");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool assetDownloading = await htmlPdfService.DownloadHtmlFilesAsync(model.BeforeLastNumberAsset + 1, model.LastNumberAsset, "Asset");
            bool vechicleDownloading = await htmlPdfService.DownloadHtmlFilesAsync(model.BeforeLastNumberVechicle + 1, model.LastNumberVechicle, "Vechicle");
            bool propertyDownloading = await htmlPdfService.DownloadHtmlFilesAsync(model.BeforeLastNumberProperties + 1, model.LastNumberProperties, "Property");

            if (assetDownloading && vechicleDownloading && propertyDownloading)
            {
                return RedirectToAction("DistrubuteFiles", "Pdf");
            }
            else
            {
                return View(model);
            }
        }
    }
}
