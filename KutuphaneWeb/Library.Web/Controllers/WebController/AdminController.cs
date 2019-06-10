using Library.DataBase.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers.WebController
{
    public class AdminController : Controller
    {
        LibraryContext db = new LibraryContext();
        // GET: Admin
        public ActionResult Index()
        {
            User user = (User)Session["User"];
            Session["BookCount"] = db.Books.ToList().Count;
            Session["UserCount"] = db.Users.ToList().Count;
            if (user.authorizationID==1)
            {
                Session["ReserveCount"] = db.Reserves.ToList().Count();
                Session["LoanCount"] = db.Loans.ToList().Count();
            }
            else
            {
                Session["ReserveCount"] = db.Reserves.Where(x=> x.userID == user.userID).ToList().Count();
                Session["LoanCount"] = db.Loans.Where(x => x.userID == user.userID).ToList().Count();
            }

            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }

        [HttpGet]
        public ActionResult MyProfile()
        {
            User user = (User)Session["User"];
            return View(user);
        }

        [HttpPost]
        public ActionResult MyProfile(User userView)
        {
            User user = (User)Session["User"];
            if (ModelState.IsValid == false)
            {
                return View(user);
            }
            User userDb = db.Users.Where(x=> x.userID == user.userID).SingleOrDefault();
            userDb.password = userView.password;
            db.SaveChanges();
            ViewBag.Basari = "Şifreniz Başarı ile değiştirilmiştir";
            Session["User"] = userDb;
            return View(user);
        }

    }
}