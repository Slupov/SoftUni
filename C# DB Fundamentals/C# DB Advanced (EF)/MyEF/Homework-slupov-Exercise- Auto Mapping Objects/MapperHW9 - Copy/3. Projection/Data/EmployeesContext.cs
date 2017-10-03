using System.Data.Entity.ModelConfiguration.Conventions;
using _3.Projection.Migrations;
using _3.Projection.Models;

namespace _3.Projection.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EmployeesContext : DbContext
    {
        public EmployeesContext()
            : base("name=EmployeesContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeesContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id)
                .HasOptional(e => e.Manager)
                .WithMany(m => m.Subordinates)
                .HasForeignKey(e => e.ManagerId);
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}