using Microsoft.AspNetCore.Mvc;
using ViewComponentWithViewDataExample.Models;

namespace ViewComponentWithViewDataExample.ViewComponents
{
    public class NewGridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //create object of PersonGridModel
            PersonGridModel model = new PersonGridModel()
            {
                GridTitle = "PersonList",
                Persons = new List<Person>()
                {
                    new Person()
                    {
                        PersonName = "John", jobTitle = "Manager"
                    },
                    new Person()
                    {
                        PersonName = "Jones", jobTitle = "Asst Manager"
                    },
                    new Person()
                    {
                        PersonName = "William", jobTitle = "Clerk"
                    }
                }
            };

            //entire model should be sent through ViewData object to partial View
            ViewData["NewGrid"] = model;

            //invoked as Partial View & PartialView name is not Default
            return View("Sample");

            //When Default.cshtml was name -> return View();
            //invoked as Partial View
            //Location is -> Views/Shared/Components/Grid/Default.cshtml
        }
    }
}
