namespace DataBankSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccounts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckingAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Number = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SavingAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Interest = c.Double(nullable: false),
                        Number = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SavingAccounts");
            DropTable("dbo.CheckingAccounts");
        }
    }
}
