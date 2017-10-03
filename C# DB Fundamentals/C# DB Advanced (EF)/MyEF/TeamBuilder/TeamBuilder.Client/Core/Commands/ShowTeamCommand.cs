using System;
using TeamBuilder.Client.Core.Services;
using TeamBuilder.Client.Utilities;

namespace TeamBuilder.Client.Core.Commands
{
    class ShowTeamCommand
    {
//        •	ShowTeam<teamName>
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);
            AuthenticationManager.Authorize();

            var teamName = inputArgs[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound,teamName));
            }

            return TeamService.ShowDetails(teamName);

        }
    }
}
