namespace BookShopSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameFKs : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Books", name: "Author_Id", newName: "AuthorId");
            RenameIndex(table: "dbo.Books", name: "IX_Author_Id", newName: "IX_AuthorId");
            AddColumn("dbo.Books", "Edition", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "EditionType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "EditionType", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Edition");
            RenameIndex(table: "dbo.Books", name: "IX_AuthorId", newName: "IX_Author_Id");
            RenameColumn(table: "dbo.Books", name: "AuthorId", newName: "Author_Id");
        }
    }
}
