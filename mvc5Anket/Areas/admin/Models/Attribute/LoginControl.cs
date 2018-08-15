using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc5Anket.Areas.admin.Models.Attribute
{
    public class LoginControl : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var currentUser = HttpContext.Current.Session["CurrentUser"];
            //if(curr)
            if (!HttpContext.Current.User.Identity.IsAuthenticated)//kullanıcı girişi olmadıysa
                filterContext.HttpContext.Response.Redirect("/Admin/Login/Index");
        }
    }
}