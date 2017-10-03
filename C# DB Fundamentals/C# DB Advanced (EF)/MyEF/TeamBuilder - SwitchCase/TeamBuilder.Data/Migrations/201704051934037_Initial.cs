namespace TeamBuilder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Events",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(maxLength: 250),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId)
                .Index(t => t.CreatorId);

            CreateTable(
                    "dbo.Users",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 25),
                        FirstName = c.String(maxLength: 25),
                        LastName = c.String(maxLength: 25),
                        Password = c.String(nullable: false, maxLength: 30),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true, name: "IX_Users_Username");

            CreateTable(
                    "dbo.Teams",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 32),
                        Acronym = c.String(nullable: false, maxLength: 3),
                        CreatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId)
                .Index(t => t.Name, unique: true, name: "IX_Teams_Name")
                .Index(t => t.CreatorId);

            CreateTable(
                    "dbo.Invitations",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvitedUserId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.InvitedUserId)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.InvitedUserId)
                .Index(t => t.TeamId);

            CreateTable(
                    "dbo.UserTeams",
                    c => new
                    {
                        UserId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new {t.UserId, t.TeamId})
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TeamId);

            CreateTable(
                    "dbo.EventTeams",
                    c => new
                    {
                        EventId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new {t.EventId, t.TeamId})
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.TeamId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.EventTeams", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.EventTeams", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.UserTeams", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.UserTeams", "UserId", "dbo.Users");
            DropForeignKey("dbo.Invitations", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Invitations", "InvitedUserId", "dbo.Users");
            DropForeignKey("dbo.Teams", "CreatorId", "dbo.Users");
            DropIndex("dbo.EventTeams", new[] {"TeamId"});
            DropIndex("dbo.EventTeams", new[] {"EventId"});
            DropIndex("dbo.UserTeams", new[] {"TeamId"});
            DropIndex("dbo.UserTeams", new[] {"UserId"});
            DropIndex("dbo.Invitations", new[] {"TeamId"});
            DropIndex("dbo.Invitations", new[] {"InvitedUserId"});
            DropIndex("dbo.Teams", new[] {"CreatorId"});
            DropIndex("dbo.Teams", "IX_Teams_Name");
            DropIndex("dbo.Users", "IX_Users_Username");
            DropIndex("dbo.Events", new[] {"CreatorId"});
            DropTable("dbo.EventTeams");
            DropTable("dbo.UserTeams");
            DropTable("dbo.Invitations");
            DropTable("dbo.Teams");
            DropTable("dbo.Users");
            DropTable("dbo.Events");
        }
    }
}