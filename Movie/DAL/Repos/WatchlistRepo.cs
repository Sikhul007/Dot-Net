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
    internal class WatchlistRepo : IWatchlist
    {
        public MovieContext _context;

        public WatchlistRepo(MovieContext context)
        {
            _context = context;
        }

        public WatchlistRepo()
        {
            _context = new MovieContext();
        }
        public List<Watchlist> GetAll()
        {
            return _context.Watchlists.ToList();
        }

        public List<Watchlist> GetByUserId(int userId)
        {
            return _context.Watchlists.Where(w => w.UserId == userId).ToList();
        }
    }
}
