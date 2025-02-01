//using AutoMapper;
//using BLL.DTOs;
//using DAL;
//using DAL.EF.Tables;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BLL.Services
//{
//    public class RatingService
//    {
//        public static Mapper GetMapper()
//        {
//            var config = new MapperConfiguration(cfg =>
//            {
//                cfg.CreateMap<Rating, RatingDTO>();
//                cfg.CreateMap<RatingDTO, Rating>();
//            });
//            return new Mapper(config);
//        }

//        public static bool AddToRatings(RatingDTO ratingDTO)
//        {
//            var repo = DataAccessFactory.RatingData();
//            var rating = GetMapper().Map<FavoriteMovie>(ratingDTO);
//            return repo.Add(rating);
//        }

//        public static List<RatingDTO> GetAllRating()
//        {
//            var repo = DataAccessFactory.RatingData();
//            var rating = repo.GetAll();
//            return GetMapper().Map<List<FavoriteMovieDTO>>(rating);
//        }
//    }
//}
