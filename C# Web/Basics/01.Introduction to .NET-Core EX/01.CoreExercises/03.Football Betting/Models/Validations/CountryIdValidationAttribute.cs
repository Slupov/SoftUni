using System.ComponentModel.DataAnnotations;

namespace _03.Football_Betting.Validations
{
    public class CountryIdValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var stringValue = value.ToString();

            if (stringValue.Length == 3)
                return true;

            return false;
        }
    }
}