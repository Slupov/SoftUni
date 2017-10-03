using System;
using System.ComponentModel.DataAnnotations;
using Section2.Users;

namespace Section2
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4,
            ErrorMessage = "Username must be between 4 and 30 characters")]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6,
            ErrorMessage = "Password must be between 6 and 50 characters")]
        [PasswordValidation]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [DataType(DataType.Upload)]
        //[UploadFileValidation]
        public byte[] ProfilePicture { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegisteredOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}
