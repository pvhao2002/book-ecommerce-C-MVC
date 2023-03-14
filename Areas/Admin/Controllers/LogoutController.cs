using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookShop.Areas.Admin.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Admin/Logout
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                Session["admin"] = null;
            }
            return RedirectToAction("Index","LoginAdmin");
        }
    }
}