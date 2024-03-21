using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        //initializing hard-coded weather data of 3 cities
        List<CityWeather> cities = new List<CityWeather>()
        {
            new CityWeather(){ CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33 },
            new CityWeather(){ CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60 },
            new CityWeather(){ CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82 }
        };

        //receive a HTTP GET request at path "/", return view with weather detail of all cities, HTTP status code 200.
        [Route("/")]
        public IActionResult Index()
        {
            //send cities collection to "Views/Weather/Index" view
            return View(cities);
        }

        [Route("/weather/{cityCode?}")]
        public IActionResult City(string? cityCode)
        {
            //if city code is not supplied in route parameter
            if (string.IsNullOrEmpty(cityCode))
            {
                //send null as model object to "Views/Weather/Index" view
                return View();
            }

            //else, if we get matching city object based on city code
            CityWeather? matchingCity = cities.Where(temp => temp.CityUniqueCode == cityCode).FirstOrDefault();

            //send matching city object to "Views/Weather/Index" view
            return View(matchingCity);
        }
    }
}
