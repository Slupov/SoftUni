using System;
using TeamBuilder.Client.Core.Services;
using TeamBuilder.Client.Utilities;

namespace TeamBuilder.Client.Core.Commands
{
    class InviteToTeamCommand
    {
        //InviteToTeam <teamName> <username>
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);
            AuthenticationManager.Authorize();

            string teamName = inputArgs[0];
            string username = inputArgs[1];

            if (!(CommandHelper.IsTeamExisting(teamName) && CommandHelper.IsUserExisting(username)))
            {
                throw new ArgumentException(Constants.ErrorMessages.TeamOrUserNotExist);
            }

            if (InviteService.IsInvitePending(teamName, username))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.InviteIsAlreadySent);
            }

            if (!TeamService.IsCreatorOrPartOfTeam(teamName))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            InviteService.SendInvite(teamName, username);

            return $"Team {teamName} invited {username}!";
        }
    }
}