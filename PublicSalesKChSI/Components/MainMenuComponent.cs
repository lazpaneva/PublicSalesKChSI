using Microsoft.AspNetCore.Mvc;

namespace PublicSalesKChSI.Components
{
    public class MainMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {                                           //когато View() е празно, търси Default в папките по конвенция
            return await Task.FromResult<IViewComponentResult>(View()); //може 2 различни вюта да се подадат, т.е. ще имаме 2 разл вюта
        }
    }
}
