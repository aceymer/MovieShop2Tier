using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DtoModel;
using MoviesShopGateway;

namespace Movieshop.Controllers
{
    public class HomeController : Controller
    {

        private Facade facade = new Facade();

        public ActionResult Index()
        {
            IEnumerable<Movie> movies = facade.GetMovieGateway().ReadAll();
            return View(movies);
        }

       /* [HttpPost]
        public ActionResult Index(string movieSearched)
        {
            List<Movie> movies = facade.GetMovieRepository().TitleFilter(movieSearched);
            return View(movies);
        }

        [HttpPost]
        public ActionResult OrderReceived(string trailerURL)
        {
            Movie movieFound = facade.GetMovieRepository().GetMovieByTrailerURL(trailerURL);
            return View(movieFound);
        }

        [HttpPost]
        public ActionResult OrderConfirmed(string customerEmail)
        {
            return View();
        }*/
    }
}