using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using TeamBuilder.Models;
using TeamBuilder.Client.Core;

namespace TeamBuilder.Services
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
                })
            }
        }
    }
}
