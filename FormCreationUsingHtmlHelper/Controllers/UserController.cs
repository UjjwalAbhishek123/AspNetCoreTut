using FormCreationUsingHtmlHelper.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormCreationUsingHtmlHelper.Controllers
{
    public class UserController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("user/register")]
        [HttpGet]
        public IActionResult Register()
        {
            //list of courses and skills
            var model = new UserRegistrationModel
            {
                Courses = new List<string> { "ASP.NET Core", "Azure", "Microservices" },
                Skills = new List<string> { "C#", "SQL", "JavaScript", "Docker", "Kubernetes" },
                HiddenField = Guid.NewGuid()
            };

            return View(model);
        }

        [Route("user/register")]
        [HttpPost]
        public IActionResult Register(UserRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                //if model is valid return success with model
                return View("Success", model);
            }

            //if validation fails, repopulate Course and skill
            model.Courses = new List<string> { "ASP.NET Core", "Azure", "Microservices" };
            model.Skills = new List<string> { "C#", "SQL", "JavaScript", "Docker", "Kubernetes" };

            return View(model);
        }
    }
}
