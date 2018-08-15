using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvc5Anket.Models.ORM.Entity
{
    public class SurveyOption : BaseEntity
    {

        public int SurveyId { get; set; }
        public int VoteCount { get; set; }

        [StringLength(100)]
        public string OptionValue { get; set; }

        [ForeignKey("SurveyId")]
        public virtual SurveyCategory SurveyCategory { get; set; }

    }
}