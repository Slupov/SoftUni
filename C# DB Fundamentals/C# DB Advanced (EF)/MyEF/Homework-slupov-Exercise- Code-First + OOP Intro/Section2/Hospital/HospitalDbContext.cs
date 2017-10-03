using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section2.Hospital
{
    class HospitalDbContext : DbContext
    {
        public HospitalDbContext() : base("HospitalDB")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<HospitalDbContext>());
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}