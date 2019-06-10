using Library.DataBase.DataBase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.Web.Controllers.Api
{
    [RoutePrefix("api/book")]

    public class BookApiController : ApiController
    {
        LibraryContext db = new LibraryContext();

        [HttpGet]
        [Route("books")]
        public HttpResponseMessage Books()
        {
            try
            {
                List<Book> books = db.Books.Where(x => x.statusID == 1).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, books);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("books/{id}")]
        public HttpResponseMessage Books(int id)
        {
            try
            {
                List<Book> books = db.Books.Where(x => x.bookID == id && x.statusID == 1).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, books);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}

