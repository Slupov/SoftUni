using TeamBuilder.Client.Utilities;

namespace TeamBuilder.Client.Core.Commands.User
{
    class DeleteUserCommand
    {
        //DeleteUser
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(0, inputArgs);

            return "todo";

        }
    }
}