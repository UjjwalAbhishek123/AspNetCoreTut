using Microsoft.AspNetCore.Mvc;

namespace ViewComponentExample.ViewComponents
{
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //invoked as Partial View & PartialView name is not Default
            return View("Sample");

            //When Default.cshtml was name -> return View();
            //invoked as Partial View
            //Location is -> Views/Shared/Components/Grid/Default.cshtml
        }
    }
}
