using New_Esign.Areas.Employee.Models;
using NewModel.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PagedList;
using New_Esign.Areas.Administrators.Models;

namespace New_Esign.AppCode
{
    public class NewCode
    {
        private SQLServerDBHelper db = new SQLServerDBHelper("ESignDB");

        private SQLServerDBHelper dbPC = new SQLServerDBHelper("ConnectDB");
        public int getFormID(string formName)
        {
           // SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            string tempStr = @"SELECT FormID FROM Forms where FormName = '" + formName + "'";
            DataTable dt = db.DoSQLSelect(tempStr);

            string te = dt.Rows[0]["FormID"].ToString();
            int formID = Convert.ToInt32(te);
            return formID;
        }

        //public DataTable getSubmitSign(int appNo)
        //{
        //    SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
        //    string tempStr = @"SELECT * FROM SubmitSign where FormID = '" + appNo + "'";
        //    DataTable tb = db.DoSQLSelect(tempStr);           
        //    return tb;
        //}
        public DataTable getSubmitApp(string appNo)
        {
            //SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            string tempStr = @"SELECT * FROM DATA_APP_ESIGN where APPNO = '" + appNo + "'";
            DataTable tb = db.DoSQLSelect(tempStr);
            return tb;
        }
        public void newCreateAppFormIT02(EmpModel am)
        {
            if (am != null)
            {
                try
                {
                    SQLServerDBHelper db = new SQLServerDBHelper("ESignDB");

                    string InsertSQL = @"INSERT INTO DATA_APP_ESIGN(APPNO,ApplicantNo,ApplicantName,
ApplicantCode,ApplicantMail,ApplicantPhone,ApplicantDep,Recipientunit,
Organizer,Copysubmission,Page,Issuer,Documentnumber,Daycreate,Title,AppContent,FileName,USERNAME,Signer1No,
Signer1Name,Signer2No,Signer2Name,Signer3No,Signer3Name,Signer4No,Signer4Name,Signer5No,Signer5Name,Signer6No,Signer6Name,
APPSTATES,Checkwait,FormID,APPSTATUS,CHECKWAITNAME) VALUES(@APPNO,@ApplicantNo,@ApplicantName,@ApplicantCode,@ApplicantMail,@ApplicantPhone,@ApplicantDep,@Recipientunit,
@Organizer,@Copysubmission,@Page,@Issuer,@Documentnumber,@Daycreate,@Title,@AppContent,@FileName,@USERNAME,@Signer1No,
@Signer1Name,@Signer2No,@Signer2Name,@Signer3No,@Signer3Name,@Signer4No,@Signer4Name,@Signer5No,@Signer5Name,@Signer6No,@Signer6Name,
@APPSTATES,@Checkwait,@FormID, @APPSTATUS,@CHECKWAITNAME)";
                    SqlParameter[] parameters = new SqlParameter[35];
                    parameters.SetValue(new SqlParameter("APPNO", am.APPNO), 0);
                    parameters.SetValue(new SqlParameter("ApplicantNo", am.ApplicantNo), 1);
                    parameters.SetValue(new SqlParameter("ApplicantName", am.ApplicantName), 2);
                    parameters.SetValue(new SqlParameter("ApplicantCode", am.ApplicantCode), 3);
                    parameters.SetValue(new SqlParameter("ApplicantMail", am.ApplicantMail), 4);
                    parameters.SetValue(new SqlParameter("ApplicantPhone", am.ApplicantPhone), 5);
                    parameters.SetValue(new SqlParameter("ApplicantDep", am.ApplicantDep), 6);
                    parameters.SetValue(new SqlParameter("Recipientunit", am.Recipientunit), 7);
                    parameters.SetValue(new SqlParameter("Organizer", am.Organizer), 8);
                    parameters.SetValue(new SqlParameter("Copysubmission", am.Copysubmission), 9);
                    parameters.SetValue(new SqlParameter("Page", am.Page), 10);
                    parameters.SetValue(new SqlParameter("Issuer", am.Issuer), 11);
                    parameters.SetValue(new SqlParameter("Documentnumber", am.Documentnumber), 12);
                    parameters.SetValue(new SqlParameter("Daycreate", am.Daycreate), 13);
                    parameters.SetValue(new SqlParameter("Title", am.Title), 14);
                    parameters.SetValue(new SqlParameter("AppContent", am.AppContent), 15);
                    parameters.SetValue(new SqlParameter("FileName", am.FileName), 16);
                    parameters.SetValue(new SqlParameter("USERNAME", am.Username), 17);
                    parameters.SetValue(new SqlParameter("Signer1No", am.Signer1No), 18);
                    parameters.SetValue(new SqlParameter("Signer1Name", am.Signer1Name), 19);
                    parameters.SetValue(new SqlParameter("Signer2No", am.Signer2No), 20);
                    parameters.SetValue(new SqlParameter("Signer2Name", am.Signer2Name), 21);
                    parameters.SetValue(new SqlParameter("Signer3No", am.Signer3No), 22);
                    parameters.SetValue(new SqlParameter("Signer3Name", am.Signer3Name), 23);
                    parameters.SetValue(new SqlParameter("Signer4No", am.Signer4No), 24);
                    parameters.SetValue(new SqlParameter("Signer4Name", am.Signer4Name), 25);
                    parameters.SetValue(new SqlParameter("Signer5No", am.Signer5No), 26);
                    parameters.SetValue(new SqlParameter("Signer5Name", am.Signer5Name), 27);
                    parameters.SetValue(new SqlParameter("Signer6No", am.Signer6No), 28);
                    parameters.SetValue(new SqlParameter("Signer6Name", am.Signer6Name), 29);
                    parameters.SetValue(new SqlParameter("APPSTATES", am.APPSTATES), 30);
                    parameters.SetValue(new SqlParameter("Checkwait", am.Checkwait), 31);
                    parameters.SetValue(new SqlParameter("FormID", am.FormID), 32);
                    parameters.SetValue(new SqlParameter("APPSTATUS", am.APPSTATUS), 33);
                    parameters.SetValue(new SqlParameter("CHECKWAITNAME", am.CHECKWAITNAME), 34);

                    db.ExcuteNonQuery(InsertSQL, parameters);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //if (db.ExcuteNonQuery(InsertSQL))
                //    Ultils.WriteCookie("Success", LanguageHelper.GetResource("AddSuccess"));
                //else
                //    Ultils.WriteCookie("Error", LanguageHelper.GetResource("AddFail"));
            }
            else
            {
                Ultils.WriteCookie("Error", LanguageHelper.GetResource("ApproverUpdateEmpty"));
            }
        }
        // lay du lieu tu don tu database
        //public DataTable getDataApp(string appNo)
        //{
        public void UpdatenewAppFormIT02(ApprovalApp am, string appNo)
        {
            if (am != null)
            {
                try
                {
                    //SQLServerDBHelper db = new SQLServerDBHelper("ESignDB");

                    string InsertSQL = @"update DATA_APP_ESIGN set Recipientunit=@Recipientunit,Organizer=@Organizer,Copysubmission=@Copysubmission,Page=@Page,Issuer=@Issuer,
Documentnumber=@Documentnumber,Title=@Title,AppContent=@AppContent,FileName=@FileName, USERNAME= @USERNAME,
Signer1No=@Signer1No,Signer1Name=@Signer1Name,Signer2No=@Signer2No,Signer2Name=@Signer2Name,Signer3No=@Signer3No,
Signer3Name=@Signer3Name,Signer4No=@Signer4No,Signer4Name=@Signer4Name,Signer5No=@Signer5No,Signer5Name=@Signer5Name,
Signer6No=@Signer6No,Signer6Name=@Signer6Name,APPSTATES=@APPSTATES,Checkwait=@Checkwait,APPSTATUS=@APPSTATUS,CHECKWAITNAME=@CHECKWAITNAME where APPNO='" + appNo+"'";
                    SqlParameter[] parameters = new SqlParameter[26]; 
                    
                    parameters.SetValue(new SqlParameter("Recipientunit", am.EmpModels.Recipientunit), 0);
                    parameters.SetValue(new SqlParameter("Organizer", am.EmpModels.Organizer), 1);
                    parameters.SetValue(new SqlParameter("Copysubmission", am.EmpModels.Copysubmission), 2);
                    parameters.SetValue(new SqlParameter("Page", am.EmpModels.Page), 3);
                    parameters.SetValue(new SqlParameter("Issuer", am.EmpModels.Issuer), 4);
                    parameters.SetValue(new SqlParameter("Documentnumber", am.EmpModels.Documentnumber), 5);

                    parameters.SetValue(new SqlParameter("Title", am.EmpModels.Title), 6);
                    parameters.SetValue(new SqlParameter("AppContent", am.EmpModels.AppContent), 7);
                    parameters.SetValue(new SqlParameter("FileName", am.EmpModels.FileName), 8);                    
                    parameters.SetValue(new SqlParameter("Signer1No", am.EmpModels.Signer1No), 9);
                    parameters.SetValue(new SqlParameter("Signer1Name", am.EmpModels.Signer1Name), 10);

                    parameters.SetValue(new SqlParameter("Signer2No", am.EmpModels.Signer2No), 11);
                    parameters.SetValue(new SqlParameter("Signer2Name", am.EmpModels.Signer2Name), 12);
                    parameters.SetValue(new SqlParameter("Signer3No", am.EmpModels.Signer3No), 13);
                    parameters.SetValue(new SqlParameter("Signer3Name", am.EmpModels.Signer3Name), 14);
                    parameters.SetValue(new SqlParameter("Signer4No", am.EmpModels.Signer4No), 15);

                    parameters.SetValue(new SqlParameter("Signer4Name", am.EmpModels.Signer4Name), 16);
                    parameters.SetValue(new SqlParameter("Signer5No", am.EmpModels.Signer5No), 17);
                    parameters.SetValue(new SqlParameter("Signer5Name", am.EmpModels.Signer5Name), 18);
                    parameters.SetValue(new SqlParameter("Signer6No", am.EmpModels.Signer6No), 19);
                    parameters.SetValue(new SqlParameter("Signer6Name", am.EmpModels.Signer6Name), 20);

                    parameters.SetValue(new SqlParameter("APPSTATES", am.EmpModels.APPSTATES), 21);
                    parameters.SetValue(new SqlParameter("Checkwait", am.EmpModels.Checkwait), 22);
                    parameters.SetValue(new SqlParameter("APPSTATUS", am.EmpModels.APPSTATUS), 23);
                    parameters.SetValue(new SqlParameter("CHECKWAITNAME", am.EmpModels.CHECKWAITNAME), 24);
                    parameters.SetValue(new SqlParameter("USERNAME", am.EmpModels.Username), 25);

                    db.ExcuteNonQuery(InsertSQL, parameters);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //if (db.ExcuteNonQuery(InsertSQL))
                //    Ultils.WriteCookie("Success", LanguageHelper.GetResource("AddSuccess"));
                //else
                //    Ultils.WriteCookie("Error", LanguageHelper.GetResource("AddFail"));
            }
            else
            {
                Ultils.WriteCookie("Error", LanguageHelper.GetResource("ApproverUpdateEmpty"));
            }
        }

        public void Update1newAppFormIT02(ApprovalApp am, string appNo)
        {
            if (am != null)
            {
                try
                {
                   // SQLServerDBHelper db = new SQLServerDBHelper("ESignDB");

                    string InsertSQL = @"update DATA_APP_ESIGN set Recipientunit=@Recipientunit,
Organizer=@Organizer,Copysubmission=@Copysubmission,Page=@Page,Issuer=@Issuer,Documentnumber=@Documentnumber,
Title=@Title,Signer1No=@Signer1No,Signer1Name=@Signer1Name,
Signer2No=@Signer2No,Signer2Name=@Signer2Name,Signer3No=@Signer3No,Signer3Name=@Signer3Name,Signer4No=@Signer4No,
Signer4Name=@Signer4Name,Signer5No=@Signer5No,Signer5Name=@Signer5Name,Signer6No=@Signer6No,Signer6Name=@Signer6Name,
APPSTATES=@APPSTATES,Checkwait=@Checkwait,APPSTATUS=@APPSTATUS,CHECKWAITNAME=@CHECKWAITNAME where APPNO='" + appNo + "'";
                    SqlParameter[] parameters = new SqlParameter[23];
                    parameters.SetValue(new SqlParameter("Recipientunit", am.EmpModels.Recipientunit), 0);
                    parameters.SetValue(new SqlParameter("Organizer", am.EmpModels.Organizer), 1);
                    parameters.SetValue(new SqlParameter("Copysubmission", am.EmpModels.Copysubmission), 2);
                    parameters.SetValue(new SqlParameter("Page", am.EmpModels.Page), 3);
                    parameters.SetValue(new SqlParameter("Issuer", am.EmpModels.Issuer), 4);
                    parameters.SetValue(new SqlParameter("Documentnumber", am.EmpModels.Documentnumber), 5);
                    parameters.SetValue(new SqlParameter("CHECKWAITNAME", am.EmpModels.CHECKWAITNAME), 6);
                    parameters.SetValue(new SqlParameter("Title", am.EmpModels.Title), 7);
                    parameters.SetValue(new SqlParameter("Signer1Name", am.EmpModels.Signer1Name), 8);
                    parameters.SetValue(new SqlParameter("Signer1No", am.EmpModels.Signer1No), 9);
                    parameters.SetValue(new SqlParameter("Signer2No", am.EmpModels.Signer2No), 10);
                    parameters.SetValue(new SqlParameter("Signer2Name", am.EmpModels.Signer2Name), 11);
                    parameters.SetValue(new SqlParameter("Signer3No", am.EmpModels.Signer3No), 12);
                    parameters.SetValue(new SqlParameter("Signer3Name", am.EmpModels.Signer3Name), 13);
                    parameters.SetValue(new SqlParameter("Signer4No", am.EmpModels.Signer4No), 14);
                    parameters.SetValue(new SqlParameter("Signer4Name", am.EmpModels.Signer4Name), 15);
                    parameters.SetValue(new SqlParameter("Signer5No", am.EmpModels.Signer5No), 16);
                    parameters.SetValue(new SqlParameter("Signer5Name", am.EmpModels.Signer5Name), 17);
                    parameters.SetValue(new SqlParameter("Signer6No", am.EmpModels.Signer6No), 18);
                    parameters.SetValue(new SqlParameter("Signer6Name", am.EmpModels.Signer6Name), 19);
                    parameters.SetValue(new SqlParameter("APPSTATES", am.EmpModels.APPSTATES), 20);
                    parameters.SetValue(new SqlParameter("Checkwait", am.EmpModels.Checkwait), 21);
                    parameters.SetValue(new SqlParameter("APPSTATUS", am.EmpModels.APPSTATUS), 22);

                    db.ExcuteNonQuery(InsertSQL, parameters);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //if (db.ExcuteNonQuery(InsertSQL))
                //    Ultils.WriteCookie("Success", LanguageHelper.GetResource("AddSuccess"));
                //else
                //    Ultils.WriteCookie("Error", LanguageHelper.GetResource("AddFail"));
            }
            else
            {
                Ultils.WriteCookie("Error", LanguageHelper.GetResource("ApproverUpdateEmpty"));
            }
        }
        //}
        // lay ra ten tu ma the 
        public string getNameEmp(string empNo)
        {
            PostmanService.PostmanServiceSoapClient postman = new PostmanService.PostmanServiceSoapClient();
            DataTable tb = new DataTable();
            tb = postman.GetEmpInfomation(empNo);
            string empName = tb.Rows[0]["USER_NAME"].ToString();
            return empName;
        }
        // lay danh sach nguoi ky tu postman
        public string getListManager(string empNo)
        {
            PostmanService.PostmanServiceSoapClient postman = new PostmanService.PostmanServiceSoapClient();
            //PostmanService.PostmanServiceSoapClient postman = new PostmanService.PostmanServiceSoapClient();
            DataTable tb = new DataTable();
            tb = postman.GetEmpInfomation(empNo);
            string SITE_ALL_MANAGERS = tb.Rows[0]["SITE_ALL_MANAGERS"].ToString();
            string[] manageEmpNo2 = SITE_ALL_MANAGERS.Split(';');
            string[] manageEmpNo = new string[manageEmpNo2.Length + 1];
            manageEmpNo[0] = empNo;
            for(int i = 1; i< manageEmpNo2.Length; i++)
            {
                manageEmpNo[i] = manageEmpNo2[i - 1];
            }
            string signer1 = "";
            // ky thay cho truong phong
            string signer9 = "";
            string signer2 = "";
            // ky thay cho truong phong cap cao
            string signerList = "";
            //string manageAuthorizationAgent31 = "";
            for(int i=0; i < manageEmpNo.Length; i++)
            {
                if(String.IsNullOrEmpty(manageEmpNo[i].ToString()))
                {
                    continue;
                }
                DataTable managerDt = postman.GetEmpInfomation(manageEmpNo[i].ToString());
                string level = managerDt.Rows[0]["USER_LEVEL"].ToString();
                string notDuty = managerDt.Rows[0]["NOTDUTY"].ToString();
                string travel = managerDt.Rows[0]["TRAVEL"].ToString();
                if (Convert.ToInt32(level) >= 10 )
                {
                    signer1 = manageEmpNo[i];
                    break;
                    //if (notDuty != "No" || travel != "No")
                    //{
                    //    signer1 = manageEmpNo[i];
                    //    DataTable manageEmpNoDt = postman.GetEmp_Agent(manageEmpNo[i]);
                    //    if (manageEmpNoDt.Rows.Count > 0 && (notDuty != "No" || travel != "No"))
                    //    {
                    //        signer1 = manageEmpNoDt.Rows[0]["AGENT_WHO"].ToString();
                    //    }
                    //    break;
                    //}
                    //else
                    //{
                    //    signer1 = manageEmpNo[i];
                    //    break;
                    //}
                }                                  
            }
            for(int i = 0; i < manageEmpNo.Length;i++)
            {
                if(String.IsNullOrEmpty(manageEmpNo[i].ToString()))
                {
                    continue;
                }
                DataTable managerDt = postman.GetEmpInfomation(manageEmpNo[i].ToString());
                string level = managerDt.Rows[0]["USER_LEVEL"].ToString();
                string notDuty = managerDt.Rows[0]["NOTDUTY"].ToString();
                string travel = managerDt.Rows[0]["TRAVEL"].ToString();
                if(Convert.ToInt32(level) > 19 && Convert.ToInt32(level) < 30)
                {
                    signer2 = manageEmpNo[i];
                    break;
                    //if (notDuty!="No" || travel != "No")
                    //{
                    //    signer2 = manageEmpNo[i];
                    //    DataTable manageAuthorizationAgent30Dt = postman.GetEmp_Agent(manageEmpNo[i]);
                    //    if((notDuty != "No" || travel != "No") && manageAuthorizationAgent30Dt.Rows.Count > 0)
                    //    {

                    //        signer2 = manageAuthorizationAgent30Dt.Rows[0]["AGENT_WHO"].ToString();
                    //    }
                    //    break;
                    //}
                    //else
                    //{
                    //    signer2 = manageEmpNo[i];
                    //    break;
                    //}
                }                
            }
            signerList = signer1 + ";" + signer2;
            return signerList;
        }
        // Lay thong tin don giay phep phan mem
        public FORM_IT_01Model sftData(string appNo)
        {
            FORM_IT_01Model mForm = new FORM_IT_01Model();
            string strQuery = @" select * from SoftWareDeclare where AppNo='" + appNo.Trim() + "' ;";
            DataTable tb = new DataTable();
            tb = db.DoSQLSelect(strQuery);
            if(tb.Rows.Count > 0)
            {
                mForm.AppNo = tb.Rows[0]["AppNo"].ToString();
                mForm.empID = tb.Rows[0]["UserNo"].ToString();
                mForm.empName = tb.Rows[0]["UserName"].ToString();
                mForm.Title2Content = tb.Rows[0]["UserPhone"].ToString();
                mForm.Title1Content = tb.Rows[0]["UserMail"].ToString();

                mForm.Title3Content = tb.Rows[0]["UserDept"].ToString();
                mForm.Title1 = tb.Rows[0]["Applicant"].ToString();
                mForm.Title6Content = tb.Rows[0]["swName"].ToString();
                mForm.Title19Content = tb.Rows[0]["Version"].ToString();
                mForm.Title13Content = tb.Rows[0]["Reason"].ToString();

                mForm.Title9 = tb.Rows[0]["fileName"].ToString();
                mForm.Title5Content = tb.Rows[0]["Location"].ToString();
                mForm.Title15Content = tb.Rows[0]["IP"].ToString();
                mForm.Title9Content = tb.Rows[0]["computerType"].ToString();
                mForm.Title11Content = tb.Rows[0]["operatingSystem"].ToString();

                mForm.Title10Content = tb.Rows[0]["systemType"].ToString();
                mForm.Title8 = tb.Rows[0]["filePath"].ToString();
                mForm.Title7 = tb.Rows[0]["TimeCreate"].ToString();
                mForm.Title14Content = tb.Rows[0]["Factory"].ToString();
                mForm.Title4Content = tb.Rows[0]["CodeCost"].ToString();
                string timeApply = tb.Rows[0]["Depart"].ToString();
                string[] arrayTimeApply = timeApply.Split('-');

                mForm.Title7Content = arrayTimeApply[0].ToString();
                mForm.Title8Content = arrayTimeApply[1].ToString();
            }
            return mForm;
        }

        //get list software declare
        public List<DATA_APP_ESIGN> listDeclare(string strWhere)
        {
            string strQuery = @"select * from SoftWareDeclare ";
            if(strWhere == null || String.IsNullOrEmpty(strWhere) )
            {
                strQuery += " order by id desc ";
            }
            else
            {
                strQuery += " where AppNo like '%" + strWhere.Trim() + "%' or UserName like N'%" + strWhere.Trim() + "%' or swName like N'%" + strWhere.Trim() + "%' or computerType like N'%" + strWhere.Trim() + "%' ";
                strQuery += " or UserNo like N'%" + strWhere.Trim() + "%' order by id desc ";
            }
            DataTable tb = new DataTable();
            tb = db.DoSQLSelect(strQuery);
            List<DATA_APP_ESIGN> listData = new List<DATA_APP_ESIGN>();
            if(tb.Rows.Count > 0)
            {
                for(int i=0;i< tb.Rows.Count;i++)
                {
                    listData.Add(
                        new DATA_APP_ESIGN
                        {
                            APPNO = tb.Rows[i]["AppNo"].ToString(),
                            USERNAME = tb.Rows[i]["UserName"].ToString(),
                            AppContent = tb.Rows[i]["swName"].ToString(),
                            APPTYPE = tb.Rows[i]["computerType"].ToString(),
                            ApplicantNo = tb.Rows[i]["Applicant"].ToString(),
                            APPREASON = tb.Rows[i]["systemType"].ToString(),
                            Daycreate = tb.Rows[i]["TimeCreate"].ToString(),
                        }
                        );
                }
            }
            return listData;
        }

        // check quyen 
        public bool checkLevel(string userId,string role)
        {
            

            bool checkKQ = false;

            string strQueAc = @"select * from Account where UserID='" + userId.Trim() + "' ";
            DataTable tbLay = db.DoSQLSelect(strQueAc);

            string level = "";
            string levelCheck = role;
            if (tbLay.Rows.Count > 0)
            {
                level = tbLay.Rows[0]["Note"].ToString();
            }
            if(level.Contains(levelCheck))
            {
                checkKQ = true;
            }
            return checkKQ;
        }
        // get list app 
        public List<DATA_APP_ESIGN> ListIssue()
        {
            DBConnectData db = new DBConnectData();
            var list = db.Database.SqlQuery<DATA_APP_ESIGN>("SP_getdata_app").ToList();
            return list;
        }

        //get List factory
        public List<FACTORY> listFac()
        {
            DBConnectData dB = new DBConnectData();
            var list = dB.Database.SqlQuery<FACTORY>("SP_GETDATA_FAC").ToList();
            return list;
        }

        // lay ma the chu quan xuong theo ten xuong
        public string checkManagerLo(string loca)
        {
            string empMana = "";
            string sqlQuery = @"select * from factoryManager where factory = '" + loca.Trim() + "' ";
            DataTable table = dbPC.DoSQLSelect(sqlQuery);
            if(table.Rows.Count > 0)
            {
                empMana = table.Rows[0]["managerID"].ToString();
            }             
            return empMana;
        }

        // lay ma the nhan vien quan ly xuong
        public string getITLo(string loca)
        {
            string empMana = "";
            string sqlQuery = @" select top 1 * from Factory where build like '%" + loca.Trim() + "%' ";
            DataTable table = dbPC.DoSQLSelect(sqlQuery);
            if(table.Rows.Count > 0)
            {
                empMana = table.Rows[0]["ITSMgr10"].ToString();
            }           
            return empMana;
        }
        //lay nhan vien IT ket an
        public string getITEmp(string facName)
        {
            string sqlQuery = @" select * from ITManager where Factory_name = N'"+facName+"' ";
            DataTable table = db.DoSQLSelect(sqlQuery);
            string empMana = table.Rows[0]["ITManager"].ToString() + ";" + table.Rows[0]["ITBU"].ToString();
           

            return empMana;
        }
        //get list don doi ky  procedure    SP_WAITING_APPROVAL

        public List<DATA_APP_ESIGN> listWating(string emp)
        {
            DBConnectData db = new DBConnectData();

            object[] sqlParams =
            {
                new SqlParameter("@Checkwait",emp),
            };

            var list = db.Database.SqlQuery<DATA_APP_ESIGN>("SP_WAITING_APPROVAL @Checkwait",sqlParams).ToList();
            return list;
        }
        // them du lieu vao bang noi dung don
        public bool insertTitleContent(string appNo,string appTitle,string titleContent, int? formNo,int ste)
        {
            try
            {
               // SQLServerDBHelper db = new SQLServerDBHelper("ESignDB");
                string sqlQuery = @"insert APP_CONTENT(AppNo,AppTitle,AppContent,FormID,Step) values (@AppNo,@AppTitle,@AppContent,@FormID,@Step)";

                SqlParameter[] param = new SqlParameter[5];
                param.SetValue(new SqlParameter("AppNo", appNo), 0);
                param.SetValue(new SqlParameter("AppTitle", appTitle), 1);
                param.SetValue(new SqlParameter("AppContent", titleContent), 2);
                param.SetValue(new SqlParameter("formID", formNo), 3);
                param.SetValue(new SqlParameter("Step", ste), 4);

                db.ExcuteNonQuery(sqlQuery, param);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        // them du lieu vao bang du lieu don de hien thi theo danh sach va trang thai
        public bool insertAppData(string appNo, string appStatus,string userName,string signerName,string createTime, string Checkwait, int? formNo, int ste, string No,string tit,string userEmp)
        {
            try
            {
               // SQLServerDBHelper db = new SQLServerDBHelper("ESignDB");
                string sqlQuery = @"insert DATA_APP_ESIGN(APPNO,APPSTATUS,ApplicantName,CHECKWAITNAME,Daycreate,Checkwait,FormID,Step,ApplicantNo,Title,USEREMP) values (@APPNO,@APPSTATUS,@ApplicantName,@CHECKWAITNAME,@Daycreate,@Checkwait,@FormID,@Step,@ApplicantNo,N'" + tit+ "' , @USEREMP) ";

                SqlParameter[] param = new SqlParameter[10];
                param.SetValue(new SqlParameter("APPNO", appNo), 0);
                param.SetValue(new SqlParameter("APPSTATUS", appStatus), 1);
                param.SetValue(new SqlParameter("ApplicantName", userName), 2);
                param.SetValue(new SqlParameter("CHECKWAITNAME", signerName), 3);
                param.SetValue(new SqlParameter("Daycreate", createTime), 4);
                param.SetValue(new SqlParameter("Checkwait", Checkwait), 5);
                param.SetValue(new SqlParameter("FormID", formNo), 6);
                param.SetValue(new SqlParameter("Step", ste), 7);
                param.SetValue(new SqlParameter("ApplicantNo", No), 8);
                param.SetValue(new SqlParameter("USEREMP", userEmp), 9);

                db.ExcuteNonQuery(sqlQuery, param);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool insertListSign(string appNo,string signerNo, string signerName, string statusName, int? ste)
        {
            try
            {
               // SQLServerDBHelper db = new SQLServerDBHelper("ESignDB");
                string sqlQuery = @"insert approvalSchedule(AppNo,signEmpNo,SignName,statusName,step) values (@AppNo,@signEmpNo,@SignName,@statusName,@step)";
                SqlParameter[] param = new SqlParameter[5];
                param.SetValue(new SqlParameter("AppNo", appNo), 0);
                param.SetValue(new SqlParameter("signEmpNo", signerNo), 1);
                param.SetValue(new SqlParameter("SignName", signerName), 2);
                param.SetValue(new SqlParameter("statusName", statusName), 3);
                param.SetValue(new SqlParameter("step", ste), 4);

                 bool kq = db.ExcuteNonQuery(sqlQuery, param);

                return kq;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        // play form id
        //public int getFormID(string formName)
        //{
        //    DataTable tb = new DataTable();
        //    int formId ;
        //    string sqlQuery = @"select * from Forms where FormName='"+formName+"'";
        //    tb = db.DoSQLSelect(sqlQuery);
        //    if(tb.Rows.Count > 0)
        //    {
        //        formId =Convert.ToInt32(tb.Rows[0]["FormID"].ToString());
        //    }
        //    else
        //    {
        //        formId = 6;
        //    }
        //    return formId;
        //}

        //Lay du lieu vao model
        public FORM_IT_01Model getDataToModel(string appNO)
        {
            FORM_IT_01Model formIT01 = new FORM_IT_01Model();
            
            string sqlQuery = @"select * from APP_CONTENT where AppNo='"+appNO+"'";

            formIT01.AppNo = appNO;

            DataTable tb = db.DoSQLSelect(sqlQuery);
            string listTitle = "";
            string listContent = "";
            if(tb.Rows.Count > 0)
            {
                for(int i = 0; i < tb.Rows.Count; i++)
                {
                    listTitle += tb.Rows[i]["AppTitle"].ToString() + ";";
                    listContent += tb.Rows[i]["AppContent"].ToString() + ";";
                }

                string[] titleList = listTitle.Split(';');
                string[] arrayContent = listContent.Split(';');

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

                // content app
                formIT01.Title0Content = arrayContent[0];
                formIT01.Title1Content = arrayContent[1];
                formIT01.Title2Content = arrayContent[2];
                formIT01.Title3Content = arrayContent[3];
                formIT01.Title4Content = arrayContent[4];
                formIT01.Title5Content = arrayContent[5];
                formIT01.Title6Content = arrayContent[6];
                formIT01.Title7Content = arrayContent[7];
                formIT01.Title8Content = arrayContent[8];
                formIT01.Title9Content = arrayContent[9];

                formIT01.Title10Content = arrayContent[10];
                formIT01.Title11Content = arrayContent[11];
                formIT01.Title12Content = arrayContent[12];
                formIT01.Title13Content = arrayContent[13];
                formIT01.Title14Content = arrayContent[14];
                formIT01.Title15Content = arrayContent[15];
                formIT01.Title16Content = arrayContent[16];
                formIT01.Title17Content = arrayContent[17];
                formIT01.Title18Content = arrayContent[18];
                formIT01.Title19Content = arrayContent[19];
                formIT01.Title20Content = arrayContent[20];
                formIT01.Title21Content = arrayContent[21];
                formIT01.Title22Content = arrayContent[22];
                formIT01.Title23Content = arrayContent[23];
                formIT01.Title24Content = arrayContent[24];
                formIT01.Title25Content = arrayContent[25];
                formIT01.Title26Content = arrayContent[26];

                // get data list sign
                string sqlQuerySign = @"SELECT step,statusName,SignName,signEmpNo,fowardInfo,(select top 1 approvalname from approvalsuggest where orderNo=a.AppNo and statusname=a.statusname and (approvalid = a.signEmpNo or approvalid=a.signOver) ) approvalname,  " +
                                " (select top 1 status from approvalsuggest where orderNo = a.AppNo and statusname = a.statusname and(approvalid = a.signEmpNo or approvalid = a.signOver)) status,  " +
                                " (select top 1 approvalsuggest from approvalsuggest where orderNo = a.AppNo and statusname = a.statusname  and(approvalid = a.signEmpNo or approvalid = a.signOver) ) approvalsuggest,  " +
                                " (select top 1 approvaltime from approvalsuggest where orderNo = a.AppNo and statusname = a.statusname and(approvalid = a.signEmpNo or approvalid = a.signOver) ) approvaltime " +
                                " FROM approvalSchedule a " +
                                " where a.AppNo = '" + appNO + "' " +
                                " order by CONVERT(int, step); ";
                 DataTable tb2 = db.DoSQLSelect(sqlQuerySign);
                if(tb2.Rows.Count > 0)
                {
                    List<ApprovalAppModel> listApprovals = new List<ApprovalAppModel>();
                    for(int i= 0; i< tb2.Rows.Count; i++)
                    {
                        string dateQue = tb2.Rows[i]["approvaltime"].ToString();
                        if(dateQue.Equals(""))
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
                    formIT01.approvalApps = listApprovals;
                }
            }
            return formIT01;
        }

        //lay du lieu xuong theo khu vuc
        public List<Location_Fac> ListLoca(string FacName)
        {
            string sqlQuery = @"select * from Location_Fac where factoryName = N'"+FacName.Trim()+"'  ";
            DataTable tb =  db.DoSQLSelect(sqlQuery);
            List<Location_Fac> listLoca = new List<Location_Fac>();
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    listLoca.Add(new Location_Fac
                    {
                        locationID = i,
                        Location = tb.Rows[i]["Location"].ToString()
                    }
                    );
                }
            }

            return listLoca;
        }

        //lay du lieu toan bo xuong
        public List<Location_Fac> ListLoca()
        {
            string sqlQuery = @"select * from Location_Fac order by Location asc  ";
            DataTable tb = db.DoSQLSelect(sqlQuery);
            List<Location_Fac> listLoca = new List<Location_Fac>();
            if (tb.Rows.Count > 0)
            {


                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    listLoca.Add(new Location_Fac
                    {
                        locationID = i,
                        Location = tb.Rows[i]["Location"].ToString()
                    }
                    );
                }

            }

            return listLoca;
        }
        //lay du lieu form mau cho vao model
        public FORM_IT_01Model setDataForm(int formID)
        {
            FORM_IT_01Model formIT01 = new FORM_IT_01Model();

            string sqlQuery = @" select * from TitleForm where FormID='" + formID + "' ;";
            DataTable tb = db.DoSQLSelect(sqlQuery);

            string listTitle = "";
            string listContent = "";
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    listTitle += tb.Rows[i]["FormContent"].ToString() + ";";
                    listContent += tb.Rows[i]["Example"].ToString() + ";";
                }

                string[] titleList = listTitle.Split(';');
                string[] arrayContent = listContent.Split(';');

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

                // content app
                formIT01.Title0Example = arrayContent[0];
                formIT01.Title1Example = arrayContent[1];
                formIT01.Title2Example = arrayContent[2];
                formIT01.Title3Example = arrayContent[3];
                formIT01.Title4Example = arrayContent[4];
                formIT01.Title5Example = arrayContent[5];
                formIT01.Title6Example = arrayContent[6];
                formIT01.Title7Example = arrayContent[7];
                formIT01.Title8Example = arrayContent[8];
                formIT01.Title9Example = arrayContent[9];

                formIT01.Title10Example = arrayContent[10];
                formIT01.Title11Example = arrayContent[11];
                formIT01.Title12Example = arrayContent[12];
                formIT01.Title13Example = arrayContent[13];
                formIT01.Title14Example = arrayContent[14];
                formIT01.Title15Example = arrayContent[15];
                formIT01.Title16Example = arrayContent[16];
                formIT01.Title17Example = arrayContent[17];
                formIT01.Title18Example = arrayContent[18];
                formIT01.Title19Example = arrayContent[19];
                formIT01.Title20Example = arrayContent[20];
                formIT01.Title21Example = arrayContent[21];
                formIT01.Title22Example = arrayContent[22];
                formIT01.Title23Example = arrayContent[23];
                formIT01.Title24Example = arrayContent[24];
                formIT01.Title25Example = arrayContent[25];
                formIT01.Title26Example = arrayContent[26];


            }

            return formIT01;
        }

        // them vao luu trinh ky don
        public bool insertSigning(int? formID, int step, string signName)
        {
            try
            {
                //SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                string sqlQuery = @"insert into SubmitSign(FormID,SignNo,SignName) values(@FormID,@SignNo,@SignName)";
                SqlParameter[] pra = new SqlParameter[3];
                pra.SetValue(new SqlParameter("FormID", formID), 0);
                pra.SetValue(new SqlParameter("SignNo", step), 1);
                pra.SetValue(new SqlParameter("SignName", signName), 2);
                bool kq = db.ExcuteNonQuery(sqlQuery, pra);
                return kq;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // them vao form
        public bool insertForm(string formName,string depart,string formDislay,string site,string creater)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                string sqlQuery= @"insert into Forms(FormName,Department,FormDisplayName,Site,Creator,UpdateTime) values (@FormName,@Department,@FormDisplayName,@Site,@Creator,@UpdateTime) ";
                SqlParameter[] para = new SqlParameter[6];
                para.SetValue(new SqlParameter("FormName", formName), 0);
                para.SetValue(new SqlParameter("Department",depart),1);
                para.SetValue(new SqlParameter("FormDisplayName", formDislay), 2);
                para.SetValue(new SqlParameter("Site", site), 3);
                para.SetValue(new SqlParameter("Creator", creater), 4);
                para.SetValue(new SqlParameter("UpdateTime", dateTime), 5);
                bool kq = db.ExcuteNonQuery(sqlQuery, para);
                return kq;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        // them vao title table
        public bool insertTitleForm(int? formID,string formContent,int formStep,string noteS,string examPle)
        {
            try
            {
                string sqlQuery = @" insert into TitleForm(FormID,FormContent,FormStep,Note,Example) values(@FormID,@FormContent,@FormStep,@Note,@Example) ;";

                SqlParameter[] para = new SqlParameter[5];
                para.SetValue(new SqlParameter("FormID",formID), 0);
                para.SetValue(new SqlParameter("FormContent",formContent), 1);
                para.SetValue(new SqlParameter("formStep", formStep), 2);
                para.SetValue(new SqlParameter("Note", noteS), 3);
                para.SetValue(new SqlParameter("Example",examPle), 4);

                bool kq = db.ExcuteNonQuery(sqlQuery, para);
                return kq;

            }
            catch(Exception ex)
            {               
                return false;
            }
        }

        // lay du lieu do vao model IT request
        public ITRequestModel requestModel(string appNo)
        {
            ITRequestModel model = new ITRequestModel();
            try
            {
    //            AppNo,EmpNo,Name,NumPhone,Site,BU,
    //    Depart,Mail,CodeCost,OfficeFac,Location,MacAd,ComputerSpeci,ComputerBrand,
    //KindofPC,AssetCode,TimeStart,TimeEnd,ApplicationType,ComputerName,IPAdd,SeriNum,ColorPC,
    //LocationApply,filePath,fileName,Reason,USB_Read,FactoryApply

                string sqlQuery = @"select * from ITRequestTem where AppNo='" + appNo + "' ";
                DataTable table = new DataTable();
                
                table = db.DoSQLSelect(sqlQuery);
                if(table.Rows.Count > 0)
                {              
                    model.AppNo = table.Rows[0]["AppNo"].ToString();
                    model.EmpNo = table.Rows[0]["EmpNo"].ToString();
                    model.Name = table.Rows[0]["Name"].ToString();
                    model.NumPhone = table.Rows[0]["NumPhone"].ToString();
                    model.Site = table.Rows[0]["Site"].ToString();
                    model.BU = table.Rows[0]["BU"].ToString();
                    model.Depart = table.Rows[0]["Depart"].ToString();
                    model.Mail = table.Rows[0]["Mail"].ToString();
                    model.CodeCost = table.Rows[0]["CodeCost"].ToString();
                    model.OfficeFac = table.Rows[0]["OfficeFac"].ToString();
                    model.Location = table.Rows[0]["Location"].ToString();
                    model.MacAd = table.Rows[0]["MacAd"].ToString();
                    model.ComputerSpeci = table.Rows[0]["ComputerSpeci"].ToString();
                    model.ComputerBrand = table.Rows[0]["ComputerBrand"].ToString();
                    model.KindofPC = table.Rows[0]["KindofPC"].ToString();
                    model.AssetCode = table.Rows[0]["AssetCode"].ToString();
                    model.TimeStart = Convert.ToDateTime(table.Rows[0]["TimeStart"].ToString()) ;
                    model.TimeEnd = Convert.ToDateTime(table.Rows[0]["TimeEnd"].ToString());
                    model.ApplicationType = table.Rows[0]["ApplicationType"].ToString();

                    model.ComputerName = table.Rows[0]["ComputerName"].ToString();
                    model.IPAdd = table.Rows[0]["IPAdd"].ToString();
                    model.SeriNum = table.Rows[0]["SeriNum"].ToString();
                    model.ColorPC = table.Rows[0]["ColorPC"].ToString();
                    model.LocationApply = table.Rows[0]["LocationApply"].ToString();

                    model.filePath = table.Rows[0]["filePath"].ToString();
                    model.fileName = table.Rows[0]["fileName"].ToString();

                    model.Reason = table.Rows[0]["Reason"].ToString();
                    model.USB_read = table.Rows[0]["USB_read"].ToString();
                    model.factoryApply = table.Rows[0]["factoryApply"].ToString();

                    // list sign
                    string sqlQuerySign = @"SELECT step,statusName,SignName,signEmpNo,fowardInfo,(select top 1 approvalname from approvalsuggest where orderNo=a.AppNo and statusname=a.statusname and stt = a.step and (approvalid = a.signEmpNo or approvalid=a.signOver) order by approvaltime desc ) approvalname,  " +
                                   " (select top 1 status from approvalsuggest where orderNo = a.AppNo and statusname = a.statusname and stt = a.step and(approvalid = a.signEmpNo or approvalid = a.signOver) order by approvaltime desc ) status,  " +
                                   " (select top 1 approvalsuggest from approvalsuggest where orderNo = a.AppNo and statusname = a.statusname and stt = a.step  and(approvalid = a.signEmpNo or approvalid = a.signOver) order by approvaltime desc ) approvalsuggest,  " +
                                   " (select top 1 approvaltime from approvalsuggest where orderNo = a.AppNo and statusname = a.statusname and stt = a.step and(approvalid = a.signEmpNo or approvalid = a.signOver) order by approvaltime desc ) approvaltime " +
                                   " FROM approvalSchedule a " +
                                   " where a.AppNo = '" + appNo + "' " +
                                   " order by CONVERT(int, step); ";
                    DataTable tb2 = db.DoSQLSelect(sqlQuerySign);
                    if(tb2.Rows.Count > 0)
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
                        model.approvalApps = listApprovals;
                    }
                }
                else
                {
                    
                }
            }
            catch(Exception ex)
            {
                
            }

            return model;
        }

        //kiem tra thong tin co trong muc Account lay so dien thoai
        public string getPhoneAccount(string empNo)
        {
            string phone = "";
            string sqlQuery = @"select * from Account where UserID = '"+empNo+"' ";
            DataTable tb = db.DoSQLSelect(sqlQuery);
            if(tb.Rows.Count > 0)
            {
                phone = tb.Rows[0]["Telephone"].ToString();
            }

            return phone;
        }
        public bool setPhoneAccount(string empNo, string Phone,string name)
        {
            try
            {
                string sqlQuery1 = "";
                string sqlQuery = @"select * from Account where UserID = '" + empNo + "' ";
                DataTable tb = db.DoSQLSelect(sqlQuery);
                if (tb.Rows.Count > 0)
                {
                    sqlQuery1 = @"update  Account set Telephone=@Telephone,Username=@Username where  UserID=@UserID ";
                }
                else
                {
                    sqlQuery1 = @"insert into Account (UserID,Telephone,Username) values (@UserID,@Telephone,@Username) ";
                }
                 
                SqlParameter[] para = new SqlParameter[3];
                para.SetValue(new SqlParameter("UserID", empNo), 0);
                para.SetValue(new SqlParameter("Telephone", Phone), 1);
                para.SetValue(new SqlParameter("Username", Phone), 2);
                bool kq =  db.ExcuteNonQuery(sqlQuery1, para);
                
                return kq;
            }
            catch(SqlException ex)
            {
                return false;
            }
        }

        // kiem tra co luu mail ko 
        public string getMailAccount(string empNo)
        {
            string phone = "";
            string sqlQuery = @"select * from Account where UserID = '" + empNo + "' ";
            DataTable tb = db.DoSQLSelect(sqlQuery);
            if (tb.Rows.Count > 0)
            {
                phone = tb.Rows[0]["Email"].ToString();
            }

            return phone;
        }
        public bool setMailAccount(string empNo, string mail,string name)
        {
            try
            {
                string sqlQuery1 = "";
                string sqlQuery = @"select * from Account where UserID = '" + empNo + "' ";
                DataTable tb = db.DoSQLSelect(sqlQuery);
                if (tb.Rows.Count > 0)
                {
                    sqlQuery1 = @"update  Account set Email=@Telephone,Username=@Username where  UserID=@UserID ";
                }
                else
                {
                    sqlQuery1 = @"insert into Account (UserID,Email,Username) values (@UserID,@Telephone,@Username) ";
                }

                SqlParameter[] para = new SqlParameter[3];
                para.SetValue(new SqlParameter("UserID", empNo), 0);
                para.SetValue(new SqlParameter("Telephone", mail), 1);
                para.SetValue(new SqlParameter("Username", name), 2);
                bool kq = db.ExcuteNonQuery(sqlQuery1, para);

                return kq;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        //lay du lieu model don ket thuc cong tac can bo nuoc ngoai
        public FORM_IT_01Model endingChina(string appNo)
        {
            FORM_IT_01Model EndingModel = new FORM_IT_01Model();
            EndingModel.AppNo = appNo;

            string sqlQuery = @"select * from EndingOperation where AppNo='" + appNo + "' ";
            DataTable table = new DataTable();
            table = db.DoSQLSelect(sqlQuery);

            if (table.Rows.Count > 0)
            {
                EndingModel.AppNo = table.Rows[0]["AppNo"].ToString();
                EndingModel.empID = table.Rows[0]["empID"].ToString();
                EndingModel.empName = table.Rows[0]["empName"].ToString();
                EndingModel.Title1 = table.Rows[0]["jobtitle"].ToString();
                EndingModel.Title2 = table.Rows[0]["rank"].ToString();

                EndingModel.Title3 = table.Rows[0]["dept"].ToString();
                EndingModel.Title4 = table.Rows[0]["empGroup"].ToString();
                EndingModel.Title5 = table.Rows[0]["BU"].ToString();
                EndingModel.Title6 = table.Rows[0]["empUnit"].ToString();
                EndingModel.Title7 = table.Rows[0]["dateEntry"].ToString();

                EndingModel.Title8 = table.Rows[0]["dateDeparture"].ToString();
                EndingModel.Title9 = table.Rows[0]["totalDate"].ToString();
                EndingModel.Title15Content = table.Rows[0]["dateEntry1"].ToString();
                EndingModel.Title16Content = table.Rows[0]["dateDeparture1"].ToString();
                EndingModel.Title17Content = table.Rows[0]["totalDate1"].ToString();

                EndingModel.Title18Content = table.Rows[0]["Description"].ToString();
                EndingModel.Title0 = table.Rows[0]["Name"].ToString();
                EndingModel.Title19Content = table.Rows[0]["transferOwner"].ToString();
                EndingModel.Title0Example = table.Rows[0]["contactFamily"].ToString();

            }
           

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
                EndingModel.approvalApps = listApprovals;
            }

            return EndingModel;
        }
    }
}