using FluentValidation;

namespace FluentApiDemo.Models
{
    //Here Validator will be written
    public class RegistrationValidator : AbstractValidator<RegistrationModel>
    {
        public RegistrationValidator()
        {
            //writing Validations for Model Properties
            //validation rule for Username
            RuleFor(x => x.Username).NotNull()
                .WithMessage("Username is Required.")
                .NotEmpty()
                .Length(5, 30)
                .WithMessage("Username must be between 5 and 30 characters.");

            //validation rule for Email
            RuleFor(x => x.Email).NotEmpty()
                .WithMessage("Email is Required.")
                .EmailAddress().WithMessage("Invalid email format")
                .NotEqual("admin@example.com")
                .WithMessage("This Email address is not allowed.");

            //validation rule for Password
            RuleFor(x => x.Password).NotNull()
                .WithMessage("Password is required.")
                .NotEmpty().WithMessage("Password cannot be empty")
                .Length(6, 50).WithMessage("Password must be between 6 and 50 characters.")
                .Matches("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{2,})$").WithMessage("Password can only contain alphanumeric characters");

            //validation rule for ConfirmPassword
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Confirm Password should match password");

            //Validation Rule for Phone number
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required.")
                .Must(p => p.StartsWith("+") && p.Length > 10)
                .WithMessage("Phone number should start with '+' and be longer than 10 digits.")
                .Unless(r => string.IsNullOrEmpty(r.PhoneNumber));

            //validation rule for Event Date
            //Ensure Event Date is in future
            RuleFor(x => x.EventDate).GreaterThan(DateTime.Now)
                .WithMessage("Event Date must be in the future");

            // For demonstration, let's assume we want events only within the next 30 days
            RuleFor(x => x.EventDate).LessThan(DateTime.Now.AddDays(30))
                .WithMessage("Event Date must be within the next 30 days");

            // Ensure the event date is not on a weekend
            RuleFor(x => x.EventDate).Must(date => date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                .WithMessage("Events on weekends are not allowed");

        }
    }
}
