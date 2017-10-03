namespace _3.Projection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableBDay : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
