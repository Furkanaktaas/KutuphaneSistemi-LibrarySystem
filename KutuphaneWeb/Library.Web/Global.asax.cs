using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Library.Web.MyControls;

namespace Library.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalFilters.Filters.Add(new AutomaticRouting());
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 30;
            //TimeOut özelliğine aktarılacak değer dakika olarak aktarılmaktadır.
        }
    }
}