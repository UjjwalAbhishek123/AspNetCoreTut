using Microsoft.AspNetCore.Mvc;
using IActionResultExample.Models;

namespace IActionResultExample.Controllers
{
    /* 
     * URL Eg -> "http://localhost:5057/book?isloggedin=true&bookid=1 or bookid should be some integer between 1-100 */
    public class Home2Controller : Controller
    {
        [Route("bookstore/{bookid?}/{isloggedin?}")]
        public IActionResult Index([FromQuery] int? bookid, [FromQuery] bool? isloggedin, Book book)
        {
            //check if bookid is not supplied in url i.e like "http://localhost:5057/book?isloggedin=true"
            //if (!Request.Query.ContainsKey("bookid"))
            //{
            //    //Response.StatusCode = 400; //Bad request
            //    //return Content("Book Id is not supplied..");

            //    //return new BadRequestResult();
            //    return BadRequest("Book Id is not supplied..");
            //}

            /* Newly added */
            if (bookid.HasValue == false)
            {
                //Response.StatusCode = 400; //Bad request
                //return Content("Book Id is not supplied..");

                //return new BadRequestResult();
                return BadRequest("Book Id is not supplied..");
            }

            //checking if bookid is supplied but empty like http://localhost:5057/book?isloggedin=true&bookid=
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                //Response.StatusCode = 400;
                //return Content("Book Id can't be null or empty..");

                return BadRequest("Book Id can't be null or empty..");
            }

            //if bookid is supplied above, it should be between 1-1000
            //int bookId = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookid <= 0)
            {
                //Response.StatusCode = 400;
                //return Content("Book Id can't be less than or equal to Zero");

                return BadRequest("Book Id can't be less than or equal to Zero");
            }
            if (bookid > 1000)
            {
                //Response.StatusCode = 400;
                //return Content("Book Id can't be more than or 1000");
                
                return BadRequest("Book Id can't be more than or 1000");
            }

            //checking if isloggedin=true
            //if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            //{
            //    //Response.StatusCode = 401; //Unauthorized
            //    //return Content("User must be authenticated");

            //    return Unauthorized("User must be authenticated");
            //}

            if (isloggedin == false)
            {
                //Response.StatusCode = 401; //Unauthorized
                //return Content("User must be authenticated");

                return Unauthorized("User must be authenticated");
            }


            //if all the conditions doesn't match, means values are correctly suplied. So, return a File as response

            /* To return file as result for the above code UNCOMMENT below code */
            //return File("/sample.pdf","application/pdf");

            /* To demonstrate REDIRECTION for above example try this*/
            //return new RedirectToActionResult("Books", "Store", new { }); //302- FOUND
            //return new RedirectToActionResult("Books", "Store", new { }, true); //301 - Moved Permanently
            return Content($"Book id: {bookid}, Book: {book.BookId}, Author Name: {book.AuthorName}", "text/plain");
        }
    }
}
