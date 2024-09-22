using Microsoft.AspNetCore.Mvc;
using StateMgmtSessionsAspNetCore.Models;

namespace StateMgmtSessionsAspNetCore.Controllers
{
    public class AccountController : Controller
    {
        //Hardcoded user data for example
        private static readonly User ValidUser = new User
        {
            Username = "admin",
            Password = "password123"
        };

        //Consider it as Dashboard/post login page
        public IActionResult Index()
        {
                // Retrieve username from session
                var username = HttpContext.Session.GetString("Username");

                // Check if username is null or empty
                if (string.IsNullOrEmpty(username))
                {
                    // Redirect to login if not logged in
                    return RedirectToAction("Login");
                }

                // Set the username in ViewBag for use in the view
                ViewBag.Username = username;

                // User is logged-in, so display dashboard
                return View();
        }

        //GET: Login Page View
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login logic to authenticate user and start session
        [HttpPost]
        public IActionResult Login(User user)
        {
            // Check if the model is valid (i.e., if the required fields are filled)
            if (!ModelState.IsValid)
            {
                // If validation fails, return the view with the current model to show errors
                return View(user);
            }

            //Check here that the credential entered by user in View page is same as set in the defined hardcoded Username and password
            if (user.Username == ValidUser.Username && user.Password == ValidUser.Password)
            {
                //store user data in session
                HttpContext.Session.SetString("Username", user.Username);

                //Redirect to Welcome Page after successful login
                return RedirectToAction("Index", "Account");
            }

            //If login fails, show error message
            ViewBag.Message = "Invalid login credentials!";
            return View();
        }

        ////GET: Welcome page after login
        //public IActionResult Welcome()
        //{
        //    //Display welcome message with username

        //    //retrieve username from session
        //    var username = HttpContext.Session.GetString("username");

        //    //check if username is Null or empty
        //    if (string.IsNullOrEmpty(username))
        //    {
        //        // Redirect to login page if session is not set
        //        return RedirectToAction("Login");
        //    }

        //    //pass username to view
        //    ViewBag.Username = username;

        //    return View();
        //}

        // POST: Logout functionality
        [HttpPost]
        public IActionResult Logout()
        {
            //Clear session data
            HttpContext.Session.Clear();

            //Redirect to login page after logout
            return RedirectToAction("LogoutConfirmation");
        }

        // GET: Logout Confirmation Page
        public IActionResult LogoutConfirmation()
        {
            return View();
        }
    }
}
