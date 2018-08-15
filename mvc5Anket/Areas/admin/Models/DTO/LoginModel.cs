using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages;
using System.Linq;
using System.Web;



namespace mvc5Anket.Areas.admin.Models.DTO
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Lütfen email adresini doldurunuz")]
        [EmailAddress(ErrorMessage = "Düzgün bir email adresi giriniz")]
        public string EMail {get; set;}
         [Required(ErrorMessage = "Lütfen parola kısmını doldurunuz")]
        public string Password { get; set; }
    }
}