using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc5Anket.Models.ORM.VM
{
    public class FullSurveyVM
    {
        public mvc5Anket.Models.ORM.Entity.SurveyCategory SurveyCategory { get; set; }
        public mvc5Anket.Models.ORM.Entity.SurveyResult SurveyResult { get; set; }
        public List<mvc5Anket.Models.ORM.Entity.SurveyOption> SurveyOption { get; set; }
    }
}