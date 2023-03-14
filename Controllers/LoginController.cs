using OnlineBookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookShop.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(FormCollection collection)
        {
            var user = Session["user"];
            if (user == null)
            {
                var email = collection["email"];
                var password = collection["password"];
                if (string.IsNullOrEmpty(email))
                {
                    ViewData["Loi1"] = "Phải nhập tên đăng nhập";
                }
                if (string.IsNullOrEmpty(password))
                {
                    ViewData["Loi2"] = "Phải nhập mật khẩu";
                }
                else
                {
                    // role: true is user, false is admin
                    users users = new DBContextBook().users.SingleOrDefault(ele =>
                        ele.email == email && ele.pass == password && ele.role == true);
                    if (users == null)
                    {
                        ViewBag.Message = "Tên đăng nhập hoặc mật khẩu không đúng";
                    }
                    else
                    {
                        Session["user"] = users;
                        return RedirectToAction("Index", "Home");
                    }
                }
                //ViewBag.Message = email.ToString() + "," + password.ToString();
                return View("Index");
            }
            else
            {
                return RedirectToAction("Index", "ProfileUser");
            }
        }
    }
}