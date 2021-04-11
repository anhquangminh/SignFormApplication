using System;
using System.Data;
using System.Data.SqlClient;

public class UserHelper
{
    public static void Login(string _userId, string _userName, string _userPermission)
    {
        int timeOut = 60; //mins
        bool neverTimeOut = false;
        try
        {
            string timeOutConfig = SystemConfigHelper.GetSystemConfig("LoginTimeOut").ToString().Trim();
            if (!"never".Equals(timeOutConfig))
                timeOut = Int16.Parse(timeOutConfig);
            else
                neverTimeOut = true;
        }
        catch (Exception exc) { }
        if (neverTimeOut)
        {
            Ultils.WriteCookie("UserId", _userId);
            Ultils.WriteCookie("UserName", _userName);
            Ultils.WriteCookie("UserPermission", _userPermission);
        }
        else
        {
            Ultils.WriteCookie("UserId", _userId, timeOut);
            Ultils.WriteCookie("UserName", _userName, timeOut);
            Ultils.WriteCookie("UserPermission", _userPermission, timeOut);
        }
    }

    public static bool Login(string _userId, string _password)
    {
        SQLServerDBHelper db = new SQLServerDBHelper("ESign");
        string tempSQL = "SELECT * FROM Account UserID='" + _userId + "' AND Password='" + _password + "'";
        DataTable dt = db.DoSQLSelect(tempSQL);
        if (dt != null && dt.Rows.Count > 0)
        {
            Login(dt.Rows[0]["UserID"].ToString(), dt.Rows[0]["Username"].ToString(), dt.Rows[0]["Permission"].ToString());
            return true;
        }
        return false;
    }

    public static bool CreateUser(string UserID, string Password, string Username, string Email, string Telephone, string CostNo, string Department, string BUID, string SiteID, string ManagerName, string ManagerEmpNo, string ManagerEmail, string Purpose, string Note, string Permission = "user")
    {
        SQLServerDBHelper db = new SQLServerDBHelper("ESign");
        string tempSQL = "INSERT INTO Account (UserID,Password,Username,Email,Telephone,CostNo,Department,BUID,SiteID,ManagerName,ManagerEmpNo,ManagerEmail,Purpose,Note,Permission) VALUES (@id,@pw,@un,@em,@te,@cn,@dept,@bu,@site,@mn,@men,@me,@pur,@note,@per)";
        SqlParameter[] parameters = new SqlParameter[15];
        parameters.SetValue(new SqlParameter("id", UserID), 0);
        parameters.SetValue(new SqlParameter("pw", Password), 1);
        parameters.SetValue(new SqlParameter("un", Username), 2);
        parameters.SetValue(new SqlParameter("em", Email), 3);
        parameters.SetValue(new SqlParameter("te", Telephone), 4);
        parameters.SetValue(new SqlParameter("cn", CostNo), 5);
        parameters.SetValue(new SqlParameter("dept", Department), 6);
        parameters.SetValue(new SqlParameter("bu", BUID), 7);
        parameters.SetValue(new SqlParameter("site", SiteID), 8);
        parameters.SetValue(new SqlParameter("mn", ManagerName), 9);
        parameters.SetValue(new SqlParameter("men", ManagerEmpNo), 10);
        parameters.SetValue(new SqlParameter("me", ManagerEmail), 11);
        parameters.SetValue(new SqlParameter("pur", Purpose), 12);
        parameters.SetValue(new SqlParameter("note", Note), 13);
        parameters.SetValue(new SqlParameter("per", Permission), 14);
        return db.ExcuteNonQuery(tempSQL, parameters);
    }

    public static bool UpdateUser(string UserID, string Password, string Username, string Email, string Telephone, string CostNo, string Department, string BUID)
    {
        SQLServerDBHelper db = new SQLServerDBHelper("ESign");
        string tempSQL = "UPDATE Account SET Password=@pw,Username=@un,Email=@em,Telephone=@te,CostNo=@cn,Department=@dept,BUID=@bu WHERE UserID=@id";
        SqlParameter[] parameters = new SqlParameter[8];
        parameters.SetValue(new SqlParameter("pw", Password), 0);
        parameters.SetValue(new SqlParameter("un", Username), 1);
        parameters.SetValue(new SqlParameter("em", Email), 2);
        parameters.SetValue(new SqlParameter("te", Telephone), 3);
        parameters.SetValue(new SqlParameter("cn", CostNo), 4);
        parameters.SetValue(new SqlParameter("dept", Department), 5);
        parameters.SetValue(new SqlParameter("bu", BUID), 6);
        parameters.SetValue(new SqlParameter("id", UserID), 7);
        return db.ExcuteNonQuery(tempSQL, parameters);
    }

    public static void Logout()
    {
        Ultils.WriteCookie("UserId", null);
        Ultils.WriteCookie("UserName", null);
        Ultils.WriteCookie("UserPermission", null);
    }
    public static bool isLogged()
    {
        string UId = Ultils.GetCookie("UserId");
        if (!string.IsNullOrWhiteSpace(UId)) return true;
        return false;
    }

    public static string getUserId()
    {
        return Ultils.GetCookie("UserId");
    }
    public static string getUserName()
    {
        return Ultils.GetCookie("UserName");
    }
    public static string getUserPermission()
    {
        return Ultils.GetCookie("UserPermission");
    }
    public static bool checkPermission()
    {
        string per = Ultils.GetCookie("UserPermission");
        if (!string.IsNullOrWhiteSpace(per) && (per.IndexOf("manager") != -1 || per.IndexOf("admin") != -1))
            return true;
        else return false;
    }
}