using TeamBuilder.Client.Utilities;

namespace TeamBuilder.Client.Core.Commands.User
{
    class LogoutCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(0, inputArgs);
            AuthenticationManager.Authorize();
            Models.User currentUser = AuthenticationManager.GetCurrentUser();

            AuthenticationManager.Logout();

            return $"User {currentUser.Username} successfully logged out!";
        }
    }
}