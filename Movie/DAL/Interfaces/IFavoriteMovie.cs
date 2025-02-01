using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFavoriteMovie
    {
        bool Add(FavoriteMovie favoriteMovie);
        bool Remove(int userId, int movieId);
        List<FavoriteMovie> GetAll();
    }
}

