using mvc5Anket.Models.ORM.Entity;
using mvc5Anket.Models.ORM.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc5Anket.Controllers
{
    public class AllSurveyController : SiteBaseController
    {
        public ActionResult Index()
        {
            ViewBag.LastThreeSlider = HttpContext.Session["LastThreeSlider"];
            ViewBag.LastThreeSurvey = HttpContext.Session["LastThreeSurvey"];

            {
                var surveyList = db.SurveyCategories.Where(x => x.IsDeleted == false).OrderBy(x => x.AddDate);
                List<SurveyCategory> model = surveyList.ToList();
                return View(model);
            }
        }
    }
}

    
