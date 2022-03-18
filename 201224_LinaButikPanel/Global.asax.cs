using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _201224_LinaButikPanel
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Bütün formlarda Authorize işlemi yapılmasını sağladık. Authorize istemediğimiz yerlere de class düzeyinde AllowAnonymous etribütünü ekledik.
            //GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
