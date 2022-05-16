namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Movies", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Directors", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "ProfileImageUrl", c => c.String());
            CreateIndex("dbo.Actors", "ApplicationUser_Id");
            CreateIndex("dbo.Movies", "ApplicationUser_Id");
            CreateIndex("dbo.Directors", "ApplicationUser_Id");
            AddForeignKey("dbo.Actors", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Directors", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Movies", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Directors", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Actors", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Directors", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Movies", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Actors", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "ProfileImageUrl");
            DropColumn("dbo.Directors", "ApplicationUser_Id");
            DropColumn("dbo.Movies", "ApplicationUser_Id");
            DropColumn("dbo.Actors", "ApplicationUser_Id");
        }
    }
}
