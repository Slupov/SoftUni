using System.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.Client.Utilities
{
    public static class CommandHelper
    {
        public static bool IsTeamExisting(string teamName)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                return db.Teams.Any(t => t.Name == teamName);
            }
        }

        public static bool IsUserExisting(string username)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                return db.Users.Any(u => u.Username == username);
            }
        }

        public static bool IsInviteExisting(string teamName, User user)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                return db.Invitations
                    .Include("InvitedUser")
                    .Any(i => i.IsActive && (i.Team.Name == teamName
                                             &&
                                             (i.InvitedUser.Id == user.Id && !user.IsDeleted)));
            }
        }

        public static bool IsUserCreatorOfTeam(string teamName, User user)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                var team = db.Teams
                    .Include("Creator")
                    .FirstOrDefault(t => t.Name == teamName);

                return team != null && (team.Creator.Id == user.Id && !user.IsDeleted);
            }
        }

        public static bool IsUserCreatorOfTeam(string teamName, string username)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                var team = db.Teams
                    .Include("Creator")
                    .FirstOrDefault(t => t.Name == teamName);

                return team != null && (team.Creator.Username == username && team.Creator.IsDeleted);
            }
        }

        public static bool IsUserCreatorOfEvent(string eventName, User user)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                var ev = db.Events.FirstOrDefault(e => e.Name == eventName);

                return ev != null && (ev.Creator.Id == user.Id && !user.IsDeleted);
            }
        }

        public static bool IsMemberOfTeam(string teamName, string username)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                var team = db.Teams.FirstOrDefault(t => t.Name == teamName);
                var user = db.Users.FirstOrDefault(u => u.Username == username);

                return (team != null && user != null) && (team.Members.Contains(user));
            }
        }

        public static bool IsEventExisting(string eventName)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                return db.Events.Any(e => e.Name == eventName);
            }
        }
    }
}