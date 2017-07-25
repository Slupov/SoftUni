using System;
using TeamBuilder.Client.Core.Services;
using TeamBuilder.Client.Utilities;

namespace TeamBuilder.Client.Core.Commands
{
    class DeclineInviteCommand
    {
        //•	DeclineInvite <teamName>
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);
            AuthenticationManager.Authorize();

            string teamName = inputArgs[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsInviteExisting(teamName,
                AuthenticationManager.GetCurrentUser()))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InviteNotFound, teamName));
            }

            InviteService.DeclineInvite(teamName);

            return $"User {AuthenticationManager.GetCurrentUser().Username} declined {teamName}'s invitation!";
        }
    }
}