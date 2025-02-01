namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.FavoriteMovies", name: "MovieId", newName: "Id");
            RenameIndex(table: "dbo.FavoriteMovies", name: "IX_MovieId", newName: "IX_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.FavoriteMovies", name: "IX_Id", newName: "IX_MovieId");
            RenameColumn(table: "dbo.FavoriteMovies", name: "Id", newName: "MovieId");
        }
    }
}
