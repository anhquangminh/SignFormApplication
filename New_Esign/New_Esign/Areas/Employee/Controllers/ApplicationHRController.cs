using New_Esign.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using New_Esign.Areas.Employee.Models;
using New_Esign.AppCode;
using NewModel.EF;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using New_Esign.Common;


namespace New_Esign.Areas.Employee.Controllers
{
    public class ApplicationHRController : BaseUserController
    {
        // cac ket noi can thiet 
        private DBConnectData db = new DBConnectData();

        private ApplicationITController itContr = new ApplicationITController();

        private SendMail sendM = new SendMail();

        private Submit sb = new Submit();

        private PostmanService.PostmanServiceSoapClient postman = new PostmanService.PostmanServiceSoapClient();

        private NewCode nCode = new NewCode();

        private SQLServerDBHelper sqlHelp = new SQLServerDBHelper("DBConnectData");
        // GET: Employee/ApplicationHR
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContactForm()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var emp = session.UserID.Trim();
            FORM_IT_01Model conModel = new FORM_IT_01Model();
            var formName = "FORM_HR_01";
            var formID = nCode.getFormID(formName);
            conModel = contactModel(formID);
            string strManage = itContr.checkManager(emp);
            conModel.Title2Content = emp;
            string[] listMan = strManage.Split(';');
            conModel.approvalApps[0].signEmpNo = emp.Trim().ToString();
            conModel.approvalApps[0].SignName = itContr.getName(emp.Trim());
            if(listMan.Length > 1)
            {
                conModel.approvalApps[1].signEmpNo = listMan[0].ToString();
                conModel.approvalApps[2].signEmpNo = listMan[1].ToString();
                conModel.approvalApps[1].SignName = itContr.getName(listMan[0].ToString().Trim());
                conModel.approvalApps[2].SignName = itContr.getName(listMan[1].ToString().Trim());
            }
            else
            {
                conModel.approvalApps[1].signEmpNo = listMan[0].ToString();
                conModel.approvalApps[1].SignName = itContr.getName(listMan[0].ToString().Trim());
            }

            DataTable tableEmp = postman.GetEmpInfomation(emp.Trim());
            // lay thong tin nguoi lam don
            conModel.Title2Content = emp;
            conModel.Title3Content = tableEmp.Rows[0]["USER_NAME"].ToString();
            conModel.Title7Content = tableEmp.Rows[0]["CURRENT_OU_NAME"].ToString();
            conModel.Title5Content = tableEmp.Rows[0]["NOTES_ID"].ToString();
            conModel.Title4Content = tableEmp.Rows[0]["CURRENT_OU_CODE"].ToString();

            string phone = nCode.getPhoneAccount(emp);
            if (!phone.Equals(""))
            {
                conModel.Title6Content = phone;
            }
            if (conModel.Title5Content.Equals("") || String.IsNullOrEmpty(conModel.Title5Content))
            {
                string mail = nCode.getMailAccount(emp);
                if (!mail.Equals(""))
                {
                    conModel.Title5Content = mail;
                }

            }                          
            return View(conModel);
        }

