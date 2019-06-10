using Library.DataBase.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers.WebController
{
    public class ReserveController : Controller
    {
        LibraryContext db = new LibraryContext();

        // GET: Reserve
        public ActionResult Index()
        {
            User user = (User)Session["User"];
            List<Reserve> reserves = new List<Reserve>();
            if (user.authorizationID == 1)
                reserves = db.Reserves.ToList();
            else
                reserves = db.Reserves.Where(x => x.userID == user.userID).ToList();
            return View(reserves);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            User user = (User)Session["User"];
            Reserve reserve = new Reserve();
            if (user.authorizationID == 1)
            {
                reserve = db.Reserves.Where(x => x.reserveID == id).SingleOrDefault();
            }
            else
            {
                reserve = db.Reserves.Where(x => x.reserveID == id && x.userID == user.userID).SingleOrDefault();
            }
            if (reserve != null)
            {
                reserve.Book.statusID = 1;
                db.SaveChanges();
                db.Reserves.Remove(reserve);
                db.SaveChanges();
                TempData["Basari"] = "Rezerve işlemi Başarı ile İptal Edildi";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Give(int id)
        {
            User user = (User)Session["User"];
            if (user.authorizationID == 1)
            {
                Reserve reserve = db.Reserves.Where(x => x.reserveID == id).SingleOrDefault();
                if (reserve != null)
                {
                    reserve.Book.statusID = 3;
                    db.SaveChanges();
                    Loan loan = new Loan();
                    loan.userID = reserve.userID;
                    loan.bookID = reserve.bookID;
                    loan.dateIssue = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    db.Loans.Add(loan);
                    db.Reserves.Remove(reserve);
                    db.SaveChanges();
                    TempData["Basari"] = "Ödünç Verme İşlemi Başarılı";
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            List<Book> books = db.Books.Where(x => x.statusID == 1).ToList();
            return View(books);
        }

        [HttpPost]
        public ActionResult Add(string bookID)
        {
            User user = (User)Session["User"];
            int idView = Convert.ToInt32(bookID);
            if (user.userID != 1)
            {
                Book book = db.Books.Where(x => x.bookID == idView && x.statusID == 1).SingleOrDefault();
                if (book != null)
                {
                    Reserve reserve = new Reserve();
                    reserve.bookID = book.bookID;
                    reserve.userID = user.userID;
                    book.statusID = 2;
                    db.Reserves.Add(reserve);
                    db.SaveChanges();
                    TempData["Basari"] = "Rezerve İşlemi Başarılı";
                }
            }
            return RedirectToAction("Index");
        }
    }
}