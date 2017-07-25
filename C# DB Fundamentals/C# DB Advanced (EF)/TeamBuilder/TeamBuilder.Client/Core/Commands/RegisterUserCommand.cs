using System;
using System.Linq;
using TeamBuilder.Client.Core.Services;
using TeamBuilder.Client.Utilities;
using TeamBuilder.Models;

namespace TeamBuilder.Client.Core.Commands
{
    public class RegisterUserCommand
    {
        //RegisterUser <username> <passwd> <rpt-passwd> <firstName> <lastName> <age> <gender>
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(7, inputArgs);

            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }
            

            string username = inputArgs[0];

            //validate username
            if (username.Length < Constants.MinUsernameLength || username.Length > Constants.MaxUsernameLength)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UsernameNotValid, username));
            }

            string password = inputArgs[1];

            //validate password
            if (!password.Any(char.IsDigit) || !password.Any(char.IsUpper))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordNotValid, password));
            }

            string repeatPassword = inputArgs[2];

            //validate passwords
            if (password != repeatPassword)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.PasswordDoesNotMatch);
            }

            //validation for firstName and lastName is optional
            string firstName = inputArgs[3];
            string lastName = inputArgs[4];

            int age;
            bool isNumber = int.TryParse(inputArgs[5], out age);

            //validate age
            if (!isNumber || age <= 0)
            {
                throw new ArgumentException(Constants.ErrorMessages.AgeNotValid);
            }

            Gender gender;
            bool isGenderValid = Enum.TryParse(inputArgs[6], out gender);

            //validate gender
            if (!isGenderValid)
            {
                throw new ArgumentException(Constants.ErrorMessages.GenderNotValid);
            }

            //check if username is taken
            if (CommandHelper.IsUserExisting(username))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.UsernameIsTaken, username));
            }

            UserService.Register(username, password, firstName, lastName, age, gender);

            return $"Username {username} was registered successfully!";
        }
    }
}