using System;
using TeamBuilder.Client.Core.Services;
using TeamBuilder.Client.Utilities;
using TeamBuilder.Models;

namespace TeamBuilder.Client.Core.Commands.Team
{
    class DisbandCommand
    {
        //•	Disband <teamName>
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1,inputArgs);
            AuthenticationManager.Authorize();

            string teamName = inputArgs[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.TeamNotFound,teamName));
            }

            Models.User currentUser = AuthenticationManager.GetCurrentUser();

            if (!CommandHelper.IsUserCreatorOfTeam(teamName,currentUser))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            TeamService.DisbandTeam(teamName);
            return $"{teamName} has been disbanded!";
        }
    }
}
