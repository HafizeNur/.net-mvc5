using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc5Anket.Areas.admin.Models.DTO
{
    public class SurveyWithOptionsVM:BaseVM
    {
        public mvc5Anket.Areas.admin.Models.DTO.SurveyCategoryVM SurveyCategoriesVM { get; set; }
        public mvc5Anket.Areas.admin.Models.DTO.SurveyOptionVM[] SurveyOptionsVM { get; set; }

    }
}