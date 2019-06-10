using Library.DataBase.DataBase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers.WebController
{
    public class LoginController : Controller
    {
        LibraryContext db = new LibraryContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User userView)
        {
            string email = userView.email.ToUpper(new CultureInfo("tr-TR", false));
            User user = db.Users.Where(x => x.email == email && x.password == userView.password).SingleOrDefault();
            if (user != null)
            {
                Session["User"] = user;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Hata = "Kullanıcı Adı veya Şifre Hatalı";
                return View();
            }
        }


    }
}