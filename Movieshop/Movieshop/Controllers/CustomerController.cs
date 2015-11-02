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
    public class CustomerController : Controller
    {
        private MovieShopContext db = new MovieShopContext();

        private Facade facade = new Facade();

        public ActionResult Index()
        {
            return View(facade.GetCustomerRepository().ReadAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            return View(customer);
        }
        [HttpGet]
        public ActionResult Update(int customerId)
        { 
            Customer customer = facade.GetCustomerRepository().FindCustomer(customerId);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "Id,Name,Email,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                facade.GetCustomerRepository().Update(customer);
                return RedirectToAction("Index", "Customer");
            }
            return View(customer);
        }

        public ActionResult Delete(int customerId)
        {
            return View(customerId);
        }

        
        [HttpPost, ActionName("DeleteAccepted")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAccepted(int customerId)
        {

            facade.GetCustomerRepository().Delete(customerId);
            return RedirectToAction("Index", "Customer");
        }
    }
}