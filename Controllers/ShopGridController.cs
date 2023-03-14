using OnlineBookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookShop.Controllers
{
    public class ShopGridController : Controller
    {
        // GET: ShopGrid
        public ActionResult Index()
        {
            var listBook = new DBContextBook().books.ToList();
            return View(listBook);
        }


        [HttpGet]
        public ActionResult productDetail(int id)
        {
            using (DBContextBook db = new DBContextBook())
            {
                var book = db.books.Find(id);
                return RedirectToAction("Index", "ProductDetail", book);
            }


        }
    }
}