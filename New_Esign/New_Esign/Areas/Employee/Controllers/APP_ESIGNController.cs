using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using New_Esign.AppCode;
using New_Esign.Areas.Administrators.Models;
using New_Esign.Areas.Employee.Models;
using New_Esign.Common;
using New_Esign.Controllers;
using NewModel.EF;
using PagedList;

namespace New_Esign.Areas.Employee.Controllers
{
    public class APP_ESIGNController : BaseUserController
    {
        private DBConnectData db = new DBConnectData();

        private SQLServerDBHelper sqlHelp = new SQLServerDBHelper("ESignDB");
        // GET: Employee/APP_ESIGN
        //[OutputCache(Location = System.Web.UI.OutputCacheLocation.Client, Duration = 3600 * 24)]
        public ActionResult Index(int? page,string searching)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            NewCode newCode = new NewCode();
            var model = newCode.ListIssue();
            var modelSea = db.DATA_APP_ESIGN.Where(x => x.APPNO.Contains(searching) || searching == null || x.ApplicantNo.Contains(searching) || x.Title.Contains(searching) || x.ApplicantName.Contains(searching)).ToList();
            var modelSear = modelSea.OrderByDescending(m => m.APPID).ToList();
            return View(modelSear.ToPagedList(pageNumber,pageSize));
        }

