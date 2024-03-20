using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.CustomValidators
{
    public class MinmumYearValidatorAttribute : ValidationAttribute
    {
        //To receive Minimum Year Dynamically
        public int MinimumYear { get; set; } = 2000; //If min year is not given, default is this
        public string DefaultErrorMessage { get; set; } = "Year shouldn't be less than {0}";

        //Parameterless Constructor
        public MinmumYearValidatorAttribute()
        {

        }

        //Parameterized Constructor
        public MinmumYearValidatorAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }

        //implementing IsValid()
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //Checking if value is not equal to null
            if(value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= MinimumYear)
                {
                    //return new ValidationResult("Minimum Year allowed is 2000");
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage , MinimumYear));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}
