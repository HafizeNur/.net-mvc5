using mvc5Anket.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvc5Anket.Areas.admin.Models.DTO
{
    public class SurveyOptionVM
    {
        public int ID { get; set; }
        public int VoteCount { get; set; }
        public int SurveyId { get; set; }
        public string OptionValue { get; set; }
        public virtual SurveyCategory SurveyCategory { get; set; }

    }
}