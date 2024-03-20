using Microsoft.AspNetCore.Mvc;

namespace BankAppUsingController.Controllers
{
    public class BankController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welcome to the Best Bank");
        }

        [Route("/account-details")]
        public IActionResult GetAccountDetails()
        {
            //hard-coded account details as anonymous
            var bankAccount = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };

            //returning bank account details as JSON
            return Json(bankAccount);
        }

        [Route("/account-statement")]
        public IActionResult GetAccountStatement()
        {
            //reutning a dummy file
            return File("/sample.pdf", "application/pdf");
        }

        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult GetCurrentBalance(int? accountNumber)
        {
            //hard-coded account details as anonymous
            var bankAccount = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };

            //checking if the account number is null or not i.e. supplied or not
            if(accountNumber == null)
            {
                return NotFound("Account Number should be supplied");
            }

            //checking if accountNumber is equal to 1001 or not, if not returning error response
            if (accountNumber != 1001)
            {
                return BadRequest("Account Number should be 1001");
            }
            else
            {
                //if condition is false and account number is 1001, returning the Current Balance
                return Content($"<h1>The Current Balance is: {bankAccount.currentBalance}</h1>", "text/html");
            }
        }
    }
}
