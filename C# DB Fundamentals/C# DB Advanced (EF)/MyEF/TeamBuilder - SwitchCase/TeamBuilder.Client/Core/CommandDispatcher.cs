using System;
using System.Linq;
using TeamBuilder.Client.Core.Commands;
using TeamBuilder.Client.Core.Commands.Event;
using TeamBuilder.Client.Core.Commands.Invite;
using TeamBuilder.Client.Core.Commands.Team;
using TeamBuilder.Client.Core.Commands.User;

namespace TeamBuilder.Client.Core
{
    public class CommandDispatcher
    {
        public string Dispatch(string input)
        {
            string result = string.Empty;

            string[] inputArgs = input.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);

            string commandName = inputArgs.Length > 0 ? inputArgs[0] : string.Empty;

            inputArgs = inputArgs.Skip(1).ToArray();

            switch (commandName)
            {
                case "RegisterUser":
                    RegisterUserCommand registerCmd = new RegisterUserCommand();
                    result = registerCmd.Execute(inputArgs);
                    break;
                case "Login":
                    LoginCommand loginCmd = new LoginCommand();
                    result = loginCmd.Execute(inputArgs);
                    break;
                case "Logout":
                    LogoutCommand logoutCmd = new LogoutCommand();
                    result = logoutCmd.Execute(inputArgs);
                    break;
                case "DeleteUser":
                    DeleteUserCommand deleteUserCmd = new DeleteUserCommand();
                    result = deleteUserCmd.Execute(inputArgs);
                    break;
                //try to make description as a one argument
                case "CreateEvent":
                    CreateEventCommand createEventCmd = new CreateEventCommand();
                    result = createEventCmd.Execute(inputArgs);
                    break;
                case "CreateTeam":
                    CreateTeamCommand createTeamCmd = new CreateTeamCommand();
                    result = createTeamCmd.Execute(inputArgs);
                    break;
                case "InviteToTeam":
                    InviteToTeamCommand inviteToTeamCmd = new InviteToTeamCommand();
                    result = inviteToTeamCmd.Execute(inputArgs);
                    break;
                case "AcceptInvite":
                    AcceptInviteCommand acceptInviteCmd = new AcceptInviteCommand();
                    result = acceptInviteCmd.Execute(inputArgs);
                    break;
                case "DeclineInvite":
                    DeclineInviteCommand declineInviteCmd = new DeclineInviteCommand();
                    result = declineInviteCmd.Execute(inputArgs);
                    break;
                case "KickMember":
                    KickMemberCommand kickMemberCmd = new KickMemberCommand();
                    result = kickMemberCmd.Execute(inputArgs);
                    break;
                case "Disband":
                    DisbandCommand disbandCmd = new DisbandCommand();
                    result = disbandCmd.Execute(inputArgs);
                    break;
//                case "AddTeamTo":
//                    AddTeamToEventCommand addTeamToCmd = new AddTeamToEventCommand();
//                    result = addTeamToCmd.Execute(inputArgs);
//                    break;
                case "ShowEvent":
                    ShowEventCommand showEventCmd = new ShowEventCommand();
                    result = showEventCmd.Execute(inputArgs);
                    break;
                case "ShowTeam":
                    ShowTeamCommand showTeamCmd = new ShowTeamCommand();
                    result = showTeamCmd.Execute(inputArgs);
                    break;
                case "Exit":
                    ExitCommand exitCmd = new ExitCommand();
                    result = exitCmd.Execute(inputArgs);
                    break;
                default:
                    result = $"Command {commandName} not supported!";
                    throw new NotSupportedException(result);
            }
            return result;
        }
    }
}