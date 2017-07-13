using System;
using TeamBuilder.Client.Core.Services;
using TeamBuilder.Client.Utilities;

namespace TeamBuilder.Client.Core.Commands
{
    class ShowEventCommand
    {
        //•	ShowEvent <eventName>
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);
            AuthenticationManager.Authorize();

            var eventName = inputArgs[0];

            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }

            return EventService.ShowDetails(eventName);
        }
    }
}