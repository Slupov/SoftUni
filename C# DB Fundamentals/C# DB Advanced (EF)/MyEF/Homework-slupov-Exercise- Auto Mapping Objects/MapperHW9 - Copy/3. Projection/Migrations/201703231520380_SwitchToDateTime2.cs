namespace _3.Projection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SwitchToDateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Birthday", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
