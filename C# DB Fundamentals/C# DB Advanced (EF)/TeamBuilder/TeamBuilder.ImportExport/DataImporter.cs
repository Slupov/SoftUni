using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.ImportExport
{
    public class DataImporter
    {
        public static List<User> GetUsersFromXml(string filePath)
        {
            XDocument xmlDoc = XDocument.Load(filePath);

            if (xmlDoc.Root != null)
            {
                var users = xmlDoc.Root.Elements();

                var usersList = new List<User>();

                using (var db = new TeamBuilderContext())
                {
                    foreach (var user in users)
                    {
                        Gender gen;
                        Gender.TryParse(user.Element("gender").Value, out gen);

                        usersList.Add(new User()
                        {
                            Username = user.Element("username").Value,
                            Password = user.Element("password").Value,
                            FirstName = user.Element("first-name").Value,
                            LastName = user.Element("last-name").Value,
                            Age = int.Parse(user.Element("age").Value),
                            Gender = gen
                        });
                    }
                }

                return usersList;
            }
            return new List<User>();
        }

        public static List<Team> GetTeamsFromXml(string filePath)
        {
            XDocument xmlDoc = XDocument.Load(filePath);

            if (xmlDoc.Root != null)
            {
                var teams = xmlDoc.Root.Elements();

                var teamsList = new List<Team>();

                using (var db = new TeamBuilderContext())
                {
                    foreach (var team in teams)
                    {
                        teamsList.Add(new Team()
                        {
                            Name = team.Element("name").Value,
                            Acronym = team.Element("acronym").Value,
                            Description = team.Element("description").Value,
                            CreatorId = int.Parse(team.Element("creator-id").Value)
                        });
                    }
                }
                return teamsList;
            }
            return new List<Team>();
        }
    }
}