using Microsoft.AspNetCore.Mvc;
using DependencyInjection2ServiceContracts;

namespace DependencyInjection2Example.Controllers
{
    public class HomeController : Controller
    {
        //create a reference variable for CitiesService.cs
        //making it readonly avoids the unwanted assignment of unwanted values into the field
        //private readonly ICitiesService _citiesService;

        ////constructor for object creation of ICitiesService class, which will be done by IoC Container automatically
        
        ////Eg. of Constructor Injection
        
        //public HomeController(ICitiesService citiesService)
        //{
        //    //create object of CitiesService class
        //    //here we will use Inversion of Control for object creation using Dependency Injection
        //    _citiesService = citiesService;
        //}


        //Method Injection
        [Route("/")]
        public IActionResult Index([FromServices]ICitiesService _citiesService)
        {
            
            //Calling Service Method
            List<string> cities = _citiesService.GetCities();

            return View(cities);
        }
    }
}
