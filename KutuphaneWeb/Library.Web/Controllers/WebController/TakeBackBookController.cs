using Library.DataBase.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers.WebController
{
    public class TakeBackBookController : Controller
    {
        LibraryContext db = new LibraryContext();
        // GET: TakeBackBook
        public ActionResult Index()
        {
            List<Loan> loans = db.Loans.Where(x => x.dateReturn == null).ToList();
            return View(loans);
        }

        [HttpGet]
        public ActionResult Receive(int id)
        {
            Loan loan = db.Loans.Where(x => x.loanID == id).SingleOrDefault();
            if (loan != null)
            {
                loan.Book.statusID = 1;
                db.SaveChanges();
                loan.dateReturn = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                db.SaveChanges();
                TempData["Basari"] = "Teslim Alma İşlemi Başarılı";
            }
            return RedirectToAction("Index");
        }
    }
}