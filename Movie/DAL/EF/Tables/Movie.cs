using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string ReleaseDate { get; set; }
        public string Trailer { get; set; }

        public ICollection<FavoriteMovie> FavoriteMovies { get; set; }
        public ICollection<Watchlist> Watchlists { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
