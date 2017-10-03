using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Client.Core.Services;
using TeamBuilder.Client.Utilities;

namespace TeamBuilder.Client.Core.Commands
{
    class AddTeamToEventCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);
            AuthenticationManager.Authorize();

            string eventName = inputArgs[0];

            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }

            string teamName = inputArgs[1];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            var currentUser = AuthenticationManager.GetCurrentUser();
            var ev = EventService.GetEvent(eventName);

            if (currentUser.Username != ev.Creator.Username)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            var team = TeamService.GetTeam(teamName);

            if (ev.ParticipatingTeams.Contains(team))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.TeamExists);
            }

            return $"Team {teamName} added for {eventName}";
        }
    }
}