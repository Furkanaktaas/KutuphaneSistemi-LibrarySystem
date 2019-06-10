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
    public class BookController : Controller
    {
        LibraryContext db = new LibraryContext();
        // GET: Book
        public ActionResult Index()
        {
            List<Book> books = db.Books.ToList();
            return View(books);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var category = db.Categories.ToList();
            ViewBag.Category = new SelectList(category, "categoryID", "name");
            return View();
        }

        [HttpPost]
        public ActionResult Add(Book bookView, HttpPostedFileBase image)
        {
            var category = db.Categories.ToList();
            if (ModelState.IsValid == false)
            {
                ViewBag.Category = new SelectList(category, "categoryID", "name");
                return View();
            }
            Photograph photograph = new Photograph();
            if (image != null)
            {
                string returnValue = photograph.Add(image, "/Content/Photograph/Book/");
                if (returnValue == "extention")
                {
                    ViewBag.Hata = "Resim uzantısı jpg ve png den başka olamaz";
                    ViewBag.Category = new SelectList(category, "categoryID", "name");
                    return View();
                }
                else if (returnValue == "length")
                {
                    ViewBag.Hata = "Resmin boyutu maksimum 3MB olabilir";
                    ViewBag.Category = new SelectList(category, "categoryID", "name");
                    return View();
                }
                bookView.imageName = returnValue;
            }
            else
            {
                bookView.imageName = "default.jpg";
            }
            Book book = new Book();
            book.name = bookView.name.ToUpper(new CultureInfo("tr-TR", false));
            book.writer = bookView.writer.ToUpper(new CultureInfo("tr-TR", false));
            book.publisher = bookView.publisher.ToUpper(new CultureInfo("tr-TR", false));
            book.numberOfPages = bookView.numberOfPages;
            book.statusID = 1;
            book.categoryID = bookView.categoryID;
            book.imageName = bookView.imageName;
            db.Books.Add(book);
            db.SaveChanges();
            TempData["Basari"] = "Kayıt başarı ile oluşturulmuştur";
            ViewBag.Category = new SelectList(category, "categoryID", "name");
            return RedirectToAction("Add");
        }

    }
}