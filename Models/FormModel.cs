using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AJAX_CRUD.Models
{
    public class FormModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string college { get; set; }
        public string course { get; set; }
        public string district { get; set; }
        public long mobile { get; set; }
        public int pincode { get; set; }
        public int regid { get; set; }
    }
}