namespace ProductShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationships : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 3),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellerId = c.Int(nullable: false),
                        BuyerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.BuyerId)
                .ForeignKey("dbo.Users", t => t.SellerId, cascadeDelete: true)
                .Index(t => t.SellerId)
                .Index(t => t.BuyerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(maxLength: 3),
                        Age = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserFriends",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FriendId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.FriendId })
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Users", t => t.FriendId)
                .Index(t => t.UserId)
                .Index(t => t.FriendId);
            
            CreateTable(
                "dbo.CategoryProducts",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Category_Id })
                .ForeignKey("dbo.Categories", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryProducts", "Category_Id", "dbo.Products");
            DropForeignKey("dbo.CategoryProducts", "Product_Id", "dbo.Categories");
            DropForeignKey("dbo.Products", "SellerId", "dbo.Users");
            DropForeignKey("dbo.UserFriends", "FriendId", "dbo.Users");
            DropForeignKey("dbo.UserFriends", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "BuyerId", "dbo.Users");
            DropIndex("dbo.CategoryProducts", new[] { "Category_Id" });
            DropIndex("dbo.CategoryProducts", new[] { "Product_Id" });
            DropIndex("dbo.UserFriends", new[] { "FriendId" });
            DropIndex("dbo.UserFriends", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "BuyerId" });
            DropIndex("dbo.Products", new[] { "SellerId" });
            DropTable("dbo.CategoryProducts");
            DropTable("dbo.UserFriends");
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
