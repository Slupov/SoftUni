using System;
using System.Collections.Generic;
using System.IO;
using TeamBuilder.Client.Core.Services;
using TeamBuilder.Client.Utilities;
using TeamBuilder.ImportExport;

namespace TeamBuilder.Client.Core.Commands
{
    class ImportTeamsCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);

            string filePath = inputArgs[0];

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format(Constants.ErrorMessages.FileNotFound, filePath));
            }

            List<Models.Team> teams;
            try
            {
                teams = DataImporter.GetTeamsFromXml(filePath);
            }
            catch (Exception e)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidXmlFormat);
            }

            TeamService.AddTeams(teams);
            return $"You have successfully imported {teams.Count} teams!";
        }
    }
}