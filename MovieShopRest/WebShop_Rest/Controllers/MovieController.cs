﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieShopDAL.Models;
using MovieShopDAL.Repository;
using MovieShopDTO;

namespace WebShop_Rest.Controllers
{
    public class MovieController : ApiController
    {
        public IEnumerable<MovieDTO> GetMovies()
        {
            //return new Facade().GetMovieRepository().ReadAll();
            return MovieConverter.ConvertToDto(new Facade().GetMovieRepository().ReadAll());
        }
    }
}