using Microsoft.AspNetCore.Mvc;
using StronglyTypedViewsExample.Models;
using System.Reflection;

namespace StronglyTypedViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "Asp.Net Core Demo App";

            ViewData["CurrentTime"] = DateTime.Now;
            List<Person> people = new List<Person>()
            {
                new Person() { Name = "John", DateOfBirth = DateTime.Parse("2000-05-06"), PersonGender = Gender.Male},
                new Person() { Name = "Linda", DateOfBirth = DateTime.Parse("2005-01-09"), PersonGender = Gender.Female},
                new Person() { Name = "Susan", DateOfBirth = DateTime.Parse("2008-07-12"), PersonGender = Gender.Other}
            };

            return View("Index", people); //Views/Home/Index.cshtml
        }
    }
}
