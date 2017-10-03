using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _03.Football_Betting.Validations
{
    public class PredictionValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var allowedValues = new HashSet<string>
            {
                "Home Team Win",
                "Draw Game",
                "Away Team Win"
            };

            if (allowedValues.Contains(value.ToString()))
                return true;

            return false;
        }
    }
}