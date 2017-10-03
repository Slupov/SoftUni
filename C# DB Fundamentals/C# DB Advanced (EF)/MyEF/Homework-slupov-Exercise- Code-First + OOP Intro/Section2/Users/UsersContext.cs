using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section2
{
    public class UsersContext : DbContext
    {
        public UsersContext() : base("UsersDB")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<UsersContext>());
        }
        public DbSet<User> Users { get; set; }
    }
}