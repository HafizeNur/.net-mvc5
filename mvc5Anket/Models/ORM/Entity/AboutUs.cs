using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc5Anket.Models.ORM.Entity
{
    public class AboutUs:BaseEntity
    {
        public string Content { get; set; }

         [Required]
        public string Title { get; set; }
    }
}