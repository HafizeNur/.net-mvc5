using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc5Anket.Areas.admin.Models.DTO
{
    public class AboutUsVM:BaseVM
    {
     
        public string Content { get; set; }

        [Required]
        public string Title { get; set; }
    }
}