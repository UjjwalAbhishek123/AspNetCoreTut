using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

namespace ControllersExample.Controllers
{
    public class HomeController  : Controller
    {
        //the route attribute will match the URL entered and then call the action method
        [Route("home")]
        [Route("/")] //it will be for empty url
        public ContentResult Index()
        {
            return new ContentResult()
            {
                Content = "Hello from Index",
                ContentType = "text/plain"
            };
        }

        //creating other Action Methods
        [Route("about")]
        public ContentResult About()
        {
            return Content("Hello from About Page", "text/plain");
            //it will be like Content(Content, ContentType)
            
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                //generate new Guid
                Id = Guid.NewGuid(),
                FirstName = "James",
                LastName = "Smith",
                Age = 25
            };
            return new JsonResult(person);
            //return "{ \"key\" : \"value\" }";
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public ContentResult Contact()
        {
            return Content("<h1>Hello from Contact Page</h1>", "text/html");
        }

        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            return new VirtualFileResult("/sample.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            return new PhysicalFileResult(@"F:\\aspNetCore\\MyFirstApp\\sample.pdf", "application/pdf");
        }

        [Route("file-download3")]
        public FileContentResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"F:\aspNetCore\MyFirstApp\sample.pdf");
            return new FileContentResult(bytes, "application/pdf");
        }
    }
}
