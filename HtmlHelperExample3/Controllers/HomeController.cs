using HtmlHelperExample3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HtmlHelperExample3.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            Company company = new Company();
            return View(company);
        }

        [Route("/")]
        [HttpPost]
        public IActionResult Index(Company company)
        {
            if(company.SelectedDepartment <= 0)
            {
                return Content("You did not select any department");
            }
            else
            {
                return Content("You Selected dept with ID = " + company.SelectedDepartment);
            }
        } 
    }
}
