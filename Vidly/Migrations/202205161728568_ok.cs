namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GeneralImageUrl = c.String(),
                        DirectorId = c.String(),
                        Director_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Directors", t => t.Director_Id)
                .Index(t => t.Director_Id);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        Actor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Actor_Id })
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.Actor_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.Actor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Director_Id", "dbo.Directors");
            DropForeignKey("dbo.MovieActors", "Actor_Id", "dbo.Actors");
            DropForeignKey("dbo.MovieActors", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.MovieActors", new[] { "Actor_Id" });
            DropIndex("dbo.MovieActors", new[] { "Movie_Id" });
            DropIndex("dbo.Movies", new[] { "Director_Id" });
            DropTable("dbo.MovieActors");
            DropTable("dbo.Directors");
            DropTable("dbo.Movies");
            DropTable("dbo.Actors");
        }
    }
}
