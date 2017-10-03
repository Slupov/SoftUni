namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Homework", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Resources", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Homework", "StudentId", "dbo.Students");
            DropIndex("dbo.Homework", new[] { "CourseId" });
            DropIndex("dbo.Homework", new[] { "StudentId" });
            DropIndex("dbo.Resources", new[] { "CourseId" });
            RenameColumn(table: "dbo.Homework", name: "CourseId", newName: "Course_Id");
            RenameColumn(table: "dbo.Resources", name: "CourseId", newName: "Course_Id");
            RenameColumn(table: "dbo.Homework", name: "StudentId", newName: "Student_Id");
            AlterColumn("dbo.Homework", "Course_Id", c => c.Int());
            AlterColumn("dbo.Homework", "Student_Id", c => c.Int());
            AlterColumn("dbo.Resources", "Course_Id", c => c.Int());
            CreateIndex("dbo.Homework", "Student_Id");
            CreateIndex("dbo.Homework", "Course_Id");
            CreateIndex("dbo.Resources", "Course_Id");
            AddForeignKey("dbo.Homework", "Course_Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.Resources", "Course_Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.Homework", "Student_Id", "dbo.Students", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Homework", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Resources", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Homework", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Resources", new[] { "Course_Id" });
            DropIndex("dbo.Homework", new[] { "Course_Id" });
            DropIndex("dbo.Homework", new[] { "Student_Id" });
            AlterColumn("dbo.Resources", "Course_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Homework", "Student_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Homework", "Course_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Homework", name: "Student_Id", newName: "StudentId");
            RenameColumn(table: "dbo.Resources", name: "Course_Id", newName: "CourseId");
            RenameColumn(table: "dbo.Homework", name: "Course_Id", newName: "CourseId");
            CreateIndex("dbo.Resources", "CourseId");
            CreateIndex("dbo.Homework", "StudentId");
            CreateIndex("dbo.Homework", "CourseId");
            AddForeignKey("dbo.Homework", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Resources", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Homework", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
