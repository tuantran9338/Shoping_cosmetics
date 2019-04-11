using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Shopping.DAO;
using Shopping.Models;
using EntityState = System.Data.Entity.EntityState;

namespace Shopping.Controllers
{
    public class HomeController : Controller
    {

        private DbShoppingContext db = new DbShoppingContext();

        // GET: Products
        public ActionResult Index(string SreachString, int? cateID, int? Page_No, int Size_Of_Page = 5)
        {
            int Number_Of_Page = (Page_No ?? 1);

            // Kiểm tra chuỗi tìm kiếm
            if (String.IsNullOrEmpty(SreachString))
            {
                SreachString = "";
            }
            ViewBag.ChuoiTimKiem = SreachString;
            var products = db.Products.Include(p => p.category).Where(p => p.name.Contains(SreachString)).OrderBy(p => p.id).ToPagedList(Number_Of_Page, Size_Of_Page);
            return View(products);
        }

        public ActionResult TimKiem(string SreachString, int? cateID, int? Page_No, int Size_Of_Page = 5)
        {
            int Number_Of_Page = (Page_No ?? 1);

            // Kiểm tra chuỗi tìm kiếm
            if (String.IsNullOrEmpty(SreachString))
            {
                SreachString = "";
            }
            ViewBag.cateId = cateID;
            ViewBag.ChuoiTimKiem = SreachString;
            var products = db.Products.Include(p => p.category).Where(p => p.cateId == cateID || p.name.Contains(SreachString)).OrderBy(p => p.id).ToPagedList(Number_Of_Page, Size_Of_Page);
            return View(products);
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
        [ChildActionOnly]
        public ActionResult Menu()
        {
            var categories = db.Categories.ToList();
            return PartialView(categories);
        }

        [Authorize(Roles = "MEMBER")]
        public ActionResult Thanhtoan()
        {
            return View();
        }


    }
}