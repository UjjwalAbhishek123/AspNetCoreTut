using CodeFirstEFcoreAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodeFirstEFcoreAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //we will use this object to access DbSet(Database Table)
        private readonly StudentDbContext _studentDb;

        public HomeController(StudentDbContext studentDb)
        {
            _studentDb = studentDb;
        }

        public IActionResult Index()
        {
            //Access Students DbSet as List
            var stdData = _studentDb.Students.ToList();

            //pass stdData to view
            return View(stdData);
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
