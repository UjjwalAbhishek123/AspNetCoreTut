using Microsoft.AspNetCore.Mvc;

namespace FileUploadAspNetCore1.Controllers
{
    public class FileUploadController : Controller
    {
        //GET
        public IActionResult SingleFileUpload()
        {
            return View();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> SingleFileUpload(IFormFile SingleFile)
        {
            if (ModelState.IsValid)
            {
                if (SingleFile != null && SingleFile.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", SingleFile.FileName);
                    //Using Buffering
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        // The file is saved in a buffer before being processed
                        await SingleFile.CopyToAsync(stream);
                    }
                    //Using Streaming
                    //using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    //{
                    //    await SingleFile.CopyToAsync(stream);
                    //}
                    // Process the file here (e.g., save to the database, storage, etc.)
                    return View("UploadSuccess");
                }
            }
            return View("SingleFileUpload");
        }
    }
}
