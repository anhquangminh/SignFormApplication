using New_Esign.AppCode;
using New_Esign.Areas.Employee.Models;
using New_Esign.Common;
using New_Esign.Controllers;
using NewModel.Dao;
using NewModel.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace New_Esign.Areas.Employee.Controllers
{
    public class CreateNewAppController : BaseUserController
    {
        private SQLServerDBHelper sqlHelp = new SQLServerDBHelper();
        private DBConnectData db = new DBConnectData();
        // GET: Employee/CreateNewApp
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewCreate()
        {
            setViewDepartment();
            return View();
        }

        [HttpPost]
        public ActionResult NewCreate(DepartmentNo appNew)
        {
            if(ModelState.IsValid)
            {
                    var sessionLay = (UserLogin)Session[CommonConstants.USER_SESSION];
                    var empLay = sessionLay.UserID.Trim();

                    NewCode nCode = new NewCode();
                    setViewDepartment();
                    string dropVa = appNew.FormName;
                    Session["formName"] = dropVa;
                    string ReDirAction = "";
                    string ReDirControll = "";

                    string listLink = "";
                    DataTable dataTable = tBleForm(dropVa);
                    if(dataTable.Rows.Count > 0)
                    {
                        listLink = dataTable.Rows[0]["LinkForm"].ToString();
                        string[] listRedi = listLink.Split(';');
                        if(listRedi.Length > 1)
                        {
                            ReDirAction = listRedi[0].ToString();
                            ReDirControll = listRedi[1].ToString();
                            return RedirectToAction(ReDirAction, ReDirControll, new { area = "Employee" });
                        }                       
                    }
                    else
                    {
                        ViewBag.ErrorType = " 表单正在开发，请再次进入 / Mẫu đơn đang được phát triển, vui lòng quay lại sau ";
                        return View("NewCreate");
                    }                  
                    //return RedirectToAction("FORM_IT_01", "ApplicationType", new { area = "Employee" });                
            }
            ViewBag.ErrorType = " 表单正在开发，请再次进入 / Mẫu đơn đang được phát triển, vui lòng quay lại sau ";
            return View("NewCreate");
        }
        
        public ActionResult CreateApp()
        {            
            return View();
        }
        //[HttpPost]
        //public ActionResult CreateApp(int formID)
        //{

        //    DataTable tb = new DataTable();
        //    tb = listFormContent(formID);
        //    //DoSQLSelect tb
        //    return View();
        //}

            // get form name
        public JsonResult getFormName(string depart)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Form> projectList = db.Forms.Where(x => x.Department == depart).ToList();
            return Json(projectList, JsonRequestBehavior.AllowGet);
        }
        public void setViewDepartment(long? selectedID = null)
        {
            var dao = new CodeDao();
            ViewBag.Department = new SelectList(dao.ListDepartment(), "Department", "Department", selectedID);
        }

        public DataTable tBleForm(string formName)
        {
            DataTable table = new DataTable();
            string strQuery = @"select * from Forms where formName='"+formName+"' ";
            table = sqlHelp.DoSQLSelect(strQuery);           
            return table;
        }
    }
}