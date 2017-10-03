using System;
using System.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.Client.Core.Services
{
    class EventService
    {
        public static void CreateEvent(string eventName, string description, DateTime startDate, DateTime endDate)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                db.Events.Add(new Event()
                {
                    Name = eventName,
                    Description = description,
                    StartDate = startDate,
                    EndDate = endDate,
                    CreatorId = AuthenticationManager.GetCurrentUser().Id
                });
                db.SaveChanges();
            }
        }

        public static string ShowDetails(string eventName)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                var ev = db.Events.FirstOrDefault(t => t.Name == eventName);
                string result = $"{eventName} {ev.StartDate} {ev.EndDate}";

                if (ev.Description != null)
                {
                    result += $"\n{ev.Description}";
                }

                if (ev.ParticipatingTeams.Any())
                {
                    result += "\nTeams:";
                }

                foreach (var team in ev.ParticipatingTeams)
                {
                    result += $"\n--{team.Name}";
                }

                return result;
            }
        }

        public static Event GetEvent(string eventName)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                return db.Events
                    .OrderByDescending(e => e.StartDate)
                    .FirstOrDefault(e => e.Name == eventName);
            }
        }
    }
}