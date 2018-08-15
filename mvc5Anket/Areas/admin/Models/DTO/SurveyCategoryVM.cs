
using mvc5Anket.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc5Anket.Areas.admin.Models.DTO
{
    public class SurveyCategoryVM : BaseVM
    {
        [Required]
        [Display(Name = "Anket Adı")]
        public string SurveyName { get; set; }

        [Display(Name = "Anket Resmi")]
        public HttpPostedFileBase PostImage { get; set; }
         [Required]
        [Display(Name = "Anket Sorusu")]
        public string Description { get; set; }

        public virtual List<SurveyOption> SurveyOptions { get; set; }

        public virtual List<SurveyResult> SurveyResults { get; set; }

    }
}