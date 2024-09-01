using CustomHtmlHelpersExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomHtmlHelpersExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            //hardcode employee details
            Employee employee = new Employee()
            {
                Id = 106724,
                FullName = "Ujjwal Abhishek",
                Designation = "SE",
                Department = "IT",
                Photo = "/Images/MyPhoto.png",
                AlternateText = "Ujjwal Abhishek photo not available"
            };

            //passing employee to view
            return View(employee);
        }
    }
}
