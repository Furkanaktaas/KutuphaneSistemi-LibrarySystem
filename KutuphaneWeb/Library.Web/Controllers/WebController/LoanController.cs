using Library.DataBase.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers.WebController
{
    public class LoanController : Controller
    {
        LibraryContext db = new LibraryContext();
        LoanModelView loanModelView = new LoanModelView();
        static int bookIDview;

        public ActionResult Index()
        {
            loanModelView.books = db.Books.Where(x => x.statusID == 1).ToList();
            loanModelView.users = db.Users.ToList();
            return View(loanModelView);
        }


        [HttpPost]
        public ActionResult Add(string userID)
        {
            Loan loan = new Loan();
            Book book = db.Books.Where(x => x.bookID == bookIDview).SingleOrDefault();
            loan.bookID = bookIDview;
            loan.userID = Convert.ToInt32(userID);
            loan.dateIssue = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            db.Loans.Add(loan);
            book.statusID = 3;
            db.SaveChanges();
            TempData["Basari"] = "Ödünç Verme İşlemi Başarılı";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult BookId(int id)
        {
            bookIDview = id;
            return Json("");
        }
    }
}