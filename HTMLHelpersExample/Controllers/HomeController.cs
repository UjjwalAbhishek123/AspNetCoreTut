using HTMLHelpersExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace HTMLHelpersExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            //for demonstrating Textarea
            Employee emp = new Employee()
            {
                EmpId = 1,
                Address = "Gandhi Chowk, Mohan Garden, 110059, New Delhi, India"
            };
            return View(emp);
        }
    }
}
