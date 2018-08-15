using mvc5Anket.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace mvc5Anket.Models.ORM.Context
{
    public class AdminContext : DbContext
    {
          public AdminContext(){
              Database.Connection.ConnectionString = "Server=DESKTOP-FPBIC9C\\SQLEXPRESS;Database=mvc5anket;Integrated Security=True;";
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet <AdminUser> AdminUsers { get; set; }//AdminUsers db. ifadelerinden sonra kullanılacak ad
        public DbSet<SurveyCategory>SurveyCategories { get; set; }//bu tabloları olusturduk fakat tablo olduklarını bildirmekiçin database'e set etmemiz gerekiyordu bu ifade onun için.   
        public DbSet<SiteMenu> SiteMenus { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SurveyOption> SurveyOptions { get; set; }
        //public DbSet<SurveyWithOption> SurveyWithOptions { get; set; }
        public DbSet<SurveyResult> SurveyResult { get; set; }

        public DbSet<AboutUs> AboutUS{ get; set; }
    }
}