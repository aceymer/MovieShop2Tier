using MovieShopDAL.Context;
using MovieShopDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.Repository
{
    public class GenreRepository
    {
        public List<Genre> ReadAll()
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Genres.ToList();
            }
        }

        public void Add(Genre genre)
        {
            using (var ctx = new MovieShopContext())
            {
                //Create the queries
                ctx.Genres.Add(genre);
                //Execute the queries
                ctx.SaveChanges();
            }
        }

        public void Delete(int genreId)
        {
            Genre genre = FindGenre(genreId);
            try
            {
                using (var ctx = new MovieShopContext())
                {
                    ctx.Genres.Attach(genre);
                    ctx.Genres.Remove(genre);
                    ctx.SaveChanges();
                }
            }
            catch (DbUpdateConcurrencyException)
            {

            }
        }

        public Genre FindGenre(int genreId)
        {
            foreach (var item in ReadAll())
            {
                if (item.Id == genreId)
                {
                    return item;
                }

            }
            return null;
        }

        public void Update(Genre genre)
        {
            using (var ctx = new MovieShopContext())
            {
                foreach (var movieDB in ctx.Genres.ToList())
                {
                    if (genre.Id == movieDB.Id)
                    {
                        movieDB.Name = genre.Name;
                        ctx.SaveChanges();

                    }
                }
            }


        }
    }
}
