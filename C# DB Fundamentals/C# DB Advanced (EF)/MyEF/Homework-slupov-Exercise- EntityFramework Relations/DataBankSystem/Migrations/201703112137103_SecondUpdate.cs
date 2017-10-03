namespace DataBankSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CheckingAccounts", name: "Customer_Id", newName: "Owner_Id");
            RenameColumn(table: "dbo.SavingAccounts", name: "Customer_Id", newName: "Owner_Id");
            RenameIndex(table: "dbo.CheckingAccounts", name: "IX_Customer_Id", newName: "IX_Owner_Id");
            RenameIndex(table: "dbo.SavingAccounts", name: "IX_Customer_Id", newName: "IX_Owner_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SavingAccounts", name: "IX_Owner_Id", newName: "IX_Customer_Id");
            RenameIndex(table: "dbo.CheckingAccounts", name: "IX_Owner_Id", newName: "IX_Customer_Id");
            RenameColumn(table: "dbo.SavingAccounts", name: "Owner_Id", newName: "Customer_Id");
            RenameColumn(table: "dbo.CheckingAccounts", name: "Owner_Id", newName: "Customer_Id");
        }
    }
}
