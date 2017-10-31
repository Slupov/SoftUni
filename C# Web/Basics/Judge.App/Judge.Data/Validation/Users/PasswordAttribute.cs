using System.Linq;

namespace Judge.Data.Validation.Users
{
    public class PasswordAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var password = value as string;
            if (password == null)
                return true;

            return password.Any(char.IsDigit)
                   && password.Any(char.IsUpper)
                   && password.Any(char.IsLower)
                   && password.Length >= 6;
        }
    }
}