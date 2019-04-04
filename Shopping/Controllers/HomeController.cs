using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shopping.DAO;
using Shopping.Models;
using EntityState = System.Data.Entity.EntityState;

namespace Shopping.Controllers
{
    public class HomeController : Controller
    {

        private DbShoppingContext db = new DbShoppingContext();

        public ActionResult Index(int? Page_No, int Size_Of_Page = 5 )
        {
            int Number_Of_Page = (Page_No ?? 1);
            var products = db.Products.Include(p => p.category).OrderBy(p =>p.id);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }


    }
}