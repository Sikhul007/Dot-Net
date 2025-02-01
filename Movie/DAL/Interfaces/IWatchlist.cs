using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IWatchlist
    {
        List<Watchlist> GetAll();
        List<Watchlist> GetByUserId(int userId);
    }
}
