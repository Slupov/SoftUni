namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRelations : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Homework", "CourseId");
            CreateIndex("dbo.Homework", "StudentId");
            CreateIndex("dbo.Resources", "CourseId");
            AddForeignKey("dbo.Homework", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Homework", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Resources", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resources", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Homework", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Homework", "CourseId", "dbo.Courses");
            DropIndex("dbo.Resources", new[] { "CourseId" });
            DropIndex("dbo.Homework", new[] { "StudentId" });
            DropIndex("dbo.Homework", new[] { "CourseId" });
        }
    }
}
