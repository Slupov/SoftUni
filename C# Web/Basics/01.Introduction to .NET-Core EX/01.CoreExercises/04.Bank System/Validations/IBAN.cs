using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace _04.Bank_System.Validations
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
