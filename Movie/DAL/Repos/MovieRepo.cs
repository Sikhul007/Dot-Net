using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MovieRepo : Repo, IRepo<Movie, int, bool>, IMovieFeatures
    {
        public bool Create(Movie obj)
        {
            db.Movies.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Movies.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Movie Get(int id)
        {
            return db.Movies.Find(id);
        }

        public List<Movie> Get()
        {
            return db.Movies.ToList();
        }

        public bool Update(Movie obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public List<Movie> SearchByTitle(string title)
        {
            return (from p in db.Movies
                    where p.Title.Contains(title)
                    select p).ToList();
        }

        public List<Movie> SearchByDirector(string director)
        {
            return (from p in db.Movies
                    where p.Title.Contains(director)
                    select p).ToList();
        }


    }
}
