using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class FavoriteMovieRepo : IFavoriteMovie
    {
        private readonly MovieContext _context;

        public FavoriteMovieRepo(MovieContext context)
        {
            _context = context;
        }

        public FavoriteMovieRepo()
        {
            _context = new MovieContext();
        }

        public bool Add(FavoriteMovie favoriteMovie)
        {
            _context.FavoriteMovies.Add(favoriteMovie);
            return _context.SaveChanges() > 0;
        }

        public bool Remove(int userId, int movieId)
        {
            var favoriteMovie = _context.FavoriteMovies.FirstOrDefault(fm => fm.UserId == userId && fm.MovieId == movieId);
            if (favoriteMovie != null)
            {
                _context.FavoriteMovies.Remove(favoriteMovie);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        //public List<FavoriteMovie> GetByUserId(int userId)
        //{
        //    return _context.FavoriteMovies.Where(fm => fm.UserId == userId).ToList();
        //}

        public List<FavoriteMovie> GetAll()
        {
            return _context.FavoriteMovies.ToList();
        }
    }
}
