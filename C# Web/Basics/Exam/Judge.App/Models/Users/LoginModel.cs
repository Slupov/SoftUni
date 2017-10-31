using System.ComponentModel.DataAnnotations;
using Judge.App.Infrastructure.Mapping;
using Judge.Data.Models;

namespace Judge.App.Models.Users
{
    public class LoginModel : IMapFrom<User>
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
