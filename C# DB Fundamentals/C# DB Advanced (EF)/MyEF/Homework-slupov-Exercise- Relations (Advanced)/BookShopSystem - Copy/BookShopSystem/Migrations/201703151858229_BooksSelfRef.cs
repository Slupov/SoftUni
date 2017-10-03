namespace BookShopSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BooksSelfRef : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CategoryBooks", newName: "BookCategories");
            DropForeignKey("dbo.Books", "Book_Id", "dbo.Books");
            DropIndex("dbo.Books", new[] { "Book_Id" });
            DropPrimaryKey("dbo.BookCategories");
            CreateTable(
                "dbo.RelatedBooks",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        RelatedBookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.RelatedBookId })
                .ForeignKey("dbo.Books", t => t.BookId)
                .ForeignKey("dbo.Books", t => t.RelatedBookId)
                .Index(t => t.BookId)
                .Index(t => t.RelatedBookId);
            
            AddPrimaryKey("dbo.BookCategories", new[] { "Book_Id", "Category_Id" });
            DropColumn("dbo.Books", "Book_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Book_Id", c => c.Int());
            DropForeignKey("dbo.RelatedBooks", "RelatedBookId", "dbo.Books");
            DropForeignKey("dbo.RelatedBooks", "BookId", "dbo.Books");
            DropIndex("dbo.RelatedBooks", new[] { "RelatedBookId" });
            DropIndex("dbo.RelatedBooks", new[] { "BookId" });
            DropPrimaryKey("dbo.BookCategories");
            DropTable("dbo.RelatedBooks");
            AddPrimaryKey("dbo.BookCategories", new[] { "Category_Id", "Book_Id" });
            CreateIndex("dbo.Books", "Book_Id");
            AddForeignKey("dbo.Books", "Book_Id", "dbo.Books", "Id");
            RenameTable(name: "dbo.BookCategories", newName: "CategoryBooks");
        }
    }
}
