using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Client.Core.Services;
using TeamBuilder.Client.Utilities;
using TeamBuilder.Models;

namespace TeamBuilder.Client.Core.Commands
{
    class ExportTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);

            var teamName = inputArgs[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            Team team = TeamService.GetTeam(teamName);

            TeamService.ExportTeam(team);

            return $"Team {teamName} exported!";
        }
    }
}