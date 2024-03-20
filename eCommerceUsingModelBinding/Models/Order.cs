using System.ComponentModel.DataAnnotations;
using eCommerceUsingModelBinding.CustomValidators;

namespace eCommerceUsingModelBinding.Models
{
    public class Order
    {
        [Display(Name="Order Number")]
        public int? OrderNo { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Display(Name = "Order Date")]
        [MinimumDateValidator("2000-01-01", ErrorMessage = "Order Date should be greater than or equal to 2000")]
        //custom Validator
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Display(Name = "Invoice Price")]
        [InvoicePriceValidator] //custom Validator
        [Range(1, double.MaxValue, ErrorMessage = "{0} can't be blank")]
        public double InvoicePrice { get; set; }

        //List of Products
        [ProductsListValidator] //custom Validator
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
