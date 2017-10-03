namespace ProductShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class What : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserFriends", name: "UserId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.UserFriends", name: "FriendId", newName: "UserId");
            RenameColumn(table: "dbo.UserFriends", name: "__mig_tmp__0", newName: "FriendId");
            RenameIndex(table: "dbo.UserFriends", name: "IX_UserId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.UserFriends", name: "IX_FriendId", newName: "IX_UserId");
            RenameIndex(table: "dbo.UserFriends", name: "__mig_tmp__0", newName: "IX_FriendId");
            AddColumn("dbo.Users", "User_Id", c => c.Int());
            CreateIndex("dbo.Users", "User_Id");
            AddForeignKey("dbo.Users", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_Id" });
            DropColumn("dbo.Users", "User_Id");
            RenameIndex(table: "dbo.UserFriends", name: "IX_FriendId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.UserFriends", name: "IX_UserId", newName: "IX_FriendId");
            RenameIndex(table: "dbo.UserFriends", name: "__mig_tmp__0", newName: "IX_UserId");
            RenameColumn(table: "dbo.UserFriends", name: "FriendId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.UserFriends", name: "UserId", newName: "FriendId");
            RenameColumn(table: "dbo.UserFriends", name: "__mig_tmp__0", newName: "UserId");
        }
    }
}
