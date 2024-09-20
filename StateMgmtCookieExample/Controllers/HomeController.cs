using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using StateMgmtCookieExample.Models;
using System.Diagnostics;

namespace StateMgmtCookieExample.Controllers
{
    public class HomeController : Controller
    {
        // IDataProtector instance for encryption/decryption
        private readonly IDataProtector _protector;

        private const string CookieUserId = "UserId";
        private const string CookieUserName = "UserName";

        // Inject IDataProtectionProvider
        public HomeController(IDataProtectionProvider provider)
        {
            //create PROTECTOR to encrypt/decrypt data
            _protector = provider.CreateProtector("CookieProtection");
        }

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

        //creating Encrypt cookie
        public IActionResult CreateEncryptCookie()
        {
            try
            {
                //Set cookie Values
                var userId = "123";
                var userName = "Ujjwal@example.com";

                //Encrypt data
                var encryptedUserId = _protector.Protect(userId);
                var encryptedUserName = _protector.Protect(userName);

                //Setting up cookie options
                CookieOptions options = new CookieOptions
                {
                    Domain = "localhost", //Set domain for cookie
                    Path = "/", //Cookie is available within entire applcn
                    Expires = DateTime.Now.AddMinutes(5), //cookie will expire in 5 minutes
                    HttpOnly = true, // Cannot be accessed by client-side scripts
                    Secure = true // Will only be sent over HTTPS
                };

                // Add encryptedUserId data to cookies
                Response.Cookies.Append(CookieUserId, encryptedUserId, options);

                //Adding encryptedUserName to the cookies
                Response.Cookies.Append(CookieUserName, encryptedUserName, options);

                ViewBag.Message = "Encrypted Cookies have been set!";
                return View("Index");
            }

            catch (Exception ex)
            {
                //Handle error during encryption
                ViewBag.Message = $"Error creating cookies: {ex.Message}";
            }

            return View("Index");
        }

        public IActionResult GetEncryptedCookie()
        {
            try
            {
                //retrieving encrypted cookies
                var encryptedUserId = Request.Cookies[CookieUserId];
                var encryptedUserName = Request.Cookies[CookieUserName];

                //check if cookie exists
                if(encryptedUserId != null && encryptedUserName != null)
                {
                    //DECRYPT cookie values
                    var userId = _protector.Unprotect(encryptedUserId);
                    var userName = _protector.Unprotect(encryptedUserName);

                    ViewBag.Message = $"Decrypted UserId: {userId}, Decrypted User: {userName}";
                }
                else
                {
                    ViewBag.Message = "No cookies found!";
                }
            }
            catch (Exception ex)
            {
                //Handle Decryption errors
                ViewBag.Message = $"Error retrieving cookies: {ex.Message}";
            }

            return View("Index");
        }

        public IActionResult DeleteEncryptedCookie()
        {
            try
            {
                Response.Cookies.Delete(CookieUserId);
                Response.Cookies.Delete(CookieUserName);

                ViewBag.Message = "Cookies have been deleted!";
            }
            catch (Exception ex)
            {
                // Handle deletion error
                ViewBag.Message = $"Error deleting cookies: {ex.Message}";
            }

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
