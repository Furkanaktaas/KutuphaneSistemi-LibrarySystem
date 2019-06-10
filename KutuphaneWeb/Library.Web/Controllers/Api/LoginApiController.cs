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
    [RoutePrefix("api/login")]

    public class LoginApiController : ApiController
    {
        LibraryContext db = new LibraryContext();

        [HttpPost]
        [Route("giris")]
        public HttpResponseMessage Login(User u)
        {
            try
            {
                string emailUpper = u.email.ToUpper(new CultureInfo("tr-TR", false));
                User user = db.Users.Where(x => x.email == emailUpper && x.password == u.password).SingleOrDefault();
                if (user != null)
                    return Request.CreateResponse(HttpStatusCode.OK, user);
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, user);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
