using Library.DataBase.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers.WebController
{
    public class PastLoanController : Controller
    {
        LibraryContext db = new LibraryContext();
        // GET: PastLoan
        public ActionResult Index()
        {
            User user = (User)Session["User"];
            List<Loan> loans = new List<Loan>();
            if (user.authorizationID == 1)
                loans = db.Loans.Where(x => x.dateReturn != null).ToList();
            else
                loans = db.Loans.Where(x => x.dateReturn != null && x.userID == user.userID).ToList();
            return View(loans);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            User user = (User)Session["User"];
            if (user.authorizationID == 1)
            {
                Loan loan = db.Loans.Where(x => x.loanID == id).SingleOrDefault();
                if (loan != null)
                {
                    db.Loans.Remove(loan);
                    db.SaveChanges();
                    TempData["Basari"] = "Silme İşlemi Başarılı";
                }
            }
            return RedirectToAction("Index");
        }
    }
}