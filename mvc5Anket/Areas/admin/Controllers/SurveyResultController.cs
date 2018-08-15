using mvc5Anket.Areas.admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc5Anket.Areas.admin.Controllers
{
    public class SurveyResultController : BaseController
    {
        //
        // GET: /admin/SurveyResult/
        public ActionResult Index()
        {
            List<SurveyCategoryVM> list = GetSurvey();
            return View(list);
        }
        public List<SurveyCategoryVM> GetSurvey()
        {

            List<SurveyCategoryVM> list = db.SurveyCategories.Where(x => x.IsDeleted == false).OrderBy(x => x.AddDate).Select(x => new SurveyCategoryVM()
           {
               SurveyName = x.SurveyName,
               Description = x.Description,
               SurveyOptions = x.SurveyOptions,
               SurveyResults = x.SurveyResults,
               ID = x.ID
           }).ToList();
            return list;
        }
        public ActionResult ShowResult()
        {

            return View();
        }
    }
}