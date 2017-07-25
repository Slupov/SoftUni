using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Client.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.Client.Core.Services
{
    class InviteService
    {
        public static bool IsInvitePending(string teamName, string username)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                return db.Invitations
                    .Include("Team")
                    .Include("InvitedUser")
                    .Any(i => i.Team.Name == teamName && i.InvitedUser.Username == username && i.IsActive);
            }
        }

        public static void SendInvite(string teamName, string username)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                var team = db.Teams.FirstOrDefault(t => t.Name == teamName);
                var user = db.Users.FirstOrDefault(u => u.Username == username);

                Invitation invitation = new Invitation()
                {
                    InvitedUser = user,
                    Team = team
                };

               
                if (CommandHelper.IsUserCreatorOfTeam(teamName, user))
                {
                    team.Members.Add(user);
                    invitation.IsActive = false;
                }

                //renew invite
                if (db.Invitations.Any(i => i.Team.Name == teamName && i.InvitedUser.Username == username && !i.IsActive))
                {
                    invitation = db.Invitations.First(i => i.Team.Name == teamName && i.InvitedUser.Username == username);

                    invitation.IsActive = true;
                }

                db.Invitations.AddOrUpdate(i => new {i.InvitedUserId, i.TeamId}, invitation);
                db.SaveChanges();
            }
        }

        public static void AcceptInvite(string teamName)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                var team = db.Teams.FirstOrDefault(t => t.Name == teamName);
                var user = AuthenticationManager.GetCurrentUser();

                db.Users.Attach(user);

                user.Teams.Add(team);

                Invitation invitation = db.Invitations.FirstOrDefault(i => i.TeamId == team.Id &&
                                                                           i.InvitedUserId == user.Id &&
                                                                           i.IsActive);

                invitation.IsActive = false;

                db.SaveChanges();
            }
        }

        public static void DeclineInvite(string teamName)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                var team = db.Teams.FirstOrDefault(t => t.Name == teamName);
                var user = AuthenticationManager.GetCurrentUser();

                db.Users.Attach(user);

                Invitation invitation = db.Invitations.FirstOrDefault(i => i.TeamId == team.Id &&
                                                                           i.InvitedUserId == user.Id &&
                                                                           i.IsActive);

                invitation.IsActive = false;
                db.SaveChanges();
            }
        }
    }
}