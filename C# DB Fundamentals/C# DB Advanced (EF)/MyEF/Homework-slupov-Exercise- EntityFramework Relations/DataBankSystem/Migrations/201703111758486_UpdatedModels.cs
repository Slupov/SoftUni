namespace DataBankSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.Binary(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CheckingAccounts", "IBAN", c => c.String(maxLength: 22));
            AddColumn("dbo.CheckingAccounts", "Customer_Id", c => c.Int());
            AddColumn("dbo.SavingAccounts", "IBAN", c => c.String(maxLength: 22));
            AddColumn("dbo.SavingAccounts", "Customer_Id", c => c.Int());
            CreateIndex("dbo.CheckingAccounts", "IBAN", unique: true);
            CreateIndex("dbo.CheckingAccounts", "Customer_Id");
            CreateIndex("dbo.SavingAccounts", "IBAN", unique: true);
            CreateIndex("dbo.SavingAccounts", "Customer_Id");
            AddForeignKey("dbo.CheckingAccounts", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.SavingAccounts", "Customer_Id", "dbo.Customers", "Id");
            DropColumn("dbo.CheckingAccounts", "Number");
            DropColumn("dbo.SavingAccounts", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SavingAccounts", "Number", c => c.String());
            AddColumn("dbo.CheckingAccounts", "Number", c => c.String());
            DropForeignKey("dbo.SavingAccounts", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.CheckingAccounts", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.SavingAccounts", new[] { "Customer_Id" });
            DropIndex("dbo.SavingAccounts", new[] { "IBAN" });
            DropIndex("dbo.CheckingAccounts", new[] { "Customer_Id" });
            DropIndex("dbo.CheckingAccounts", new[] { "IBAN" });
            DropColumn("dbo.SavingAccounts", "Customer_Id");
            DropColumn("dbo.SavingAccounts", "IBAN");
            DropColumn("dbo.CheckingAccounts", "Customer_Id");
            DropColumn("dbo.CheckingAccounts", "IBAN");
            DropTable("dbo.Customers");
        }
    }
}
