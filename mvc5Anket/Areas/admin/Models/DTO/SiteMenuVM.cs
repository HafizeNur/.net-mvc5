using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc5Anket.Areas.admin.Models.DTO
{
    public class SiteMenuVM : BaseVM
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string cssClass { get; set; }
    }
}