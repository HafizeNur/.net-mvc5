using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc5Anket.Models.ORM.Entity
{
    public class Slider :BaseEntity
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
    }
}