using OnlineBookShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookShop.Areas.Admin.Controllers
{
    public class UserAdminController : Controller
    {
        // GET: Admin/UserAdmin
        public ActionResult Index()
        {
            using(DBContextBook db = new DBContextBook())
            {
                var list = db.users.ToList();
                return View(list);
            }
            
        }

        [HttpGet]
        public ActionResult addUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addUser(users u)
        {
            if (ModelState.IsValid)
            {
                using (DBContextBook db = new DBContextBook())
                {
                    u.role = true;
                    db.users.Add(u);
                    db.SaveChanges();
                    ViewBag.Message = "success";
                }
            }
            else
            {
                ViewBag.Message = "error";
            }
            return View("addUser");
        }



        [HttpGet]
        public ActionResult updateUser(int id)
        {
            using (DBContextBook db = new DBContextBook())
            {
                var u = db.users.Find(id);
                return View(u);
            }
        }

        [HttpPost]
        public ActionResult updateUser(users u)
        {
            if (ModelState.IsValid)
            {
                using (DBContextBook db = new DBContextBook())
                {
                    var data = db.users.FirstOrDefault(item => item.id == u.id);
                    if (data != null)
                    {
                        data.name = u.name;
                        data.pass = u.pass;
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult deleteUser(int id)
        {
            using (DBContextBook db = new DBContextBook())
            {
                var item = db.users.FirstOrDefault(u => u.id == id);
                if (item != null)
                {
                    db.users.Remove(item);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}