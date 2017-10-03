using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section2.Hospital
{
    class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string Address { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }

        [DataType(DataType.Upload)]
        private byte[] picture { get; set; }

        [Required]
        public bool IsInsured { get; set; }

        public byte[] Picture
        {
            get { return this.picture; }
            set
            {
                if (value.Length > 1024*1024)
                {
                    throw new Exception("Profile picture is bigger than 1 MB!");
                }
                else
                {
                    this.picture = value;
                }
            }
        }
    }
}