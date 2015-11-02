using MovieshopDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShopDAL.Models;

namespace MovieShopDAL.Repository
{
    public class Facade
    {
        private IRepository<Movie> movieRepo;
        private GenreRepository genreRepo;
        private CustomerRepository customerRepo;

        public IRepository<Movie> GetMovieRepository()
        {
            if (movieRepo == null)
            {
                movieRepo = new MovieRepository();
                //Movie = new FrogEatsFrogRepo();
            }
            return movieRepo;
        }
        public GenreRepository GetGenresRepository()
        {
            if (genreRepo == null)
            {
                genreRepo = new GenreRepository();
            }
            return genreRepo;
        }

        public CustomerRepository GetCustomerRepository()
        {
            if (customerRepo == null)
            {
                customerRepo = new CustomerRepository();
            }
            return customerRepo;
        }
    }
}