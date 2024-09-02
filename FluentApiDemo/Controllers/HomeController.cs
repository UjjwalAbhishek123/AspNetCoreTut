using FluentApiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FluentApiDemo.Controllers
{
    public class HomeController : Controller
    {
        //Validating registration model within controller

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                //validation failed, return to the form with errors
                return View(model);
            }
            //Handle successful validation logic
            return RedirectToAction("Success");
        }
        public string Success()
        {
            return "Registration Successful";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
