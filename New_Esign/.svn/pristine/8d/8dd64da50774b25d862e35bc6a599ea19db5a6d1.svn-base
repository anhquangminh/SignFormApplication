using New_Esign.AppCode;
using New_Esign.Areas.Employee.Models;
using New_Esign.Common;
using New_Esign.Controllers;
using NewModel.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New_Esign.Areas.Employee.Controllers
{
    public class RegisterAccountController : BaseUserController
    {
        private NewCode nCode = new NewCode();
        private SendMail sendM = new SendMail();
        private Submit sb = new Submit();
        private SQLServerDBHelper db = new SQLServerDBHelper();
        // GET: Employee/RegisterAccount
        [HttpGet]
        public ActionResult Index()
        {
            setViewFactoryDec();
            //FORM_IT_01Model conModel = new FORM_IT_01Model();
            return View();
        }

        private ApplicationITController itContr = new ApplicationITController();

        [HttpPost]
        public ActionResult Index(FORM_IT_01Model conModel)
        {
            bool checkReasonFlag = false;
            setViewFactoryDec();
            try
            {
                var dao = new AccountDao();
                                    
                    conModel.AppNo = DateTime.Now.ToString("yyyyMMddHHmmss") + GenerateRandom(2);
                    switch (conModel.Title15Content)
                    {
                        case "Esign system 2.0":
                            {
                                using (SqlConnection conn = new SqlConnection(@"Data Source=10.224.81.131,3000;Initial Catalog=esign;Persist Security Info=True;User ID=sa;Password=foxconn168!!"))
                                {
                                    
                                    int rowAff;
                                    if (conn.State != ConnectionState.Open) conn.Open();
                                    using (SqlTransaction trans = conn.BeginTransaction())
                                    {
                                        
                                        string strQuery = @"ngac nhien khong baby";
                                    //int checkAcc = dao.Login2(conModel.empID.Trim());
                                    //if(checkAcc == 1)
                                    //{
                                    //    string role="";
                                    //    if (conModel.role1) role += "USER;";
                                    //    if (conModel.role2) role += "MANAGERMENTUSER;";
                                    //    if (conModel.role3) role += "ITNETWORK;";
                                    //    if (conModel.role4) role += "ITMANAGER;";
                                    //    strQuery = @"update Account set note='"+role+"' where UserID='"+conModel.empID+"'";
                                    //    SqlCommand cmd = new SqlCommand(strQuery, conn, trans);
                                    //     rowAff = cmd.ExecuteNonQuery();
                                    //    if(rowAff > 0)
                                    //    {
                                    //        checkReasonFlag = true;
                                    //    }   

                                    //}
                                    //else
                                    //{
                                    //    string role = "";
                                    //    if (conModel.role1) role += "USER;";
                                    //    if (conModel.role2) role += "MANAGERMENTUSER;";
                                    //    if (conModel.role3) role += "ITNETWORK;";
                                    //    if (conModel.role4) role += "ITMANAGER;";
                                    //    strQuery = @"insert into Account(userid,username,telephone,Email,note) values(@userid,@username,@telephone,@Email,@note);";

                                    //    SqlCommand cmd = new SqlCommand(strQuery, conn, trans);

                                    //    SqlParameter[] param = new SqlParameter[5];
                                    //    param.SetValue(new SqlParameter("userid", conModel.empID), 0);
                                    //    param.SetValue(new SqlParameter("userid", conModel.empID), 0);
                                    //    param.SetValue(new SqlParameter("userid", conModel.empID), 0);
                                    //    param.SetValue(new SqlParameter("userid", conModel.empID), 0);

                                    //    rowAff = cmd.ExecuteNonQuery();
                                    //    if (rowAff > 0)
                                    //    {
                                    //        checkReasonFlag = true;
                                    //    }
                                    //}  
                                    string role = "";
                                    if (conModel.role11) role += "USER;";
                                    if (conModel.role12) role += "MANAGERMENTUSER;";
                                    if (conModel.role13) role += "ITNETWORK;";
                                    if (conModel.role14) role += "ITMANAGER;";

                                    strQuery = @"insert into RegisterAccount(EmpID,empName,EmpDePart,EmpPhone,EmpCost,EmpSys,EmpRole,EmpFac,EmpLocation,AppNoReg,EmpMail)
    values (@EmpID,@empName,@EmpDePart,@EmpPhone,@EmpCost,@EmpSys,@EmpRole,@EmpFac,@EmpLocation,@AppNoReg,@EmpMail);";
                                        SqlCommand cmd = new SqlCommand(strQuery, conn, trans);
                                        SqlParameter[] param = new SqlParameter[11];
                                        param.SetValue(new SqlParameter("EmpID", conModel.empID), 0);
                                        param.SetValue(new SqlParameter("empName", conModel.empName), 1);
                                        param.SetValue(new SqlParameter("EmpDePart", conModel.Title3Content), 2);
                                        param.SetValue(new SqlParameter("EmpPhone", conModel.Title2Content), 3);
                                        param.SetValue(new SqlParameter("EmpCost", conModel.Title4Content), 4);

                                        param.SetValue(new SqlParameter("EmpSys", conModel.Title15Content), 5);
                                        param.SetValue(new SqlParameter("EmpRole", role), 6);
                                        param.SetValue(new SqlParameter("EmpFac", conModel.Title14Content), 7);
                                        param.SetValue(new SqlParameter("EmpLocation", conModel.Title5Content), 8);
                                        param.SetValue(new SqlParameter("AppNoReg", conModel.AppNo.Trim()), 9);
                                        param.SetValue(new SqlParameter("EmpMail", conModel.Title1Content), 10);




                                        cmd.Parameters.AddRange(param);
                                        rowAff = cmd.ExecuteNonQuery();
                                        if (rowAff > 0) checkReasonFlag = true;

                                        if (checkReasonFlag)
                                        {
                                            // thiet lap luu trinh ky don
                                            string[] managerDep = itContr.checkManager(conModel.empID).Split(';');
                                            managerDep = managerDep.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                                            string[] managerDepTitle = new string[managerDep.Length];
                                            if (managerDep.Length > 1)
                                            {
                                                managerDepTitle[0] = "課級 / Cấp phòng"; managerDepTitle[1] = "部級 / Cấp bộ phận";
                                            }
                                            else
                                            {
                                                managerDepTitle[0] = " 部級 / Cấp bộ phận";
                                            }

                                            string[] managerIT = { "V0903271" };
                                            string[] managerITtitle = { "會簽IT課長 / Trưởng phòng IT " };

                                            string[] signer = new string[managerDep.Length + managerIT.Length + 2];
                                            string[] signerTitle = new string[managerDep.Length + managerIT.Length + 2];

                                            signer[0] = conModel.empID;
                                            signerTitle[0] = "申請人 / Người xin đơn";

                                            for (int i = 0; i < signer.Length; i++)
                                            {
                                                if (signer[i] == null)
                                                {
                                                    for (int j = 0; j < managerDep.Length; j++)
                                                    {
                                                        signer[i + j] = managerDep[j].ToString();
                                                        signerTitle[i + j] = managerDepTitle[j].ToString();
                                                    }
                                                    break;
                                                }
                                            }
                                            for (int i = 0; i < signer.Length; i++)
                                            {
                                                if (signer[i] == null)
                                                {
                                                    for (int j = 0; j < managerIT.Length; j++)
                                                    {
                                                        signer[i + j] = managerIT[j].ToString();
                                                        signerTitle[i + j] = managerITtitle[j].ToString();
                                                    }
                                                    break;
                                                }
                                            }
                                            for (int i = 0; i < signer.Length; i++)
                                            {
                                                if (signer[i] == null)
                                                {
                                                    signer[i] = "V0957033";

                                                    signerTitle[i] = "結案單位IT / IT kết án ";
                                                    break;
                                                }
                                            }
                                            string name = "";
                                            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                                            var empCreate = session.UserID.Trim();
                                            for (int i = 0; i < signer.Length; i++)
                                            {
                                                name = itContr.getName(signer[i].Trim().ToString());
                                                nCode.insertListSign(conModel.AppNo, signer[i].Trim().ToString(), name, signerTitle[i].ToString(), i);
                                            }
                                            string signerName =itContr.getName(signer[1].ToString());
                                            nCode.insertAppData(conModel.AppNo, signerTitle[1].ToString(), conModel.empName, signerName, DateTime.Now.ToString("yyyy/MM/dd HH:mm"), signer[1].ToString(), 2, 1, conModel.empID, "Register Account", empCreate);


                                            sb.f_submit_yellow("Submit", conModel.AppNo, 2, conModel.empName, conModel.empID, 0);

                                            sendM.insertSenmail(signer[1].Trim().ToString(), conModel.AppNo, "Register Account", signer[0].Trim().ToString(), "文件電子簽核申請單等待簽核", "Register Account");
                                            sendM.insertSenmail(signer[0].Trim().ToString(), conModel.AppNo, "Register Account", signer[0].Trim().ToString(), "提交文件表格电子批准申请", conModel.Title1Content);
                                        }

                                        if (checkReasonFlag == true) trans.Commit();
                                        else trans.Rollback();

                                        if (conn.State == ConnectionState.Open) conn.Close();
                                    }
                                }
                                    break;
                            }
                        default:
                            {
                                break;
                            }                
                    }
            }
            catch
            {

            }

            if(checkReasonFlag) return RedirectToAction("ListSoftWare", "APP_ESIGN");
            else
            {
                return View(conModel);
            }
            
        }

        // bieu mau ky don
        [HttpGet]
        public ActionResult RegisterSigning(string appNo)
        {
            FORM_IT_01Model conModel = requestModelReg(appNo);
            return View(conModel);
        }
        [HttpPost]
        public ActionResult RegisterSigning(FORM_IT_01Model model,string ApprovalButton)
        {
            bool kq = true;
            bool kq2 = true;
            string sqlQuery = "";
            string checkWait = "";
            string applicant = "";
            if (model.AppContent == null) model.AppContent = " ";
            
            SendMail sen = new SendMail();
            switch (ApprovalButton)
            {
                case "Approval":
                    //kq = sb.f_insert_sub_yellow("通過", model.AppNo, model.USB_Write);
                    kq2 = sb.SigningYellowCarD(model.AppNo, "Approval", model.AppContent);
                    DataTable dataTable = sb.f_get_desc(model.AppNo);
                    applicant = dataTable.Rows[0]["USEREMP"].ToString();
                    checkWait = dataTable.Rows[0]["Checkwait"].ToString();

                    //update  dataTable2.Rows[0]["CHECKWAITNAME"].ToString()
                    sen.insertSenmail(checkWait.Trim(), model.AppNo.Trim(), dataTable.Rows[0]["Title"].ToString(), applicant, "文件電子簽核申請單等待簽核");
                    break;
                case "Reject":
                    //kq = sb.f_insert_sub_yellow("駁回", model.AppNo, model.USB_Write);
                    kq2 = sb.SigningYellowCarD(model.AppNo, "Reject", model.AppContent);

                    //sqlQuery = @"select * from DATA_APP_ESIGN where APPNO='" + fORM_IT_.AppNo.Trim() + "' ;";
                    DataTable dataTable2 = sb.f_get_desc(model.AppNo);
                    checkWait = dataTable2.Rows[0]["Checkwait"].ToString();
                    SendMail sen2 = new SendMail();
                    bool kqsen = sen2.insertSenmail(checkWait.Trim(), model.AppNo.Trim(), dataTable2.Rows[0]["Title"].ToString(), applicant, "文件電子簽核申請單被駁回");
                    //string kqte = "";
                    break;
            }
            return RedirectToAction("WaitingForYourApproval", "APP_ESIGN");
        }

        public void setViewFactoryDec(long? selectedID = null)
        {
            ViewBag.Title14Content = new SelectList(nCode.listFac(), "Factory_name", "Factory_name", selectedID);
        }

        public static char[] constant =
        {
        '0','1','2','3','4','5','6','7','8','9'
        };
        public static string GenerateRandom(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(10);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(10)]);
            }
            return newRandom.ToString();
        }

        public FORM_IT_01Model requestModelReg(string appNo)
        {
            FORM_IT_01Model conModel = new FORM_IT_01Model();
            try
            {
                //            AppNo,EmpNo,Name,NumPhone,Site,BU,
                //    Depart,Mail,CodeCost,OfficeFac,Location,MacAd,ComputerSpeci,ComputerBrand,
                //KindofPC,AssetCode,TimeStart,TimeEnd,ApplicationType,ComputerName,IPAdd,SeriNum,ColorPC,
                //LocationApply,filePath,fileName,Reason,USB_Read,FactoryApply

                string sqlQuery = @"select * from RegisterAccount where AppNoReg='" + appNo + "' ";
                DataTable table = new DataTable();

                table = db.DoSQLSelect(sqlQuery);
                if (table.Rows.Count > 0)
                {
                    conModel.empID = table.Rows[0]["EmpID"].ToString();
                    conModel.empName = table.Rows[0]["EmpName"].ToString();
                    conModel.Title3Content = table.Rows[0]["EmpDePart"].ToString();
                    conModel.Title2Content = table.Rows[0]["EmpPhone"].ToString();
                    conModel.Title6 = table.Rows[0]["EmpCost"].ToString();
                    conModel.AppNo = table.Rows[0]["AppNoReg"].ToString();

                    conModel.Title1Content = table.Rows[0]["EmpMail"].ToString();
                    conModel.Title15Content = table.Rows[0]["EmpSys"].ToString();
                    conModel.Title4Content = table.Rows[0]["EmpRole"].ToString();
                    conModel.Title14Content = table.Rows[0]["EmpFac"].ToString();
                    conModel.Title5Content = table.Rows[0]["EmpLocation"].ToString();

                    

                    if (conModel.Title4Content.Contains("USER")) conModel.role11 = true;
                    if (conModel.Title4Content.Contains("MANAGERMENT")) conModel.role12 = true;
                    if (conModel.Title4Content.Contains("ITNETWORK")) conModel.role13 = true;
                    if (conModel.Title4Content.Contains("ITMANAGER")) conModel.role14 = true;

                    

                    // list sign
                    string sqlQuerySign = @"SELECT step,statusName,SignName,signEmpNo,fowardInfo,(select top 1 approvalname from approvalsuggest where orderNo=a.AppNo and statusname=a.statusname and stt = a.step and (approvalid = a.signEmpNo or approvalid=a.signOver) order by approvaltime desc ) approvalname,  " +
                                   " (select top 1 status from approvalsuggest where orderNo = a.AppNo and statusname = a.statusname and stt = a.step and(approvalid = a.signEmpNo or approvalid = a.signOver) order by approvaltime desc ) status,  " +
                                   " (select top 1 approvalsuggest from approvalsuggest where orderNo = a.AppNo and statusname = a.statusname and stt = a.step  and(approvalid = a.signEmpNo or approvalid = a.signOver) order by approvaltime desc ) approvalsuggest,  " +
                                   " (select top 1 approvaltime from approvalsuggest where orderNo = a.AppNo and statusname = a.statusname and stt = a.step and(approvalid = a.signEmpNo or approvalid = a.signOver) order by approvaltime desc ) approvaltime " +
                                   " FROM approvalSchedule a " +
                                   " where a.AppNo = '" + appNo + "' " +
                                   " order by CONVERT(int, step); ";
                    DataTable tb2 = db.DoSQLSelect(sqlQuerySign);
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
                        conModel.approvalApps = listApprovals;
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }

            return conModel;
        }

    }
}