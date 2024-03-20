using Microsoft.AspNetCore.Mvc;
using StronglyTypedViewsMultipleModels.Models;
using System.Reflection;

namespace StronglyTypedViewsMultipleModels.Controllers
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
            if (name == null)
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

        [Route("person-with-product")]
        public IActionResult PersonWithProduct()
        {
            //creating object of both Person and Product class
            Person person = new Person()
            {
                Name = "Sara", PersonGender = Gender.Female, DateOfBirth = Convert.ToDateTime("2004-07-01")
            };

            Product product = new Product()
            {
                ProductId = 1, ProductName = "Air Conditioner"
            };

            //to pass 2 individual objects of different types at same time to view
            //create object of wrapper model class
            PersonAndProductWrapperModel personAndProductWrapperModel = new PersonAndProductWrapperModel()
            {
                //productData contains reference of Product type of objects, and PersonData contains reference of Person type of objects
                PersonData = person, ProductData = product
            };
            return View(personAndProductWrapperModel);
        }
    }
}
