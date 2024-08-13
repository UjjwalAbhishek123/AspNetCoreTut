using Microsoft.AspNetCore.Mvc;

namespace EnvirenmentExample.Controllers
{
    public class HomeController : Controller
    {

        //We want to access current working Environment programmatically in Controller, we can INJECT a predefined service "IWebHostEnvironment" in the constructor and access all the things
        private readonly IWebHostEnvironment _webHostEnvironment;

        //Injecting Service in Constructor
        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.CurrentEnvironment = _webHostEnvironment.EnvironmentName;
            return View();
        }
    }
}
