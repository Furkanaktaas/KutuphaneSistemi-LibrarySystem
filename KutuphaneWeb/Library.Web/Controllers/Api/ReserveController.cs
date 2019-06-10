using Library.DataBase.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.Web.Controllers.Api
{

    [RoutePrefix("api/reserve")]

    public class ReserveController : ApiController
    {
        LibraryContext db = new LibraryContext();

        [HttpGet]
        [Route("reserves")]
        public HttpResponseMessage Reserve(int id)
        {
            try
            {
                List<Reserve> reserves = db.Reserves.Where(x => x.userID == id).ToList();
                List<ReserveApiModelView> reserveApiModelViews = new List<ReserveApiModelView>();
                foreach (var item in reserves)
                {
                    reserveApiModelViews.Add(new ReserveApiModelView()
                    {
                        bookID = Convert.ToInt32(item.bookID),
                        name = item.Book.name,
                        reserveID = item.reserveID,
                        writer = item.Book.writer,
                        publisher = item.Book.publisher,
                        numberOfPages = Convert.ToInt32(item.Book.numberOfPages),
                        userID = Convert.ToInt32(item.userID)
                    });
                }

                return Request.CreateResponse(HttpStatusCode.OK, reserveApiModelViews);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("delete")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Reserve reserve = db.Reserves.Where(x => x.reserveID == id).SingleOrDefault();
                if (reserve != null)
                {
                    reserve.Book.statusID = 1;
                    db.SaveChanges();
                    db.Reserves.Remove(reserve);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Basari");
                }
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "Hata");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("add")]
        public HttpResponseMessage Add(ReserveApiModelView reser)
        {
            try
            {
                Reserve reserve = new Reserve();
                Book book = db.Books.Where(x=> x.bookID==reser.bookID).SingleOrDefault();
                reserve.bookID = reser.bookID;
                reserve.userID = reser.userID;
                db.Reserves.Add(reserve);
                book.statusID = 2;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Basari");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
