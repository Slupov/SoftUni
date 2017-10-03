using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Section2.Users
{
    class UploadFileValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            byte[] file = (byte[])value;

            if (file == null)
            {
                return false;
            }

            if (file.Length > 1024*1024)
            {
                return false;
            }

            return true;
        }
    }
}
