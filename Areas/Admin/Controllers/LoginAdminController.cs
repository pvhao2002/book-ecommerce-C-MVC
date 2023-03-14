using OnlineBookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookShop.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: Admin/LoginAdmin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult adminLogin(FormCollection collection)
        {
            var email = collection["email"];
            var password = collection["pass"];
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Message = "Vui lòng nhập đầy đủ thông tin";
                return View("Index");
            }
            using(DBContextBook db = new DBContextBook())
            {
                users u = db.users.SingleOrDefault(ele =>
                    ele.email == email && ele.pass == password && ele.role == false);
                if (u == null)
                {
                    ViewBag.Message = "Tên đăng nhập hoặc mật khẩu không đúng";
                    return View("Index");
                }
                Session["admin"] = u;
                return RedirectToAction("Index", "HomeAdmin");
            }
            
        }
    }
}