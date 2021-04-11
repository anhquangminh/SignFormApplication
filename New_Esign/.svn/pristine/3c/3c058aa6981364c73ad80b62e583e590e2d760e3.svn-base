using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace New_Esign.Controllers
{
    public class GetterController : Controller
    {
        // GET: Getter
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetListSite()
        {
            var listSite = new List<Tuple<string, string>>();
            SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            DataTable dt = db.DoSQLSelect("SELECT * FROM Site");
            foreach (DataRow dr in dt.Rows)
            {
                listSite.Add(Tuple.Create(dr["SiteID"].ToString().Trim(), dr["SiteName"].ToString().Trim()));
            }
            return Json(listSite, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetListBu(string site)
        {
            var listBU = new List<Tuple<string, string>>();
            SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            DataTable dt = db.DoSQLSelect("SELECT * FROM BU WHERE SiteID='" + site.Trim() + "'");
            foreach (DataRow dr in dt.Rows)
            {
                listBU.Add(Tuple.Create(dr["BUID"].ToString().Trim(), dr["BUName"].ToString().Trim()));
            }
            return Json(listBU, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetEmployeeName(string empNO)
        {
            return Json(EmployeeHelper.GetEmployeeName(empNO), JsonRequestBehavior.AllowGet);
        }

    }
}