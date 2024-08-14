using DepnInjcService1;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionService1Example.Controllers
{
    public class HomeController : Controller
    {
        //create a reference variable for CitiesService.cs
        //making it readonly avoids the unwanted assignment of unwanted values into the field
        private readonly CitiesService _citiesService;

        //constructor for object creation of CitiesService class
        public HomeController()
        {
            //create object of CitiesService class
            _citiesService = new CitiesService(); 
        }

        [Route("/")]
        public IActionResult Index()
        {
            //Calling Service Method
            List<string> cities = _citiesService.GetCities();

            return View(cities);
        }
    }
}
