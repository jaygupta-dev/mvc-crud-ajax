using AJAX_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJAX_CRUD.Controllers
{
    public class HomeController : Controller
    {
        DBLayer db = new DBLayer();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public JsonResult AddDetails(FormModel md)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@name",md.name),
                new SqlParameter("@email",md.email),
                new SqlParameter("@mobile",md.mobile),
                new SqlParameter("@college",md.college),
                new SqlParameter("@course",md.course),
                new SqlParameter("@district",md.district),
                new SqlParameter("@pincode",md.pincode)
            };
            int res = db.ExecuteDML("sp_add_details", para);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ShowData()
        {
            DataTable dt = db.ExecuteSelect("sp_show_all_details");
            List<FormModel> list = new List<FormModel>();
            foreach (DataRow dr in dt.Rows)
            {
                FormModel md = new FormModel();
                md.name = dr["name"].ToString();
                md.email = dr["email"].ToString();
                md.college = dr["college"].ToString();
                md.course = dr["course"].ToString();
                md.district = dr["district"].ToString();
                md.mobile = Convert.ToInt64(dr["mobile"]);
                md.regid = Convert.ToInt32(dr["regid"]);
                md.pincode = Convert.ToInt32(dr["pincode"]);
                list.Add(md);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteOneData(FormModel md)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@regid",md.regid)
            };
            int res = db.ExecuteDML("sp_delete_one_record", para);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SelectOneData(FormModel md)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@regid",md.regid)
            };
            DataTable dt = db.ExecuteSelect("sp_select_one_record", para);
            List<FormModel> list = new List<FormModel>();
            foreach (DataRow dr in dt.Rows)
            {
                md.regid = Convert.ToInt32(dr["regid"]);
                md.name = dr["name"].ToString();
                md.email = dr["email"].ToString();
                md.college = dr["college"].ToString();
                md.course = dr["course"].ToString();
                md.district = dr["district"].ToString();
                md.mobile = Convert.ToInt64(dr["mobile"]);
                md.pincode = Convert.ToInt32(dr["pincode"]);
                list.Add(md);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateDetails(FormModel md)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@regid",md.regid),
                new SqlParameter("@name",md.name),
                new SqlParameter("@email",md.email),
                new SqlParameter("@mobile",md.mobile),
                new SqlParameter("@college",md.college),
                new SqlParameter("@course",md.course),
                new SqlParameter("@district",md.district),
                new SqlParameter("@pincode",md.pincode),
            };
            int res = db.ExecuteDML("sp_update_details", para);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}