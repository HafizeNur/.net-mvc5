using mvc5Anket.Models.ORM.Context;
using mvc5Anket.Models.ORM.Entity;
using mvc5Anket.Models.ORM.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc5Anket.Controllers
{
    public class SiteSurveyController : SiteBaseController
    {

        public ActionResult Index()
        {
            ViewBag.LastThreeSlider = HttpContext.Session["LastThreeSlider"];
            ViewBag.LastThreeSurvey = HttpContext.Session["LastThreeSurvey"];

            int surveyid = Convert.ToInt32(Request.QueryString["surveyid"]);

            if (surveyid != 0)
            {
                FullSurveyVM fsm = new FullSurveyVM();
                SurveyCategory post = db.SurveyCategories.FirstOrDefault(x => x.ID == surveyid);
                fsm.SurveyCategory = post;
                fsm.SurveyOption = post.SurveyOptions;
                if (post != null)
                {
                    HttpContext.Session["SurveyID"] = post.ID;
                    return View(fsm);
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


        [HttpPost]
        public void VoteResult(FullSurveyVM model)
        {
            int selectedSurveyID = Convert.ToInt32(HttpContext.Session["SurveyID"].ToString());
            var selectedSurvey = db.SurveyCategories.Where(s => s.ID == selectedSurveyID).FirstOrDefault();
            selectedSurvey.SurveyResults.Add(model.SurveyResult);
            if (!selectedSurvey.SurveyOptions.Any(s => !string.IsNullOrEmpty(s.OptionValue)))
            {
                int result = db.SaveChanges();
                if (result > 0)
                {
                    var selectedOption = selectedSurvey.SurveyOptions.Where(s => s.OptionValue == model.SurveyResult.ClientChoose).FirstOrDefault();
                    selectedOption.VoteCount += 1;
                    db.SaveChanges();

                    Response.Redirect("/Result/Successful", true);
                    ViewBag.IslemDurum = 1;
                }
                else
                {

                    Response.Redirect("/Result/Error", true);
                    ViewBag.IslemDurum = 2;
                }
            }
            else
            {
                Response.Redirect("/Result/Error2", true);
                ViewBag.IslemDurum = 3;
            }
            //Response.RedirectToRoute("");
        }
    }
}