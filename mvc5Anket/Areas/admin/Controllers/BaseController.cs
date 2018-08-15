using mvc5Anket.Areas.admin.Models.Attribute;
using mvc5Anket.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc5Anket.Areas.admin.Controllers
{
    [LoginControl]
    public class BaseController : Controller
    {
        public AdminContext db;

        public BaseController()
        {
            // ViewBag.User = HttpContext.User.Identity.Name;
            db = new AdminContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
	}
}