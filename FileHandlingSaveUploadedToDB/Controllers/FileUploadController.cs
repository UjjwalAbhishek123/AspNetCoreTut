using Microsoft.AspNetCore.Mvc;

namespace FileUploadAspNetCore2.Controllers
{
    public class FileUploadController : Controller
    {
        //GET
        public IActionResult SingleFileUpload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SingleFileUpload(IFormFile SingleFile)
        {
            return View();
        }
    }
}
