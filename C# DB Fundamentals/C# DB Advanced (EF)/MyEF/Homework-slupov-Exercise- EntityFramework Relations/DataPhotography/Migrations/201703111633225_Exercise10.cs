namespace DataPhotography.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wut : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "Photographer_Id", "dbo.Photographers");
            DropForeignKey("dbo.Albums", "Photographer_Id1", "dbo.Photographers");
            DropForeignKey("dbo.Photographers", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.Photographers", "Album_Id1", "dbo.Albums");
            DropIndex("dbo.Albums", new[] { "Photographer_Id" });
            DropIndex("dbo.Albums", new[] { "Photographer_Id1" });
            DropIndex("dbo.Photographers", new[] { "Album_Id" });
            DropIndex("dbo.Photographers", new[] { "Album_Id1" });
            CreateTable(
                "dbo.PhotographerAlbums",
                c => new
                    {
                        Photographer_Id = c.Int(nullable: false),
                        Album_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Photographer_Id, t.Album_Id })
                .ForeignKey("dbo.Photographers", t => t.Photographer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_Id, cascadeDelete: true)
                .Index(t => t.Photographer_Id)
                .Index(t => t.Album_Id);
            
            DropColumn("dbo.Albums", "Photographer_Id");
            DropColumn("dbo.Albums", "Photographer_Id1");
            DropColumn("dbo.Photographers", "Album_Id");
            DropColumn("dbo.Photographers", "Album_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photographers", "Album_Id1", c => c.Int());
            AddColumn("dbo.Photographers", "Album_Id", c => c.Int());
            AddColumn("dbo.Albums", "Photographer_Id1", c => c.Int());
            AddColumn("dbo.Albums", "Photographer_Id", c => c.Int());
            DropForeignKey("dbo.PhotographerAlbums", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.PhotographerAlbums", "Photographer_Id", "dbo.Photographers");
            DropIndex("dbo.PhotographerAlbums", new[] { "Album_Id" });
            DropIndex("dbo.PhotographerAlbums", new[] { "Photographer_Id" });
            DropTable("dbo.PhotographerAlbums");
            CreateIndex("dbo.Photographers", "Album_Id1");
            CreateIndex("dbo.Photographers", "Album_Id");
            CreateIndex("dbo.Albums", "Photographer_Id1");
            CreateIndex("dbo.Albums", "Photographer_Id");
            AddForeignKey("dbo.Photographers", "Album_Id1", "dbo.Albums", "Id");
            AddForeignKey("dbo.Photographers", "Album_Id", "dbo.Albums", "Id");
            AddForeignKey("dbo.Albums", "Photographer_Id1", "dbo.Photographers", "Id");
            AddForeignKey("dbo.Albums", "Photographer_Id", "dbo.Photographers", "Id");
        }
    }
}
