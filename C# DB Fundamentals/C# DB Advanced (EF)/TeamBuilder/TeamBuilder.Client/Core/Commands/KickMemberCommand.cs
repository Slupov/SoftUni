using System;
using TeamBuilder.Client.Core.Services;
using TeamBuilder.Client.Utilities;

namespace TeamBuilder.Client.Core.Commands
{
    class KickMemberCommand
    {
        //•	KickMember <teamName> <username>
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);
            AuthenticationManager.Authorize();

            var currentUser = AuthenticationManager.GetCurrentUser();
            var teamName = inputArgs[0];
            var username = inputArgs[1];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsUserExisting(username))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UserNotFound, username));
            }


            if (CommandHelper.IsUserCreatorOfTeam(teamName, username))
            {
                throw new ArgumentException(Constants.ErrorMessages.NotAllowed);
            }

            //when trying to kick themselves
            if (currentUser.Username == username)
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.CommandNotAllowed,
                    "DisbandTeam"));
            }

            TeamService.KickMemberFromTeam(teamName, username);

            return $"User {username} has been kicked from {teamName} by {currentUser.Username}";
        }
    }
}