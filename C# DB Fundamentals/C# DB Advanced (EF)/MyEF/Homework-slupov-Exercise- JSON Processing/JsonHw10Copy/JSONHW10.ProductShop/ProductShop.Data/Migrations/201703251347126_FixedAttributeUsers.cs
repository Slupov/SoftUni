namespace ProductShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedAttributeUsers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 3));
        }
    }
}
