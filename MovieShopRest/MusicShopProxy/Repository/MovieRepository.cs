using MovieShopDAL.Models;
using MovieShopDAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure;
using MovieShopDAL.Repository;

namespace MovieshopDAL.Repository
{
    public class MovieRepository : IRepository<Movie>
    {
        public List<Movie> ReadAll()
        {
            try {
                using (var ctx = new MovieShopContext())
                {
                    return ctx.Movies.Include("Genres").ToList();

                }
            }
            catch (Exception e) {
                    return null;
            }
           
        }


        public void Add(Movie movie)
        {
            using (var ctx = new MovieShopContext())
            {
                
                //Create the queries
                ctx.Movies.Add(movie);
                //Execute the queries
                ctx.SaveChanges();
            }
        }
        

        public void Delete(int movieId)
        {
            Movie movie = Find(movieId);
            try { 
            using (var ctx = new MovieShopContext())
            {
                ctx.Movies.Attach(movie);
                ctx.Movies.Remove(movie);
                ctx.SaveChanges();
            }
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }
        }

        public Movie Find(int movieId)
        {
            foreach (var item in ReadAll())
            {
                if (item.Id == movieId)
                {
                    return item;
                }

            }
            return null;
        }

        public void Update(Movie movie)
        {
            using (var ctx = new MovieShopContext())
            {
                foreach (var movieDB in ctx.Movies.ToList())
                {
                    if (movie.Id == movieDB.Id)
                    {
                        movieDB.Title = movie.Title;
                        movieDB.ReleaseDate = movie.ReleaseDate;
                        movieDB.Price = movie.Price;
                        movieDB.TrailerURL = movie.TrailerURL;
                        movieDB.PictureURL = movie.PictureURL;
                        movieDB.Rating = movie.Rating;
                        movieDB.PlotDescription = movie.PlotDescription;
                        //movieDB.Genres = movie.Genres;
                        ctx.SaveChanges();

                    }
                }
            }
        }

        public List<Movie> RatingFilter(int rating)
        {
            List<Movie> ratingList = new List<Movie>();
            foreach (var movie in ReadAll())
            {
                if (rating >= movie.Rating)
                {
                    ratingList.Add(movie);
                }
            }

            return ratingList;
              
        }

        public List<Movie> YearFilter(int year)
        {
            List<Movie> yearList = new List<Movie>();
            foreach (var movie in ReadAll())
            {
                if (year == movie.ReleaseDate.Year)
                {
                    yearList.Add(movie);
                }
            }
            return yearList;
        }

        public List<Movie> TitleFilter(string filter)
        {
            List<Movie> nameList = new List<Movie>();
            foreach (var movie in ReadAll())
            {
                if (movie.Title.Contains(filter))
                {
                    nameList.Add(movie);
                }
            }
            return nameList;

        }
        public Movie GetMovieByTrailerURL(string trailerURL)
        {
            foreach (var item in ReadAll())
            {
                if (item.TrailerURL.Equals(trailerURL))
                {
                    return item;
                }
            }
            return null;
        }
    }
}