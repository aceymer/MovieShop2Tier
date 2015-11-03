using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieShopDAL.Models;
using MovieShopDAL.Repository;
using MovieShopDTO;

namespace MovieShop_Rest.Controllers
{
    public class MovieController : ApiController
    {
        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = new Facade().GetMovieRepository().ReadAll();
            return new MovieConverter().Convert(movies);
        }
        /*
        public IEnumerable<Movie> GetMovies()
        {
            return new Facade().GetMovieRepository().ReadAll();
        }*/

        public MovieDto PostMovie(MovieDto dto)
        {
            return dto;
        }
    }
}
