using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationsExample.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        //creating constructor to receive FromDate property
        public string OtherPropertyName { get; set; }
        public DateRangeValidatorAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                //getting value of to_Date
                DateTime to_Date = Convert.ToDateTime(value);


                //getting value of FromDate
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);
                
                if(otherProperty != null)
                {
                    DateTime from_Date = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

                    if (from_Date > to_Date)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { OtherPropertyName, validationContext.MemberName });
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                return null;
            }
            return null;
        }
    }
}
