namespace AutenticationTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogPostModels", "Topic_Id1", "dbo.TopicModels");
            DropForeignKey("dbo.BlogPostModels", "User_Id1", "dbo.UserModels");
            DropIndex("dbo.BlogPostModels", new[] { "Topic_Id1" });
            DropIndex("dbo.BlogPostModels", new[] { "User_Id1" });
            DropIndex("dbo.UserModels", new[] { "ApplicationUser_Id1" });
            DropColumn("dbo.BlogPostModels", "Topic_Id");
            DropColumn("dbo.BlogPostModels", "User_Id");
            DropColumn("dbo.UserModels", "ApplicationUser_Id");
            RenameColumn(table: "dbo.BlogPostModels", name: "Topic_Id1", newName: "Topic_Id");
            RenameColumn(table: "dbo.BlogPostModels", name: "User_Id1", newName: "User_Id");
            RenameColumn(table: "dbo.UserModels", name: "ApplicationUser_Id1", newName: "ApplicationUser_Id");
            AlterColumn("dbo.BlogPostModels", "Topic_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.BlogPostModels", "User_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserModels", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.BlogPostModels", "Topic_Id");
            CreateIndex("dbo.BlogPostModels", "User_Id");
            CreateIndex("dbo.UserModels", "ApplicationUser_Id");
            AddForeignKey("dbo.BlogPostModels", "Topic_Id", "dbo.TopicModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BlogPostModels", "User_Id", "dbo.UserModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPostModels", "User_Id", "dbo.UserModels");
            DropForeignKey("dbo.BlogPostModels", "Topic_Id", "dbo.TopicModels");
            DropIndex("dbo.UserModels", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.BlogPostModels", new[] { "User_Id" });
            DropIndex("dbo.BlogPostModels", new[] { "Topic_Id" });
            AlterColumn("dbo.UserModels", "ApplicationUser_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.BlogPostModels", "User_Id", c => c.Guid());
            AlterColumn("dbo.BlogPostModels", "Topic_Id", c => c.Guid());
            RenameColumn(table: "dbo.UserModels", name: "ApplicationUser_Id", newName: "ApplicationUser_Id1");
            RenameColumn(table: "dbo.BlogPostModels", name: "User_Id", newName: "User_Id1");
            RenameColumn(table: "dbo.BlogPostModels", name: "Topic_Id", newName: "Topic_Id1");
            AddColumn("dbo.UserModels", "ApplicationUser_Id", c => c.Guid(nullable: false));
            AddColumn("dbo.BlogPostModels", "User_Id", c => c.Guid(nullable: false));
            AddColumn("dbo.BlogPostModels", "Topic_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.UserModels", "ApplicationUser_Id1");
            CreateIndex("dbo.BlogPostModels", "User_Id1");
            CreateIndex("dbo.BlogPostModels", "Topic_Id1");
            AddForeignKey("dbo.BlogPostModels", "User_Id1", "dbo.UserModels", "Id");
            AddForeignKey("dbo.BlogPostModels", "Topic_Id1", "dbo.TopicModels", "Id");
        }
    }
}
