using mvc5Anket.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc5Anket.Controllers
{
    public class SiteHomeController : SiteBaseController
    {
        //
        // GET: /SiteHome/
        public ActionResult Index()
        {       
            //bu kısmı ben ekliyorum!normalde yoktu.Site surveyden aldım
            ViewBag.LastThreeSlider = HttpContext.Session["LastThreeSlider"];
            ViewBag.LastThreeSurvey = HttpContext.Session["LastThreeSurvey"];

            return View();
        }    
	}
}