namespace _3.Projection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredBDay : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Birthday", c => c.DateTime());
        }
    }
}
