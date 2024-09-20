using Microsoft.AspNetCore.Mvc;
using StateMgmtCookieExample.Models;
using System.Diagnostics;

namespace StateMgmtCookieExample.Controllers
{
    public class HomeController : Controller
    {
        private const string CookieUserId = "UserId";
        private const string CookieUserName = "UserName";

        //Home Page action
        public IActionResult Index()
        {
            return View();
        }
        
        //Creating/Setting a cookie
        public IActionResult CreateCookie()
        {
            //Set cookie Values
            var userId = "123";
            var userName = "Ujjwal@example.com";

            //Setting up cookie options
            CookieOptions options = new CookieOptions
            {
                Domain = "localhost", //Set domain for cookie
                Path = "/", //Cookie is available within entire applcn
                Expires = DateTime.Now.AddMinutes(5), //cookie will expire in 5 minutes
                HttpOnly = true, // Cannot be accessed by client-side scripts
                Secure = true // Will only be sent over HTTPS
            };

            //Adding UserId to the cookies
            Response.Cookies.Append(CookieUserId, userId, options);

            //Adding UserName to the cookies
            Response.Cookies.Append(CookieUserName, userName, options);

            ViewBag.Message = "Cookies have been set!";
            return View("Index");
        }

        //Retrieving/Reading Cookies
        public IActionResult GetCookie()
        {
            //Retrieve cookies using Request.Cookies
            var userId = Request.Cookies[CookieUserId];
            var userName = Request.Cookies[CookieUserName];

            //check if userId and userName exists or not
            if(userId != null && userName != null)
            {
                ViewBag.Message = $"UserId: {userId}, UserName: {userName}";
                ViewBag.UserId = userId;
                ViewBag.UserName = userName;
            }
            else
            {
                ViewBag.Message = "Cookies are not available!";
            }

            return View("Index");
        }

        public IActionResult DeleteCookie()
        {
            //Deleting cookies 
            Response.Cookies.Delete(CookieUserId);
            Response.Cookies.Delete(CookieUserName);

            ViewBag.Message = "Cookies have been deleted!";

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
