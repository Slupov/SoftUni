using TeamBuilder.Data.Configurations;
using TeamBuilder.Data.Migrations;
using TeamBuilder.Models;

namespace TeamBuilder.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TeamBuilderContext : DbContext
    {
        public TeamBuilderContext()
            : base("name=TeamBuilderContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TeamBuilderContext, Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new InvitationConfiguration());
            modelBuilder.Configurations.Add(new TeamConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}