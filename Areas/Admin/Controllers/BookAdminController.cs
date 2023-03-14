using OnlineBookShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookShop.Areas.Admin.Controllers
{
    public class BookAdminController : Controller
    {
        // GET: Admin/BookAdmin
        public ActionResult Index()
        {
            using (DBContextBook db = new DBContextBook())
            {
                var listBook = db.books.ToList();
                return View(listBook);
            }
        }


        [HttpGet]
        public ActionResult addBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insertBook(books book, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/images"), _FileName);
                    file.SaveAs(_path);
                    book.image_url = "~/Content/images/" + _FileName;
                }
                using (DBContextBook db = new DBContextBook())
                {
                    db.books.Add(book);
                    db.SaveChanges();
                    ViewBag.Message = "success";
                }
            }
            else
            {
                ViewBag.Message = "error";
            }
            return View("addBook");
        }



        [HttpGet]
        public ActionResult editBook(int id)
        {
            using (DBContextBook db = new DBContextBook())
            {
                var book = db.books.Find(id);
                return View(book);
            }
        }

        [HttpPost]
        public ActionResult updateBook(books book, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                using (DBContextBook db = new DBContextBook())
                {
                    var data = db.books.FirstOrDefault(item => item.id == book.id);
                    if (data != null)
                    {
                        data.title = book.title;
                        data.author = book.author;
                        data.price = book.price;
                        data.public_date = book.public_date;
                        data.category = book.category;
                        data.decription = book.decription;
                        if (file.ContentLength > 0)
                        {
                            string _FileName = Path.GetFileName(file.FileName);
                            string _path = Path.Combine(Server.MapPath("~/Content/images"), _FileName);
                            file.SaveAs(_path);
                            data.image_url = "~/Content/images/" + _FileName;
                        }
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult deleteBook(int id)
        {
            using(DBContextBook db = new DBContextBook())
            {
                var item = db.books.FirstOrDefault(book => book.id == id);
                if(item != null)
                {
                    db.books.Remove(item);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}