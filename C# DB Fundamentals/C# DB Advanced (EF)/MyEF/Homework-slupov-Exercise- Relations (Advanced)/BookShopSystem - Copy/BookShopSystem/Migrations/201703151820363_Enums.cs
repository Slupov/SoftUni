namespace BookShopSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Enums : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "EditionType", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "AgeRestriction", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "AgeRestriction");
            DropColumn("dbo.Books", "EditionType");
        }
    }
}
