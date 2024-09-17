using FileHandlingSaveUploadedToDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FileHandlingSaveUploadedToDB.Controllers
{
    public class HomeController : Controller
    {
        //Demo for Saving Uploaded files to Database

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
