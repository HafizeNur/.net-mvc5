using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc5Anket.Areas.admin.Models.DTO
{
    public class SurveyResultVM : BaseVM
    {
        public int SurveyId { get; set; }
        public string ClientName { get; set; }
        public string ClientChoose { get; set; }

        public virtual SurveyCategoryVM SurveyCategory { get; set; }
    }
}