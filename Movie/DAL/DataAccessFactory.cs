using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Movie, int, bool> MovieData()
        {
            return new MovieRepo();
        }

        public static IMovieFeatures MovieFeatures()
        {
            return new MovieRepo();
        }

        public static IFavoriteMovie FavoriteMovieData()
        {
            return new FavoriteMovieRepo();
        }

        public static IWatchlist WatchlistData()
        {
            return new WatchlistRepo();
        }

        //public static IRating RatingData()
        //{
        //    return new RatingRepo();
        //}
    }
}
