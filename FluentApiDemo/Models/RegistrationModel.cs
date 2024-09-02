namespace FluentApiDemo.Models
{
    public class RegistrationModel
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public DateTime EventDate { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