        //Hien thi trang khai bao ban quyen phan mem
        public ActionResult ListSoftWare(int? page,string searching)
        {
            if (page == null) page = 1;
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            NewCode nCode = new NewCode();
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var emp = session.UserID.Trim();
            bool checkLv = nCode.checkLevel(emp,"ITNETWORK");
           
            if (checkLv)
            {
                var model = nCode.listDeclare(searching);

                var mod = from m in model select m;

                //var modelSea =model.Data_ .Where(x => x.APPNO.Contains(searching) || searching == null || x.ApplicantNo.Contains(searching) || x.USERNAME.Contains(searching) || x.AppContent.Contains(searching) || x.APPREASON.Contains(searching));
                //var modelSear = modelSea.OrderByDescending(m => m.APPNO).ToList();
                return View(model.ToPagedList(pageNumber, pageSize));
            }
            else
                return RedirectToAction("WaitingForYourApproval", "APP_ESIGN");
        }
       // [OutputCache(Location = System.Web.UI.OutputCacheLocation.Client, Duration = 3600 * 24)]
        public ActionResult WaitingForYourApproval(int? page, string searching)
        {
            //string sqlDB = 
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var emp = session.UserID.Trim();
            NewCode newCod = new NewCode();
            var mod = newCod.listWating(emp);
            var modelSea = db.DATA_APP_ESIGN.Where(x => x.APPNO.Contains(searching) || searching == null || x.ApplicantNo.Contains(searching) || x.Title.Contains(searching)|| x.ApplicantName.Contains(searching)).ToList();
            var modelS = modelSea.Where(x => x.Checkwait.Contains(emp) ).ToList();
            var modelSear = modelS.OrderByDescending(m => m.APPID).ToList();

            return View(modelSear.ToPagedList(pageNumber, pageSize));
        }
        // GET: Employee/APP_ESIGN/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATA_APP_ESIGN dATA_APP_ESIGN = db.DATA_APP_ESIGN.Find(id);
            if (dATA_APP_ESIGN == null)
            {
                return HttpNotFound();
            }
            return View(dATA_APP_ESIGN);
        }

        // GET: Employee/APP_ESIGN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/APP_ESIGN/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "APPID,APPNO,APPSTATUS,Checkwait,APPSTATES,USEREMP,COSTCODE," +
            "USERDEPARTMENT,USERNAME,USERMAIL,USERPHONE,FACTORY,PRIORITY,APPREASON,REQUIREDDEPARTMENT,CODEWORKSID,APPTYPE," +
            "CHECKWAITNAME,BUID,SiteID,TIMECREATE,DOU,FileName,FileContent,ApplicantNo,ApplicantName,ApplicantCode,ApplicantMail" +
            ",ApplicantPhone,ApplicantDep,FormID,Recipientunit,Organizer,Copysubmission,Page,Issuer,Documentnumber,Daycreate,Title,A" +
            "ppContent,Signer1No,Signer1Name,Signer2No,Signer2Name,Signer3No,Signer3Name,Signer4No,Signer4Name,Signer5No,Signer5Name," +
            "Signer6No,Signer6Name,Signer7No,Signer7Name,Signer8No,Signer8Name,Signer9No,Signer9Name,Signer2NoAgent,Signer2NameAgent," +
            "Signer3NoAgent,Signer3NameAgent,Signer4NoAgent,Signer4NameAgent,Signer5NoAgent,Signer5NameAgent,Signer6NoAgent,Signer6NameAgent," +
            "Signer7NoAgent,Signer7NameAgent,Signer8NoAgent,Signer8NameAgent,Signer9NoAgent,Signer9NameAgent")] DATA_APP_ESIGN dATA_APP_ESIGN)
        {
            if (ModelState.IsValid)
            {
                db.DATA_APP_ESIGN.Add(dATA_APP_ESIGN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dATA_APP_ESIGN);
        }

        // GET: Employee/APP_ESIGN/Edit/5
        public ActionResult Edit(string appNo)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //DATA_APP_ESIGN dATA_APP_ESIGN = db.DATA_APP_ESIGN.Find(id);
            //if (dATA_APP_ESIGN == null)
            //{
            //    return HttpNotFound();
            //}
            //var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            //if(session.UserID.Trim() != dATA_APP_ESIGN.Checkwait.Trim())
            //{
            //    return RedirectToAction("Index");
            //}
            //string appNo = dATA_APP_ESIGN.APPNO.Trim().ToString();
            ApprovalApp approval = getApprovalApp(appNo);
            return View(approval);
        }
        
        //lay danh sach
        [HttpGet]
        private List<DATA_APP_ESIGN> GetFileListApp(string appno)
        {
            DBConnectData cn = new DBConnectData();
            object[] sqlParams =
            {                
                new SqlParameter("@APPNO", appno),
            };
            var res = cn.Database.SqlQuery<DATA_APP_ESIGN>("SP_getfile_app @APPNO", sqlParams).ToList();
            return res;
            
        }
        //down file attach
        [HttpGet]
        public FileResult DownloadFilesApp(string appno)
        {
            //List<Application> ObjFiles = GetFileListApp();
            //var FileByID = (from FC in ObjFiles
            //                where FC.ApplicationNo.Equals(id)
            //                select new { FC.FileName, FC.FileContent }).ToList().FirstOrDefault();

            //return File(FileByID.FileContent, "application/pdf", FileByID.FileName);
            try
            {
                List<DATA_APP_ESIGN> ObjFiles = GetFileListApp(appno);
                var FileByID = (from FC in ObjFiles
                                where FC.APPNO == appno
                                select new { FC.FileName, FC.FileContent }).ToList().FirstOrDefault();
                return File(FileByID.FileContent, "application/pdf", FileByID.FileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //lay du lieu trang ky don        
        private ApprovalApp getApprovalApp(string appNo)
        {
            ApprovalApp aprApp = new ApprovalApp();
            string sqlQuery = @"select * from APPROVE_SIGN where APPNO = '" + appNo + "'";
            SQLServerDBHelper dBHelper = new SQLServerDBHelper("EsignDB");
            DataTable tb = dBHelper.DoSQLSelect(sqlQuery);
            string sqlQuery1 = @"select * from DATA_APP_ESIGN where APPNO = '" + appNo + "'";
            DataTable tb1 = dBHelper.DoSQLSelect(sqlQuery1);
            //aprApp.EmpModels = new EmpModel();
            // don nguoi dung lam
            EmpModel empM = new EmpModel();
            if (tb1.Rows.Count > 0)
            {
                DataRow dr1 = tb1.Rows[0];
                empM.APPSTATES = dr1["APPSTATES"].ToString();
                empM.APPNO = dr1["APPNO"].ToString();
                empM.Checkwait = dr1["Checkwait"].ToString();
                empM.ApplicantNo = dr1["ApplicantNo"].ToString();
                empM.ApplicantName = dr1["ApplicantName"].ToString();
                empM.ApplicantCode = dr1["ApplicantCode"].ToString();
                empM.ApplicantMail = dr1["ApplicantMail"].ToString();
                empM.ApplicantPhone = dr1["ApplicantPhone"].ToString();
                empM.ApplicantDep = dr1["ApplicantDep"].ToString();
                empM.Recipientunit = dr1["Recipientunit"].ToString();
                empM.Organizer = dr1["Organizer"].ToString();
                empM.Copysubmission = dr1["Copysubmission"].ToString();
                empM.Page = dr1["Page"].ToString();
                empM.Issuer = dr1["Issuer"].ToString();
                empM.Documentnumber = dr1["Documentnumber"].ToString();
                empM.Daycreate = dr1["Daycreate"].ToString();
                empM.Title = dr1["Title"].ToString();
                empM.AppContent = dr1["AppContent"].ToString();
                empM.FileName = dr1["FileName"].ToString();
                empM.Signer3No = dr1["Signer3No"].ToString();
                empM.Signer3Name = dr1["Signer3Name"].ToString();
                empM.Signer4No = dr1["Signer4No"].ToString();
                empM.Signer4Name = dr1["Signer4Name"].ToString();
                empM.Signer5No = dr1["Signer5No"].ToString();
                empM.Signer5Name = dr1["Signer5Name"].ToString();
                empM.Signer6No = dr1["Signer6No"].ToString();
                empM.Signer6Name = dr1["Signer6Name"].ToString();
                empM.Username = dr1["USERNAME"].ToString();
                //empM.FileContent = dr1["FileContent"].ToString();
                //empM.FileContent = Convert.ToByte(dr1["FileContent"].);
            }
            List<APPROVE_SIGN> list_A = new List<APPROVE_SIGN>();
            long approveID = 0;
            string appID = "";
            string approverName = "";
            string approverNo = "";
            string processName = "";
            DateTime time = DateTime.Now;
            string note = "";
            string status = "";
            string agentIP = "";
            string agent = "";
            if (tb.Rows.Count > 0)
            {
                //DataRow dr = tb.Rows[0];
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    //approveID = Convert.ToInt32(tb.Rows[i]["APPROVEID"].ToString());
                    appID = tb.Rows[i]["APPNO"].ToString();
                    approverName = tb.Rows[i]["APPROVERNAME"].ToString();
                    approverNo = tb.Rows[i]["APPROVEREMP"].ToString();
                    processName = tb.Rows[i]["PROCESSNAME"].ToString();
                    note = tb.Rows[i]["NOTES"].ToString();
                    status = tb.Rows[i]["STATUS"].ToString();
                    time = Convert.ToDateTime(tb.Rows[i]["TIMEAPPROVE"].ToString());
                    //agentIP = tb.Rows[i]["AGENTEMP"].ToString();
                    //agent = tb.Rows[i]["AGENTNAME"].ToString();
                    list_A.Add(new APPROVE_SIGN
                    {
                        APPROVEID = approveID,
                        APPNO = appID,
                        APPROVERNAME = approverName,
                        APPROVEREMP = approverNo,
                        PROCESSNAME = processName,
                        NOTES = note,
                        STATUS = status,
                        TIMEAPPROVE = time
                        //AGENTEMP = agentIP,
                        //AGENTNAME = agent
                    });
                }
            }
            aprApp.APPROVEs = list_A;
            aprApp.EmpModels = empM;

            return aprApp;
        }
        //hien thi trang ky don
        public ActionResult EditApp(string appNo)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];

            ApprovalApp approval = getApprovalApp(appNo);
            
                return View(approval);
            
        }
        //ky don
        [HttpPost]
        public ActionResult EditApp(ApprovalApp approvals, string ApprovalButton)
        {
            var subM = new Submit();
            var newCode =new NewCode();
            switch (ApprovalButton )
            {
                case "Approval":
                    {
                        
                        //string no1 = approvals.NoteApproval;
                        //string no3 = approvals.EmpModels.APPNO;

                        //subM.checkStateApp("Approval", no3, no1);

                        bool kqNow = subM.SigningApp(approvals.EmpModels.APPNO, "ok");
                        //string no2 = "Reject";
                        break;
                    }
                case "Reject":
                    {
                        //string no1 = approvals.NoteApproval;
                        //string no3 = approvals.EmpModels.APPNO;

                        //subM.checkStateApp("Reject", no3, no1);
                        //string no2 = "Reject";
                        newCode.getDataToModel("20200731094049");
                        break;
                    }
                case "Submit":
                    {

                        //var files = Request.Files["file"];
                        //string no3 = approvals.EmpModels.APPNO;
                        //string no1 = approvals.NoteApproval;
                        //if (files != null)
                        //{
                        //    subM.checkStateApp("Submit", no3, no1);
                        //    String FileExt = Path.GetExtension(files.FileName).ToUpper();
                        //    if (FileExt == ".PDF" || FileExt == ".XLSX" || FileExt == ".XLS")
                        //    {

                        //        string _fileName = approvals.EmpModels.APPNO + Path.GetFileName(files.FileName);

                        //        String filePath = "/UploadFiles/" + _fileName;
                        //        string _path = Path.Combine(Server.MapPath("~/UploadFiles"), _fileName);
                        //        //Stream str = files.InputStream;
                        //        //BinaryReader Br = new BinaryReader(str);
                        //        //Byte[] FileDet = Br.ReadBytes((Int32)str.Length);
                        //        //files.SaveAs(MapPath(filePath));
                        //        files.SaveAs(_path);
                        //        //files.SaveAs(MapPath)
                        //        approvals.EmpModels.FileName = files.FileName;
                        //        approvals.EmpModels.Username = filePath;
                        //        //appEmp.TIMECREATE = DateTime.Now;
                        //        //CreateApplication(appEmp);  
                        //        var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                        //        var signList = newCode.getListManager(session.UserID.Trim());
                        //        string[] signemp = signList.Split(';');
                        //        string signemp1 = signemp[0];
                        //        string signemp2 = signemp[1];
                        //        var signname11 = newCode.getNameEmp(signemp1);
                        //        var signname22 = newCode.getNameEmp(signemp2);
                        //        approvals.EmpModels.APPSTATES = "020";
                        //        approvals.EmpModels.Signer1No = signemp1;
                        //        approvals.EmpModels.Signer1Name = signname11;
                        //        approvals.EmpModels.Checkwait = approvals.EmpModels.Signer1No;
                        //        approvals.EmpModels.CHECKWAITNAME = approvals.EmpModels.Signer1Name;
                        //        approvals.EmpModels.APPSTATUS = "Waiting...";


                        //        approvals.EmpModels.Signer2No = signemp2;
                        //        approvals.EmpModels.Signer2Name = signname22;
                        //        newCode.UpdatenewAppFormIT02(approvals, no3);
                        //        break;
                        //    }
                        //    else
                        //    {
                        //        //ViewBag.FileStatus = "Invalid file format!";
                        //        SetAlert("Invalid file format!", "danger");
                        //        return View();
                        //    }
                        //}
                        //else
                        //{

                        //    //string no3 = approvals.EmpModels.APPNO;

                        //    subM.checkStateApp("Submit", no3, no1);
                        //    var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                        //    var signList = newCode.getListManager(session.UserID.Trim());
                        //    string[] signemp = signList.Split(';');
                        //    string signemp1 = signemp[0];
                        //    string signemp2 = signemp[1];
                        //    var signname11 = newCode.getNameEmp(signemp1);
                        //    var signname22 = newCode.getNameEmp(signemp2);
                        //    approvals.EmpModels.APPSTATES = "020";
                        //    approvals.EmpModels.Signer1No = signemp1;
                        //    approvals.EmpModels.Signer1Name = signname11;
                        //    approvals.EmpModels.Checkwait = approvals.EmpModels.Signer1No;
                        //    approvals.EmpModels.CHECKWAITNAME = approvals.EmpModels.Signer1Name;
                        //    approvals.EmpModels.APPSTATUS = "Waiting...";


                        //    approvals.EmpModels.Signer2No = signemp2;
                        //    approvals.EmpModels.Signer2Name = signname22;

                        //    newCode.Update1newAppFormIT02(approvals, no3);                          

                          break;
                        //}

                    }
            }  
            if(ApprovalButton== "Approval")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
        // POST: Employee/APP_ESIGN/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "APPID,APPNO,APPSTATUS,Checkwait,APPSTATES,USEREMP,COSTCODE,USERDEPARTMENT,USERNAME,USERMAIL,USERPHONE,FACTORY,PRIORITY,APPREASON,REQUIREDDEPARTMENT,CODEWORKSID,APPTYPE,CHECKWAITNAME,BUID,SiteID,TIMECREATE,DOU,FileName,FileContent,ApplicantNo,ApplicantName,ApplicantCode,ApplicantMail,ApplicantPhone,ApplicantDep,FormID,Recipientunit,Organizer,Copysubmission,Page,Issuer,Documentnumber,Daycreate,Title,AppContent,Signer1No,Signer1Name,Signer2No,Signer2Name,Signer3No,Signer3Name,Signer4No,Signer4Name,Signer5No,Signer5Name,Signer6No,Signer6Name,Signer7No,Signer7Name,Signer8No,Signer8Name,Signer9No,Signer9Name,Signer2NoAgent,Signer2NameAgent,Signer3NoAgent,Signer3NameAgent,Signer4NoAgent,Signer4NameAgent,Signer5NoAgent,Signer5NameAgent,Signer6NoAgent,Signer6NameAgent,Signer7NoAgent,Signer7NameAgent,Signer8NoAgent,Signer8NameAgent,Signer9NoAgent,Signer9NameAgent")] DATA_APP_ESIGN dATA_APP_ESIGN)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var newCode = new NewCode();
        //        var subM = new Submit();


        //        //db.Entry(dATA_APP_ESIGN).State = EntityState.Modified;
        //        //db.SaveChanges();
        //        //subM.checkStateApp(dATA_APP_ESIGN.APPNO.Trim());
        //        return RedirectToAction("Index");
        //    }
        //    return View(dATA_APP_ESIGN);
        //}

        // GET: Employee/APP_ESIGN/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATA_APP_ESIGN dATA_APP_ESIGN = db.DATA_APP_ESIGN.Find(id);
            if (dATA_APP_ESIGN == null)
            {
                return HttpNotFound();
            }
            return View(dATA_APP_ESIGN);
        }

        // POST: Employee/APP_ESIGN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DATA_APP_ESIGN dATA_APP_ESIGN = db.DATA_APP_ESIGN.Find(id);
            db.DATA_APP_ESIGN.Remove(dATA_APP_ESIGN);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
