namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initw : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Watchlists",
                c => new
                    {
                        WId = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        UserId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
            AddColumn("dbo.Movies", "Trailer", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Watchlists", "UserId", "dbo.Users");
            DropForeignKey("dbo.Watchlists", "MovieId", "dbo.Movies");
            DropIndex("dbo.Watchlists", new[] { "MovieId" });
            DropIndex("dbo.Watchlists", new[] { "UserId" });
            DropColumn("dbo.Movies", "Trailer");
            DropTable("dbo.Watchlists");
        }
    }
}
