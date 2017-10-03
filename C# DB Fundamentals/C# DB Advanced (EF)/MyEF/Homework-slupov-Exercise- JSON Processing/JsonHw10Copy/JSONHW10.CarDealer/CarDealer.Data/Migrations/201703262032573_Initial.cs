namespace CarDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(nullable: false, maxLength: 30),
                        Model = c.String(nullable: false, maxLength: 50),
                        TravelledDistance = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Supplier_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id, cascadeDelete: true)
                .Index(t => t.Supplier_Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsImporter = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(nullable: false),
                        IsYoungDriver = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Discount = c.Double(nullable: false),
                        Car_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Car_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.PartCars",
                c => new
                    {
                        Part_Id = c.Int(nullable: false),
                        Car_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Part_Id, t.Car_Id })
                .ForeignKey("dbo.Parts", t => t.Part_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.Car_Id, cascadeDelete: true)
                .Index(t => t.Part_Id)
                .Index(t => t.Car_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Sales", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.Parts", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.PartCars", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.PartCars", "Part_Id", "dbo.Parts");
            DropIndex("dbo.PartCars", new[] { "Car_Id" });
            DropIndex("dbo.PartCars", new[] { "Part_Id" });
            DropIndex("dbo.Sales", new[] { "Customer_Id" });
            DropIndex("dbo.Sales", new[] { "Car_Id" });
            DropIndex("dbo.Parts", new[] { "Supplier_Id" });
            DropTable("dbo.PartCars");
            DropTable("dbo.Sales");
            DropTable("dbo.Customers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Parts");
            DropTable("dbo.Cars");
        }
    }
}
