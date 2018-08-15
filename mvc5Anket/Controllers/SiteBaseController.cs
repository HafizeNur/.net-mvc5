using mvc5Anket.Models.ORM.Context;
using mvc5Anket.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc5Anket.Controllers
{
    public class SiteBaseController :Controller
    {
        public AdminContext db;
        public SiteBaseController()
        {
            db = new AdminContext();
        }

        //public ActionResult Index()
        //{
            
        //        SurveyCategory last_survey=db.SurveyCategories.OrderByDescending(x=>x.AddDate).FirstOrDefault();
        //        SiteSurveyPostVM model = new SiteSurveyPostVM();
        //        model.SurveyName = last_survey.SurveyName;
        //        model.PostImagePath = last_survey.ImagePath;

        //        return View(model);
        //}
        

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}