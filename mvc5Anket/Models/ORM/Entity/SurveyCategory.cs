using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc5Anket.Models.ORM.Entity
{
    public class SurveyCategory : BaseEntity
    {
        public string SurveyName { get; set; }
       
        public string Description { get; set; }
        
        public string ImagePath { get; set; }

        public virtual List<SurveyOption> SurveyOptions { get; set; }

        public virtual List<SurveyResult> SurveyResults { get; set; }
    }
}