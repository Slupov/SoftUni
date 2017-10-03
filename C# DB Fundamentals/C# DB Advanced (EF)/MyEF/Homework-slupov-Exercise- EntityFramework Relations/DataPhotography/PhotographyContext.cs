using DataPhotography.Migrations;
using Models.Photography;

namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotographyContext : DbContext
    {
        public PhotographyContext()
            : base("name=PhotographyContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotographyContext, Configuration>());
        }

        public virtual DbSet<Photographer> Photographers { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

    }
}