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
    }
}