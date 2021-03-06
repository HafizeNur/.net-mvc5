﻿using mvc5Anket.Areas.admin.Models.DTO;
using mvc5Anket.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc5Anket.Areas.admin.Controllers
{
    public class AdminUserController : BaseController
    {
        public ActionResult Index()
        {
                List<AdminUserVM> model = db.AdminUsers.Where(x => x.IsDeleted == false).OrderBy(x => x.AddDate).Select(x => new AdminUserVM()
                {
                    EMail = x.EMail,
                    Password=x.Password,
                    ID = x.ID

                }).ToList();

                return View(model);           
        }
        public ActionResult AddAdminUser()
        {
            return View();
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddAdminUser(AdminUserVM model)
        {


            if (ModelState.IsValid)
            {
                AdminUser post = new AdminUser();
                post.EMail = model.EMail;
                post.Password = model.Password;

                db.AdminUsers.Add(post);
                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return View();
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View();
            }

        }


        public ActionResult UpdateAdminUser(int id)
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
        public ActionResult UpdateAdminUser(AdminUserVM model)
        {
            //güncellenecek kategori yakalanır ve yeni verilerie update edilir
            if (ModelState.IsValid)
            {
                AdminUser admin = db.AdminUsers.FirstOrDefault(x => x.ID == model.ID);
                admin.EMail = model.EMail;
                admin.Password = model.Password;


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

        public JsonResult DeleteAdminUser(int id)
        {
            AdminUser admin = db.AdminUsers.FirstOrDefault(x => x.ID == id);
            admin.IsDeleted = true;
            admin.DeleteDate = DateTime.Now;
            int result = db.SaveChanges();

            return Json(result == 1);
        }



	}
}