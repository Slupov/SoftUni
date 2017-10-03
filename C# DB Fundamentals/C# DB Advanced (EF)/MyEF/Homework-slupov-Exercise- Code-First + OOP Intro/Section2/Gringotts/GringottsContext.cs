using System.Data.Entity;

namespace Section2
{
    public class GringottsDbContext : DbContext
    {
        public GringottsDbContext() : base("GringottsDB")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<GringottsDbContext>());
        }

        public DbSet<WizardDeposit> WizzardDeposits { get; set; }
        public DbSet<User> Users { get; set; }
    }
}