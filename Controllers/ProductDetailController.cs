using OnlineBookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookShop.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        public ActionResult Index(books book)
        {
            return View(book);
        }
    }
}