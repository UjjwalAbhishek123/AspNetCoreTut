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

        [Route("person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if(name == null)
            {
                return Content("Person name can't be null");
            }

            List<Person> people = new List<Person>()
            {
                new Person() { Name = "John", DateOfBirth = DateTime.Parse("2000-05-06"), PersonGender = Gender.Male},
                new Person() { Name = "Linda", DateOfBirth = DateTime.Parse("2005-01-09"), PersonGender = Gender.Female},
                new Person() { Name = "Susan", DateOfBirth = DateTime.Parse("2008-07-12"), PersonGender = Gender.Other}
            };

            //fetching the corresponding person object based on person Name using LINQ
            //whenever Person Name matches with the name argument, then fetch that
            Person? matchingPerson = people.Where(temp => temp.Name == name).FirstOrDefault();

            return View(matchingPerson); //Views/Home/Details.cshtml

        }
    }
}
