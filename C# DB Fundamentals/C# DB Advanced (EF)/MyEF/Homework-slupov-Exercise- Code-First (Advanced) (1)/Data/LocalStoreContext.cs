namespace Data
{
    using Models.LocalStore;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LocalStoreContext : DbContext
    {
        public LocalStoreContext()
            : base("name=LocalStoreContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LocalStoreContext>());
        }
        public virtual DbSet<Product> Products { get; set; }

    }
}