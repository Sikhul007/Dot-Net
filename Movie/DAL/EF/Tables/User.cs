using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<FavoriteMovie> FavoriteMovies { get; set; }
        public ICollection<Watchlist> Watchlists { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
