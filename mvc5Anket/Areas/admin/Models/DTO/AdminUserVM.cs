﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc5Anket.Areas.admin.Models.DTO
{
    public class AdminUserVM: BaseVM
    {
        [Required]
        [StringLength(40)]
        public string EMail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}