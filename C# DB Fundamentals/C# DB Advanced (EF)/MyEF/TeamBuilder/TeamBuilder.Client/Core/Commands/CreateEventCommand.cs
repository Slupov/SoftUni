using System;
using System.Globalization;
using TeamBuilder.Client.Core.Services;
using TeamBuilder.Client.Utilities;

namespace TeamBuilder.Client.Core.Commands
{
    class CreateEventCommand
    {
        //•	CreateEvent <name> <description> <startDate> <startTime> <endDate> <endTime>
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(6, inputArgs);

            AuthenticationManager.Authorize();

            var name = inputArgs[0];
            var description = inputArgs[1];

            DateTime startDateTime;

            bool isStartDateTime = DateTime.TryParseExact(
                inputArgs[2] + " " + inputArgs[3],
                Constants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out startDateTime);

            DateTime endDateTime;

            bool isEndDateTime = DateTime.TryParseExact(
                inputArgs[4] + " " + inputArgs[5],
                Constants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out endDateTime);

            if (!isEndDateTime || !isStartDateTime)
            {
                throw new ArgumentException(Constants.ErrorMessages.InvalidDateFormat);
            }

            if (startDateTime > endDateTime)
            {
                throw new ArgumentException(Constants.ErrorMessages.InvalidStartDate);
            }

            EventService.CreateEvent(name, description, startDateTime, endDateTime);

            return $"Event {name} was created successfully!";
        }
    }
}