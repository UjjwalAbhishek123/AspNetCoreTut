using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidationsExample.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.Models
{
    public class Person : IValidatableObject
    {
        //Here we will apply validations on properties
        [Required(ErrorMessage = "{0} can't be null or empty")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = " {0} should be between {2} and {1} characters long")]
        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should contain only alphabets, space & dot(.)")]
        public string? PersonName { get; set; }

        [EmailAddress(ErrorMessage = "{0} should be a proper email address")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "{0} should contain 10 digits")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        public string? Password{ get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match")]
        [Display(Name = "Re-enter Password")]
        public string? ConfirmPassword{ get; set; }

        [Range(0,999.99, ErrorMessage = "{0} should be between {1} & {2}")]
        public double? Price { get; set; }

        //It is an example of Custom Validator Attribute
        [MinmumYearValidator(2005)]
        //[BindNever]
        public DateTime? DateOfBirth { get; set; }
        public DateTime? FromDate { get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "'From Date' should be older than or equal to 'To Date'")]
        public DateTime? ToDate { get; set; }

        public int? Age { get; set; }

        //For Demonstration of COLLECTION BINDING, eg.-> want to collect multiple Hashtags
        public List<string?> Tags { get; set; } = new List<string?>();

        public override string ToString()
        {
            return $"Person Object - Person Name: {PersonName}, Email: {Email}, Phone: {Phone}, Password: {Password}, Confirm Password: {ConfirmPassword}, Price: {Price}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //We want either DateOfBirth or Age to be null,but not both at same time
            if(DateOfBirth.HasValue==false && Age.HasValue == false)
            {
                yield return new ValidationResult("Either of DoB or Age should be supplied", new[] { nameof(Age) });
            }
        }
    }
}
