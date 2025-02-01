using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class WatchlistService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Watchlist, WatchlistDTO>();
                cfg.CreateMap<WatchlistDTO, Watchlist>();
            });
            return new Mapper(config);
        }

        public static List<WatchlistDTO> GetWatchList()
        {
            var repo = DataAccessFactory.WatchlistData();
            var watchlist = repo.GetAll();
            return GetMapper().Map<List<WatchlistDTO>>(watchlist);
        }

        public static List<WatchlistDTO> GetWatchlistByUser(int userId)
        {
            var repo = DataAccessFactory.WatchlistData();
            var watchlist = repo.GetByUserId(userId);
            return GetMapper().Map<List<WatchlistDTO>>(watchlist);
        }
    }
}