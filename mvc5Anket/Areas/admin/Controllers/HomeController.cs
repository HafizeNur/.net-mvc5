using mvc5Anket.Areas.admin.Models.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc5Anket.Areas.admin.Controllers
{
    [LoginControl]//Bunu istersek actionun üstünede alabilirdik.
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //kullanıcı ad ve soyadı login olduktan sonra aldığımız email adresi ile yakaladık

            //AdminContext db = new AdminContext();
            //string email = HttpContext.User.Identity.Name;
            //AdminUser adminuser = db.AdminUsers.FirstOrDefault(x => x.EMail == email);
            //string name = adminuser.Name;
            //string surname = adminuser.Surname;
            return View();
        }
	}
}