namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.MovieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.MovieContext context)
        {
            //for (int i = 1; i <= 10; i++)
            //{
            //    context.Movies.AddOrUpdate(
            //        m => m.Title, // Prevent duplicate data based on Title
            //        new EF.Tables.Movie
            //        {
            //            Title = "Movie " + i,
            //            Director = "Director " + i,
            //            Genre = i % 2 == 0 ? "Action" : "Drama",
            //            ReleaseDate = DateTime.Now.AddYears(-i).ToString("yyyy-MM-dd")// Example: release date set to past years
            //        }
            //    );
            //}

            //for (int i = 1; i <= 6; i++)
            //{
            //    context.Users.Add(new DAL.EF.Tables.User
            //    {
            //        UserId = i, // Assuming UserId is an integer
            //        UserName = $"User {i}"
            //    });
            //}

            //Random rand = new Random();
            //for (int i = 1; i <= 2; i++) // Iterate over users
            //{
            //    for (int j = 1; j <= 3; j++) // Each user gets 3 movies in their watchlist
            //    {
            //        context.Watchlists.Add(new DAL.EF.Tables.Watchlist
            //        {
            //            WId = (i - 1) * 3 + j, // Unique WId
            //            Status = j % 2 == 0 ? "Watched" : "To Watch", // Alternate statuses
            //            UserId = rand.Next(1, 7),
            //            MovieId = rand.Next(1, 11)// Randomly assign movies
            //        });
            //    }
            //}
            //context.SaveChanges();


            //context.SaveChanges();
        }
    }
}
