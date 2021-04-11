using New_Esign.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace New_Esign.AppCode
{
    public class Submit
    {
        private SQLServerDBHelper dbQR = new SQLServerDBHelper("ConnectDB"); 
        private SQLServerDBHelper dbDHCP = new SQLServerDBHelper("ConnectDHCP");
        private SQLServerDBHelper dbES= new SQLServerDBHelper("EsignDB");
        private NewCode newCode = new NewCode();
        // kiem tra ky don thay
        public void approvalAppAgent(string appNo)
        {
            var newCodeSub = new NewCode();

            PostmanService.PostmanServiceSoapClient postman = new PostmanService.PostmanServiceSoapClient();
            //ket noi db
            SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            // cau lenh sql
           
            //DataTable tb = new DataTable();
            //tb = postman.GetEmpInfomation(empNo);
            // thong tin
            DataTable tbinfo = new DataTable();
            // kiem tra nghi viec va cong tac
            string notDuty = "";
            string travel = "";
            string checkwait = "";
            string checkwaitname = "";
            string checkwaitAgent = "";
            string signNoAgent = "";
            string signNameAgent = "";
            
            
            DataTable tb = new DataTable();
            tb = newCodeSub.getSubmitApp(appNo);
            string formID = tb.Rows[0]["FormID"].ToString();
            string state = tb.Rows[0]["APPSTATES"].ToString();
            switch(formID)
            {
                case "7":
                    {
                        switch(state)
                        {
                            case "010":
                                {
                                    break;
                                }
                            case "020":
                                {
                                    string signer1 = tb.Rows[0]["Signer2No"].ToString().Trim();
                                    tbinfo = postman.GetEmpInfomation(signer1);
                                    notDuty = tbinfo.Rows[0]["NOTDUTY"].ToString();
                                    travel = tbinfo.Rows[0]["TRAVEL"].ToString();
                                    if(notDuty != "No" || travel != "No")
                                    {
                                        //string empNo = tb.Rows[0]["signer1"].ToString().Trim();
                                        checkwaitAgent = postman.GetEmp_Agent(signer1).Rows[0]["AGENT_WHO"].ToString();
                                        checkwait = checkwaitAgent;
                                        checkwaitname = postman.GetEmpInfomation(checkwait).Rows[0]["USER_NAME"].ToString();                                        
                                    }
                                    else
                                    {
                                        checkwait = signer1;
                                        checkwaitname = postman.GetEmpInfomation(checkwait).Rows[0]["USER_NAME"].ToString();
                                    }
                                    signNoAgent = "Signer2NoAgent";
                                    signNameAgent = "Signer2NameAgent";

                                    break;
                                }
                            case "030":
                                {
                                    string signer1 = tb.Rows[0]["Signer3No"].ToString().Trim();
                                    tbinfo = postman.GetEmpInfomation(signer1);
                                    notDuty = tbinfo.Rows[0]["NOTDUTY"].ToString();
                                    travel = tbinfo.Rows[0]["TRAVEL"].ToString();
                                    if (notDuty != "No" || travel != "No")
                                    {
                                        //string empNo = tb.Rows[0]["signer1"].ToString().Trim();
                                        checkwaitAgent = postman.GetEmp_Agent(signer1).Rows[0]["AGENT_WHO"].ToString();
                                        checkwait = checkwaitAgent;
                                        checkwaitname = postman.GetEmpInfomation(checkwait).Rows[0]["USER_NAME"].ToString();

                                    }
                                    else
                                    {
                                        checkwait = signer1;
                                        checkwaitname = postman.GetEmpInfomation(checkwait).Rows[0]["USER_NAME"].ToString();
                                    }
                                    signNoAgent = "Signer3NoAgent";
                                    signNameAgent = "Signer3NameAgent";

                                    break;
                                }
                            case "040":
                                {
                                    string signer1 = tb.Rows[0]["Signer4No"].ToString().Trim();
                                    tbinfo = postman.GetEmpInfomation(signer1);
                                    notDuty = tbinfo.Rows[0]["NOTDUTY"].ToString();
                                    travel = tbinfo.Rows[0]["TRAVEL"].ToString();
                                    if (notDuty != "No" || travel != "No")
                                    {
                                        //string empNo = tb.Rows[0]["signer1"].ToString().Trim();
                                        checkwaitAgent = postman.GetEmp_Agent(signer1).Rows[0]["AGENT_WHO"].ToString();
                                        checkwait = checkwaitAgent;
                                        checkwaitname = postman.GetEmpInfomation(checkwait).Rows[0]["USER_NAME"].ToString();

                                    }
                                    else
                                    {
                                        checkwait = signer1;
                                        checkwaitname = postman.GetEmpInfomation(checkwait).Rows[0]["USER_NAME"].ToString();
                                    }
                                    signNoAgent = "Signer4NoAgent";
                                    signNameAgent = "Signer4NameAgent";

                                    break;
                                }
                            case "050":
                                {
                                    string signer1 = tb.Rows[0]["Signer5No"].ToString().Trim();
                                    tbinfo = postman.GetEmpInfomation(signer1);
                                    notDuty = tbinfo.Rows[0]["NOTDUTY"].ToString();
                                    travel = tbinfo.Rows[0]["TRAVEL"].ToString();
                                    if (notDuty != "No" || travel != "No")
                                    {
                                        //string empNo = tb.Rows[0]["signer1"].ToString().Trim();
                                        checkwaitAgent = postman.GetEmp_Agent(signer1).Rows[0]["AGENT_WHO"].ToString();
                                        checkwait = checkwaitAgent;
                                        checkwaitname = postman.GetEmpInfomation(checkwait).Rows[0]["USER_NAME"].ToString();

                                    }
                                    else
                                    {
                                        checkwait = signer1;
                                        checkwaitname = postman.GetEmpInfomation(checkwait).Rows[0]["USER_NAME"].ToString();
                                    }
                                    signNoAgent = "Signer5NoAgent";
                                    signNameAgent = "Signer5NameAgent";

                                    break;
                                }
                            case "060":
                                {
                                    string signer1 = tb.Rows[0]["Signer6No"].ToString().Trim();
                                    tbinfo = postman.GetEmpInfomation(signer1);
                                    notDuty = tbinfo.Rows[0]["NOTDUTY"].ToString();
                                    travel = tbinfo.Rows[0]["TRAVEL"].ToString();
                                    if (notDuty != "No" || travel != "No")
                                    {
                                        //string empNo = tb.Rows[0]["signer1"].ToString().Trim();
                                        checkwaitAgent = postman.GetEmp_Agent(signer1).Rows[0]["AGENT_WHO"].ToString();
                                        checkwait = checkwaitAgent;
                                        checkwaitname = postman.GetEmpInfomation(checkwait).Rows[0]["USER_NAME"].ToString();

                                    }
                                    else
                                    {
                                        checkwait = signer1;
                                        checkwaitname = postman.GetEmpInfomation(checkwait).Rows[0]["USER_NAME"].ToString();
                                    }
                                    signNoAgent = "Signer6NoAgent";
                                    signNameAgent = "Signer6NameAgent";

                                    break;
                                }


                        }
                        // cau lenh sql
                        string updateDataAgent = @"Update DATA_APP_ESIGN set " + signNoAgent + " = '" + checkwait + "'," + signNameAgent + " = '" + checkwaitname + "' where APPNO ='" + appNo + "' ";
                        db.ExcuteNonQuery(updateDataAgent);

                        break;
                    }
            }
        }
        //kiem tra trang tha tren don
        public bool checkStateApp(string appro,string appNo,string noTe)
        {
            try
            {
                SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                string checkwait = "";
                string checkwaitname = "";

                var newCodeSub = new NewCode();
                DataTable tb = new DataTable();
                tb = newCodeSub.getSubmitApp(appNo);
                string formID = tb.Rows[0]["FormID"].ToString();
                string state = tb.Rows[0]["APPSTATES"].ToString();
                string empNo = "";
                string empName = "";
                string empNonext = "";
                string empNamenext = "";
                string nextstate = "";
                string empcheck = "";
                switch (formID)
                {
                    case "7":
                        {
                            switch (state)
                            {
                                case "010":
                                    {
                                        if (appro == "Submit")
                                        {
                                            empNonext = tb.Rows[0]["Signer1No"].ToString();
                                            empNamenext = tb.Rows[0]["Signer1Name"].ToString();
                                            empName = tb.Rows[0]["ApplicantName"].ToString();
                                            empNo = tb.Rows[0]["ApplicantNo"].ToString();
                                            approSuggest(false, appNo, empNonext, "020", empNamenext);
                                            f_insert_submit(false, "7", state, appNo, empName, empNo, noTe);
                                        }
                                        else
                                        {
                                            empNonext = tb.Rows[0]["ApplicantNo"].ToString(); ;
                                            empName = tb.Rows[0]["ApplicantName"].ToString();
                                            empName = tb.Rows[0]["Signer2Name"].ToString();
                                            empNo = tb.Rows[0]["Signer2No"].ToString();
                                            approSuggest(true, appNo, empNonext, "020", empNamenext);
                                            f_insert_submit(false, "7", state, appNo, empName, empNo, noTe);
                                        }
                                        break;
                                    }
                                case "020":
                                    {
                                        //approvalAppAgent(appNo);
                                        if(appro== "Approval")
                                        {
                                            empNonext = tb.Rows[0]["Signer2No"].ToString();
                                            empNamenext = tb.Rows[0]["Signer2Name"].ToString();
                                            empName = tb.Rows[0]["Signer1Name"].ToString();
                                            empNo = tb.Rows[0]["Signer1No"].ToString();
                                            
                                            if(empNo == empNonext)
                                            {
                                                empNonext = tb.Rows[0]["Signer3No"].ToString();
                                                empNamenext = tb.Rows[0]["Signer3Name"].ToString();
                                                approSuggest(false, appNo, empNonext, "040", empNamenext);
                                                f_insert_approval(false, "7", "030", appNo, empName, empNo, noTe);
                                            }
                                            else
                                            {
                                                approSuggest(false, appNo, empNonext, "030", empNamenext);
                                                f_insert_approval(false, "7", state, appNo, empName, empNo, noTe);
                                            }
                                            
                                        }
                                        else
                                        {
                                            empNonext = tb.Rows[0]["ApplicantNo"].ToString(); ;
                                            empName = tb.Rows[0]["ApplicantName"].ToString();
                                            empName = tb.Rows[0]["Signer1Name"].ToString();
                                            empNo = tb.Rows[0]["Signer1No"].ToString();
                                            approSuggest(true, appNo, empNonext, "010", empNamenext);
                                            f_insert_approval(false, "7", state, appNo, empName, empNo, noTe);
                                        }

                                        break;
                                    }
                                case "030":
                                    {
                                        //approvalAppAgent(appNo);
                                        if(appro == "Approval")
                                        {
                                            empNonext = tb.Rows[0]["Signer3No"].ToString();
                                            empNamenext = tb.Rows[0]["Signer3Name"].ToString();
                                            empName = tb.Rows[0]["Signer2Name"].ToString();
                                            empNo = tb.Rows[0]["Signer2No"].ToString();
                                            approSuggest(false, appNo, empNonext, "040", empNamenext);
                                            f_insert_approval(false, "7", state, appNo, empName, empNo, noTe);
                                        }
                                        else
                                        {
                                            empNonext = tb.Rows[0]["ApplicantNo"].ToString(); ;
                                            empName = tb.Rows[0]["ApplicantName"].ToString();
                                            empName = tb.Rows[0]["Signer2Name"].ToString();
                                            empNo = tb.Rows[0]["Signer2No"].ToString();
                                            approSuggest(true, appNo, empNonext, "010", empNamenext);
                                            f_insert_approval(false, "7", state, appNo, empName, empNo, noTe);
                                        }
                                        
                                        break;
                                    }
                                case "040":
                                    {
                                        //approvalAppAgent(appNo);
                                        if(appro == "Approval")
                                        {
                                            empNonext = tb.Rows[0]["Signer4No"].ToString();
                                            empNamenext = tb.Rows[0]["Signer4Name"].ToString();
                                            empName = tb.Rows[0]["Signer3Name"].ToString();
                                            empNo = tb.Rows[0]["Signer3No"].ToString();
                                            approSuggest(false, appNo, empNonext, "050", empNamenext);
                                            f_insert_approval(false, "7", state, appNo, empName, empNo, noTe);
                                        }
                                        else
                                        {

                                            empNonext = tb.Rows[0]["ApplicantNo"].ToString(); ;
                                            empName = tb.Rows[0]["ApplicantName"].ToString();
                                            empName = tb.Rows[0]["Signer3Name"].ToString();
                                            empNo = tb.Rows[0]["Signer3No"].ToString();
                                            approSuggest(true, appNo, empNonext, "010", empNamenext);
                                            f_insert_approval(false, "7", state, appNo, empName, empNo, noTe);
                                        }
                                        break;
                                    }
                                case "050":
                                    {
                                        //approvalAppAgent(appNo);
                                        if(appro == "Approval")
                                        {
                                            empNonext = tb.Rows[0]["Signer5No"].ToString();
                                            empNamenext = tb.Rows[0]["Signer5Name"].ToString();
                                            empName = tb.Rows[0]["Signer4Name"].ToString();
                                            empNo = tb.Rows[0]["Signer4No"].ToString();
                                            approSuggest(false, appNo, empNonext, "060", empNamenext);
                                            f_insert_approval(false, "7", state, appNo, empName, empNo, noTe);
                                        }
                                        else
                                        {
                                            empNonext = tb.Rows[0]["ApplicantNo"].ToString(); ;
                                            empName = tb.Rows[0]["ApplicantName"].ToString();
                                            empName = tb.Rows[0]["Signer4Name"].ToString();
                                            empNo = tb.Rows[0]["Signer4No"].ToString();
                                            approSuggest(true, appNo, empNonext, "010", empNamenext);
                                            f_insert_approval(false, "7", state, appNo, empName, empNo, noTe);
                                        }
                                        break;
                                    }
                                case "060":
                                    {
                                        //approvalAppAgent(appNo);
                                        if(appro == "Approval")
                                        {
                                                                                        
                                            empNo = tb.Rows[0]["Signer5No"].ToString();
                                            approSuggest(false, appNo, empNonext, "023", empNamenext);
                                            f_insert_approval(false, "7", state, appNo, empName, empNo, noTe);
                                        }
                                        else
                                        {
                                            empNonext = tb.Rows[0]["ApplicantNo"].ToString(); ;
                                            empName = tb.Rows[0]["ApplicantName"].ToString();
                                            empName = tb.Rows[0]["Signer5Name"].ToString();
                                            empNo = tb.Rows[0]["Signer5No"].ToString();
                                            approSuggest(true, appNo, empNonext, "010", empNamenext);
                                            f_insert_approval(false, "7", state, appNo, empName, empNo, noTe);
                                        }
                                        break;
                                    }
                            }
                            //string updateData = @"Update DATA_APP_ESIGN set Checkwait='" + checkwait + "',CHECKWAITNAME = '" + checkwaitname + "' where APPNO ='" + appNo + "' ";

                            break;
                        }
                       
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

            //string listState = "";
            //return listState;
        }

        //chuyen trang thai sau khi ky don
        public bool approSuggest(bool isRejected, string appNo, string empNonext, string nextstate,string empNamenext)
        {
            try
            {
                string reject_str = "Waiting";
                if (isRejected) reject_str = "Reject";
                if (reject_str == "Waiting")
                {
                    string sqlQuery = @"update DATA_APP_ESIGN set APPSTATUS = N'" + reject_str + "', Checkwait = N'" + empNonext + "',APPSTATES ='" + nextstate + "',CHECKWAITNAME= N'" + empNamenext + "' where APPNO='" + appNo + "'";
                    SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                    db.ExcuteNonQuery(sqlQuery);
                }
                else
                {
                    string sqlQuery = @"update DATA_APP_ESIGN set APPSTATUS = N'" + reject_str + "', Checkwait = N'"+empNonext+"',APPSTATES ='010',CHECKWAITNAME= N'" + empNamenext + "' where APPNO='" + appNo + "'";
                    SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                    db.ExcuteNonQuery(sqlQuery);
                }
                return true;
            }
            catch(Exception ex)
            {
                var error = ex;
                return false;
            }
            
        }
        public bool submitSuggest(bool isRejected, string appNo, string empNonext, string nextstate, string empNamenext)
        {
            try
            {
                string reject_str = "Waiting";
                if (isRejected) reject_str = "Reject";
                if (reject_str == "Waiting")
                {
                    string sqlQuery = @"update DATA_APP_ESIGN set APPSTATUS = N'" + reject_str + "', Checkwait = N'" + empNonext + "',APPSTATES ='" + nextstate + "',CHECKWAITNAME= N'" + empNamenext + "' where APPNO='" + appNo + "'";
                    SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                    db.ExcuteNonQuery(sqlQuery);
                }
                else
                {
                    string sqlQuery = @"update DATA_APP_ESIGN set APPSTATUS = N'" + reject_str + "', Checkwait = N'" + empNonext + "',APPSTATES ='010',CHECKWAITNAME= N'" + empNamenext + "' where APPNO='" + appNo + "'";
                    SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                    db.ExcuteNonQuery(sqlQuery);
                }
                return true;
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }

        }
        // ham insert du lieu ky don
        public bool f_insert_approval(bool isRejected,string formID,string stateID, string appNo, string empName,string empNo,string note)
        {
            try
            {
                string reject_str = "通過";
                if (isRejected) reject_str = "駁回";
                string ip = getIPCom();
                string description = f_get_description(formID, stateID);
                string sql = @"insert into APPROVE_SIGN([APPNO],[APPROVERNAME],[APPROVEREMP],[PROCESSNAME],[TIMEAPPROVE],[NOTES],
[STATUS],[AGENTEMP]) values ('" + appNo + "', N'" + empName + "',N'"+empNo+"',N'" + description + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "',N'" + note + "',N'" + reject_str + "','IP:" + ip + "')";
                SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                db.ExcuteNonQuery(sql);
                return true;
            }
            catch(Exception ex)
            {
                var error = ex;
                return false;
            }
            //var session = 
            
        }
        // insert khi submit
        public bool f_insert_submit(bool isRejected, string formID, string step, string appNo, string empName, string empNo, string note)
        {
            try
            {
                //string reject_str = isRejected;                
                string ip = getIPCom();
                string description = f_get_description(formID,step );
                string sql = @"insert into approvalsuggest(orderno,approvalname,statusname,approvalid ,approvaltime,approvalsuggest,
status,agent) values ('" + appNo + "', N'" + empName + "',N'" + empNo + "',N'" + description + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "',N'" + note + "',N'" + isRejected + "','IP:" + ip + "')";
                SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                db.ExcuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
            //var session = 

        }

        // ky don
        public bool f_insert_sub(string isRejected, string appNo, string note)
        {
            try
            {
                //string reject_str = isRejected;                
                string ip = getIPCom();
                DataTable table = f_get_desc(appNo);
                string empName = table.Rows[0]["CHECKWAITNAME"].ToString();
                string empNo = table.Rows[0]["Checkwait"].ToString();
                string description = table.Rows[0]["APPSTATUS"].ToString();
                string sql = @"insert into approvalsuggest(orderno,approvalname,approvalid ,statusname ,approvaltime,approvalsuggest,
status,agent) values ('" + appNo + "', N'" + empName + "',N'" + empNo + "',N'" + description + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "',N'" + note + "',N'" + isRejected + "','IP:" + ip + "')";
                SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                db.ExcuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
            //var session = 

        }
        // ky don cho tem vang
        public bool f_insert_sub_yellow(string isRejected, string appNo, string note,string empName,int stt, string empNo,string description)
        {
            try
            {
                //string reject_str = isRejected;                
                string ip = getIPCom();
                
                string sql = @"insert into approvalsuggest(orderno,approvalname,approvalid ,statusname ,approvaltime,approvalsuggest,
status,agent,stt) values ('" + appNo + "', N'" + empName + "',N'" + empNo + "',N'" + description + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "',N'" + note + "',N'" + isRejected + "','IP:" + ip + "', '"+stt+"')";
                SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                db.ExcuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
            //var session = 

        }

        // trinh don
        public bool f_submit(string isRejected,string appNo ,int? formID,string empName,string empNo)
        {
            try
            {
                //string reject_str = isRejected;                
                string ip = getIPCom();
                DataTable table = f_get_name(formID);
                //string empName = table.Rows[0]["CHECKWAITNAME"].ToString();
                //string empNo = table.Rows[0]["Checkwait"].ToString();
                string description = table.Rows[0]["SignName"].ToString();
                string sql = @"insert into approvalsuggest(orderno,approvalname,approvalid ,statusname ,approvaltime,
status,agent) values ('" + appNo + "', N'" + empName + "',N'" + empNo + "',N'" + description + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "',N'" + isRejected + "','IP:" + ip + "')";
                SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                db.ExcuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
            //var session = 
        }

        //tring don tem vang
        public bool f_submit_yellow(string isRejected, string appNo, int? formID, string empName, string empNo,int stt)
        {
            try
            {
                //string reject_str = isRejected;                
                string ip = getIPCom();
                DataTable table = f_get_name(formID);
                //string empName = table.Rows[0]["CHECKWAITNAME"].ToString();
                //string empNo = table.Rows[0]["Checkwait"].ToString();
                string description = "申請人 / Người xin đơn";
                string sql = @"insert into approvalsuggest(orderno,approvalname,approvalid ,statusname ,approvaltime,
status,agent,stt) values ('" + appNo + "', N'" + empName + "',N'" + empNo + "',N'" + description + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "',N'" + isRejected + "','IP:" + ip + "', '"+stt+"')";
                SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                db.ExcuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
            //var session = 
        }


        //get ip computer
        public string getIPCom()
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip;
        }

        private string f_get_description(string formID,string signNo)
        {
            SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            string tempStr = @"SELECT * FROM SubmitSign where FormID = '"+formID+ "' and SignNo ='" + signNo + "'";
            DataTable tb = db.DoSQLSelect(tempStr);
            string rank = tb.Rows[0]["SignName"].ToString();
            return rank;
        }

        // lay thong tin  tu DATa
        public DataTable f_get_desc(string formID)
        {
            SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            string tempStr = @"SELECT * FROM DATA_APP_ESIGN where APPNO = '" + formID + "' ";
            DataTable tb = db.DoSQLSelect(tempStr);
            //string rank = tb.Rows[0]["APPSTATUS"].ToString();
            return tb;
        }
        // lay thong tin nguoi ky
        private DataTable f_get_name(int? formID)
        {
            SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            string tempStr = @"SELECT * FROM SubmitSign where FormID= '" + formID + "' ";
            DataTable tb = db.DoSQLSelect(tempStr);
            //string rank = tb.Rows[0]["APPSTATUS"].ToString();
            return tb;
        }
        // chuyen trang thai khi ky don
        public bool SigningApp(string appNo,string approve)
        {
            try
            {
                SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                string tempStr = @"SELECT * FROM DATA_APP_ESIGN where APPNO = '" + appNo + "' ";
                DataTable tb = db.DoSQLSelect(tempStr);
                string checkWa = "";
                string staTus = "";
                string checkNa = "";
                if (tb.Rows.Count > 0)
                {
                    int ste = Convert.ToInt32(tb.Rows[0]["step"].ToString());
                    if(approve == "Approval")
                    {
                        int steNext = ++ste;
                        string sqlQuery = @"select * from approvalSchedule where AppNo='"+appNo+"' and step='"+steNext+"' ";
                        DataTable tb1 = db.DoSQLSelect(sqlQuery);
                        if(tb1.Rows.Count > 0)
                        {
                            checkWa = tb1.Rows[0]["signEmpNo"].ToString();
                            staTus = tb1.Rows[0]["statusName"].ToString();
                            checkNa = tb1.Rows[0]["SignName"].ToString();

                            string sqlQuery2 = @"update DATA_APP_ESIGN set APPSTATUS= @APPSTATUS , CHECKWAITNAME=@CHECKWAITNAME,Checkwait=@Checkwait , 
            Step=@Step where APPNO=@appNo ";
                            SqlParameter[] param = new SqlParameter[5];
                            param.SetValue(new SqlParameter("APPSTATUS", staTus), 0);
                            param.SetValue(new SqlParameter("CHECKWAITNAME", checkNa), 1);
                            param.SetValue(new SqlParameter("Checkwait", checkWa), 2);
                            param.SetValue(new SqlParameter("Step", steNext), 3);
                            param.SetValue(new SqlParameter("APPNO", appNo), 4);

                            db.ExcuteNonQuery(sqlQuery2,param);
                        }
                        else 
                        {
                            checkWa = "通過";
                            staTus = "通過";
                            checkNa = "通過";

                            string sqlQuery2 = @"update DATA_APP_ESIGN set APPSTATUS= @APPSTATUS , CHECKWAITNAME=@CHECKWAITNAME,Checkwait=@Checkwait , 
            Step=@Step where APPNO=@appNo ";
                            SqlParameter[] param = new SqlParameter[5];
                            param.SetValue(new SqlParameter("APPSTATUS", staTus), 0);
                            param.SetValue(new SqlParameter("CHECKWAITNAME", checkNa), 1);
                            param.SetValue(new SqlParameter("Checkwait", checkWa), 2);
                            param.SetValue(new SqlParameter("Step", steNext), 3);
                            param.SetValue(new SqlParameter("APPNO", appNo), 4);

                            db.ExcuteNonQuery(sqlQuery2, param);
                        }

                    }
                    else if (approve == "Reject")
                    {
                        int steNext = 0;
                        string sqlQuery = @"select * from approvalSchedule where AppNo='" + appNo + "' and step='" + steNext + "' ";
                        DataTable tb1 = db.DoSQLSelect(sqlQuery);
                        if (tb1.Rows.Count > 0)
                        {
                            checkWa = tb1.Rows[0]["signEmpNo"].ToString();
                            staTus = tb1.Rows[0]["statusName"].ToString();
                            checkNa = tb1.Rows[0]["SignName"].ToString();

                            string sqlQuery2 = @"update DATA_APP_ESIGN set APPSTATUS= @APPSTATUS , CHECKWAITNAME=@CHECKWAITNAME,Checkwait=@Checkwait , 
            Step=@Step where APPNO=@appNo ";
                            SqlParameter[] param = new SqlParameter[5];
                            param.SetValue(new SqlParameter("APPSTATUS", staTus), 0);
                            param.SetValue(new SqlParameter("CHECKWAITNAME", checkNa), 1);
                            param.SetValue(new SqlParameter("Checkwait", checkWa), 2);
                            param.SetValue(new SqlParameter("Step", steNext), 3);
                            param.SetValue(new SqlParameter("APPNO", appNo), 4);

                            db.ExcuteNonQuery(sqlQuery2, param);
                        }
                    }
                    else if(approve == "Submit")
                    {
                        string sqlQuery = @" ";
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        // nut ky don cho form tem vang
        public bool SigningYellowCarD(string appNo, string approve,string note)
        {
            try
            {
                SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                string tempStr = @"SELECT * FROM DATA_APP_ESIGN where APPNO = '" + appNo + "' ";
                DataTable tb = db.DoSQLSelect(tempStr);
                string checkWa = "";
                string staTus = "";
                string checkNa = "";
                string checkDupSigner = "";
                if (tb.Rows.Count > 0)
                {
                    int ste = Convert.ToInt32(tb.Rows[0]["step"].ToString());
                    
                    if (approve == "Approval")
                    {
                        string sqlQueryYe = @"select * from approvalSchedule where AppNo='" + appNo + "'order by step asc ";
                        DataTable dataTable = db.DoSQLSelect(sqlQueryYe);
                        if (dataTable.Rows.Count > 0)
                        {
                            string sqlQuery1 = @"select * from approvalSchedule where AppNo='" + appNo + "' and step='" + ste + "' ";
                            DataTable tb2 = db.DoSQLSelect(sqlQuery1);
                            if(tb2.Rows.Count > 0)
                            {
                                checkWa = tb2.Rows[0]["signEmpNo"].ToString();
                                staTus = tb2.Rows[0]["statusName"].ToString();
                                checkNa = tb2.Rows[0]["SignName"].ToString();
                                if(staTus == "申請人 / Người xin đơn") f_insert_sub_yellow("Submit", appNo, note, checkNa, ste, checkWa, staTus);
                                else
                                {
                                    f_insert_sub_yellow("通過", appNo, note, checkNa, ste, checkWa, staTus);
                                }
                                
                            }
                            int steNext;
                            // check nhieu ma the
                            for (int i = ste; i < dataTable.Rows.Count; i++)
                            {
                                int checkSign = dataTable.Rows.Count - 1;
                                if (ste == checkSign)
                                {
                                    steNext = 200;

                                }
                                else
                                {
                                    steNext = i+1;
                                }
                                checkDupSigner = tb.Rows[0]["Checkwait"].ToString();
                                string sqlQuery = @"select * from approvalSchedule where AppNo='" + appNo + "' and step='" + steNext + "' ";
                                DataTable tb1 = db.DoSQLSelect(sqlQuery);
                                if (tb1.Rows.Count > 0)
                                {
                                    // kiem tra ma the 

                                    checkWa = tb1.Rows[0]["signEmpNo"].ToString();
                                    staTus = tb1.Rows[0]["statusName"].ToString();
                                    checkNa = tb1.Rows[0]["SignName"].ToString();
                                    if (checkDupSigner == checkWa)
                                    {
                                        f_insert_sub_yellow("通過", appNo, note, checkNa, steNext, checkWa, staTus);
                                        
                                    }
                                    else
                                    {
                                        string sqlQuery2 = @"update DATA_APP_ESIGN set APPSTATUS= @APPSTATUS , CHECKWAITNAME=@CHECKWAITNAME,Checkwait=@Checkwait, 
            Step=@Step where APPNO=@appNo ";
                                        SqlParameter[] param = new SqlParameter[5];
                                        param.SetValue(new SqlParameter("APPSTATUS", staTus), 0);
                                        param.SetValue(new SqlParameter("CHECKWAITNAME", checkNa), 1);
                                        param.SetValue(new SqlParameter("Checkwait", checkWa), 2);
                                        param.SetValue(new SqlParameter("Step", steNext), 3);
                                        param.SetValue(new SqlParameter("APPNO", appNo), 4);

                                        db.ExcuteNonQuery(sqlQuery2, param);
                                        break;
                                    }

                                }
                                else
                                {
                                    checkWa = "通過";
                                    staTus = "通過";
                                    checkNa = "通過";

                                    string sqlQuery2 = @"update DATA_APP_ESIGN set APPSTATUS= @APPSTATUS , CHECKWAITNAME=@CHECKWAITNAME,Checkwait=@Checkwait , 
            Step=@Step where APPNO=@appNo ";
                                    SqlParameter[] param = new SqlParameter[5];
                                    param.SetValue(new SqlParameter("APPSTATUS", staTus), 0);
                                    param.SetValue(new SqlParameter("CHECKWAITNAME", checkNa), 1);
                                    param.SetValue(new SqlParameter("Checkwait", checkWa), 2);
                                    param.SetValue(new SqlParameter("Step", steNext), 3);
                                    param.SetValue(new SqlParameter("APPNO", appNo), 4);

                                    db.ExcuteNonQuery(sqlQuery2, param);

                                    string sqlQueryQR = @" select * from ITRequestTem where AppNo = '" + appNo + "' ";
                                    DataTable dataTableQR = db.DoSQLSelect(sqlQueryQR);
                                    if (dataTableQR.Rows.Count > 0)
                                    {
                                        string checkYellow = dataTableQR.Rows[0]["ApplicationType"].ToString();
                                        if (checkYellow == "yellowCard")
                                        {
                                            string QR_Code = dataTableQR.Rows[0]["AppNo"].ToString();
                                            string Control_Code = dataTableQR.Rows[0]["AssetCode"].ToString();
                                            string Emp_No = dataTableQR.Rows[0]["EmpNo"].ToString();
                                            string Emp_Name = dataTableQR.Rows[0]["Name"].ToString();
                                            string Depart = dataTableQR.Rows[0]["Depart"].ToString();
                                            string Brand = dataTableQR.Rows[0]["ComputerBrand"].ToString();
                                            string Spec = dataTableQR.Rows[0]["ComputerSpeci"].ToString();
                                            string Serial_Number = dataTableQR.Rows[0]["SeriNum"].ToString();
                                            string Color = dataTableQR.Rows[0]["ColorPC"].ToString();
                                            string TimeStart = dataTableQR.Rows[0]["TimeStart"].ToString();

                                            string TimeEnd = dataTableQR.Rows[0]["TimeEnd"].ToString();
                                            string LocationAccess = dataTableQR.Rows[0]["LocationApply"].ToString();

                                            DateTime timeS = Convert.ToDateTime(TimeStart);
                                            DateTime timeE = Convert.ToDateTime(TimeEnd);
                                            string sqlInsertQR = @" Insert into QR_Infor(QR_Code,Control_Code,Emp_No,Emp_Name, Depart, Brand, Spec , Serial_Number,Color,TimeStart, TimeEnd,LocationAccess)
values (@QR_Code,@Control_Code,@Emp_No,@Emp_Name, @Depart, @Brand, @Spec , @Serial_Number,@Color,@TimeStart, @TimeEnd,@LocationAccess)";

                                            SqlParameter[] par = new SqlParameter[12];
                                            par.SetValue(new SqlParameter("QR_Code", QR_Code), 0);
                                            par.SetValue(new SqlParameter("Control_Code", Control_Code), 1);
                                            par.SetValue(new SqlParameter("Emp_No", Emp_No), 2);
                                            par.SetValue(new SqlParameter("Emp_Name", Emp_Name), 3);
                                            par.SetValue(new SqlParameter("Depart", Depart), 4);
                                            par.SetValue(new SqlParameter("Brand", Brand), 5);
                                            par.SetValue(new SqlParameter("Spec", Spec), 6);
                                            par.SetValue(new SqlParameter("Serial_Number", Serial_Number), 7);
                                            par.SetValue(new SqlParameter("Color", Color), 8);
                                            par.SetValue(new SqlParameter("TimeStart", timeS), 9);
                                            par.SetValue(new SqlParameter("TimeEnd", timeE), 10);
                                            par.SetValue(new SqlParameter("LocationAccess", LocationAccess), 11);

                                            bool inserKq = dbQR.ExcuteNonQuery(sqlInsertQR, par);
                                        }
                                        else if(checkYellow == "addDHCP")
                                        {
                                            string macAdd = dataTableQR.Rows[0]["MacAd"].ToString();
                                            string descr = dataTableQR.Rows[0]["EmpNo"].ToString();
                                            string Emp_No = dataTableQR.Rows[0]["EmpNo"].ToString();
                                            string Depart = dataTableQR.Rows[0]["EmpNo"].ToString();
                                            string station = dataTableQR.Rows[0]["usb_read"].ToString() +"-"+dataTableQR.Rows[0]["Location"].ToString();

                                            string strDhcp = @"insert into LIST_MAC(MAC_ADDRESS,DESCRIPTION,DEPARTMENT,ID_CARD,STATUS,ACTION,DATE_TIME,STATION) values (@MAC_ADDRESS,@DESCRIPTION,@DEPARTMENT,@ID_CARD,'0','ADD',getdate(),@STATION)";

                                            SqlParameter[] para = new SqlParameter[5];
                                            para.SetValue(new SqlParameter("MAC_ADDRESS", macAdd), 0);
                                            para.SetValue(new SqlParameter("DESCRIPTION", descr), 1);
                                            para.SetValue(new SqlParameter("DEPARTMENT", station), 2);
                                            para.SetValue(new SqlParameter("ID_CARD", Emp_No), 3);
                                            para.SetValue(new SqlParameter("STATION", station), 4);

                                            bool inserKq = dbDHCP.ExcuteNonQuery(strDhcp, para);
                                        }
                                    }

                                    break;
                                }
                                
                            }                          
                        }
                    }
                    else if (approve == "Reject")
                    {
                        string sqlQuery1 = @"select * from approvalSchedule where AppNo='" + appNo + "' order by step asc ";
                        DataTable tb2 = db.DoSQLSelect(sqlQuery1);
                        if (tb2.Rows.Count > 0)
                        {
                            checkWa = tb2.Rows[ste]["signEmpNo"].ToString();
                            staTus = tb2.Rows[ste]["statusName"].ToString();
                            checkNa = tb2.Rows[ste]["SignName"].ToString();
                            f_insert_sub_yellow("駁回", appNo, note, checkNa, ste, checkWa, staTus);
                        }
                        string AppNoR = appNo;
                        string signEmpNo = "";
                        string SignName = "";
                        string statusName = "";
                        int stepR;

                        for (int i = 0; i < tb2.Rows.Count; i++)
                        {
                            signEmpNo = tb2.Rows[i]["signEmpNo"].ToString();
                            SignName = tb2.Rows[i]["SignName"].ToString();
                            statusName = tb2.Rows[i]["statusName"].ToString();
                            stepR = Convert.ToInt32(tb2.Rows[i]["step"].ToString());
                            insertReject(AppNoR, signEmpNo, SignName, statusName, stepR);
                        }
                        NewCode nCode = new NewCode();
                        int steNext = ste + 1;
                        for (int i= steNext;i < tb2.Rows.Count; i++)
                        {
                            deleteReject(appNo, i);
                        }

                        string sqlQueryRej = @"select * from approvalRejectFlag where AppNo='" + appNo + "' order by step asc";
                        DataTable tbRejectFlag = db.DoSQLSelect(sqlQueryRej);
                        for(int i = 0; i <tbRejectFlag.Rows.Count; i++)
                        {
                            signEmpNo = tbRejectFlag.Rows[i]["signEmpNo"].ToString();
                            SignName = tbRejectFlag.Rows[i]["SignName"].ToString();
                            statusName = tbRejectFlag.Rows[i]["statusName"].ToString();
                            stepR = steNext + i;
                            nCode.insertListSign(appNo, signEmpNo, SignName, statusName, stepR);
                        }
                        //int steNext = ste + 1;
                        string sqlQuery = @"select * from approvalSchedule where AppNo='" + appNo + "' and step='" + steNext + "' ";
                        DataTable tb1 = db.DoSQLSelect(sqlQuery);
                        if (tb1.Rows.Count > 0)
                        {
                            //checkWa = tb1.Rows[0]["signEmpNo"].ToString();
                            //staTus = tb1.Rows[0]["statusName"].ToString();
                            //checkNa = tb1.Rows[0]["SignName"].ToString();

                            checkWa = tb1.Rows[0]["signEmpNo"].ToString();
                            staTus = tb1.Rows[0]["statusName"].ToString();
                            checkNa = tb1.Rows[0]["SignName"].ToString();

                            string sqlQuery2 = @"update DATA_APP_ESIGN set APPSTATUS= @APPSTATUS , CHECKWAITNAME=@CHECKWAITNAME,Checkwait=@Checkwait , 
            Step=@Step where APPNO=@appNo ";
                            SqlParameter[] param = new SqlParameter[5];
                            param.SetValue(new SqlParameter("APPSTATUS", staTus), 0);
                            param.SetValue(new SqlParameter("CHECKWAITNAME", checkNa), 1);
                            param.SetValue(new SqlParameter("Checkwait", checkWa), 2);
                            param.SetValue(new SqlParameter("Step", steNext), 3);
                            param.SetValue(new SqlParameter("APPNO", appNo), 4);

                            db.ExcuteNonQuery(sqlQuery2, param);
                        }
                    }
                    else if (approve == "Forward")
                    {
                        string sqlQuery = @" ";
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }


        //chuyen nguoi ky 
        public bool forWardSigner(string appNo, string note,string rank, string empNo,string empName)
        {
            string strQuery1 = @"SELECT * FROM DATA_APP_ESIGN where APPNO = '" + appNo + "' ";
            try
            {
                string checkWa = "";
                string staTus = "";
                string checkNa = "";
                string checkDupSigner = "";
                string signEmpNo = " ";
                string SignName = " ";
                string statusName = " ";

                DataTable tbData = dbES.DoSQLSelect(strQuery1);
                if (tbData.Rows.Count > 0)
                {
                    int ste = Convert.ToInt32(tbData.Rows[0]["step"].ToString());
                    string sqlQuery1 = @"select * from approvalSchedule where AppNo='" + appNo + "' order by step asc ";
                    DataTable tb2 = dbES.DoSQLSelect(sqlQuery1);
                    if (tb2.Rows.Count > 0)
                    {
                        deleteflag(appNo);
                        checkWa = tb2.Rows[ste]["signEmpNo"].ToString();
                        staTus = tb2.Rows[ste]["statusName"].ToString();
                        checkNa = tb2.Rows[ste]["SignName"].ToString();
                        f_insert_sub_yellow("forward", appNo, note, checkNa, ste, checkWa, staTus);
                        int stepR = ste + 1;
                        insertReject(appNo, empNo, empName, rank, stepR);

                        for (int i = ste;i < tb2.Rows.Count; i++)
                        {
                            stepR = i + 2;
                            signEmpNo = tb2.Rows[i]["signEmpNo"].ToString();
                            SignName = tb2.Rows[i]["SignName"].ToString();
                            statusName = tb2.Rows[i]["statusName"].ToString();
                            //stepR = Convert.ToInt32(tb2.Rows[i]["step"].ToString());
                            insertReject(appNo, signEmpNo, SignName, statusName, stepR);
                            deleteReject(appNo, i);
                        }

                        string sqlQueryRej = @"select * from approvalRejectFlag where AppNo='" + appNo + "' order by step asc";
                        DataTable tbRejectFlag = dbES.DoSQLSelect(sqlQueryRej);
                        for (int i = 0; i < tbRejectFlag.Rows.Count; i++)
                        {
                            signEmpNo = tbRejectFlag.Rows[i]["signEmpNo"].ToString();
                            SignName = tbRejectFlag.Rows[i]["SignName"].ToString();
                            statusName = tbRejectFlag.Rows[i]["statusName"].ToString();
                            stepR = Convert.ToInt32(tbRejectFlag.Rows[i]["step"].ToString());
                            newCode.insertListSign(appNo, signEmpNo, SignName, statusName, stepR);
                        }
                        stepR = ste + 1;
                        //kiem tra xem co du lieu nguoi ky ke tiep ko
                        string sqlQuery = @"select * from approvalSchedule where AppNo='" + appNo + "' and step='" + stepR + "' ";
                        DataTable tb1 = dbES.DoSQLSelect(sqlQuery);
                        if (tb1.Rows.Count > 0)
                        {
                            //checkWa = tb1.Rows[0]["signEmpNo"].ToString();
                            //staTus = tb1.Rows[0]["statusName"].ToString();
                            //checkNa = tb1.Rows[0]["SignName"].ToString();

                            checkWa = tb1.Rows[0]["signEmpNo"].ToString();
                            staTus = tb1.Rows[0]["statusName"].ToString();
                            checkNa = tb1.Rows[0]["SignName"].ToString();

                            string sqlQuery2 = @"update DATA_APP_ESIGN set APPSTATUS= @APPSTATUS , CHECKWAITNAME=@CHECKWAITNAME,Checkwait=@Checkwait , 
            Step=@Step where APPNO=@appNo ";
                            SqlParameter[] param = new SqlParameter[5];
                            param.SetValue(new SqlParameter("APPSTATUS", staTus), 0);
                            param.SetValue(new SqlParameter("CHECKWAITNAME", checkNa), 1);
                            param.SetValue(new SqlParameter("Checkwait", checkWa), 2);
                            param.SetValue(new SqlParameter("Step", stepR), 3);
                            param.SetValue(new SqlParameter("APPNO", appNo), 4);

                            dbES.ExcuteNonQuery(sqlQuery2, param);
                        }
                    }
                   
                    return true;
                }
                else return false;
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }

        // insert vao bang approvalrejectflag khi reject
        private void insertReject(string AppNo, string signEmpNo, string SignName, string statusName, int step)
        {
            SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");

            string strString = @"insert into approvalRejectFlag(AppNo,signEmpNo,SignName,statusName,step) values (@AppNo,@signEmpNo,@SignName,@statusName,@step) ";
            SqlParameter[] param = new SqlParameter[5];
            param.SetValue(new SqlParameter("AppNo", AppNo), 0);
            param.SetValue(new SqlParameter("signEmpNo", signEmpNo), 1);
            param.SetValue(new SqlParameter("SignName", SignName), 2);
            param.SetValue(new SqlParameter("statusName", statusName), 3);
            param.SetValue(new SqlParameter("step", step), 4);

            db.ExcuteNonQuery(strString, param);
        }

        // delete when reject
        private void deleteReject(string appNo, int step)
        {
            SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            string strQuery = @"delete from approvalSchedule where AppNo='"+appNo+"' and step ='"+step+"'" ;
            db.ExcuteNonQuery(strQuery);
        }

        private void deleteflag(string appNo)
        {           
            string strQuery = @"delete from approvalRejectFlag where AppNo='" + appNo + "' ;";
            dbES.ExcuteNonQuery(strQuery);
        }


    }
}