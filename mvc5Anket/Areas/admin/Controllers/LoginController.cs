using mvc5Anket.Areas.admin.Models.DTO;
using mvc5Anket.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using System.Web.Mvc;
using System.Web.Security;

namespace mvc5Anket.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        private AdminContext db = new AdminContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.AdminUsers.Any(x => x.EMail == model.EMail && x.Password == model.Password && x.IsDeleted == false))
                {
                    //HttpCookie cerez = new HttpCookie("AdminEmail", "");

                    // cerez.Expires = DateTime.Now.AddDays(5);

                    // Response.Cookies.Add(cerez);
                    var currentUser = db.AdminUsers.Where(x => x.EMail == model.EMail && x.Password == model.Password && x.IsDeleted == false).FirstOrDefault();
                    FormsAuthentication.SetAuthCookie(currentUser.EMail, true);
                    //HttpContext.Session["CurrentUser"] = currentUser;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}