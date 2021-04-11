using New_Esign.AppCode;
using New_Esign.Areas.Employee.Models;
using New_Esign.Common;
using New_Esign.Controllers;
using NewModel.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace New_Esign.Areas.Employee.Controllers
{
    public class ApplicationTypeController : BaseUserController
    {
        private SQLServerDBHelper dbHelpers = new SQLServerDBHelper("ESignDB");

        //private UserLogin session = (UserLogin)Session[CommonConstants.USER_SESSION];
        // GET: Employee/ApplicationType
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
       // [OutputCache(Location = System.Web.UI.OutputCacheLocation.Server, Duration = 3600 * 24, VaryByParam = "None")]
        public ActionResult FORM_IT_01()
        {
            FORM_IT_01Model formIT01 = new FORM_IT_01Model();
            var formID = "FORM_IT_01";
            var newCode = new NewCode();
            
            if(formID == null)
            {
                return RedirectToAction("");
            }
           

            formIT01.FormID = newCode.getFormID(formID);
            string sqlQuery = @"select * from TitleForm where FormID = '" + formIT01.FormID + "'";
            DataTable dataTitle = new DataTable();
            dataTitle = dbHelpers.DoSQLSelect(sqlQuery);
            string titleBu = "";
            string titleEx = "";
            if (dataTitle.Rows.Count > 0)
            {
                for (int i = 0; i < dataTitle.Rows.Count; i++)
                {
                    titleBu += dataTitle.Rows[i]["FormContent"].ToString() + ";";
                    titleEx += dataTitle.Rows[i]["Example"].ToString() + ";";
                }
            }

            // gan gia tri cho list signer
            string sqlQuery1 = @"select * from SubmitSign where FormID = '" + formIT01.FormID + "' order by SignNo asc";
            DataTable tbSignProcess = new DataTable();
            tbSignProcess = dbHelpers.DoSQLSelect(sqlQuery1);
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

            formIT01.approvalApps = listAppro;
            // gan gia tri  cho title 
            string[] titleList = titleBu.Split(';');

            formIT01.Title0 = titleList[0];
            formIT01.Title1 = titleList[1];
            formIT01.Title2 = titleList[2];
            formIT01.Title3 = titleList[3];
            formIT01.Title4 = titleList[4];

            formIT01.Title5 = titleList[5];
            formIT01.Title6 = titleList[6];
            formIT01.Title7 = titleList[7];
            formIT01.Title8 = titleList[8];
            formIT01.Title9 = titleList[9];

            formIT01.Title10 = titleList[10];
            formIT01.Title11 = titleList[11];
            formIT01.Title12 = titleList[12];
            formIT01.Title13 = titleList[13];
            formIT01.Title14 = titleList[14];

            formIT01.Title15 = titleList[15];
            formIT01.Title16 = titleList[16];
            formIT01.Title17 = titleList[17];
            formIT01.Title18 = titleList[18];
            formIT01.Title19 = titleList[19];

            formIT01.Title20 = titleList[20];
            formIT01.Title21 = titleList[21];
            formIT01.Title22 = titleList[22];
            formIT01.Title23 = titleList[23];
            formIT01.Title24 = titleList[24];

            formIT01.Title25 = titleList[25];

            formIT01.Title26 = titleList[26];

            string[] exampleList = titleEx.Split(';');
            formIT01.Title0Example = exampleList[0];
            formIT01.Title1Example = exampleList[1];
            formIT01.Title5Example = exampleList[5];
            formIT01.Title7Example = exampleList[7];
            formIT01.Title8Example = exampleList[8];

            formIT01.Title10Example = exampleList[10];
            formIT01.Title11Example = exampleList[11];
            formIT01.Title12Example = exampleList[12];
            formIT01.Title13Example = exampleList[13];
            formIT01.Title14Example = exampleList[14];
            formIT01.Title15Example = exampleList[15];
            formIT01.Title16Example = exampleList[16];
            formIT01.Title17Example = exampleList[17];

            formIT01.Title26Example = exampleList[26];



            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            formIT01.Title3Content =  session.UserName.ToString();
            formIT01.Title4Content = session.UserID.ToString();

            PostmanService.PostmanServiceSoapClient postman = new PostmanService.PostmanServiceSoapClient();
            DataTable tbPost = new DataTable();
            tbPost = postman.GetEmpInfomation(formIT01.Title4Content.Trim());

            formIT01.Title17Content = tbPost.Rows[0]["NOTES_ID"].ToString();
            formIT01.Title1Content = tbPost.Rows[0]["CURRENT_OU_NAME"].ToString();
            if (formIT01.Title17Content == null || formIT01.Title17Content == "")
            {
                formIT01.Title17Content = "";
            }
            //formIT01.titleName = titleList;
            setViewFac();
            var a = titleList.Count();      

            return View(formIT01);
        }

        [HttpPost]        
        public ActionResult FORM_IT_01(FORM_IT_01Model formIT01)
        {
            var test1 = Request.Form["testKQ"].ToString();
            var test2 = Request.Form["testKQ1"].ToString();
            var test3 = Request.Form["testKQ2"].ToString();
            //try
            //{
            //    setViewFac();
            //    var formID = Session["formName"].ToString();
            //    var newCode = new NewCode();
            //    formIT01.AppNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            //    //Session["APPNO"] = formIT01.AppNo;
            //    formIT01.FormID = newCode.getFormID(formID);
            //    string sqlQuery = @"select * from TitleForm where FormID = '" + formIT01.FormID + "'";
            //    DataTable dataTitle = new DataTable();
            //    dataTitle = dbHelpers.DoSQLSelect(sqlQuery);
            //    string titleBu = "";
            //    if (dataTitle.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dataTitle.Rows.Count; i++)
            //        {
            //            titleBu += dataTitle.Rows[i]["FormContent"].ToString() + ";";
            //        }
            //    }

            //    string[] titleList = titleBu.Split(';');


            //    formIT01.Title0 = titleList[0];
            //    formIT01.Title1 = titleList[1];
            //    formIT01.Title2 = titleList[2];
            //    formIT01.Title3 = titleList[3];
            //    formIT01.Title4 = titleList[4];
            //    formIT01.Title5 = titleList[5];
            //    formIT01.Title6 = titleList[6];
            //    formIT01.Title7 = titleList[7];
            //    formIT01.Title8 = titleList[8];
            //    formIT01.Title9 = titleList[9];

            //    formIT01.Title10 = titleList[10];
            //    formIT01.Title11 = titleList[11];
            //    formIT01.Title12 = titleList[12];
            //    formIT01.Title13 = titleList[13];
            //    //formIT01.Title14 = titleList[14];
            //    //formIT01.Title15 = titleList[15];
            //    //formIT01.Title16 = titleList[16];
            //    formIT01.Title17 = titleList[17];
            //    formIT01.Title18 = titleList[18];
            //    formIT01.Title19 = titleList[19];
            //    formIT01.Title20 = titleList[20];
            //    formIT01.Title21 = titleList[21];
            //    formIT01.Title22 = titleList[22];
            //    formIT01.Title23 = titleList[23];
            //    formIT01.Title24 = titleList[24];
            //    formIT01.Title25 = titleList[25];

            //    formIT01.Title26 = titleList[26];

            //    string a = formIT01.Title14;
            //    string b = formIT01.Title15;
            //    string c = formIT01.Title16;
            //    //// test
            //    //string a = formIT01.Title4Content;

            //    //string b = formIT01.Title2;

            //    ////string c = HttpContext.Request.Form["title2"].ToString();
            //    string dataTiltle = formIT01.Title0 + ";" + formIT01.Title1 + ";" + formIT01.Title2 + ";" + formIT01.Title3 + ";" + formIT01.Title4 + ";";
            //    dataTiltle += formIT01.Title5 + ";" + formIT01.Title6 + ";" + formIT01.Title7 + ";" + formIT01.Title8 + ";" + formIT01.Title9 + ";";
            //    dataTiltle += formIT01.Title10 + ";" + formIT01.Title11 + ";" + formIT01.Title12 + ";" + formIT01.Title13 + ";" + formIT01.Title14 + ";";
            //    dataTiltle += formIT01.Title15 + ";" + formIT01.Title16 + ";" + formIT01.Title17 + ";" + formIT01.Title18 + ";" + formIT01.Title19 + ";";
            //    dataTiltle += formIT01.Title20 + ";" + formIT01.Title21 + ";" + formIT01.Title22 + ";" + formIT01.Title23 + ";" + formIT01.Title24 + ";" + formIT01.Title25 + "; " + formIT01.Title26 + ";";

            //    string[] arrayTitle = dataTiltle.Split(';');
            //    var arTitle = arrayTitle.Count();
            //    // lay duong dan file
            //    var files = Request.Files["file"];


            //    if (files != null)
            //    {
            //        String FileExt = Path.GetExtension(files.FileName).ToUpper();
            //        string _fileName = formIT01.AppNo + Path.GetFileName(files.FileName);

            //        String filePath = "/UploadFiles/" + _fileName;
            //        string _path = Path.Combine(Server.MapPath("~/UploadFiles"), _fileName);
            //        //Stream str = files.InputStream;
            //        //BinaryReader Br = new BinaryReader(str);
            //        //Byte[] FileDet = Br.ReadBytes((Int32)str.Length);
            //        //files.SaveAs(MapPath(filePath));
            //        files.SaveAs(_path);

            //        formIT01.Title22Content = filePath;
            //        formIT01.Title23Content = files.FileName;


            //    }
            //        //var files = Request.Files["file"];

            //    // gan gia tri cho content rong de tham vao mang
            //    if (formIT01.Title0Content == null) formIT01.Title0Content = "";

            //    if (formIT01.Title1Content == null) formIT01.Title1Content = "";

            //    if (formIT01.Title2Content == null) formIT01.Title2Content = "";

            //    if (formIT01.Title3Content == null) formIT01.Title3Content = "";

            //    if (formIT01.Title4Content == null) formIT01.Title4Content = "";

            //    if (formIT01.Title5Content == null) formIT01.Title5Content = "";

            //    if (formIT01.Title6Content == null) formIT01.Title6Content = "";

            //    if (formIT01.Title7Content == null) formIT01.Title7Content = "";

            //    if (formIT01.Title8Content == null) formIT01.Title8Content = "";

            //    if (formIT01.Title9Content == null) formIT01.Title9Content = "";

            //    if (formIT01.Title10Content == null) formIT01.Title10Content = "";

            //    if (formIT01.Title11Content == null) formIT01.Title11Content = "";

            //    if (formIT01.Title12Content == null) formIT01.Title12Content = "";

            //    if (formIT01.Title13Content == null) formIT01.Title13Content = "";

            //    if (formIT01.Title14Content == null) formIT01.Title14Content = "";

            //    if (formIT01.Title15Content == null) formIT01.Title15Content = "";

            //    if (formIT01.Title16Content == null) formIT01.Title16Content = "";

            //    //get mail cho nguoi lam don

            //    if (formIT01.Title17Content == null) formIT01.Title17Content = "";

            //    if (formIT01.Title18Content == null) formIT01.Title18Content = "";

            //    if (formIT01.Title19Content == null) formIT01.Title19Content = "";

            //    if (formIT01.Title20Content == null) formIT01.Title20Content = "";

            //    if (formIT01.Title21Content == null) formIT01.Title21Content = "";

            //    if (formIT01.Title22Content == null) formIT01.Title22Content = "";


            //    if (formIT01.Title23Content == null) formIT01.Title23Content = "";

            //    if (formIT01.Title24Content == null) formIT01.Title24Content = "";

            //    if (formIT01.Title25Content == null) formIT01.Title25Content = "";

            //    if (formIT01.Title26Content == null) formIT01.Title26Content = "";


            //    string dataContent = formIT01.Title0Content + ";" + formIT01.Title1Content + ";" + formIT01.Title2Content + ";" + formIT01.Title3Content + ";" + formIT01.Title4Content + ";";
            //    dataContent += formIT01.Title5Content + ";" + formIT01.Title6Content + ";" + formIT01.Title7Content + ";" + formIT01.Title8Content + ";" + formIT01.Title9Content + ";";
            //    dataContent += formIT01.Title10Content + ";" + formIT01.Title11Content + ";" + formIT01.Title12Content + ";" + formIT01.Title13Content + ";" + formIT01.Title14Content + ";";
            //    dataContent += formIT01.Title15Content + ";" + formIT01.Title16Content + ";" + formIT01.Title17Content + ";" + formIT01.Title18Content + ";" + formIT01.Title19Content + ";";
            //    dataContent += formIT01.Title20Content + ";" + formIT01.Title21Content + ";" + formIT01.Title22Content + ";" + formIT01.Title23Content + ";" + formIT01.Title24Content + ";" + formIT01.Title25Content + ";" + formIT01.Title26Content + ";";  

            //    formIT01.AppNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            //    string[] arrayContent = dataContent.Split(';');
            //    for(int i =0; i < arTitle; i++)
            //    {
            //        bool kq = newCode.insertTitleContent(formIT01.AppNo, arrayTitle[i], arrayContent[i], formIT01.FormID, i);
            //        if (kq == false)
            //        {
            //            break;
            //        }
            //    }
            //    // lay thong tin nguoi lam don
            //    var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            //    var emp = session.UserID.Trim();
            //    var name = session.UserName;

            //    //lay du lieu nguoi ky don
            //    string sqlQuery1 = @"select * from SubmitSign where FormID = '" + formIT01.FormID + "' order by SignNo asc";
            //    DataTable tbSignProcess = new DataTable();
            //    tbSignProcess = dbHelpers.DoSQLSelect(sqlQuery1);
            //    string signEmpNo1 = "";
            //    string SignName1 = "";
            //    string statusName1 = "";
            //    int step1 = 0;
            //    //string agent = "";

            //    if (tbSignProcess.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < tbSignProcess.Rows.Count; i++)
            //        {
            //            step1 = i;
            //            statusName1 = tbSignProcess.Rows[i]["SignName"].ToString();
            //            signEmpNo1 = formIT01.approvalApps[i].signEmpNo.ToString();
            //            SignName1 = formIT01.approvalApps[i].SignName.ToString();

            //            newCode.insertListSign(formIT01.AppNo, signEmpNo1, SignName1, statusName1, step1);
            //        }
            //        // them du lieu vao danh sach don
            //        newCode.insertAppData(formIT01.AppNo, tbSignProcess.Rows[1]["SignName"].ToString(), name , formIT01.approvalApps[1].SignName, DateTime.Now.ToString("yyyy/MM/dd HH:mm"), formIT01.approvalApps[1].signEmpNo,formIT01.FormID,1, formIT01.Title4Content.Trim(), formIT01.Title20);
            //    }
            //    Submit sm = new Submit();
            //    sm.f_submit("Submit", formIT01.AppNo, formIT01.FormID,formIT01.Title3Content, formIT01.Title4Content);
            //    //RedirectToAction("signingProcess.cshtml");
            //    SendMail sendM = new SendMail();

            //    sendM.insertSenmail1(formIT01.Title4Content.Trim(), formIT01.AppNo.Trim(), formIT01.Title20, formIT01.approvalApps[0].signEmpNo, "提交文件表格电子批准申请",formIT01.Title17Content);
            //    sendM.insertSenmail(formIT01.approvalApps[1].signEmpNo.Trim(), formIT01.AppNo.Trim(), formIT01.Title20, formIT01.approvalApps[0].signEmpNo, "文件電子簽核申請單等待簽核");
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            //return RedirectToAction("Index", "APP_ESIGN");
            return View("");
        }

        //trang ky don
        [HttpGet]
        public ActionResult Form_signing(string appNo)
        {
            NewCode newCode = new NewCode();
            FORM_IT_01Model fORM_IT_01 = newCode.getDataToModel(appNo);


            return View(fORM_IT_01);
        }
        [HttpPost]
        public ActionResult Form_signing(FORM_IT_01Model fORM_IT_, string ApprovalButton)
        {
            Submit sb = new Submit();
            bool kq = true;
            bool kq2 = true;
            string sqlQuery = "";
            string checkWait = "";
            if (fORM_IT_.AppContent == null) fORM_IT_.AppContent = " ";
            switch(ApprovalButton)
            {
                case "Approval":
                    kq = sb.f_insert_sub("通過", fORM_IT_.AppNo,fORM_IT_.AppContent);
                    kq2 = sb.SigningApp(fORM_IT_.AppNo, "Approval");

                    sqlQuery = @"select * from DATA_APP_ESIGN where APPNO='" + fORM_IT_.AppNo.Trim() + "' ;";
                    DataTable dataTable = dbHelpers.DoSQLSelect(sqlQuery);
                    checkWait = dataTable.Rows[0]["Checkwait"].ToString();
                    SendMail sen = new SendMail();
                    sen.insertSenmail(checkWait.Trim(), fORM_IT_.AppNo.Trim(), fORM_IT_.Title20, fORM_IT_.Title4Content.Trim(), "文件電子簽核申請單等待簽核");
                    break;
                case "Reject":
                    kq = sb.f_insert_sub("駁回", fORM_IT_.AppNo, fORM_IT_.AppContent);
                    kq2 = sb.SigningApp(fORM_IT_.AppNo, "Reject");

                    sqlQuery = @"select * from DATA_APP_ESIGN where APPNO='" + fORM_IT_.AppNo.Trim() + "' ;";
                    DataTable dataTable2 = dbHelpers.DoSQLSelect(sqlQuery);
                    checkWait = dataTable2.Rows[0]["Checkwait"].ToString();
                    SendMail sen2 = new SendMail();
                    bool kqsen = sen2.insertSenmail(checkWait.Trim(), fORM_IT_.AppNo.Trim(), fORM_IT_.Title20, fORM_IT_.Title4Content.Trim(), "文件電子簽核申請單被駁回");
                    //string kqte = "";
                    break;
                case "Submit":

                    break;
                case "Delete":
                    break;
            }
            

            return RedirectToAction("Index", "APP_ESIGN");
        }
        [HttpGet]
        public ActionResult signingProcess(string appNo)
        {

            FORM_IT_01Model fORM_IT_01 = new FORM_IT_01Model();

            List<ApprovalAppModel> listAppro = new List<ApprovalAppModel>();
            var formID = Session["formName"].ToString();
            var newCode = new NewCode();

            //fORM_IT_01.AppNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            //Session["APPNO"] = fORM_IT_01.AppNo;
            fORM_IT_01.FormID = newCode.getFormID(formID);

            string sqlQuery = @"select * from SubmitSign where FormID = '"+ fORM_IT_01.FormID + "' order by SignNo asc";
            DataTable tbSignProcess = new DataTable();
            tbSignProcess = dbHelpers.DoSQLSelect(sqlQuery);
            string signEmpNo1 = "";
            string SignName1 = "";
            string statusName1 = "";
            int step1 = 0;
            string agent = "";

            

            if(tbSignProcess.Rows.Count > 0)
            {
                for(int i =0;i < tbSignProcess.Rows.Count; i++)
                {
                    step1 = i;
                    statusName1 = tbSignProcess.Rows[i]["SignName"].ToString();

                    listAppro.Add(new ApprovalAppModel
                    {
                        step = step1,
                        statusName = statusName1,
                        signEmpNo = "",
                        SignName = ""
                        
                    });
                }               
            }

            fORM_IT_01.approvalApps = listAppro;

            return View(fORM_IT_01);
        }

        [HttpPost]
        public ActionResult signingProcess(FORM_IT_01Model fORM_IT_01s)
        {
            var formID = Session["formName"].ToString();
            var newCode = new NewCode();
            //fORM_IT_01.AppNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            //Session["APPNO"] = fORM_IT_01.AppNo;
            fORM_IT_01s.FormID = newCode.getFormID(formID);
            fORM_IT_01s.AppNo = Session["APPNO"].ToString();

            string sqlQuery = @"select * from SubmitSign where FormID = '" + fORM_IT_01s.FormID + "' order by SignNo asc";
            DataTable tbSignProcess = new DataTable();
            tbSignProcess = dbHelpers.DoSQLSelect(sqlQuery);
            string signEmpNo1 = "";
            string SignName1 = "";
            string statusName1 = "";
            int step1 = 0;
            string agent = "";



            if (tbSignProcess.Rows.Count > 0)
            {
                for (int i = 0; i < tbSignProcess.Rows.Count; i++)
                {
                    step1 = i;
                    statusName1 = tbSignProcess.Rows[i]["SignName"].ToString();
                    signEmpNo1 = fORM_IT_01s.approvalApps[i].signEmpNo.ToString();
                    SignName1 = fORM_IT_01s.approvalApps[i].SignName.ToString();

                    newCode.insertListSign(fORM_IT_01s.AppNo, signEmpNo1, SignName1, statusName1, step1);
                }
                
            }

            return View("appITForm02");
        }

        [HttpGet]
        public ActionResult appITForm02()
        {                       

            return View();
        }

        [HttpPost]
        public ActionResult appITForm02(EmpModel appEmp, HttpPostedFileBase files)
        {
            var newCode = new NewCode();
            appEmp.APPNO = DateTime.Now.ToString("yyyyMMddHHmmss");
            appEmp.FormID = newCode.getFormID("FORM_IT_02");

            //int formId = appEmp.FormID;
            appEmp.Daycreate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            DataTable tbSubsign = new DataTable();
            
            if (files != null)
            {
                String FileExt = Path.GetExtension(files.FileName).ToUpper();
                if (FileExt == ".PDF" || FileExt == ".XLSX" || FileExt == ".XLS")
                {
                    
                    string _fileName = appEmp.APPNO + Path.GetFileName(files.FileName);
                    
                    String filePath = "/UploadFiles/" + _fileName;
                    string _path = Path.Combine(Server.MapPath("~/UploadFiles"), _fileName);
                    //Stream str = files.InputStream;
                    //BinaryReader Br = new BinaryReader(str);
                    //Byte[] FileDet = Br.ReadBytes((Int32)str.Length);
                    //files.SaveAs(MapPath(filePath));
                    files.SaveAs(_path);
                    //files.SaveAs(MapPath)
                    appEmp.FileName = files.FileName;
                    appEmp.Username = filePath;
                    //var path1 = _path.Split('/UploadFiles/');
                    //appEmp.FileContent = FileDet;
                    //appEmp.TIMECREATE = DateTime.Now;
                    //CreateApplication(appEmp);                    
                }
                else
                {
                    //ViewBag.FileStatus = "Invalid file format!";
                    SetAlert("Invalid file format!", "danger");
                    return View();
                }
            }
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var signList = newCode.getListManager(session.UserID.Trim());
            string[] signemp = signList.Split(';');
            string signemp1 = signemp[0];
            string signemp2 = signemp[1];
            var signname11 = newCode.getNameEmp(signemp1);
            var signname22 = newCode.getNameEmp(signemp2);
            appEmp.APPSTATES = "";
            appEmp.Signer1No = signemp1;
            appEmp.Signer1Name = signname11;
            appEmp.Checkwait = appEmp.Signer1No;
            appEmp.CHECKWAITNAME = appEmp.Signer1Name;
            appEmp.APPSTATUS = "Waiting...";
            appEmp.ApplicantNo = session.UserID.Trim();
            appEmp.ApplicantName = session.UserName;
            appEmp.ApplicantCode = session.CostCode;
            appEmp.ApplicantMail = session.Mail;
            appEmp.ApplicantDep = session.Department;
           
            
            appEmp.Signer2No = signemp2;
            appEmp.Signer2Name = signname22;

            //appEmp.OrderNo = DateTime.Now.ToString("yyyymm")
            newCode.newCreateAppFormIT02(appEmp);
            return RedirectToAction("Index", "APP_ESIGN",new { area = "Employee"});
        }  
        
        [HttpGet]
        public ActionResult CreateAppForm()
        {
            NewCode newCode = new NewCode();
            if (Session["dislayFormName"] == null)
            {
                return RedirectToAction("CreateForm", "ApplicationType", new { area = "Employee" });
            }
            string formSS = Session["dislayFormName"].ToString();
            int formID = newCode.getFormID(formSS);
            FORM_IT_01Model mode = newCode.setDataForm(6);
            return View(mode);
        }

        [HttpPost]
        public ActionResult CreateAppForm(FORM_IT_01Model mode)
        {
            string ve = "";

            NewCode newCode = new NewCode();
            //if (Session["dislayFormName"] == null)
            //{
            //    return RedirectToAction("CreateForm", "ApplicationType", new { area = "Employee" });
            //}
            string formName = Session["dislayFormName"].ToString();
            mode.FormID = newCode.getFormID(formName);

            if (mode.Title0Content == null) mode.Title0Content = "";

            if (mode.Title1Content == null) mode.Title1Content = "";

            if (mode.Title2Content == null) mode.Title2Content = "";

            if (mode.Title3Content == null) mode.Title3Content = "";

            if (mode.Title4Content == null) mode.Title4Content = "";

            if (mode.Title5Content == null) mode.Title5Content = "";

            if (mode.Title6Content == null) mode.Title6Content = "";

            if (mode.Title7Content == null) mode.Title7Content = "";

            if (mode.Title8Content == null) mode.Title8Content = "";

            if (mode.Title9Content == null) mode.Title9Content = "";

            if (mode.Title10Content == null) mode.Title10Content = "";

            if (mode.Title11Content == null) mode.Title11Content = "";

            if (mode.Title12Content == null) mode.Title12Content = "";

            if (mode.Title13Content == null) mode.Title13Content = "";

            if (mode.Title14Content == null) mode.Title14Content = "";

            if (mode.Title15Content == null) mode.Title15Content = "";

            if (mode.Title16Content == null) mode.Title16Content = "";


            if (mode.Title17Content == null) mode.Title17Content = "";

            if (mode.Title18Content == null) mode.Title18Content = "";

            if (mode.Title19Content == null) mode.Title19Content = "";

            if (mode.Title20Content == null) mode.Title20Content = "";

            if (mode.Title21Content == null) mode.Title21Content = "";

            if (mode.Title22Content == null) mode.Title22Content = "";


            if (mode.Title23Content == null) mode.Title23Content = "";

            if (mode.Title24Content == null) mode.Title24Content = "";

            if (mode.Title25Content == null) mode.Title25Content = "";

            if (mode.Title26Content == null) mode.Title26Content = "";


            if (mode.Title0 == null) mode.Title0 = "";

            if (mode.Title1 == null) mode.Title1 = "";

            if (mode.Title2 == null) mode.Title2 = "";

            if (mode.Title3 == null) mode.Title3 = "";

            if (mode.Title4 == null) mode.Title4= "";

            if (mode.Title5 == null) mode.Title5 = "";

            if (mode.Title6 == null) mode.Title6 = "";

            if (mode.Title7 == null) mode.Title7 = "";

            if (mode.Title8 == null) mode.Title8 = "";

            if (mode.Title9 == null) mode.Title9 = "";

            if (mode.Title10 == null) mode.Title10 = "";

            if (mode.Title11 == null) mode.Title11 = "";

            if (mode.Title12 == null) mode.Title12 = "";

            if (mode.Title13 == null) mode.Title13 = "";

            if (mode.Title14 == null) mode.Title14 = "";

            if (mode.Title15 == null) mode.Title15 = "";

            if (mode.Title16 == null) mode.Title16 = "";


            if (mode.Title17 == null) mode.Title17 = "";

            if (mode.Title18 == null) mode.Title18 = "";

            if (mode.Title19 == null) mode.Title19 = "";

            if (mode.Title20 == null) mode.Title20 = "";

            if (mode.Title21 == null) mode.Title21 = "";

            if (mode.Title22 == null) mode.Title22 = "";


            if (mode.Title23 == null) mode.Title23 = "";

            if (mode.Title24 == null) mode.Title24 = "";

            if (mode.Title25 == null) mode.Title25 = "";

            if (mode.Title26 == null) mode.Title26 = "";



            string dataTiltle = mode.Title0 + ";" + mode.Title1 + ";" + mode.Title2 + ";" + mode.Title3 + ";" + mode.Title4 + ";";
            dataTiltle += mode.Title5 + ";" + mode.Title6 + ";" + mode.Title7 + ";" + mode.Title8 + ";" + mode.Title9 + ";";
            dataTiltle += mode.Title10 + ";" + mode.Title11 + ";" + mode.Title12 + ";" + mode.Title13 + ";" + mode.Title14 + ";";
            dataTiltle += mode.Title15 + ";" + mode.Title16 + ";" + mode.Title17 + ";" + mode.Title18 + ";" + mode.Title19 + ";";
            dataTiltle += mode.Title20 + ";" + mode.Title21 + ";" + mode.Title22 + ";" + mode.Title23 + ";" + mode.Title24 + ";" + mode.Title25 + ";" + mode.Title26;

            string dataContent = mode.Title0Content + ";" + mode.Title1Content + ";" + mode.Title2Content + ";" + mode.Title3Content + ";" + mode.Title4Content + ";";
            dataContent += mode.Title5Content + ";" + mode.Title6Content + ";" + mode.Title7Content + ";" + mode.Title8Content + ";" + mode.Title9Content + ";";
            dataContent += mode.Title10Content + ";" + mode.Title11Content + ";" + mode.Title12Content + ";" + mode.Title13Content + ";" + mode.Title14Content + ";";
            dataContent += mode.Title15Content + ";" + mode.Title16Content + ";" + mode.Title17Content + ";" + mode.Title18Content + ";" + mode.Title19Content + ";";
            dataContent += mode.Title20Content + ";" + mode.Title21Content + ";" + mode.Title22Content + ";" + mode.Title23Content + ";" + mode.Title24Content + ";" + mode.Title25Content + ";" + mode.Title26Content;

            string[] listTitle = dataTiltle.Split(';');
            string err = "error";

            string[] listContent = dataContent.Split(';');
            string tit = "";
            for (int i = 0; i < listTitle.Length; i++)
            {
                bool kqtt = newCode.insertTitleForm(mode.FormID, listTitle[i], i, tit, listContent[i]);
                if (kqtt == false) { err += "error" + listTitle[i].ToString(); } 
            }
            string kqTe = HttpContext.Request.Form["testKQ"].ToString();
            //string kqTe1 = HttpContext.Request.Form["testKQ1"].ToString();
            //string kqTe2 = HttpContext.Request.Form["testKQ2"].ToString();

            string[] nameKQ = kqTe.Split(',');
            //string[] nameKQ1 = kqTe1.Split(',');
            //string[] nameKQ2 = kqTe2.Split(',');

            for(int i=0;i<nameKQ.Length;i++)
            {
                if (nameKQ[i].Equals(""))
                {
                    break;
                }
                else
                {
                    bool insertSubmitSign = newCode.insertSigning(mode.FormID, i, nameKQ[i]);
                    if (insertSubmitSign == false) { err = "error" + listTitle[i].ToString(); }
                }
               
            }
            
            if(err.Trim() != "error")
            {
                return RedirectToAction("errorShow", "Home", new { area = "" });
            }
            return RedirectToAction("Index", "APP_ESIGN", new { area = "Employee" });
        }

        // tra ve chuoi string
        //[HttpPost]
        //public ActionResult testData(ListDataModel dataModel)
        //{
        //    string Ahihi = "";
        //    return 
        //}

        [HttpGet]
        public ActionResult CreateForm()
        {

            setViewSite();
            setViewDepart();
            return View();
        }  

        [HttpPost]
        public ActionResult CreateForm(CreateNewForm createNewForm)
        {
            NewCode newCode = new NewCode();

            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            string creator = session.UserID;
            string ahihi=     createNewForm.Site.Trim();

            string formName = "FORM_" + createNewForm.Department.Trim()+"_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            
            newCode.insertForm(formName.Trim(), createNewForm.Department.Trim(), createNewForm.FormDisplayName, createNewForm.Site.Trim(), creator.Trim());
            Session["dislayFormName"] = formName.Trim();

            setViewSite();
            setViewDepart();
            return RedirectToAction("CreateAppForm", "ApplicationType", new { area = "Employee" });
        }

        public void setViewSite(long? selectedID = null)
        {
            var dao = new CodeDao();
            ViewBag.Site = new SelectList(dao.ListSite(), "SiteID", "SiteName", selectedID);
        }

        public void setViewDepart(long? selectedID = null)
        {
            var dao = new CodeDao();
            ViewBag.Department = new SelectList(dao.ListDepart(), "DepartmentName", "DepartmentName", selectedID);
        }
        public void setViewFac(long? selectedID = null)
        {
            var dao = new NewCode();
            ViewBag.Title0Content = new SelectList(dao.listFac(), "Factory_name", "Factory_name", selectedID);
        }
    }


    //Trang tao mau don
   
}
