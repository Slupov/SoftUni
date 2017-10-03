using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Models.ValidationAttributes
{
    public class Tag : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string stringValue = (string)value;
            Regex hashtagCheck = new Regex("^#([A-Za-z0-6]){1,19}$");

            if (!hashtagCheck.IsMatch(stringValue))
            {
                return false;
            }
            return true;
        }
    }
}
