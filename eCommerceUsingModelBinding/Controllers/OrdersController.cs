using eCommerceUsingModelBinding.Models;
using Microsoft.AspNetCore.Mvc;
using System;


namespace eCommerceUsingModelBinding.Controllers
{
    public class OrdersController : Controller
    {
        //When request is received at path "/order"
        [Route("/order")]

        //bind only the desired properties of Order class, i.e. 'OrderDate', "InvoicePrice" and "Products"
        public IActionResult Index([Bind(nameof(Order.OrderDate), nameof(Order.InvoicePrice), nameof(Order.Products))] Order order)
        {
            //if there are any validation errors (as per data annotations)
            if (!ModelState.IsValid)
            {
                string messages = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));

                // send HTTP 400 response with error messages
                return BadRequest(messages);
            }

            //If no validation errors, the application should generate a new order number(random number between 1 and 99999) and sent it as response.
            Random random = new Random();
            int randomOrderNumber = random.Next(1, 99999);

            //Return JsonResult(that includes newly generated order number) with HTTP 200 status code, if no validation errors.
            return Json(new { orderNumber = randomOrderNumber });
        }
    }
}
