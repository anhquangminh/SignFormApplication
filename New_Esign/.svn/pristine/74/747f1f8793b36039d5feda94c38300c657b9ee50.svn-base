using New_Esign.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace New_Esign.AppCode
{
    public class SendMail
    {
        public SQLServerDBHelper sqlDB = new SQLServerDBHelper("ConnectDB");

        public SQLServerDBHelper sqlDBEsign = new SQLServerDBHelper("ESignDB");

        public NewCode nCode = new NewCode();

        public bool insertSenmail(string empNo, string orderNo,string conten,string appliCant,string notes)
        {
            try
            {
                PostmanService.PostmanServiceSoapClient postman = new PostmanService.PostmanServiceSoapClient();
                DataTable tableEmp = postman.GetEmpInfomation(empNo);
                string userName =  tableEmp.Rows[0]["USER_NAME"].ToString();
                string mailTo = nCode.getMailAccount(empNo);
                if (mailTo != null || mailTo != "")
                {
                    mailTo = tableEmp.Rows[0]["NOTES_ID"].ToString();
                    if (mailTo.Equals("") || mailTo == null)
                    {
                        mailTo = ",";
                    }
                }

                Random newRan = new Random();
                int num = newRan.Next(1,1000);
                string ran = Convert.ToString(num);
                string id = DateTime.Now.ToString("yyyyMMddHHmmss") + ran;
                DataTable tableEmp2 = postman.GetEmpInfomation(appliCant);
                string userName2 = tableEmp2.Rows[0]["USER_NAME"].ToString();
                string copyto = "";

                string sqlQueryLink = @"select * from link_formSign where linkNameTrim = '" + conten.Trim() + "'";
                DataTable tbLink = sqlDBEsign.DoSQLSelect(sqlQueryLink);
                string conte = conten;
                string linkForm = "";

                if (tbLink.Rows.Count > 0)
                {
                    linkForm = tbLink.Rows[0]["linkSign"].ToString();
                }
                else linkForm = "http://10.224.81.136:8686/Employee/ApplicationIT/formSign?appNo=";
                

                string fla = "0";
                string mailTitle = userName + " , 您好, 《Esign-system 2.0》" + notes + " ! 單據名稱: "+ conte + " , 申請人: "+ userName2 + " ,申請單號:" + orderNo;
                string mailBody1 = "\n《Esign-system 2.0》文件電子簽核申請信息,申請單號: " + orderNo;
                string mailBody2 = "系統網址(web site): http://10.224.81.136:8686/";
                string mailBody3 = "\n單據簽核連接(web site of approve): " + linkForm + orderNo;
                string mailBody4 = "\n";
                string mailBody5 = @"\n基本操作說明(Basic operating instructions):
1.點擊系統網址後會出現登錄畫面(使用域帳號登錄[開機帳號 + 開機密碼]).
 --enter the login page, key in your computer account / your computer password.
2.進入系統界面後，即可選擇申請單號進行簽核.

--login system select apply number to approve.
3.若沒有賬號請先註冊您的賬號,待審核審核通過即可登錄使用.
--If you don't have an account, please register your account first, and you can login to use after being approved.
基本操作說明:
                1.點擊系統網址後會出現登錄畫面()
     （1）若沒有手動註冊過,則初始賬號和密碼均為工號，該頁面權限已自動開通，無需聯繫系統管理員
     （2）若無法登錄，請注意查看系統提示信息,詳情如下：
         a）若提示沒有賬號，則請自行註冊(若有[新版]和[舊版]，請點擊[舊版]進行註冊)，註冊成功后再郵件通知系統管理員去開通權限或註冊時自動選擇相應權限(步驟：點擊[自助選擇權限]--》彈出的頁面中選擇相應權限)
         b）若提示沒有權限，則請郵件通知系統管理員去開通權限
         c）若提示密碼不對，則請重置開機密碼
         c）若提示賬號被鎖，則請點擊[忘記密碼] 自行解鎖
    2.進入系統界面後﹐即可選擇申請單號.
    3.系統管理員聯繫方式在系統登錄頁面，請自行查找(若有[新版]和[舊版]，請點擊[舊版]進行查找).
" ;
                string mailBody6 = "IT聯絡信息 (Ext:535-27847/27123 Mail:vngw-it-app@mail.foxconn.com)";
                string mailBody = string.Format(@"{0}
{1}
{2} 
{3} 
{4} 
{5}
{6}", mailBody1.PadLeft(4), mailBody2.PadLeft(4), mailBody3.PadLeft(4), mailBody4.PadLeft(4), mailBody5.PadLeft(4), mailBody6.PadLeft(4), DateTime.Now.ToString().PadLeft(4));

                string title2 = mailTitle;
                string sqlQuery = @"insert into sendm(id,sendto,copyto,title,body,flag) values (@id,@sendto,@copyto,@title,@body,@flag) ;";

                SqlParameter[] param = new SqlParameter[6];

                param.SetValue(new SqlParameter("id", id), 0);
                param.SetValue(new SqlParameter("sendto", mailTo), 1);
                param.SetValue(new SqlParameter("copyto", copyto), 2);
                param.SetValue(new SqlParameter("title", title2), 3);
                param.SetValue(new SqlParameter("body", mailBody), 4);
                param.SetValue(new SqlParameter("flag", fla), 5);

                bool kr = sqlDB.ExcuteNonQuery(sqlQuery,param);

                return kr;
            }
            catch
            {
                return false;
            }
        }
        //gui mail theo dau don 
        public bool insertSenmail(string empNo, string orderNo, string conten, string appliCant, string notes,string title)
        {
            try
            {
                PostmanService.PostmanServiceSoapClient postman = new PostmanService.PostmanServiceSoapClient();
                DataTable tableEmp = postman.GetEmpInfomation(empNo);
                string userName = tableEmp.Rows[0]["USER_NAME"].ToString();

                string mailTo = nCode.getMailAccount(empNo); 
                if (mailTo != null || mailTo != "")
                {
                    mailTo = tableEmp.Rows[0]["NOTES_ID"].ToString();
                    if (mailTo.Equals("") || mailTo == null)
                    {
                        mailTo = ",";
                    }
                }

                Random newRan = new Random();
                int num = newRan.Next(1, 1000);
                string ran = Convert.ToString(num);
                string id = DateTime.Now.ToString("yyyyMMddHHmmss") + ran;
                DataTable tableEmp2 = postman.GetEmpInfomation(appliCant);
                string userName2 = tableEmp2.Rows[0]["USER_NAME"].ToString();
                string copyto = "";
                if (mailTo.Equals(""))
                {
                    mailTo = "vngw-it-app@mail.foxconn.com";
                    copyto = "kiem tra loi";
                }

                string sqlQueryLink = @"select * from link_formSign where linkNameTrim = '" + conten.Trim() + "'";
                DataTable tbLink = sqlDBEsign.DoSQLSelect(sqlQueryLink);
                string conte = conten;
                string linkForm = "";

                if (tbLink.Rows.Count > 0)
                {
                    linkForm = tbLink.Rows[0]["linkSign"].ToString();
                }                
                else linkForm = "https://appvn3.foxconn.com/Employee/ApplicationIT/formSign?appNo=";
                //https://appvn3.foxconn.com/EsignVN/Employee/ApplicationIT/formSign?appNo=
                //switch (conte.Trim())
                //{
                //    case "PCYellowCard ":
                //        {
                //            linkForm = "https://appvn3.foxconn.com/Employee/ApplicationIT/formSign?appNo=";
                //            break;
                //        }

                //    case "OpenAccessPermission":
                //        {
                //            linkForm = "https://appvn3.foxconn.com/Employee/ApplicationIT/formSign?appNo=";
                //            break;
                //        }
                //    case "Openport445":
                //        {
                //            linkForm = "https://appvn3.foxconn.com/Employee/ApplicationIT/formSign?appNo=";
                //            break;
                //        }
                //    case "Authorizeyouraccount":
                //        {
                //            linkForm = "https://appvn3.foxconn.com/Employee/ApplicationIT/formSign?appNo=";
                //            break;
                //        }
                //    case "OpenUSB":
                //        {
                //            linkForm = "https://appvn3.foxconn.com/Employee/ApplicationIT/formSign?appNo=";
                //            break;
                //        }
                //    case "Contactdocument":
                //        {
                //            linkForm = "https://appvn3.foxconn.com/Employee/ApplicationHR/signingForm?appNo=";
                //            break;
                //        }
                //    case "AddMacDHCP":
                //        {
                //            linkForm = "https://appvn3.foxconn.com/Employee/ApplicationIT/formSign?appNo=";
                //            break;
                //        }
                //    default:
                //        {
                //            linkForm = "https://appvn3.foxconn.com/Employee/ApplicationIT/formSign?appNo=";
                //            break;
                //        }
                //}
                string fla = "0";
                string mailTitle = userName + " , 您好, 《Esign-system 2.0》" + notes + " ! 單據名稱: " + conte + " , 申請人: " + userName2 + " ,申請單號:" + orderNo;
                string mailBody1 = "\n《Esign-system 2.0》文件電子簽核申請信息,申請單號: " + orderNo;
                string mailBody2 = "系統網址(web site): http://10.224.81.136:8686/";
                string mailBody3 = "\n單據簽核連接(web site of approve): "+ linkForm + orderNo;
                string mailBody4 = "\n";
                string mailBody5 = @"\n基本操作說明(Basic operating instructions):
1.點擊系統網址後會出現登錄畫面(使用域帳號登錄[開機帳號 + 開機密碼]).
 --enter the login page, key in your computer account / your computer password.
2.進入系統界面後，即可選擇申請單號進行簽核.

--login system select apply number to approve.
3.若沒有賬號請先註冊您的賬號,待審核審核通過即可登錄使用.
--If you don't have an account, please register your account first, and you can login to use after being approved.
基本操作說明:
                1.點擊系統網址後會出現登錄畫面()
     （1）若沒有手動註冊過,則初始賬號和密碼均為工號，該頁面權限已自動開通，無需聯繫系統管理員
     （2）若無法登錄，請注意查看系統提示信息,詳情如下：
         a）若提示沒有賬號，則請自行註冊(若有[新版]和[舊版]，請點擊[舊版]進行註冊)，註冊成功后再郵件通知系統管理員去開通權限或註冊時自動選擇相應權限(步驟：點擊[自助選擇權限]--》彈出的頁面中選擇相應權限)
         b）若提示沒有權限，則請郵件通知系統管理員去開通權限
         c）若提示密碼不對，則請重置開機密碼
         c）若提示賬號被鎖，則請點擊[忘記密碼] 自行解鎖
    2.進入系統界面後﹐即可選擇申請單號.
    3.系統管理員聯繫方式在系統登錄頁面，請自行查找(若有[新版]和[舊版]，請點擊[舊版]進行查找).
";
                string mailBody6 = "IT聯絡信息 (Ext:535-27847/27123 Mail:vngw-it-app@mail.foxconn.com)";
                string mailBody = string.Format(@"{0}
{1}
{2} 
{3} 
{4} 
{5}
{6}", mailBody1.PadLeft(4), mailBody2.PadLeft(4), mailBody3.PadLeft(4), mailBody4.PadLeft(4), mailBody5.PadLeft(4), mailBody6.PadLeft(4), DateTime.Now.ToString().PadLeft(4));

                string title2 = mailTitle;
                string sqlQuery = @"insert into sendm(id,sendto,copyto,title,body,flag) values (@id,@sendto,@copyto,@title,@body,@flag) ;";

                SqlParameter[] param = new SqlParameter[6];

                param.SetValue(new SqlParameter("id", id), 0);
                param.SetValue(new SqlParameter("sendto", mailTo), 1);
                param.SetValue(new SqlParameter("copyto", copyto), 2);
                param.SetValue(new SqlParameter("title", title2), 3);
                param.SetValue(new SqlParameter("body", mailBody), 4);
                param.SetValue(new SqlParameter("flag", fla), 5);

                bool kr = sqlDB.ExcuteNonQuery(sqlQuery, param);

                return kr;
                
            }
            catch
            {
                return false;
            }
        }

        // gui mail cho nguoi dung 
        public bool insertSenmail1(string empNo, string orderNo, string conten, string appliCant, string notes, string mail)
        {
            try
            {
                PostmanService.PostmanServiceSoapClient postman = new PostmanService.PostmanServiceSoapClient();
                DataTable tableEmp = postman.GetEmpInfomation(empNo);
                string userName = tableEmp.Rows[0]["USER_NAME"].ToString();
                string mailTo = mail.Trim();

                Random newRan = new Random();
                int num = newRan.Next(1, 1000);
                string ran = Convert.ToString(num);
                string id = DateTime.Now.ToString("yyyyMMddHHmmss") + ran;

                DataTable tableEmp2 = postman.GetEmpInfomation(appliCant);
                string userName2 = tableEmp2.Rows[0]["USER_NAME"].ToString();
                string copyto = "";
                if (mailTo.Equals(""))
                {
                    mailTo = nCode.getMailAccount(empNo);
                    if (mailTo != null || mailTo != "")
                    {
                        mailTo = tableEmp.Rows[0]["NOTES_ID"].ToString();
                        if (mailTo.Equals(""))
                        {
                            mailTo = ",";
                        }
                    }
                }

                string conte = conten;

                string fla = "0";
                string mailTitle = userName + " , 您好, 《Esign-system 2.0》" + notes + "! 單據名稱:" + conte + ", 申請人: " + userName2 + " ,申請單號:" + orderNo;
                string mailBody1 = "\n《Esign-system 2.0》文件電子簽核申請信息,申請單號: " + orderNo;
                string mailBody2 = "系統網址(web site): https://appvn3.foxconn.com/";
                string mailBody3 = "\n單據簽核連接(web site of approve): https://appvn3.foxconn.com/Employee/ApplicationIT/formSign?appNo=" + orderNo;
                string mailBody4 = "\n";
                string mailBody5 = @"\n基本操作說明(Basic operating instructions):
1.點擊系統網址後會出現登錄畫面(使用域帳號登錄[開機帳號 + 開機密碼]).
 --enter the login page, key in your computer account / your computer password.
2.進入系統界面後，即可選擇申請單號進行簽核.

--login system select apply number to approve.
3.若沒有賬號請先註冊您的賬號,待審核審核通過即可登錄使用.
--If you don't have an account, please register your account first, and you can login to use after being approved.
基本操作說明:
                1.點擊系統網址後會出現登錄畫面()
     （1）若沒有手動註冊過,則初始賬號和密碼均為工號，該頁面權限已自動開通，無需聯繫系統管理員
     （2）若無法登錄，請注意查看系統提示信息,詳情如下：
         a）若提示沒有賬號，則請自行註冊(若有[新版]和[舊版]，請點擊[舊版]進行註冊)，註冊成功后再郵件通知系統管理員去開通權限或註冊時自動選擇相應權限(步驟：點擊[自助選擇權限]--》彈出的頁面中選擇相應權限)
         b）若提示沒有權限，則請郵件通知系統管理員去開通權限
         c）若提示密碼不對，則請重置開機密碼
         c）若提示賬號被鎖，則請點擊[忘記密碼] 自行解鎖
    2.進入系統界面後﹐即可選擇申請單號.
    3.系統管理員聯繫方式在系統登錄頁面，請自行查找(若有[新版]和[舊版]，請點擊[舊版]進行查找).
";
                string mailBody6 = "IT聯絡信息 (Ext:535-27847/27123 Mail:vngw-it-app@mail.foxconn.com)";
                string mailBody = string.Format(@"{0}
{1}
{2} 
{3} 
{4} 
{5}
{6}", mailBody1.PadLeft(4), mailBody2.PadLeft(4), mailBody3.PadLeft(4), mailBody4.PadLeft(4), mailBody5.PadLeft(4), mailBody6.PadLeft(4), DateTime.Now.ToString().PadLeft(4));
                string title2 = mailTitle;

                string sqlQuery = @"insert into sendm(id,sendto,copyto,title,body,flag) values (@id,@sendto,@copyto,N'"+title2+"',@body,@flag) ;";

                SqlParameter[] param = new SqlParameter[5];

                param.SetValue(new SqlParameter("id", id), 0);
                param.SetValue(new SqlParameter("sendto", mailTo), 1);
                param.SetValue(new SqlParameter("copyto", copyto), 2);
                
                param.SetValue(new SqlParameter("body", mailBody), 3);
                param.SetValue(new SqlParameter("flag", fla), 4);

                bool kr = sqlDB.ExcuteNonQuery(sqlQuery, param);

                return kr;
            }
            catch
            {
                return false;
            }
        }

        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }
    }
}