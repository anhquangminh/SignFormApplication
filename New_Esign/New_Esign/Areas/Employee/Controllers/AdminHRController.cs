using New_Esign.Areas.Employee.Models;
using New_Esign.Common;
using New_Esign.Controllers;
using NewModel.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New_Esign.Areas.Employee.Controllers
{
    

    public class AdminHRController : BaseUserController
    {
        public SQLServerDBHelper sqlHelp = new SQLServerDBHelper();
        // GET: Employee/AdminHR
        public ActionResult Index()
        {
            return View();
        }

        // Thiet lap luu trinh ky 
        [HttpGet]
        public ActionResult SetUpSigner()
        {
            FORM_IT_01Model reqModel = new FORM_IT_01Model();

            setViewDepartment();
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var emp = session.UserID.Trim();
            setViewDepartment();
            if (emp == "V0957033")
                reqModel.Title1Example = "batdau";
            else reqModel.Title1Example = "khongquyen";

            return View(reqModel);
        }

        [HttpPost]
        public ActionResult SetUpSigner(FORM_IT_01Model reqModel,string Approval)
        {
            setViewDepartment();
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var emp = session.UserID.Trim();
            if (ModelState.IsValid)
            {
                switch(Approval)
                {
                    case "Next":
                        {
                            if (emp == "V0957033")
                            {
                                
                                if (reqModel.Title2 == "FORM_HR_01" || reqModel.Title2 == "FORM_HR_02")
                                {
                                    reqModel.Title1Example = "Tieptheo";
                                    string strQuery = @"select * from Forms where formName = '" + reqModel.Title2.Trim() + "' ;";
                                    DataTable tb = new DataTable();
                                    tb = sqlHelp.DoSQLSelect(strQuery);
                                    if (tb.Rows.Count > 0)
                                    {

                                        int formD = Convert.ToInt32(tb.Rows[0]["FormID"].ToString());
                                        string sqlQuery1 = @"select * from SubmitSign where FormID = '" + formD + "' order by SignNo asc";
                                        DataTable tbSignProcess = new DataTable();
                                        tbSignProcess = sqlHelp.DoSQLSelect(sqlQuery1);
                                        string signEm = "";
                                        string SignNa = "";
                                        string statusNa = "";
                                        int step1 = 0;
                                        //string agent = "";
                                        List<ApprovalAppModel> listAppro = new List<ApprovalAppModel>();

                                        if (tbSignProcess.Rows.Count > 0)
                                        {
                                            for (int i = 0; i < tbSignProcess.Rows.Count; i++)
                                            {
                                                step1 = i;
                                                statusNa = tbSignProcess.Rows[i]["SignName"].ToString();

                                                listAppro.Add(new ApprovalAppModel
                                                {
                                                    step = step1,
                                                    statusName = statusNa,
                                                    signEmpNo = "",
                                                    SignName = ""
                                                });
                                            }
                                        }
                                        reqModel.approvalApps = listAppro;
                                        reqModel.Title3Example = tb.Rows[0]["FormID"].ToString();
                                    }
                                }
                            }
                            else
                            {

                            }
                            break;
                        }
                    case "Return":
                        {
                            reqModel.Title1Example = "khongthayduoc";
                            break;
                        }
                    case "submit_ok":
                        {
                            var pSelect = Request.Form["testKQ"].ToString();
                            string[] signSelect = pSelect.Split(',');
                            signSelect = signSelect.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                            string strQueryDel = @"delete SubmitSign where FormID='"+ reqModel.Title3Example + "';";
                            sqlHelp.ExcuteNonQuery(strQueryDel);
                            int formS = 32;
                            bool checkFlag = false;

                            for (int i =0; i< signSelect.Length;i++)
                            {
                                string strInsert = @"insert into SubmitSign(FormID,SignNo,SignName) values ('"+formS+"','"+i+"',N'"+signSelect[i].ToString()+"') ;";
                                checkFlag = sqlHelp.ExcuteNonQuery(strInsert);
                                if (checkFlag == false) break;
                            }
                            if(checkFlag)
                                reqModel.Title1Example = "thanhcong";
                            else
                                reqModel.Title1Example = "thatbai";
                            break;
                        }
                }
                
   
            }
            return View(reqModel);
        }

        // lay thong tin don 
        public void setViewDepartment(long? selectedID = null)
        {
            var dao = new CodeDao();
            ViewBag.Title1 = new SelectList(dao.ListDepartment(), "Department", "Department", selectedID);
        }

        //unn
        public DataTable tBleForm(string formName)
        {
            DataTable table = new DataTable();
            string strQuery = @"select * from Forms where formName='" + formName + "' ";
            table = sqlHelp.DoSQLSelect(strQuery);
            return table;
        }
    }
}