using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models.ValidationAttributes
{
    public class IBAN : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string stringValue = (string)value;
            Regex IBANCheck = new Regex("^([A-Za-z0-9]){10}$");

            if (!IBANCheck.IsMatch(stringValue))
            {
                return false;
            }
            return true;
        }
    }
}
