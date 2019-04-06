using Shopping.DAO;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Areas.AdministratorCP.Controllers
{
    [Authorize(Roles = "MANAGER, ADMIN")]
    public class ThongKeSanPhamController : Controller
    {
        private DbShoppingContext db = new DbShoppingContext();
        // GET: AdministratorCP/ThongKe
        public ActionResult ThongKeSanPham()
        {
            var products = db.Products.ToList();
            var result = new List<SPThongKe>();
            foreach (var item in products)
            {
                result.Add(new SPThongKe { id = item.id, name = item.name, quantity = item.amount, price = item.price });
            }
            return View(result);
        }

        [HttpGet]
        public JsonResult JsonThongKeSanPham()
        {
            var products = db.Products.ToList();
            var result = new List<SPThongKe>();
            foreach (var item in products)
            {
                result.Add(new SPThongKe { id = item.id, name = item.name, quantity = item.amount, price = item.price });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}