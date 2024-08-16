using Microsoft.AspNetCore.Mvc;
using AutofacDependencyInjectionServiceContracts;
using Autofac;

namespace AutofacDependencyInjectionExample.Controllers
{
    public class HomeController : Controller
    {
        //create a reference variable for CitiesService.cs
        //making it readonly avoids the unwanted assignment of unwanted values into the field
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;

        //readonly field for creating scopes
        private readonly ILifetimeScope _lifetimeScope;


        //constructor for object creation of ICitiesService class, which will be done by IoC Container automatically
        //Eg. of Constructor Injection
        public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3, ILifetimeScope lifetimeScope)
        {
            //create object of CitiesService class
            //here we will use Inversion of Control for object creation using Dependency Injection
            _citiesService1 = citiesService1;
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
            _lifetimeScope = lifetimeScope;
            
        }

        [Route("/")]
        public IActionResult Index()
        {
            //Calling Service Method
            List<string> cities = _citiesService1.GetCities();

            ViewBag.Instance_Id_CitiesService_1 = _citiesService1.ServiceInstanceId;
            ViewBag.Instance_Id_CitiesService_2 = _citiesService2.ServiceInstanceId;
            ViewBag.Instance_Id_CitiesService_3 = _citiesService3.ServiceInstanceId;

            //demonstrating Child Scope for AUTOFAC
            //creating new scope in using() through IServiceScope
            using(ILifetimeScope scope = _lifetimeScope.BeginLifetimeScope())
            {
                //Inject CitiesService in CHILD Scope
                ICitiesService citiesService = scope.Resolve<ICitiesService>();

                ViewBag.Instance_Id_CitiesService_InChildScope = citiesService.ServiceInstanceId;
            }//end of scope, it calls CitiesService.Dispose() automatically

            //for each citiesService instance, we have an independent serviceInstanceId
            return View(cities);
        }
    }
}
