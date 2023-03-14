using OnlineBookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Controllers
{
    public class ProfileUserController : Controller
    {


        // GET: ProfileUser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            var user = Session["user"];
            if (user != null)
            {
                Session["user"] = null;
                ViewBag.classInfo = "";
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditInfo()
        {
            ViewBag.classInfo = "edit";
            return View("Index");
        }


        [HttpPost]
        public ActionResult Update(users user)
        {
            if(user == null)
            {
                return View("Index");
            }
            else
            {
                using (DBContextBook db = new DBContextBook())
                {
                    users users = db.users.SingleOrDefault(item => item.id == user.id);
                    if (users != null)
                    {
                        users.name = user.name;
                        users.pass = user.pass;
                        db.SaveChanges();
                        Session["user"] = users;
                        return View("Index");
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}