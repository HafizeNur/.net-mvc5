using mvc5Anket.Areas.admin.Models.DTO;
using mvc5Anket.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc5Anket.Areas.admin.Controllers
{
    public class SiteMenuController : BaseController
    {
        //
        // GET: /admin/SiteMenu/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddSiteMenu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSiteMenu(SiteMenuVM model)
        {
            //sitemenu nesnesi olusturup modelimizle eşlestirme yapıyoruz
            SiteMenu sitemenu = new SiteMenu();
            sitemenu.Name = model.Name;
            sitemenu.Url = model.Url;
            sitemenu.cssClass = model.cssClass;

            //site menu nesnemizin içindekileri veri tabanımıza ekleyip,değişiklikleri kaydediyoruz
            db.SiteMenus.Add(sitemenu);
            db.SaveChanges();

            ViewBag.IslemDurum = 1;

            return View();
        }
	}
}