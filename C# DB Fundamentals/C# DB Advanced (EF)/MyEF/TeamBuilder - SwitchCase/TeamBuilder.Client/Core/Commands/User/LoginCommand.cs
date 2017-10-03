using System;
using TeamBuilder.Client.Core.Services;
using TeamBuilder.Client.Utilities;

namespace TeamBuilder.Client.Core.Commands.User
{
    class LoginCommand
    {
        //Login <username> <password>
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);

            string username = inputArgs[0];
            string password = inputArgs[1];

            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }

            Models.User user = UserService.GetUserByCredentilas(username, password);

            if (user == null)
            {
                throw new ArgumentException(Constants.ErrorMessages.UserOrPasswordIsInvalid);
            }

            AuthenticationManager.Login(user);

            return $"User {username} successfully logged in!";
        }
    }
}