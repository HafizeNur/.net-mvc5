using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc5Anket.Areas.admin.Controllers
{
    public class AdminResultController : Controller
    {
        public ActionResult AdminSuccessful()
        {
            return View();
        }
        public ActionResult AdminError()
        {
            return View();
        }
	}
}