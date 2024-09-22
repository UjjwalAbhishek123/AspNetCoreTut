using System.ComponentModel.DataAnnotations;

namespace StateMgmtSessionsAspNetCore.Models
{
    public class User
    {
        //properties for user
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
