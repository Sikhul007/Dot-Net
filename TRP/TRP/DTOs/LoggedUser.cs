using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TRP.DTOs
{
    public class LoggedUser : AuthorizeAttribute
    {
        public LoggedUser() { }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["user"] == null)
            {
                filterContext.Result = new RedirectResult("/Auth/Login");
            }
        }
    }
}