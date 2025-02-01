using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class FavoriteMovieDTO
    {
        public int FId { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
