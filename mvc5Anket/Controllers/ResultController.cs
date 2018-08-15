using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc5Anket.Controllers
{
    public class ResultController : Controller
    {
        //
        // GET: /Sonuc/
        public ActionResult Successful()
        {
            return View();
        } 
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Error2()
        {
            return View();
        }
	}
}