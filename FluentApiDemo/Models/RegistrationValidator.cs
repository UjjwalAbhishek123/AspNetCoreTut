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
            RuleFor(x => x.Username).NotEmpty()
                .WithMessage("Username is Required.")
                .Length(5, 30)
                .WithMessage("Username must be between 5 and 30 characters.");

            //validation rule for Email
            RuleFor(x => x.Email).NotEmpty()
                .WithMessage("Email is Required.")
                .EmailAddress()
                .WithMessage("Valid Email address is Required.");

            //validation rule for Password
            RuleFor(x => x.Password).NotEmpty()
                .WithMessage("Password is required.")
                .Length(6, 100)
                .WithMessage("Password must be between 6 and 100 characters.");
        }
    }
}
