using mvc5Anket.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc5Anket.Models.ORM.Entity;

namespace mvc5Anket.Utils
{
    public class GlobalFunctions
    {
        public AdminContext db;
        public GlobalFunctions()
        {
            db = new AdminContext();
        }

        public List<Slider> GetSliderPaths()
        {
            List<Slider> last_slider = db.Sliders.Where(s => s.IsDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            if (last_slider.Count > 3)
                last_slider = last_slider.Take(3).ToList();

            return last_slider;
        }
        public List<SurveyCategory> GetImagePaths()
        {
            List<SurveyCategory> last_survey = db.SurveyCategories.OrderByDescending(x => x.AddDate).ToList();
            if (last_survey.Count > 3)
                last_survey = last_survey.Take(3).ToList();
            return last_survey;
        }
        //public List<SurveyCategory>GetAllImagePath()
        //{
        //    List<SurveyCategory> all_survey = db.SurveyCategories.OrderByDescending(x => x.AddDate).ToList();

        //    return all_survey;
        //}
    }
}