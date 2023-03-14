using OnlineBookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookShop.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signUp(FormCollection collection)
        {
            var email = collection["email"];
            var password = collection["password"];
            var name = collection["name"];

            using(DBContextBook db = new DBContextBook())
            {
                var user = db.users.SingleOrDefault(item => item.email == email);
                if(user == null)
                {
                    var u = new users();
                    u.email = email;
                    u.pass = password;
                    u.name = name;
                    u.role = true;
                    db.users.Add(u);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.Message = "Email đã được đăng ký tài khoản. Vui lòng chọn email khác...";
                    return View("Index");
                }
            }
        }
    }
}