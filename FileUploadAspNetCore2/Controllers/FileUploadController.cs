using FileUploadAspNetCore2.Models;
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
        [RequestSizeLimit(10000000)] // Limit file size to 10 MB
        public async Task<IActionResult> SingleFileUpload(IFormFile SingleFile)
        {
            //Checking if the file getting upload is null or doesn't has any content then show error
            if (SingleFile == null || SingleFile.Length == 0)
            {
                ModelState.AddModelError("", "File not selected");
                return View("SingleFileUpload");
            }

            //making extensions that will be allowed only to upload
            var permittedExtensions = new[] { ".jpg", ".png", ".gif" };
            var extension = Path.GetExtension(SingleFile.FileName).ToLowerInvariant();

            //checking if the extensionb is Null or Empty or is not present in permittedExtensions array, then show error
            if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
            {
                ModelState.AddModelError("", "Invalid file type.");
            }

            //Validate MIME type as well
            var mimeType = SingleFile.ContentType;
            var permittedMimeTypes = new[] { "image/jpeg", "image/png", "image/gif" };

            if (!permittedMimeTypes.Contains(mimeType))
            {
                ModelState.AddModelError("", "Invalid MIME type.");
            }

            if (ModelState.IsValid)
            {
                //Creating a unique File Name
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(SingleFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", uniqueFileName);

                //Using Buffering
                //using (var stream = System.IO.File.Create(filePath))
                //{
                //    // The file is saved in a buffer before being processed
                //    await SingleFile.CopyToAsync(stream);
                //}

                //Using Streaming
                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    //This will save to Local folder
                    await SingleFile.CopyToAsync(stream);
                }
                // Create an instance of FileModel
                var fileModel = new FileModel
                {
                    FileName = uniqueFileName,
                    Length = SingleFile.Length,
                    ContentType = mimeType,
                    Data = ConvertToByteArray(filePath)
                };

                // Save to database
                EFCoreDbContext _context = new EFCoreDbContext();
                _context.Files.Add(fileModel);
                await _context.SaveChangesAsync();

                // Process the file here (e.g., save to the database, storage, etc.)
                return View("UploadSuccess");
            }
            return View("Index");
        }

        //        File ko byte array mein convert karne ka primary purpose hai file data ko efficiently store, transfer, aur process karna.Byte array ek general data format hai jo kisi bhi type ki file ko represent kar sakta hai, jaise image, document, video, etc.

        //Yahan kuch main reasons hain jo explain karte hain ki uploaded file ko byte array mein kyu convert kiya jata hai:

        //1. Database Storage
        //Binary data storage: Agar aap uploaded file ko database (jaise SQL Server) mein store karna chahte hain, toh file ko byte array mein convert karke BLOB(Binary Large Object) format mein store kar sakte hain.Most databases byte[] ko support karte hain file storage ke liye.

        //2. Temporary Storage and Caching
        //In-memory storage: Byte arrays ko efficiently memory mein store kiya ja sakta hai, jo performance optimization ke liye useful hota hai jab aapko kisi uploaded file ko temporarily cache karna ho.For example, agar aapko kisi file ko multiple times use karna ho bina usse baar-baar disk se read kiye, toh byte array ko in-memory store karke aap performance improve kar sakte hain.

        private byte[] ConvertToByteArray(string filePath)
        {
            byte[] fileData;

            //Create a File Stream Object to read the data
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    fileData = reader.ReadBytes((int)fs.Length);
                }
            }

            return fileData;
        }
    }
}
