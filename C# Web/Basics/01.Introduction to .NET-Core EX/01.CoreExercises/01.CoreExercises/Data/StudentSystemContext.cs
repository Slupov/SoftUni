using Microsoft.EntityFrameworkCore;
using _01.Student_System.Models;

namespace _01.Student_System
{
    class StudentSystemContext : DbContext
    {
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<License> Licenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=.;Database=StudentSystemDB;Integrated Security=True;");
        }
    }
}