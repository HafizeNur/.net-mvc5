using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc5Anket.Models.ORM.Entity
{
    public class BaseEntity
    {
        public int ID { get; set; }

        private DateTime _addDate = DateTime.Now;
        public DateTime AddDate
        {
            get
            {
                return _addDate;
            }
            set
            {
                _addDate = value;
            }
        }
        private bool isDeleted =false;
        public bool IsDeleted {
            get
            {
               return isDeleted;            
            }
            set 
            {
                isDeleted = value;
            }
        }
        public DateTime? DeleteDate { get; set; }
    }
}