using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvc5Anket.Models.ORM.Entity
{
    public class SurveyResult : BaseEntity
    {
        public int SurveyId { get; set; }
        public string ClientName { get; set; }
        public string ClientChoose { get; set; }

        [ForeignKey("SurveyId")]
        public virtual SurveyCategory SurveyCategory { get; set; }

    }
}