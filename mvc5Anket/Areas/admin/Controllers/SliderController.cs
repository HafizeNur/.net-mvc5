using mvc5Anket.Areas.admin.Models.DTO;
using mvc5Anket.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc5Anket.Areas.admin.Controllers
{
    public class SliderController : BaseController
    {
        Utils.GlobalFunctions functions = new Utils.GlobalFunctions();
        public ActionResult Index()
        {
            {
                List<SliderVM> model = db.Sliders.Where(x => x.IsDeleted == false).OrderBy(x => x.AddDate).Select(x => new SliderVM()
                {
                    Title = x.Title,
                    ID = x.ID

                }).ToList();

                return View(model);
            }
        }
        public ActionResult AddSlider()
        {
            return View();
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddSlider(SliderVM model)
        {


            if (ModelState.IsValid)
            {
                string filename = "";
                foreach (string name in Request.Files)
                {

                    model.PostImage = Request.Files[name];
                    string ext = Path.GetExtension(Request.Files[name].FileName);
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    {
                        string uniqnumber = Guid.NewGuid().ToString();
                        filename = uniqnumber + model.PostImage.FileName;
                        model.PostImage.SaveAs(Server.MapPath("~/Areas/admin/Content/Site/images/slider/" + filename));
                    }

                }

                Slider post = new Slider();
                post.Title = model.Title;
                post.ImagePath = filename;

                db.Sliders.Add(post);
                int result = db.SaveChanges();
                if (result > 0)
                    this.HttpContext.Session["LastThreeSlider"] = functions.GetSliderPaths();
                ViewBag.IslemDurum = 1;
                return View();
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View();
            }

        }


        public ActionResult UpdateSlider(int id)
        {


            Slider image = db.Sliders.FirstOrDefault(x => x.ID == id);
            //önce güncellenecek kategoriyi bulup ekrana verileri yazdırıyoruz
            //SurveyCategoryVM model = new SurveyCategoryVM();
            //model.SurveyName = survey.SurveyName;
            //model.Description = survey.Description;

            //return View(model);
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSlider(SliderVM model)
        {
            //güncellenecek kategori yakalanır ve yeni verilerie update edilir
            if (ModelState.IsValid)
            {
                Slider image = db.Sliders.FirstOrDefault(x => x.ID == model.ID);
                image.Title = model.Title;


                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return View();
            }
            else
            {
                ViewBag.IslemDurum = 1;
                return View();
            }



        }

        public JsonResult DeleteSlider(int id)
        {
            Slider image = db.Sliders.FirstOrDefault(x => x.ID == id);
            image.IsDeleted = true;
            image.DeleteDate = DateTime.Now;
            int result = db.SaveChanges();

            if (result > 0)
                return Json("1");
            else
                return Json("2");
        }



    }
}