namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavoriteMovies",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavoriteMovies", "UserId", "dbo.Users");
            DropForeignKey("dbo.FavoriteMovies", "MovieId", "dbo.Movies");
            DropIndex("dbo.FavoriteMovies", new[] { "MovieId" });
            DropIndex("dbo.FavoriteMovies", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.FavoriteMovies");
        }
    }
}
