using OnlineBookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookShop.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "LoginAdmin");
            }
            using (DBContextBook db = new DBContextBook())
            {
                ViewBag.countUser = db.users.Count().ToString();
                ViewBag.countBook = db.books.Count().ToString();
                ViewBag.countOrder = db.orders.Count().ToString();
                ViewBag.countOrderItem = db.order_item.Count().ToString();
                return View();
            }

        }
    }
}