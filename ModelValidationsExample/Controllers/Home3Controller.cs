using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.CustomModelBinders;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers
{
    public class Home3Controller : Controller
    {
        [Route("register")]
        //[Bind(nameof(Person.PersonName), nameof(Person.Email), nameof(Person.Password), nameof(Person.ConfirmPassword))]
        //[ModelBinder(BinderType = typeof(PersonModelBinder))]
        public IActionResult Index(Person person)
        {
            //Demonstrating ModelState Property
            //Return "True" if no error, else "False"
            if (!ModelState.IsValid)
            {
                //List<string> errorsList = new List<string>();

                //Iterating through each values in ModelState
                //foreach(var value in ModelState.Values)
                //{
                //    //getting errors from Error property of each values in ModelState.Values
                //    foreach(var error in value.Errors)
                //    {
                //        errorsList.Add(error.ErrorMessage);
                //    }
                //}

                //Above loop can be simplified using LINQ Query
                //First LINQ Query will work as Outer Loop and next as Inner Loop
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));


                //joining all the list of errors line by line, and it forms a single string
                //string errors = string.Join("\n", errorsList);
                return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}
