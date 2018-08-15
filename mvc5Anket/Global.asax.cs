using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace mvc5Anket
{
    public class MvcApplication : System.Web.HttpApplication
    {
        Utils.GlobalFunctions functions = new Utils.GlobalFunctions();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                if (HttpContext.Current.Session["LastThreeSlider"] == null)
                    HttpContext.Current.Session["LastThreeSlider"] = functions.GetSliderPaths();

                if (HttpContext.Current.Session["LastThreeSurvey"] == null)
                    HttpContext.Current.Session["LastThreeSurvey"] = functions.GetImagePaths();

                //if (HttpContext.Current.Session["AllSurvey"] == null)
                //    HttpContext.Current.Session["AllSurvey"] = functions.GetAllImagePath();
            }
        }
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(
        //          "AnaSayfa",
        //          "SiteHome",
        //          new { controller = "SiteHome", action = "Index" }
        //     );
        //}
    }
}
