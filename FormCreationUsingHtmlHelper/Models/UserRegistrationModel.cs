using System.ComponentModel.DataAnnotations;

namespace FormCreationUsingHtmlHelper.Models
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string? Address {  get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; set; }
        public bool RememberMe { get; set; }

        [Required(ErrorMessage = "Please select a course")]
        public string? SelectedCourse { get; set; }
        public List<string>? Courses { get; set; }

        [Required(ErrorMessage = "Please select one or more skills")]
        public List<string>? SelectedSkills { get; set; }
        public List<string>? Skills { get; set; }

        public Guid HiddenField { get; set; }
    }
}
