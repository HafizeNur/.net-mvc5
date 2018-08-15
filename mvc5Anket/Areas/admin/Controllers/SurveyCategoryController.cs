
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

    public class SurveyCategoryController : BaseController
    {

        public ActionResult Index()
        {

            List<SurveyCategoryVM> list = GetSurvey();
            return View(list);
        }

        public ActionResult AddSurvey()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSurvey(SurveyWithOptionsVM model)
        {
            ////SurveyCategoryVM vmodel = new SurveyCategoryVM();

            //if (ModelState.IsValid || (!ModelState.IsValid && model.SurveyCategoriesVM.PostImage == null))
            if (ModelState.IsValid)
            {
                string filename = "";
                foreach (string name in Request.Files)
                {

                    model.SurveyCategoriesVM.PostImage = Request.Files[name];
                    string ext = Path.GetExtension(Request.Files[name].FileName);
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    {
                        string uniqnumber = Guid.NewGuid().ToString();
                        filename = uniqnumber + model.SurveyCategoriesVM.PostImage.FileName;
                        model.SurveyCategoriesVM.PostImage.SaveAs(Server.MapPath("~/Areas/admin/Content/Site/images/addsurvey/" + filename));
                    }

                }

                SurveyCategory post = new SurveyCategory();
                post.SurveyName = model.SurveyCategoriesVM.SurveyName;
                post.Description = model.SurveyCategoriesVM.Description;
                post.ImagePath = filename;
                //Eğer ID boş ise ekleme için kullanılır
                //if (model.SurveyCategoriesVM.ID == 0)
                db.SurveyCategories.Add(post);
                //else
                //{//Eğer ID dolu ise bu varolan bir kayıttır vt'den bu kayıt bulunup güncelleme işlemi yapılır.
                //var existedSurvey = db.SurveyCategories.Where(s => s.ID == model.SurveyCategoriesVM.ID).FirstOrDefault();
                ////existedSurvey.ImagePath = model.SurveyCategoriesVM.PostImage.p;
                //existedSurvey.SurveyName = model.SurveyCategoriesVM.SurveyName;
                //existedSurvey.Description = model.SurveyCategoriesVM.Description;
                //}

                int result1 = db.SaveChanges();
                //Seçenekler Ekleniyor
                if (result1 > 0)
                {
                    //if (model.SurveyOptionsVM.Length > 0)
                    //{
                    var optionsList = model.SurveyOptionsVM.Where(s => !string.IsNullOrEmpty(s.OptionValue)).ToList();

                    foreach (var opt in optionsList)
                    {
                        //if (opt.ID == 0)
                        //{
                        SurveyOption sOm = new SurveyOption();
                        sOm.OptionValue = opt.OptionValue;
                        sOm.SurveyId = post.ID;
                        sOm.SurveyCategory = post;
                        db.SurveyOptions.Add(sOm);
                        //}
                        //else
                        //{
                        //    var existedOption = db.SurveyOptions.Where(s => s.ID == opt.ID).FirstOrDefault();
                        //    existedOption.OptionValue = opt.OptionValue;
                        //}
                    }

                }

                int result2 = db.SaveChanges();
                if (result2 > 0)
                {
                    Response.Redirect("/admin/AdminResult/AdminSuccessful", true);
                    ViewBag.IslemDurum = 1;
                    return View();
                }
                else
                {
                    Response.Redirect("/admin/AdminResult/AdminError", true);
                    ViewBag.IslemDurum = 2;
                    return View();
                }
                //return View();
            }
            else
            {
                Response.Redirect("/admin/AdminResult/AdminError", true);
                ViewBag.IslemDurum = 2;
                return View();
            }

        }


        //Listeleme ekranından anket seçildiğinde seçilen anketin bilgileri dolduruluyor.
        public ActionResult UpdateSurvey()
        {

            int id = Convert.ToInt32(Request.QueryString["surveyid"].ToString());
            SurveyCategory survey = db.SurveyCategories.FirstOrDefault(x => x.ID == id);
            List<SurveyOption> options = db.SurveyOptions.Where(s => s.SurveyId == id).ToList();
            SurveyWithOptionsVM svm = new SurveyWithOptionsVM();

            SurveyCategoryVM scvm = new SurveyCategoryVM();
            scvm.Description = survey.Description;
            scvm.ID = survey.ID;
            scvm.SurveyName = survey.SurveyName;
            scvm.SurveyOptions = survey.SurveyOptions;

            svm.SurveyCategoriesVM = scvm;
            svm.SurveyOptionsVM = new SurveyOptionVM[scvm.SurveyOptions.Count];
            for (int i = 0; i <= scvm.SurveyOptions.Count - 1; i++)
            {
                svm.SurveyOptionsVM[i] = new SurveyOptionVM();
                svm.SurveyOptionsVM[i].OptionValue = scvm.SurveyOptions[i].OptionValue;
                svm.SurveyOptionsVM[i].SurveyId = scvm.SurveyOptions[i].SurveyId;
                svm.SurveyOptionsVM[i].ID = scvm.SurveyOptions[i].ID;
            }

            //güncellenecek kategoriyi ekrana yazdırmak için 
            //SurveyCategory model = new SurveyCategory();
            //model.SurveyName = survey.SurveyName;
            //model.Description = survey.Description;

            //return View(model);
            ViewBag.Mode = "Update";
            if (survey != null)
                return View(svm);
            else
                return View();
        }
        [HttpPost]
        public ActionResult UpdateSurvey(SurveyWithOptionsVM model)
        {
            if (ModelState.IsValid)
            {
                // Eğer ID dolu ise bu varolan bir kayıttır vt'den bu kayıt bulunup güncelleme işlemi yapılır.
                var existedSurvey = db.SurveyCategories.Where(s => s.ID == model.SurveyCategoriesVM.ID).FirstOrDefault();
                //existedSurvey.ImagePath = model.SurveyCategoriesVM.PostImage.p;
                existedSurvey.SurveyName = model.SurveyCategoriesVM.SurveyName;
                existedSurvey.Description = model.SurveyCategoriesVM.Description;

                string filename = "";
                foreach (string name in Request.Files)
                {
                    model.SurveyCategoriesVM.PostImage = Request.Files[name];
                    string ext = Path.GetExtension(Request.Files[name].FileName);
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    {
                        string uniqnumber = Guid.NewGuid().ToString();
                        filename = uniqnumber + model.SurveyCategoriesVM.PostImage.FileName;
                        model.SurveyCategoriesVM.PostImage.SaveAs(Server.MapPath("~/Areas/admin/Content/Site/images/addsurvey/" + filename));
                    }
                }
                if (!string.IsNullOrEmpty(filename))
                    existedSurvey.ImagePath = filename;

                var optionsList = model.SurveyOptionsVM.Where(s => !string.IsNullOrEmpty(s.OptionValue)).ToList();

                foreach (var opt in optionsList)
                {
                    var existedOption = db.SurveyOptions.Where(s => s.ID == opt.ID).FirstOrDefault();
                    existedOption.OptionValue = opt.OptionValue;
                }

                int result = db.SaveChanges();
                if (result > 0)
                {
                    Response.Redirect("/Result/AdminSuccessful", true);
                    ViewBag.IslemDurum = 1;
                    return View();
                }
                else
                {
                    Response.Redirect("/AdminResult/AdminError", true);
                    ViewBag.IslemDurum = 2;
                }

            }
            Response.Redirect("/Result/AdminSuccessful", true);
            ViewBag.IslemDurum = 1;
            return View();
        }

        public JsonResult DeleteSurvey(int id)
        {
            SurveyCategory survey = db.SurveyCategories.FirstOrDefault(x => x.ID == id);
            survey.IsDeleted = true;
            if (survey.SurveyOptions.Count > 0)
            {
                foreach (var opt in survey.SurveyOptions)
                {
                    opt.IsDeleted = true;
                    opt.DeleteDate = DateTime.Now;
                }
            }
            survey.DeleteDate = DateTime.Now;
            int result = db.SaveChanges();
            if (result > 0)
                return Json("1");
            else
                return Json("2");
        }

        public List<SurveyCategoryVM> GetSurvey()
        {

            List<SurveyCategoryVM> list = db.SurveyCategories.Where(x => x.IsDeleted == false).OrderBy(x => x.AddDate).Select(x => new SurveyCategoryVM()
           {
               SurveyName = x.SurveyName,
               Description = x.Description,
               SurveyOptions = x.SurveyOptions,
               ID = x.ID
           }).ToList();
            return list;
        }

    }
}