using Microsoft.AspNetCore.Mvc;
using ViewComponentResultExample.Models;

namespace ViewComponentResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("friends-list")]
        public IActionResult LoadFriendsList()
        {
            PersonGridModel personGridModel = new PersonGridModel()
            {
                GridTitle = "Friends",
                Persons = new List<Person>()
    {
        new Person() { PersonName = "Mia", jobTitle = "Developer" },
        new Person() { PersonName = "Emma", jobTitle = "UI Designer" },
        new Person() { PersonName = "Avva", jobTitle = "QA" }
    }
            };

            return ViewComponent("Grid", new { grid = personGridModel });
        }
    }
}