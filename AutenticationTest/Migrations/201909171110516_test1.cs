namespace AutenticationTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "ApplicationUser_Id", c => c.Guid(nullable: false));
            AddColumn("dbo.UserModels", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserModels", "ApplicationUser_Id1");
            AddForeignKey("dbo.UserModels", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserModels", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.UserModels", new[] { "ApplicationUser_Id1" });
            DropColumn("dbo.UserModels", "ApplicationUser_Id1");
            DropColumn("dbo.UserModels", "ApplicationUser_Id");
        }
    }
}
