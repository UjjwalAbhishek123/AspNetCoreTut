using Microsoft.AspNetCore.Mvc;
using PartialViewResultExample.Models;

namespace PartialViewResultExample.Controllers
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

        [Route("programming-languages")]
        public IActionResult ProgrammingLanguages()
        {
            //We will invoke this action method using JS code asynchronously
            //creating object of ListModel Class
            ListModel listModel = new ListModel()
            {
                ListTitle = "Programming Languages",
                ListItems = new List<string>()
                {
                    "C#", "Java", "Python"
                }
            };
            //return new PartialViewResult() { ViewName = "_ListPartialView", Model = listModel };
            return PartialView("_ListPartialView", listModel);
        }
    }
}
