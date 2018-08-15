using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc5Anket.Areas.admin.Models.DTO
{
    public class SliderVM : BaseVM
    {
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen slider için resim ekleyiniz")]
        public HttpPostedFileBase PostImage { get; set; }
    }
}