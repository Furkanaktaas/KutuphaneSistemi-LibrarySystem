using Library.DataBase.DataBase;
using Library.Web.MyControls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers.WebController
{
    public class UserController : Controller
    {
        LibraryContext db = new LibraryContext();
        // GET: User
        public ActionResult Index()
        {
            List<User> user = db.Users.ToList();
            return View(user);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var authorization = db.Authorizations.ToList();
            ViewBag.Authorization = new SelectList(authorization, "authorizationID", "name");
            return View();
        }

        [HttpPost]
        public ActionResult Add(User userView, HttpPostedFileBase image)
        {
            var authorization = db.Authorizations.ToList();
            string email = userView.email.ToUpper(new CultureInfo("tr-TR", false));
            if (ModelState.IsValid == false)
            {
                ViewBag.Authorization = new SelectList(authorization, "authorizationID", "name");
                return View();
            }
            User userDb = db.Users.Where(x => x.email == email && x.authorizationID == userView.authorizationID).SingleOrDefault();
            if (userDb != null)
            {
                ViewBag.Hata = "Böyle bir kullanıcı kayıtlıdır";
                ViewBag.Authorization = new SelectList(authorization, "authorizationID", "name");
                return View();
            }
            Photograph photograph = new Photograph();
            if (image != null)
            {
                string returnValue = photograph.Add(image);
                if (returnValue == "extention")
                {
                    ViewBag.Hata = "Resim uzantısı jpg ve png den başka olamaz";
                    ViewBag.Authorization = new SelectList(authorization, "authorizationID", "name");
                    return View();
                }
                else if (returnValue == "length")
                {
                    ViewBag.Hata = "Resmin boyutu maksimum 3MB olabilir";
                    ViewBag.Authorization = new SelectList(authorization, "authorizationID", "name");
                    return View();
                }
                userView.imageName = returnValue;
            }
            else
            {
                userView.imageName = "default.jpg";
            }
            userDb = new User();
            userDb.name = userView.name.ToUpper(new CultureInfo("tr-TR", false));
            userDb.surname = userView.surname.ToUpper(new CultureInfo("tr-TR", false));
            userDb.email = userView.email.ToUpper(new CultureInfo("tr-TR", false));
            userDb.phoneNumber = userView.phoneNumber;
            userDb.password = userView.password;
            userDb.authorizationID = userView.authorizationID;
            userDb.imageName = userView.imageName;
            db.Users.Add(userDb);
            db.SaveChanges();
            TempData["Basari"] = "Kayıt başarı ile oluşturulmuştur";
            ViewBag.Authorization = new SelectList(authorization, "authorizationID", "name");
            return RedirectToAction("Add");
        }

    }
}