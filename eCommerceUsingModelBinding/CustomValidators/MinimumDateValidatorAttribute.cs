using System.ComponentModel.DataAnnotations;

namespace eCommerceUsingModelBinding.CustomValidators
{
    public class MinimumDateValidatorAttribute : ValidationAttribute
    {
        //it will show default error message
        public string DefaulErrorMessage { get; set; } = "Order date should be greater than or equal to {0}";

        //it will capture Date
        public DateTime MinimumDate { get; set; }

        //Constructor to receive date
        public MinimumDateValidatorAttribute(string minimumDateString)
        {
            MinimumDate = Convert.ToDateTime(minimumDateString);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //checking if value of OrderDate is not null
            if (value != null)
            {
                //Get the value of OrderDate
                DateTime orderDate = (DateTime)value;

                //checking if the value of "OrderDate" property is greater than minimumDate
                if (orderDate > MinimumDate)
                {
                    //return Validation Error
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaulErrorMessage, MinimumDate.ToString("yyyy-MM-dd")), new string[] { nameof(validationContext.MemberName) });
                }

                //No validation error
                return ValidationResult.Success;
            }
            return null;
        }
    }
}
