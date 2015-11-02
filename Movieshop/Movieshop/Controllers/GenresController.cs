using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieShopProxy.Context;
using MovieShopProxy.DomainModel;
using MovieShopProxy.Repository;

namespace Movieshop.Controllers
{
    public class GenresController : Controller
    {
        private MovieShopContext db = new MovieShopContext();

        private Facade facade = new Facade();

        // GET: Genres
        public ActionResult Index()
        {
            return View(facade.GetGenresRepository().ReadAll());
        }

      

        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Genres/Edit/5
        public ActionResult Update(int genreId)
        {
            Genre genre = facade.GetGenresRepository().FindGenre(genreId);
            return View(genre);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Update([Bind(Include = "Id,Name")] Genre genre)
        {

            facade.GetGenresRepository().Update(genre);
            return RedirectToAction("Index", "Genres");
            //return View(genre);
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int genreId)
        {
            
            return View(genreId);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("DeleteAccepted")]
        public ActionResult DeleteAccepted(int genreId)
        {
            facade.GetGenresRepository().Delete(genreId);
            return RedirectToAction("Index", "Genres");

        }
    

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
