using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FavoriteMovieService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FavoriteMovie, FavoriteMovieDTO>();
                cfg.CreateMap<FavoriteMovieDTO, FavoriteMovie>();
            });
            return new Mapper(config);
        }

        public static bool AddToFavorites(FavoriteMovieDTO favoriteMovieDTO)
        {
            var repo = DataAccessFactory.FavoriteMovieData();
            var favoriteMovie = GetMapper().Map<FavoriteMovie>(favoriteMovieDTO);
            return repo.Add(favoriteMovie);
        }

        public static bool RemoveFromFavorites(int userId, int movieId)
        {
            var repo = DataAccessFactory.FavoriteMovieData();
            return repo.Remove(userId, movieId);
        }

        public static List<FavoriteMovieDTO> GetAllFavoriteMovies()
        {
            var repo = DataAccessFactory.FavoriteMovieData();
            var favoriteMovies = repo.GetAll();
            return GetMapper().Map<List<FavoriteMovieDTO>>(favoriteMovies);
        }
    }
}
