
using MovieShopProxy.DomainModel;
using MovieShopProxy.Models;
using MovieShopProxy.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movieshop.Controllers
{
    public class MovieController : Controller
    {
        private Facade facade = new Facade();

        public ActionResult Index()
        {
            List<Movie> movies = facade.GetMovieRepository().ReadAll();
            Debug.WriteLine(movies);
            return View(movies);
        }
        public ActionResult Create()
        {
            /*
            For adding Genre to the create movie:
            
            List<Movie> movieList = facade.GetMovieRepository().ReadAll();
            List<Genre> genreList = facade.GetGenresRepository().ReadAll();
            List<ICollection> list = new List<ICollection>();
            list.Add(movieList);
            list.Add(genreList);
            */
            return View();
        }
        public ActionResult StartPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Title, Price, ReleaseDate, TrailerURL, PictureURL, Rating, PlotDescription")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                facade.GetMovieRepository().Add(movie);
                return Redirect("Index");
            }
            return View(movie);
        }
        
        public ActionResult Delete(int movieId)
        {
            return View(movieId);
        }

        
        [HttpPost]
        [ActionName("DeleteAccepted")]
        public ActionResult DeleteAccepted(int movieId)
        {
            facade.GetMovieRepository().Delete(movieId);
            return Redirect("Index");

        }

    
        [HttpGet]
        public ActionResult Update(int movieId)
        {
            Movie movie = facade.GetMovieRepository().FindMovie(movieId);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Update(Movie movie)
        {
            facade.GetMovieRepository().Update(movie);
            return RedirectToAction("Index", "Movie");
        }

       
        
    }
}