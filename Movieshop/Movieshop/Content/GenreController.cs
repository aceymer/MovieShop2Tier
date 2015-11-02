using MovieShopProxy.Context;
using MovieShopProxy.DomainModel;
using MovieShopProxy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movieshop.Controllers
{
    public class GenreController : Controller
    {
        private MovieShopContext db = new MovieShopContext();

        private Facade facade = new Facade();

        public ActionResult Index()
        {
            return View(facade.GetGenresRepository().ReadAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Genre genre)
        {

            db.Genres.Add(genre);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        /* Lars' way of doing it:

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genre);
        }
        */

        public ActionResult Delete(int genreId)
        {
            return View(genreId);
        }


        [HttpPost]
        [ActionName("DeleteAccepted")]
        public ActionResult DeleteAccepted(int genreId)
        {
            facade.GetGenresRepository().Delete(genreId);
            return Redirect("Index");

        }

        [HttpGet]
        public ActionResult Update(int genreId)
        {
            Genre genre = facade.GetGenresRepository().FindGenre(genreId);
            return View(genre);
        }

        [HttpPost]
        public ActionResult Update(Genre genre)
        {
            facade.GetGenresRepository().Update(genre);
            return RedirectToAction("Index", "Genre");
        }

    }


}