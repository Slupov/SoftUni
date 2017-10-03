using System;
using TeamBuilder.Client.Core.Services;
using TeamBuilder.Client.Utilities;

namespace TeamBuilder.Client.Core.Commands
{
    class CreateTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            //CreateTeam <name> <acronym> <description>
            AuthenticationManager.Authorize();

            if (inputArgs.Length != 2 && inputArgs.Length != 3)
            {
                throw new ArgumentOutOfRangeException(nameof(inputArgs));
            }

            string teamName = inputArgs[0];

            if (teamName.Length > 25)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InvalidTeamName, teamName));
            }

            if (CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamExists, teamName));
            }

            string acronym = inputArgs[1];

            if (acronym.Length != 3)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InvalidAcronym, acronym));
            }

            string description = inputArgs.Length == 3 ? inputArgs[2] : null;

            TeamService.AddTeam(teamName, acronym, description);



            return $"Team {teamName} successfully created!";
        }
    }
}