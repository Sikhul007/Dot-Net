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
    public class MovieService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieDTO>();
                cfg.CreateMap<MovieDTO, Movie>();

            });
            return new Mapper(config);
        }

        public static List<MovieDTO> Get()
        {
            var repo = DataAccessFactory.MovieData();
            var movies = repo.Get();
            var result = GetMapper().Map<List<MovieDTO>>(movies);
            return result;
        }

        public static MovieDTO Get(int id)
        {
            var repo = DataAccessFactory.MovieData();
            var movie = repo.Get(id);
            var result = GetMapper().Map<MovieDTO>(movie);
            return result;
        }

        public static bool Create(MovieDTO movie)
        {
            var repo = DataAccessFactory.MovieData();
            var data = GetMapper().Map<Movie>(movie);
            return repo.Create(data);
        }

        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.MovieData();
            return repo.Delete(id);
        }

        public static bool Update(MovieDTO movie)
        {
            var repo = DataAccessFactory.MovieData();
            var data = GetMapper().Map<Movie>(movie); // Map DTO to Entity
            return repo.Update(data); // Update the entity in the repository
        }

        public static List<MovieDTO> SearchByTitle(string title)
        {
            var repo = DataAccessFactory.MovieFeatures();
            return GetMapper().Map<List<MovieDTO>>(repo.SearchByTitle(title));
        }

        public static List<MovieDTO> SearchByDirector(string director)
        {
            var repo = DataAccessFactory.MovieFeatures();
            return GetMapper().Map<List<MovieDTO>>(repo.SearchByDirector(director));

        }
    }
}