        [HttpPost]
        public ActionResult ContactForm(FORM_IT_01Model reqModel)
        {
            try
            {
                var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                var emp = session.UserID.Trim();
                var empName = session.UserName;

                string phone = nCode.getPhoneAccount(emp);
                if (phone.Equals("") || reqModel.Title6Content != phone)
                {
                    nCode.setPhoneAccount(emp, reqModel.Title6Content, empName);
                }
                string mail = nCode.getMailAccount(emp);
                if (mail.Equals("") || reqModel.Title5Content != mail)
                {

                    nCode.setMailAccount(emp, reqModel.Title5Content, empName);
                }

                reqModel.AppNo = DateTime.Now.ToString("yyyyMMddHHmmss") + GenerateRandom(2);
                FORM_IT_01Model conModel = new FORM_IT_01Model();
                conModel = contactModel(reqModel.FormID);

                reqModel.Title0 = conModel.Title0;
                reqModel.Title1 = conModel.Title1;
                reqModel.Title2 = conModel.Title2;
                reqModel.Title3 = conModel.Title3;
                reqModel.Title4 = conModel.Title4;

                reqModel.Title5 = conModel.Title5;
                reqModel.Title6 = conModel.Title6;
                reqModel.Title7 = conModel.Title7;
                reqModel.Title8 = conModel.Title8;
                reqModel.Title9 = conModel.Title9;

                reqModel.Title10 = conModel.Title10;
                reqModel.Title11 = conModel.Title11;
                reqModel.Title12 = conModel.Title12;
                reqModel.Title13 = conModel.Title13;
                reqModel.Title14 = conModel.Title14;

                reqModel.Title15 = conModel.Title15;
                reqModel.Title16 = conModel.Title16;
                reqModel.Title17 = conModel.Title17;
                reqModel.Title18 = conModel.Title18;
                reqModel.Title19 = conModel.Title19;

                reqModel.Title20 = conModel.Title20;

                string titleList = reqModel.Title0 + ";" + reqModel.Title1 + ";" + reqModel.Title2 + ";" + reqModel.Title3 + ";" + reqModel.Title4 + ";";
                titleList += reqModel.Title5 + ";" + reqModel.Title6 + ";" + reqModel.Title7 + ";" + reqModel.Title8 + ";" + reqModel.Title9 + ";";
                titleList += reqModel.Title10 + ";" + reqModel.Title11 + ";" + reqModel.Title12 + ";" + reqModel.Title13 + ";" + reqModel.Title14 + ";";
                titleList += reqModel.Title15 + ";" + reqModel.Title16 + ";" + reqModel.Title17 + ";" + reqModel.Title18 + ";" + reqModel.Title19 + ";" + reqModel.Title20;

                var files = Request.Files["file"];


                if (files != null)
                {
                    String FileExt = Path.GetExtension(files.FileName).ToUpper();
                    string _fileName = reqModel.AppNo + Path.GetFileName(files.FileName);

                    String filePath = "/UploadFiles/" + _fileName;
                    string _path = Path.Combine(Server.MapPath("~/UploadFiles"), _fileName);
                    //Stream str = files.InputStream;
                    //BinaryReader Br = new BinaryReader(str);
                    //Byte[] FileDet = Br.ReadBytes((Int32)str.Length);
                    //files.SaveAs(MapPath(filePath));
                    files.SaveAs(_path);

                    reqModel.Title18Content = files.FileName;
                    reqModel.Title19Content = filePath;


                }

                string[] arrayTitle = titleList.Split(';');

                if (reqModel.Title0Content == null) reqModel.Title0Content = " ";
                if (reqModel.Title1Content == null) reqModel.Title1Content = " ";
                if (reqModel.Title2Content == null) reqModel.Title2Content = " ";
                if (reqModel.Title3Content == null) reqModel.Title3Content = " ";
                if (reqModel.Title4Content == null) reqModel.Title4Content = " ";
                
                if (reqModel.Title5Content == null) reqModel.Title5Content = " ";
                if (reqModel.Title6Content == null) { ViewBag.ErrorType = " 請填寫所有必填信息 / Vui lòng điền đầy đủ thông tin bắt buộc "; return View(conModel); }
                if (reqModel.Title7Content == null) reqModel.Title7Content = " ";
                if (reqModel.Title8Content == null) reqModel.Title8Content = " ";
                if (reqModel.Title9Content == null) { ViewBag.ErrorType = " 請填寫所有必填信息 / Vui lòng điền đầy đủ thông tin bắt buộc "; return View(conModel); }

                if (reqModel.Title10Content == null) { ViewBag.ErrorType = " 請填寫所有必填信息 / Vui lòng điền đầy đủ thông tin bắt buộc "; return View(conModel); }
                if (reqModel.Title11Content == null) reqModel.Title11Content = " ";
                if (reqModel.Title12Content == null) reqModel.Title12Content = " ";
                if (reqModel.Title13Content == null) { ViewBag.ErrorType = " 請填寫所有必填信息 / Vui lòng điền đầy đủ thông tin bắt buộc "; return View(conModel); }
                if (reqModel.Title14Content == null) reqModel.Title14Content = reqModel.AppNo;

                if (reqModel.Title15Content == null) reqModel.Title15Content = " ";
                if (reqModel.Title16Content == null) { ViewBag.ErrorType = " 請填寫所有必填信息 / Vui lòng điền đầy đủ thông tin bắt buộc "; return View(conModel); }
                if (reqModel.Title17Content == null) { ViewBag.ErrorType = " 請填寫所有必填信息 / Vui lòng điền đầy đủ thông tin bắt buộc "; return View(conModel); }
                if (reqModel.Title18Content == null) reqModel.Title18Content = " ";
                if (reqModel.Title19Content == null) reqModel.Title19Content = " ";

                if (reqModel.Title20Content == null) reqModel.Title20Content = " ";

                

                string titleListContent = reqModel.Title0Content + ";" + reqModel.Title1Content + ";" + reqModel.Title2Content + ";" + reqModel.Title3Content + ";" + reqModel.Title4Content + ";";
                titleListContent += reqModel.Title5Content + ";" + reqModel.Title6Content + ";" + reqModel.Title7Content + ";" + reqModel.Title8Content + ";" + reqModel.Title9Content + ";";
                titleListContent += reqModel.Title10Content + ";" + reqModel.Title11Content + ";" + reqModel.Title12Content + ";" + reqModel.Title13Content + ";" + reqModel.Title14Content + ";";
                titleListContent += reqModel.Title15Content + ";" + reqModel.Title16Content + ";" + reqModel.Title17Content + ";" + reqModel.Title18Content + ";" + reqModel.Title19Content + ";" + reqModel.FormID;

                string[] arrayContent = titleListContent.Split(';');



                var pName = Request.Form["testKQ1"].ToString();
                var pNo = Request.Form["testKQ2"].ToString();
                var pSelect = Request.Form["testKQ"].ToString();

                string[] signSelect = pSelect.Split(',');
                signSelect = signSelect.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                string[] signPno = pNo.Split(',');
                signPno = signPno.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                string[] signName = pName.Split(',');
                signName = signName.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                if (signSelect.Length != signPno.Length || signSelect.Length != signName.Length) { ViewBag.ErrorType = " 請填寫所有必填信息 / Vui lòng kiểm tra lại lưu trình ký đơn "; return View(conModel); }


                using (SqlConnection conn = new SqlConnection("Data Source=10.224.81.131,3000;Initial Catalog=esign;Persist Security Info=True;User ID=khangbeoit;Password=foxconn168!!"))
                {
                    bool checkReasonFlag = false;
                    if (conn.State != ConnectionState.Open) conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        //insert vao appcontent
                        for(int i=0; i < arrayTitle.Length; i++)
                        {
                            string sqlStr = string.Format("INSERT INTO APP_CONTENT(AppNo,AppTitle,AppContent,FormID,Step) VALUES('{0}',N'{1}',N'{2}','{3}','{4}')", reqModel.AppNo, arrayTitle[i].ToString(), arrayContent[i].ToString(),reqModel.FormID , i);
                            SqlCommand cmd = conn.CreateCommand();
                            cmd.Transaction = trans;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = sqlStr;

                            int rowAff = cmd.ExecuteNonQuery();
                            if(rowAff > 0)
                            {
                                string sqlStr1 = string.Format("INSERT INTO APP_CONTENT_LOG(AppNo,AppTitle,AppContent,FormID,Step) VALUES('{0}',N'{1}',N'{2}','{3}','{4}')", reqModel.AppNo, arrayTitle[i].ToString(), arrayContent[i].ToString(), reqModel.FormID, i);
                                SqlCommand cmd1 = conn.CreateCommand();
                                cmd1.Transaction = trans;
                                cmd1.CommandType = CommandType.Text;
                                cmd1.CommandText = sqlStr1;

                                int rowAff1 = cmd1.ExecuteNonQuery();
                                if(rowAff1 > 0)
                                {
                                    checkReasonFlag = true;
                                }
                                else
                                {
                                    checkReasonFlag = false;
                                    break;
                                }
                                
                            }
                            else
                            {
                                checkReasonFlag = false;
                                break;
                            }
                        }

                        //insert luu trinh ky
                        if(checkReasonFlag == true)
                        {
                            for (int i = 0; i < signSelect.Length; i++)
                            {
                                string sqlStr = string.Format("INSERT INTO approvalSchedule(AppNo,signEmpNo,SignName,statusName,step) VALUES('{0}',N'{1}',N'{2}',N'{3}','{4}')", reqModel.AppNo, signPno[i].ToString().Trim(), signName[i].ToString(),signSelect[i].ToString(), i);
                                SqlCommand cmd = conn.CreateCommand();
                                cmd.Transaction = trans;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = sqlStr;

                                int rowAff = cmd.ExecuteNonQuery();
                                if (rowAff > 0)
                                {
                                    checkReasonFlag = true;
                                } 
                                else
                                {
                                    checkReasonFlag = false;
                                    break;
                                }
                            }                           
                        }
                        if(checkReasonFlag == true)
                        {
                            bool kqSub = sb.f_submit_yellow("Submit", reqModel.AppNo, 32, reqModel.Title3Content, reqModel.Title2Content, 0);
                            if (kqSub == true)
                            {
                                checkReasonFlag = true;
                            }
                            else
                            {
                                checkReasonFlag = false;
                            }
                        }

                        //insert data_app_esign
                        if(checkReasonFlag == true)
                        {
                            string date = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
                            //int ste = 0;
                            string sqlStr = string.Format(@"INSERT INTO DATA_APP_ESIGN(AppNo,APPSTATUS,Checkwait,USEREMP,CHECKWAITNAME,ApplicantNo,ApplicantName,FormID,Daycreate,Title,Step) VALUES(
'{0}',N'{1}','{2}','{3}',N'{4}','{5}',N'{6}','{7}','{8}',N'Contact document','1')
", reqModel.AppNo, signSelect[1].ToString(), signPno[1].ToString().Trim(), emp,signName[1].ToString(),arrayContent[2].ToString(),arrayContent[3].ToString(), reqModel.FormID, date );
                            SqlCommand cmd = conn.CreateCommand();
                            cmd.Transaction = trans;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = sqlStr;

                            int rowAff = cmd.ExecuteNonQuery(); 
                            if (rowAff > 0) checkReasonFlag = true;
                            else checkReasonFlag = false;
                        }

                        //gui mail cho nguoi lam don va gui mail cho nguoi ky don 
                        if(checkReasonFlag == true)
                        {
                            sendM.insertSenmail(signPno[1].Trim().ToString(), reqModel.AppNo, "聯絡單", emp, "文件電子簽核申請單等待簽核", "Contact document");
                            sendM.insertSenmail(emp, reqModel.AppNo, "聯絡單", emp, "提交文件表格电子批准申请", "Contact document");
                        }

                        if (checkReasonFlag == true)
                        {
                            trans.Commit();
                            conn.Close();
                            return RedirectToAction("Index", "APP_ESIGN");
                        }                           
                        else
                        {
                            trans.Rollback();
                            conn.Close();
                            return View("ContactForm");
                        }                                                                          
                    }                                       
                }
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "ErrorPage", new { area = "" });
            }
           
        }       

        // trang ky don
        public ActionResult signingForm(string appNo)
        {
            FORM_IT_01Model model = new FORM_IT_01Model();
            model = signContactForm(appNo);
            return View(model);
        }

        [HttpPost]
        public ActionResult signingForm(FORM_IT_01Model model, string ApprovalButton)
        {
            bool kq = true;
            bool kq2 = true;
            string sqlQuery = "";
            string checkWait = "";
            string applicant = " ";
            SendMail sen = new SendMail();
            if (model.AppContent == null) model.AppContent = " ";
            switch (ApprovalButton)
            {
                case "Approval":
                    //kq = sb.f_insert_sub_yellow("通過", model.AppNo, model.AppContent);
                    kq2 = sb.SigningYellowCarD(model.AppNo, "Approval", model.AppContent);

                    DataTable dataTable = sb.f_get_desc(model.AppNo);
                    checkWait = dataTable.Rows[0]["Checkwait"].ToString();
                    applicant = dataTable.Rows[0]["ApplicantNo"].ToString();
                    
                    //update  dataTable2.Rows[0]["CHECKWAITNAME"].ToString()
                    sen.insertSenmail(checkWait.Trim(), model.AppNo.Trim(), dataTable.Rows[0]["Title"].ToString(), applicant, "文件電子簽核申請單等待簽核", dataTable.Rows[0]["Title"].ToString());
                    break;
                case "Reject":
                    //kq = sb.f_insert_sub_yellow("駁回", model.AppNo, model.AppContent);
                    kq2 = sb.SigningYellowCarD(model.AppNo, "Reject", model.AppContent);

                    //sqlQuery = @"select * from DATA_APP_ESIGN where APPNO='" + fORM_IT_.AppNo.Trim() + "' ;";
                    DataTable dataTable2 = sb.f_get_desc(model.AppNo);
                    checkWait = dataTable2.Rows[0]["Checkwait"].ToString();
                    applicant = dataTable2.Rows[0]["ApplicantNo"].ToString();
                    
                    bool kqsen = sen.insertSenmail(checkWait.Trim(), model.AppNo.Trim(), dataTable2.Rows[0]["Title"].ToString(), applicant, "文件電子簽核申請單被駁回", dataTable2.Rows[0]["Title"].ToString());
                    //string kqte = "";
                    break;
                case "Submit":

                    break;
                case "Delete":
                    break;
                
                case "ForWard":
                    //kq = sb.f_insert_sub_yellow("駁回", model.AppNo, model.AppContent);
                    kq2 = sb.forWardSigner(model.AppNo, model.AppContent,model.Title7Example,model.Title8Example,model.Title9Example);

                    //sqlQuery = @"select * from DATA_APP_ESIGN where APPNO='" + fORM_IT_.AppNo.Trim() + "' ;";
                    DataTable dataTable2VI2 = sb.f_get_desc(model.AppNo);
                    checkWait = dataTable2VI2.Rows[0]["Checkwait"].ToString();
                    applicant = dataTable2VI2.Rows[0]["ApplicantNo"].ToString();
                    
                    bool kqsenVI2 = sen.insertSenmail(checkWait.Trim(), model.AppNo.Trim(), dataTable2VI2.Rows[0]["Title"].ToString(), applicant, "文件電子簽核申請單被駁回", dataTable2VI2.Rows[0]["Title"].ToString());
                    //string kqte = "";
                    break;                
            }

            return RedirectToAction("WaitingForYourApproval", "APP_ESIGN");
        }
        // lay du lieu mau don theo form id
        public FORM_IT_01Model contactModel(int formID)
        {
            FORM_IT_01Model fORM_IT_01 = new FORM_IT_01Model();
            try
            {              
                string sqlQuery = @"select * from TitleForm where FormID='" + formID + "' order by FormStep asc ";
                DataTable tble = sqlHelp.DoSQLSelect(sqlQuery);
                if (tble.Rows.Count > 0)
                {
                    fORM_IT_01.Title0 = tble.Rows[0]["FormContent"].ToString();
                    fORM_IT_01.Title1 = tble.Rows[1]["FormContent"].ToString();
                    fORM_IT_01.Title2 = tble.Rows[2]["FormContent"].ToString();
                    fORM_IT_01.Title3 = tble.Rows[3]["FormContent"].ToString();
                    fORM_IT_01.Title4 = tble.Rows[4]["FormContent"].ToString();

                    fORM_IT_01.Title5 = tble.Rows[5]["FormContent"].ToString();
                    fORM_IT_01.Title6 = tble.Rows[6]["FormContent"].ToString();
                    fORM_IT_01.Title7 = tble.Rows[7]["FormContent"].ToString();
                    fORM_IT_01.Title8 = tble.Rows[8]["FormContent"].ToString();
                    fORM_IT_01.Title9 = tble.Rows[9]["FormContent"].ToString();

                    fORM_IT_01.Title10 = tble.Rows[10]["FormContent"].ToString();
                    fORM_IT_01.Title11 = tble.Rows[11]["FormContent"].ToString();
                    fORM_IT_01.Title12 = tble.Rows[12]["FormContent"].ToString();
                    fORM_IT_01.Title13 = tble.Rows[13]["FormContent"].ToString();
                    fORM_IT_01.Title14 = tble.Rows[14]["FormContent"].ToString();

                    fORM_IT_01.Title15 = tble.Rows[15]["FormContent"].ToString();
                    fORM_IT_01.Title16 = tble.Rows[16]["FormContent"].ToString();
                    fORM_IT_01.Title17 = tble.Rows[17]["FormContent"].ToString();
                    fORM_IT_01.Title18 = tble.Rows[18]["FormContent"].ToString();
                    fORM_IT_01.Title19 = tble.Rows[19]["FormContent"].ToString();

                    fORM_IT_01.Title20 = tble.Rows[20]["FormContent"].ToString();

                    fORM_IT_01.FormID = Convert.ToInt32(tble.Rows[0]["FormID"].ToString());

                    //lay du lieu luu trinh ky
                    string sqlQuery1 = @"select * from SubmitSign where FormID = '" + fORM_IT_01.FormID + "' order by SignNo asc";
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

                    fORM_IT_01.approvalApps = listAppro;
                }

            }
            catch
            {

            }
            
            return fORM_IT_01;
        }

        //lay du lieu ky don
        public FORM_IT_01Model signContactForm(string appNo)
        {
            FORM_IT_01Model fORM_IT_01 = new FORM_IT_01Model();
            try
            {
                string sqlQuery = @"select * from APP_CONTENT where AppNo='" + appNo + "' order by Step asc ";
                DataTable tble = sqlHelp.DoSQLSelect(sqlQuery);
                if (tble.Rows.Count > 0)
                {
                    fORM_IT_01.Title0 = tble.Rows[0]["AppTitle"].ToString();
                    fORM_IT_01.Title1 = tble.Rows[1]["AppTitle"].ToString();
                    fORM_IT_01.Title2 = tble.Rows[2]["AppTitle"].ToString();
                    fORM_IT_01.Title3 = tble.Rows[3]["AppTitle"].ToString();
                    fORM_IT_01.Title4 = tble.Rows[4]["AppTitle"].ToString();

                    fORM_IT_01.Title5 = tble.Rows[5]["AppTitle"].ToString();
                    fORM_IT_01.Title6 = tble.Rows[6]["AppTitle"].ToString();
                    fORM_IT_01.Title7 = tble.Rows[7]["AppTitle"].ToString();
                    fORM_IT_01.Title8 = tble.Rows[8]["AppTitle"].ToString();
                    fORM_IT_01.Title9 = tble.Rows[9]["AppTitle"].ToString();

                    fORM_IT_01.Title10 = tble.Rows[10]["AppTitle"].ToString();
                    fORM_IT_01.Title11 = tble.Rows[11]["AppTitle"].ToString();
                    fORM_IT_01.Title12 = tble.Rows[12]["AppTitle"].ToString();
                    fORM_IT_01.Title13 = tble.Rows[13]["AppTitle"].ToString();
                    fORM_IT_01.Title14 = tble.Rows[14]["AppTitle"].ToString();

                    fORM_IT_01.Title15 = tble.Rows[15]["AppTitle"].ToString();
                    fORM_IT_01.Title16 = tble.Rows[16]["AppTitle"].ToString();
                    fORM_IT_01.Title17 = tble.Rows[17]["AppTitle"].ToString();
                    fORM_IT_01.Title18 = tble.Rows[18]["AppTitle"].ToString();
                    fORM_IT_01.Title19 = tble.Rows[19]["AppTitle"].ToString();

                    fORM_IT_01.Title20 = tble.Rows[20]["AppTitle"].ToString();

                    fORM_IT_01.FormID = Convert.ToInt32(tble.Rows[0]["FormID"].ToString());

                    fORM_IT_01.Title0Content = tble.Rows[0]["AppContent"].ToString();
                    fORM_IT_01.Title1Content = tble.Rows[1]["AppContent"].ToString();
                    fORM_IT_01.Title2Content = tble.Rows[2]["AppContent"].ToString();
                    fORM_IT_01.Title3Content = tble.Rows[3]["AppContent"].ToString();
                    fORM_IT_01.Title4Content = tble.Rows[4]["AppContent"].ToString();

                    fORM_IT_01.Title5Content = tble.Rows[5]["AppContent"].ToString();
                    fORM_IT_01.Title6Content = tble.Rows[6]["AppContent"].ToString();
                    fORM_IT_01.Title7Content = tble.Rows[7]["AppContent"].ToString();
                    fORM_IT_01.Title8Content = tble.Rows[8]["AppContent"].ToString();
                    fORM_IT_01.Title9Content = tble.Rows[9]["AppContent"].ToString();

                    fORM_IT_01.Title10Content = tble.Rows[10]["AppContent"].ToString();
                    fORM_IT_01.Title11Content = tble.Rows[11]["AppContent"].ToString();
                    fORM_IT_01.Title12Content = tble.Rows[12]["AppContent"].ToString();
                    fORM_IT_01.Title13Content = tble.Rows[13]["AppContent"].ToString();
                    fORM_IT_01.Title14Content = tble.Rows[14]["AppContent"].ToString();

                    fORM_IT_01.Title15Content = tble.Rows[15]["AppContent"].ToString();
                    fORM_IT_01.Title16Content = tble.Rows[16]["AppContent"].ToString();
                    fORM_IT_01.Title17Content = tble.Rows[17]["AppContent"].ToString();
                    fORM_IT_01.Title18Content = tble.Rows[18]["AppContent"].ToString();
                    fORM_IT_01.Title19Content = tble.Rows[19]["AppContent"].ToString();

                    fORM_IT_01.Title20Content = tble.Rows[20]["AppContent"].ToString();

                    fORM_IT_01.AppNo = appNo;

                    //lay danh sach nguoi ky va trang thai
                    string sqlQuerySign = @"SELECT step,statusName,SignName,signEmpNo,fowardInfo,(select top 1 approvalname from approvalsuggest where orderNo=a.AppNo and statusname=a.statusname and stt = a.step and (approvalid = a.signEmpNo or approvalid=a.signOver) order by approvaltime desc ) approvalname,  " +
                                   " (select top 1 status from approvalsuggest where orderNo = a.AppNo and statusname = a.statusname and stt = a.step and(approvalid = a.signEmpNo or approvalid = a.signOver) order by approvaltime desc ) status,  " +
                                   " (select top 1 approvalsuggest from approvalsuggest where orderNo = a.AppNo and statusname = a.statusname and stt = a.step  and(approvalid = a.signEmpNo or approvalid = a.signOver) order by approvaltime desc ) approvalsuggest,  " +
                                   " (select top 1 approvaltime from approvalsuggest where orderNo = a.AppNo and statusname = a.statusname and stt = a.step and(approvalid = a.signEmpNo or approvalid = a.signOver) order by approvaltime desc ) approvaltime " +
                                   " FROM approvalSchedule a " +
                                   " where a.AppNo = '" + appNo + "' " +
                                   " order by CONVERT(int, step); ";
                    DataTable tb2 = sqlHelp.DoSQLSelect(sqlQuerySign);
                    if (tb2.Rows.Count > 0)
                    {
                        List<ApprovalAppModel> listApprovals = new List<ApprovalAppModel>();
                        for (int i = 0; i < tb2.Rows.Count; i++)
                        {
                            string dateQue = tb2.Rows[i]["approvaltime"].ToString();
                            if (dateQue.Equals(""))
                            {
                                listApprovals.Add(
                                new ApprovalAppModel
                                {
                                    step = i,
                                    statusName = tb2.Rows[i]["statusName"].ToString(),
                                    signEmpNo = tb2.Rows[i]["signEmpNo"].ToString(),
                                    SignName = tb2.Rows[i]["SignName"].ToString(),
                                    approvalsuggest = tb2.Rows[i]["approvalsuggest"].ToString(),
                                    status = tb2.Rows[i]["status"].ToString(),
                                    approvaltime = null,
                                    fowardInfo = tb2.Rows[i]["fowardInfo"].ToString()

                                }
                            );
                            }
                            else
                            {
                                listApprovals.Add(
                                new ApprovalAppModel
                                {
                                    step = i,
                                    statusName = tb2.Rows[i]["statusName"].ToString(),
                                    signEmpNo = tb2.Rows[i]["signEmpNo"].ToString(),
                                    SignName = tb2.Rows[i]["SignName"].ToString(),
                                    approvalsuggest = tb2.Rows[i]["approvalsuggest"].ToString(),
                                    status = tb2.Rows[i]["status"].ToString(),
                                    approvaltime = DateTime.Parse(dateQue),
                                    fowardInfo = tb2.Rows[i]["fowardInfo"].ToString()
                                }
                                );
                            }
                        }
                        fORM_IT_01.approvalApps = listApprovals;
                    }
                }


            }
            catch (Exception ex)
            {

            }
            return fORM_IT_01;
        }

        //ran dom 
        private static char[] constant =
        {
            '0','1','2','3','4','5','6','7','8','9'
        };
        private static string GenerateRandom(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(10);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(10)]);
            }
            return newRandom.ToString();
        }


        //Ending China
        public ActionResult EndingChina()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EndingChina(FORM_IT_01Model EndingChina)
        {
            try
            {
                var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                var emp = session.UserID.Trim();
                var empName = session.UserName;

                if (EndingChina.Title0 == null) EndingChina.Title0 = " ";
                if (EndingChina.Title1 == null) EndingChina.Title1 = " ";
                if (EndingChina.Title2 == null) EndingChina.Title2 = " ";
                if (EndingChina.Title3 == null) EndingChina.Title3 = " ";
                if (EndingChina.Title4 == null) EndingChina.Title4 = " ";

                if (EndingChina.Title5 == null) EndingChina.Title5 = " ";
                if (EndingChina.Title6 == null) EndingChina.Title6 = " ";
                if (EndingChina.Title7 == null) EndingChina.Title7 = " ";
                if (EndingChina.Title8 == null) EndingChina.Title8 = " ";
                if (EndingChina.Title9 == null) EndingChina.Title9 = " ";

                if (EndingChina.Title10 == null) EndingChina.Title10 = " ";
                if (EndingChina.Title11 == null) EndingChina.Title11 = " ";
                if (EndingChina.Title12 == null) EndingChina.Title12 = " ";
                if (EndingChina.Title13 == null) EndingChina.Title13 = " ";
                if (EndingChina.Title14 == null) EndingChina.Title14 = " ";

                if (EndingChina.Title15 == null) EndingChina.Title15 = " ";
                if (EndingChina.Title16 == null) EndingChina.Title16 = " ";
                if (EndingChina.Title17 == null) EndingChina.Title17 = " ";
                if (EndingChina.Title18 == null) EndingChina.Title18 = " ";
                if (EndingChina.Title19 == null) EndingChina.Title19 = " ";

                if (EndingChina.Title20 == null) EndingChina.Title20 = " ";
                if (EndingChina.Title21 == null) EndingChina.Title21 = " ";
                if (EndingChina.Title22 == null) EndingChina.Title22 = " ";
                if (EndingChina.Title23 == null) EndingChina.Title23 = " ";
                if (EndingChina.Title24 == null) EndingChina.Title24 = " ";

                if (EndingChina.Title27 == null) EndingChina.Title27 = " ";
                if (EndingChina.Title28 == null) EndingChina.Title28 = " ";
                if (EndingChina.Title29 == null) EndingChina.Title29 = " ";
                if (EndingChina.Title30 == null) EndingChina.Title30 = " ";
                if (EndingChina.Title31 == null) EndingChina.Title31 = " ";

                if (EndingChina.Title32 == null) EndingChina.Title32 = " ";
                if (EndingChina.Title33 == null) EndingChina.Title33 = " ";
                if (EndingChina.Title34 == null) EndingChina.Title34 = " ";
                if (EndingChina.Title35 == null) EndingChina.Title35 = " ";
                if (EndingChina.Title36 == null) EndingChina.Title36 = " ";

                if (EndingChina.Title37 == null) EndingChina.Title37 = " ";
                if (EndingChina.Title38 == null) EndingChina.Title38 = " ";

                if (EndingChina.Title0Content == null) EndingChina.Title0Content = " ";
                if (EndingChina.Title1Content == null) EndingChina.Title1Content = " ";
                if (EndingChina.Title2Content == null) EndingChina.Title2Content = " ";
                if (EndingChina.Title3Content == null) EndingChina.Title3Content = " ";
                if (EndingChina.Title4Content == null) EndingChina.Title4Content = " ";

                if (EndingChina.Title5Content == null) EndingChina.Title5Content = " ";
                if (EndingChina.Title6Content == null) EndingChina.Title6Content = " ";
                if (EndingChina.Title7Content == null) EndingChina.Title7Content = " ";
                if (EndingChina.Title8Content == null) EndingChina.Title8Content = " ";
                if (EndingChina.Title9Content == null) EndingChina.Title9Content = " ";

                if (EndingChina.Title10Content == null) EndingChina.Title10Content = " ";
                if (EndingChina.Title11Content == null) EndingChina.Title11Content = " ";
                if (EndingChina.Title12Content == null) EndingChina.Title12Content = " ";
                if (EndingChina.Title13Content == null) EndingChina.Title13Content = " ";
                if (EndingChina.Title14Content == null) EndingChina.Title14Content = " ";

                if (EndingChina.Title15Content == null) EndingChina.Title15Content = " ";
                if (EndingChina.Title16Content == null) EndingChina.Title16Content = " ";
                if (EndingChina.Title17Content == null) EndingChina.Title17Content = " ";
                if (EndingChina.Title18Content == null) EndingChina.Title18Content = " ";
                if (EndingChina.Title19Content == null) EndingChina.Title19Content = " ";

                if (EndingChina.Title27Content == null) EndingChina.Title27Content = " ";
                if (EndingChina.Title28Content == null) EndingChina.Title28Content = " ";
                if (EndingChina.Title29Content == null) EndingChina.Title29Content = " ";
                if (EndingChina.Title30Content == null) EndingChina.Title30Content = " ";
                if (EndingChina.Title31Content == null) EndingChina.Title31Content = " ";

                if (EndingChina.Title32Content == null) EndingChina.Title32Content = " ";
                if (EndingChina.Title33Content == null) EndingChina.Title33Content = " ";
                if (EndingChina.Title34Content == null) EndingChina.Title34Content = " ";
                if (EndingChina.Title35Content == null) EndingChina.Title35Content = " ";
                if (EndingChina.Title36Content == null) EndingChina.Title36Content = " ";

                if (EndingChina.Title37Content == null) EndingChina.Title37Content = " ";
                if (EndingChina.Title38Content == null) EndingChina.Title38Content = " ";

                if (EndingChina.Title0Example == null) EndingChina.Title0Example = " ";
                if (EndingChina.Title1Example == null) EndingChina.Title1Example = " ";
                if (EndingChina.Title2Example == null) EndingChina.Title2Example = " ";
                if (EndingChina.Title3Example == null) EndingChina.Title3Example = " ";
                if (EndingChina.Title10Example == null) EndingChina.Title10Example = " ";

                if (EndingChina.Title11Example == null) EndingChina.Title11Example = " ";
                if (EndingChina.Title12Example == null) EndingChina.Title12Example = " ";
                if (EndingChina.Title13Example == null) EndingChina.Title13Example = " ";
                if (EndingChina.Title14Example == null) EndingChina.Title14Example = " ";
                if (EndingChina.Title15Example == null) EndingChina.Title15Example = " ";

                if (EndingChina.Title16Example == null) EndingChina.Title16Example = " ";



                EndingChina.AppNo = DateTime.Now.ToString("yyyyMMddHHmmss") + GenerateRandom(2);
                bool checkReasonflag = false;
                using(SqlConnection conn = new SqlConnection("Data Source=10.224.81.131,3000;Initial Catalog=esign;Persist Security Info=True;User ID=khangbeoit;Password=foxconn168!!"))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        string strQueryEnding = @"insert into EndingOperation(AppNo,FormID,empID,empName,Name,
                                                    jobtitle,rank,dept,empGroup,BU,empUnit,dateEntry,dateDeparture,
                                                    totalDate,dateEntry1,dateDeparture1,totalDate1,Description,TimeCreate,transferOwner,contactFamily)
                                                    values(@AppNo,'34',@empID,@empName,@Name,
                                                    @jobtitle,@rank,@dept,@empGroup,@BU,@empUnit,@dateEntry,@dateDeparture,
                                                    @totalDate,@dateEntry1,@dateDeparture1,@totalDate1,@Description,'" + DateTime.Now.ToString("yyyy/MM/dd") + "',@transferOwner,@contactFamily);";
                        SqlParameter[] sqlParam = new SqlParameter[19];
                        sqlParam.SetValue(new SqlParameter("AppNo", EndingChina.AppNo), 0);
                        sqlParam.SetValue(new SqlParameter("empID", EndingChina.empID), 1);
                        sqlParam.SetValue(new SqlParameter("empName", EndingChina.empName), 2);
                        sqlParam.SetValue(new SqlParameter("jobtitle", EndingChina.Title1), 3);
                        sqlParam.SetValue(new SqlParameter("rank", EndingChina.Title2), 4);

                        sqlParam.SetValue(new SqlParameter("dept", EndingChina.Title3), 5);
                        sqlParam.SetValue(new SqlParameter("empGroup", EndingChina.Title4), 6);
                        sqlParam.SetValue(new SqlParameter("BU", EndingChina.Title5), 7);
                        sqlParam.SetValue(new SqlParameter("empUnit", EndingChina.Title6), 8);
                        sqlParam.SetValue(new SqlParameter("dateEntry", EndingChina.Title7), 9);

                        sqlParam.SetValue(new SqlParameter("dateDeparture", EndingChina.Title8), 10);
                        sqlParam.SetValue(new SqlParameter("totalDate", EndingChina.Title9), 11);
                        sqlParam.SetValue(new SqlParameter("dateEntry1", EndingChina.Title15Content), 12);
                        sqlParam.SetValue(new SqlParameter("dateDeparture1", EndingChina.Title16Content), 13);
                        sqlParam.SetValue(new SqlParameter("totalDate1", EndingChina.Title17Content), 14);

                        sqlParam.SetValue(new SqlParameter("Description", EndingChina.Title18Content), 15);
                        sqlParam.SetValue(new SqlParameter("Name", EndingChina.Title0), 16);
                        sqlParam.SetValue(new SqlParameter("transferOwner", EndingChina.Title19Content), 17);
                        sqlParam.SetValue(new SqlParameter("contactFamily", EndingChina.Title0Example), 18);

                        SqlCommand cmd = conn.CreateCommand();
                        cmd.Transaction = trans;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = strQueryEnding;
                        cmd.Parameters.AddRange(sqlParam);

                        int rowff = cmd.ExecuteNonQuery();
                        if(rowff > 0)
                        {
                            string strQueryEnding_log = @"insert into EndingOperation_log(AppNo,FormID,empID,empName,Name,
                                                    jobtitle,rank,dept,empGroup,BU,empUnit,dateEntry,dateDeparture,
                                                    totalDate,dateEntry1,dateDeparture1,totalDate1,Description,TimeCreate,transferOwner,contactFamily)
                                                    values(@AppNo,'34',@empID,@empName,@Name,
                                                    @jobtitle,@rank,@dept,@empGroup,@BU,@empUnit,@dateEntry,@dateDeparture,
                                                    @totalDate,@dateEntry1,@dateDeparture1,@totalDate1,@Description,'"+DateTime.Now.ToString("yyyy / MM / dd")+"',@transferOwner,@contactFamily);";
                            SqlParameter[] sqlParam_log = new SqlParameter[19];
                            sqlParam_log.SetValue(new SqlParameter("AppNo", EndingChina.AppNo), 0);
                            sqlParam_log.SetValue(new SqlParameter("empID", EndingChina.empID), 1);
                            sqlParam_log.SetValue(new SqlParameter("empName", EndingChina.empName), 2);
                            sqlParam_log.SetValue(new SqlParameter("jobtitle", EndingChina.Title1), 3);
                            sqlParam_log.SetValue(new SqlParameter("rank", EndingChina.Title2), 4);

                            sqlParam_log.SetValue(new SqlParameter("dept", EndingChina.Title3), 5);
                            sqlParam_log.SetValue(new SqlParameter("empGroup", EndingChina.Title4), 6);
                            sqlParam_log.SetValue(new SqlParameter("BU", EndingChina.Title5), 7);
                            sqlParam_log.SetValue(new SqlParameter("empUnit", EndingChina.Title6), 8);
                            sqlParam_log.SetValue(new SqlParameter("dateEntry", EndingChina.Title7), 9);

                            sqlParam_log.SetValue(new SqlParameter("dateDeparture", EndingChina.Title8), 10);
                            sqlParam_log.SetValue(new SqlParameter("totalDate", EndingChina.Title9), 11);
                            sqlParam_log.SetValue(new SqlParameter("dateEntry1", EndingChina.Title15Content), 12);
                            sqlParam_log.SetValue(new SqlParameter("dateDeparture1", EndingChina.Title16Content), 13);
                            sqlParam_log.SetValue(new SqlParameter("totalDate1", EndingChina.Title17Content), 14);

                            sqlParam_log.SetValue(new SqlParameter("Description", EndingChina.Title18Content), 15);
                            sqlParam_log.SetValue(new SqlParameter("Name", EndingChina.Title0), 16);
                            sqlParam_log.SetValue(new SqlParameter("transferOwner", EndingChina.Title19Content), 17);
                            sqlParam_log.SetValue(new SqlParameter("contactFamily", EndingChina.Title0Example), 18);


                            SqlCommand cmdLog = conn.CreateCommand();
                            cmdLog.Transaction = trans;
                            cmdLog.CommandType = CommandType.Text;
                            cmdLog.CommandText = strQueryEnding_log;
                            cmdLog.Parameters.AddRange(sqlParam_log);

                            int rowff_log = cmdLog.ExecuteNonQuery();
                            if (rowff_log > 0) checkReasonflag = true;
                            else checkReasonflag = false;

                        }

                        string[] arrayLocReturn = new string[5];
                       
                        string[] arrayLocGo = new string[5];                        
                        string[] arrayTimeGo = new string[5];
                        
                        string[] arrayVehide = new string[5];
                        
                        string[] arrayTotalTime = new string[5];
                        

                        if (checkReasonflag == true)
                        {

                            arrayLocReturn[0] = EndingChina.Title10;
                            arrayLocReturn[1] = EndingChina.Title15;
                            arrayLocReturn[2] = EndingChina.Title20;
                            arrayLocReturn[3] = EndingChina.Title27;
                            arrayLocReturn[4] = EndingChina.Title33;

                            arrayLocGo[0] = EndingChina.Title11;
                            arrayLocGo[1] = EndingChina.Title16;
                            arrayLocGo[2] = EndingChina.Title21;
                            arrayLocGo[3] = EndingChina.Title29;
                            arrayLocGo[4] = EndingChina.Title35;

                            arrayTimeGo[0] = EndingChina.Title12 + "~" + EndingChina.Title11Example;
                            arrayTimeGo[1] = EndingChina.Title17 + "~" + EndingChina.Title12Example;
                            arrayTimeGo[2] = EndingChina.Title22 + "~" + EndingChina.Title13Example;
                            arrayTimeGo[3] = EndingChina.Title28 + "~" + EndingChina.Title30;
                            arrayTimeGo[4] = EndingChina.Title34 + "~" + EndingChina.Title36;

                            arrayVehide[0] = EndingChina.Title13;
                            arrayVehide[1] = EndingChina.Title18;
                            arrayVehide[2] = EndingChina.Title23;
                            arrayVehide[3] = EndingChina.Title31;
                            arrayVehide[4] = EndingChina.Title37;

                            arrayTotalTime[0] = EndingChina.Title14;
                            arrayTotalTime[1] = EndingChina.Title19;
                            arrayTotalTime[2] = EndingChina.Title24;
                            arrayTotalTime[3] = EndingChina.Title32;
                            arrayTotalTime[4] = EndingChina.Title38;

                            for (int i=0; i< arrayLocReturn.Length; i++)
                            {
                                    if (arrayLocReturn[i] == null) arrayLocReturn[i] = " ";
                                    if (arrayLocGo[i] == null) arrayLocGo[i] = " ";
                                    if (arrayTimeGo[i] == null) arrayLocGo[i] = " ";
                                    if (arrayVehide[i] == null) arrayLocGo[i] = " ";
                                    if (arrayTotalTime[i] == null) arrayLocGo[i] = " ";

                                    string strGohome = @"insert into returnHome(AppNo,locationReturn,locationGo,timeReturn,Vehicle,totalTime,state) 
                                    values (@AppNo,@locationReturn,@locationGo,@timeReturn,@Vehicle,@totalTime,'1');";
                                    SqlParameter[] parGohome = new SqlParameter[6];
                                    parGohome.SetValue(new SqlParameter("AppNo", EndingChina.AppNo), 0);
                                    parGohome.SetValue(new SqlParameter("locationReturn", arrayLocReturn[i].ToString()), 1);
                                    parGohome.SetValue(new SqlParameter("locationGo", arrayLocGo[i].ToString()), 2);
                                    parGohome.SetValue(new SqlParameter("timeReturn", arrayTimeGo[i].ToString()), 3);                                   
        
                                    parGohome.SetValue(new SqlParameter("Vehicle", arrayVehide[i].ToString()), 4);
                                    parGohome.SetValue(new SqlParameter("totalTime", arrayTotalTime[i].ToString()), 5);

                                SqlCommand cmd1 = conn.CreateCommand();
                                cmd1.Transaction = trans;
                                cmd1.CommandType = CommandType.Text;
                                cmd1.CommandText = strGohome;
                                    cmd1.Parameters.AddRange(parGohome);
                                    rowff = cmd1.ExecuteNonQuery();
                                    if (rowff > 0) checkReasonflag = true;
                                    else { checkReasonflag = false; break; }
                            }
                        }

                        if(checkReasonflag == true)
                        {                           

                            
                            arrayLocReturn[0] = EndingChina.Title0Content;
                            arrayLocReturn[1] = EndingChina.Title5Content;
                            arrayLocReturn[2] = EndingChina.Title10Content;
                            arrayLocReturn[3] = EndingChina.Title27Content;
                            arrayLocReturn[4] = EndingChina.Title33Content;

                            arrayLocGo[0] = EndingChina.Title1Content;
                            arrayLocGo[1] = EndingChina.Title6Content;
                            arrayLocGo[2] = EndingChina.Title11Content;
                            arrayLocGo[3] = EndingChina.Title29Content;
                            arrayLocGo[4] = EndingChina.Title35Content;

                            arrayTimeGo[0] = EndingChina.Title2Content + "~" + EndingChina.Title14Example;
                            arrayTimeGo[1] = EndingChina.Title7Content + "~" + EndingChina.Title15Example;
                            arrayTimeGo[2] = EndingChina.Title12Content + "~" + EndingChina.Title16Example;
                            arrayTimeGo[3] = EndingChina.Title28Content + "~" + EndingChina.Title30Content;
                            arrayTimeGo[4] = EndingChina.Title34Content + "~" + EndingChina.Title36Content;

                            arrayVehide[0] = EndingChina.Title3Content;
                            arrayVehide[1] = EndingChina.Title8Content;
                            arrayVehide[2] = EndingChina.Title13Content;
                            arrayVehide[3] = EndingChina.Title31Content;
                            arrayVehide[4] = EndingChina.Title37Content;

                            arrayTotalTime[0] = EndingChina.Title4Content;
                            arrayTotalTime[1] = EndingChina.Title9Content;
                            arrayTotalTime[2] = EndingChina.Title14Content;
                            arrayTotalTime[3] = EndingChina.Title32Content;
                            arrayTotalTime[4] = EndingChina.Title38Content;

                            for (int i = 0; i < arrayLocReturn.Length; i++)
                            {
                                if (arrayLocReturn[i] == null) arrayLocReturn[i] = " ";
                                if (arrayLocGo[i] == null) arrayLocGo[i] = " ";
                                if (arrayTimeGo[i] == null) arrayLocGo[i] = " ";
                                if (arrayVehide[i] == null) arrayLocGo[i] = " ";
                                if (arrayTotalTime[i] == null) arrayLocGo[i] = " ";
                                string strGohome = @"insert into returnHome(AppNo,locationReturn,locationGo,timeReturn,Vehicle,totalTime,state) 
                                    values (@AppNo,@locationReturn,@locationGo,@timeReturn,@Vehicle,@totalTime,'2');";
                                SqlParameter[] parGohome = new SqlParameter[6];
                                parGohome.SetValue(new SqlParameter("AppNo", EndingChina.AppNo), 0);
                                parGohome.SetValue(new SqlParameter("locationReturn", arrayLocReturn[i].ToString()), 1);
                                parGohome.SetValue(new SqlParameter("locationGo", arrayLocGo[i].ToString()), 2);
                                parGohome.SetValue(new SqlParameter("timeReturn", arrayTimeGo[i].ToString()), 3);

                                parGohome.SetValue(new SqlParameter("Vehicle", arrayVehide[i].ToString()), 4);
                                parGohome.SetValue(new SqlParameter("totalTime", arrayTotalTime[i].ToString()), 5);

                                SqlCommand cmd2 = conn.CreateCommand();
                                cmd2.Transaction = trans;
                                cmd2.CommandType = CommandType.Text;
                                cmd2.CommandText = strGohome;
                                cmd2.Parameters.AddRange(parGohome);
                                rowff = cmd2.ExecuteNonQuery();
                                if (rowff > 0) checkReasonflag = true;
                                else { checkReasonflag = false; break; }
                            }
                        }

                       
                        //lay danh sach ky don 

                        var pName = EndingChina.Title1Example;
                        var pNo = EndingChina.Title2Example;
                        var pSelect = EndingChina.Title3Example;

                        string[] signSelect = pSelect.Split(',');
                        string[] signpNo = pNo.Split(',');
                        string[] signpName = pName.Split(',');
                        
                        if(checkReasonflag == true)
                        {
                            for(int i=0;i < signSelect.Length;i++)
                            {
                                string sqlStr = string.Format("INSERT INTO approvalSchedule(AppNo,signEmpNo,SignName,statusName,step) VALUES('{0}',N'{1}',N'{2}',N'{3}','{4}')", EndingChina.AppNo, signpNo[i].ToString().Trim(), signpName[i].ToString(), signSelect[i].ToString(), i);


                                SqlCommand cmd3 = conn.CreateCommand();
                                cmd3.Transaction = trans;
                                cmd3.CommandType = CommandType.Text;
                                cmd3.CommandText = sqlStr;

                                int rowAff = cmd3.ExecuteNonQuery();
                                if (rowAff > 0)
                                {
                                    checkReasonflag = true;
                                }
                                else
                                {
                                    checkReasonflag = false;
                                    break;
                                }
                            }
                        }
                        if (checkReasonflag == true)
                        {
                            bool kqSub = sb.f_submit_yellow("Submit", EndingChina.AppNo, 34, EndingChina.Title10Example, EndingChina.empID, 0);
                            if (kqSub == true)
                            {
                                checkReasonflag = true;
                            }
                            else
                            {
                                checkReasonflag = false;
                            }
                        }
                        if (checkReasonflag == true)
                        {
                            checkReasonflag = nCode.insertAppData(EndingChina.AppNo, signSelect[1].ToString(), EndingChina.empName, signpName[1].ToString(), DateTime.Now.ToString("yyyy/MM/dd HH:mm"), signpNo[1].ToString(), 34, 1, EndingChina.empID, "出差越南中幹期滿返鄉申請單", emp);
                        }
                        // ket thuc
                        if (checkReasonflag == true)
                        {
                            trans.Commit();
                            conn.Close();
                            sendM.insertSenmail(signpNo[1].Trim().ToString(), EndingChina.AppNo, "出差越南中幹期滿返鄉申請單", emp, "文件電子簽核申請單等待簽核", "出差越南中幹期滿返鄉申請單");
                            sendM.insertSenmail(emp, EndingChina.AppNo, "出差越南中幹期滿返鄉申請單", emp, "提交文件表格电子批准申请", "出差越南中幹期滿返鄉申請單");

                            return RedirectToAction("Index", "APP_ESIGN");
                        }
                        else
                        {
                            trans.Rollback();
                            conn.Close();
                            return View("EndingChina");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            //string a = EndingChina.empID;
            //string a1 = EndingChina.empName;

            //string ojkk = EndingChina.Title1;
            //string okada = "";
            //return View();
        }

        //ky don ket thuc cong tac cho can bo nuoc ngoai
        [HttpGet]
        public ActionResult signEnding(string appNo)
        {
            FORM_IT_01Model EndingChina = new FORM_IT_01Model();
            EndingChina = nCode.endingChina(appNo);
            string[] timeEntry = new string[3];
            string[] timeEntry2 = new string[3];

            if (EndingChina.Title7.Equals("") && EndingChina.Title8.Equals(""))
            {
                timeEntry = EndingChina.Title7.Split('-');
                EndingChina.Title12Example = timeEntry[0].ToString();
                EndingChina.Title13Example = timeEntry[1].ToString();
                EndingChina.Title14Example = timeEntry[2].ToString();

                timeEntry2 = EndingChina.Title8.Split('-');
                EndingChina.Title15Example = timeEntry[0].ToString();
                EndingChina.Title16Example = timeEntry[1].ToString();
                EndingChina.Title17Example = timeEntry[2].ToString();
               
            }
            else
            {

                EndingChina.Title12Example = "";
                EndingChina.Title13Example = "";
                EndingChina.Title14Example = "";

                EndingChina.Title15Example = "";
                EndingChina.Title16Example = "";
                EndingChina.Title17Example = "";
            }

            if (EndingChina.Title15Content.Equals("") && EndingChina.Title16Content.Equals(""))
            {
                timeEntry = EndingChina.Title15Content.Split('-');
                EndingChina.Title18Example = timeEntry[0].ToString();
                EndingChina.Title19Example = timeEntry[1].ToString();
                EndingChina.Title20Example = timeEntry[2].ToString();

                timeEntry2 = EndingChina.Title16Content.Split('-');
                EndingChina.Title21Example = timeEntry[0].ToString();
                EndingChina.Title22Example = timeEntry[1].ToString();
                EndingChina.Title23Example = timeEntry[2].ToString();
            }
            else
            {
                EndingChina.Title18Example = "";
                EndingChina.Title19Example = "";
                EndingChina.Title20Example = "";

                EndingChina.Title21Example = "";
                EndingChina.Title22Example = "";
                EndingChina.Title23Example = "";
            }


            return View(EndingChina);
        }

        [HttpPost]
        public ActionResult signEnding(FORM_IT_01Model model,string ApprovalButton)
        {
            bool kq = true;
            bool kq2 = true;
            string sqlQuery = "";
            string checkWait = "";
            string applicant = " ";
            SendMail sen = new SendMail();
            if (model.AppContent == null) model.AppContent = " ";
            switch (ApprovalButton)
            {
                case "Approval":
                    //kq = sb.f_insert_sub_yellow("通過", model.AppNo, model.AppContent);
                    kq2 = sb.SigningYellowCarD(model.AppNo, "Approval", model.AppContent);

                    DataTable dataTable = sb.f_get_desc(model.AppNo);
                    checkWait = dataTable.Rows[0]["Checkwait"].ToString();
                    applicant = dataTable.Rows[0]["ApplicantNo"].ToString();

                    //update  dataTable2.Rows[0]["CHECKWAITNAME"].ToString()
                    sen.insertSenmail(checkWait.Trim(), model.AppNo.Trim(), dataTable.Rows[0]["Title"].ToString(), applicant, "文件電子簽核申請單等待簽核", dataTable.Rows[0]["Title"].ToString());
                    break;
                case "Reject":
                    //kq = sb.f_insert_sub_yellow("駁回", model.AppNo, model.AppContent);
                    kq2 = sb.SigningYellowCarD(model.AppNo, "Reject", model.AppContent);

                    //sqlQuery = @"select * from DATA_APP_ESIGN where APPNO='" + fORM_IT_.AppNo.Trim() + "' ;";
                    DataTable dataTable2 = sb.f_get_desc(model.AppNo);
                    checkWait = dataTable2.Rows[0]["Checkwait"].ToString();
                    applicant = dataTable2.Rows[0]["ApplicantNo"].ToString();

                    bool kqsen = sen.insertSenmail(checkWait.Trim(), model.AppNo.Trim(), dataTable2.Rows[0]["Title"].ToString(), applicant, "文件電子簽核申請單被駁回", dataTable2.Rows[0]["Title"].ToString());
                    //string kqte = "";
                    break;
                case "Submit":

                    break;
                case "Delete":
                    break;

                case "ForWard":
                    //kq = sb.f_insert_sub_yellow("駁回", model.AppNo, model.AppContent);
                    kq2 = sb.forWardSigner(model.AppNo, model.AppContent, model.Title7Example, model.Title8Example, model.Title9Example);

                    //sqlQuery = @"select * from DATA_APP_ESIGN where APPNO='" + fORM_IT_.AppNo.Trim() + "' ;";
                    DataTable dataTable2VI2 = sb.f_get_desc(model.AppNo);
                    checkWait = dataTable2VI2.Rows[0]["Checkwait"].ToString();
                    applicant = dataTable2VI2.Rows[0]["ApplicantNo"].ToString();

                    bool kqsenVI2 = sen.insertSenmail(checkWait.Trim(), model.AppNo.Trim(), dataTable2VI2.Rows[0]["Title"].ToString(), applicant, "文件電子簽核申請單被駁回", dataTable2VI2.Rows[0]["Title"].ToString());
                    //string kqte = "";
                    break;
            }

            return RedirectToAction("WaitingForYourApproval", "APP_ESIGN");

        }
        
        //Mẫu đơn liên lạc mới
        [HttpGet]
        public ActionResult formContact2()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var emp = session.UserID.Trim();
            FORM_IT_01Model conModel = new FORM_IT_01Model();
            var formName = "FORM_HR_01";
            var formID = nCode.getFormID(formName);
            conModel = contactModel(formID);
            string strManage = itContr.checkManager(emp);
            conModel.Title2Content = emp;
            string[] listMan = strManage.Split(';');
            conModel.approvalApps[0].signEmpNo = emp.Trim().ToString();
            conModel.approvalApps[0].SignName = itContr.getName(emp.Trim());
            if (listMan.Length > 1)
            {
                conModel.approvalApps[1].signEmpNo = listMan[0].ToString();
                conModel.approvalApps[2].signEmpNo = listMan[1].ToString();
                conModel.approvalApps[1].SignName = itContr.getName(listMan[0].ToString().Trim());
                conModel.approvalApps[2].SignName = itContr.getName(listMan[1].ToString().Trim());
            }
            else
            {
                conModel.approvalApps[1].signEmpNo = listMan[0].ToString();
                conModel.approvalApps[1].SignName = itContr.getName(listMan[0].ToString().Trim());
            }

            DataTable tableEmp = postman.GetEmpInfomation(emp.Trim());
            // lay thong tin nguoi lam don
            conModel.Title2Content = emp;
            conModel.Title3Content = tableEmp.Rows[0]["USER_NAME"].ToString();
            conModel.Title7Content = tableEmp.Rows[0]["CURRENT_OU_NAME"].ToString();
            conModel.Title5Content = tableEmp.Rows[0]["NOTES_ID"].ToString();
            conModel.Title4Content = tableEmp.Rows[0]["CURRENT_OU_CODE"].ToString();

            string phone = nCode.getPhoneAccount(emp);
            if (!phone.Equals(""))
            {
                conModel.Title6Content = phone;
            }
            if (conModel.Title5Content.Equals("") || String.IsNullOrEmpty(conModel.Title5Content))
            {
                string mail = nCode.getMailAccount(emp);
                if (!mail.Equals(""))
                {
                    conModel.Title5Content = mail;
                }

            }
            return View(conModel);
        }

        [HttpPost]
        public ActionResult formContact2(FORM_IT_01Model reqModel)
        {
            return View();
        }

        public ActionResult TestPDF()
        {
            return View();
        }
    }
}