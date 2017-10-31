using Judge.Data.Validation;
using Judge.Data.Validation.Users;

namespace Judge.App.Models.Users
{
    public class RegisterModel
    {
        [Required]
        [Email]
        public string Email { get; set; }

        public string Name { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}