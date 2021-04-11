using New_Esign.AppCode;
using System.Data;

public class EmployeeHelper
{
    public static New_Esign.HRWebService.ElistQuerySoapClient hr = new New_Esign.HRWebService.ElistQuerySoapClient();
    public static EmployeeModel GetEmployeeInfo(string _EmployeeIdOrUserName)
    {
        _EmployeeIdOrUserName = _EmployeeIdOrUserName.ToUpper();
        EmployeeModel em = new EmployeeModel();
        if (hr != null)
        {
            DataSet ds = hr.ByUserID(_EmployeeIdOrUserName);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                ds = hr.ByUserName(_EmployeeIdOrUserName);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //USER_ID Employee ID
                em.USER_ID = ds.Tables[0].Rows[0]["USER_ID"].ToString();
                //USER_NAME  : Employee name in chinese
                em.USER_NAME = ds.Tables[0].Rows[0]["USER_NAME"].ToString();
                //SEX   男:man   女:women
                em.SEX = ds.Tables[0].Rows[0]["SEX"].ToString();

                em.GRADE = ds.Tables[0].Rows[0]["GRADE"].ToString();
                em.JOB_TITLE = ds.Tables[0].Rows[0]["JOB_TITLE"].ToString();
                em.CURRENT_OU_CODE = ds.Tables[0].Rows[0]["CURRENT_OU_CODE"].ToString();
                em.DEPARTMENT_NAME = ds.Tables[0].Rows[0]["CURRENT_OU_NAME"].ToString();

                em.NOTES_ID = ds.Tables[0].Rows[0]["NOTES_ID"].ToString();
                em.EMAIL = ds.Tables[0].Rows[0]["EMAIL"].ToString();

                em.LOCATION = ds.Tables[0].Rows[0]["LOCATION"].ToString();

                em.ALL_MANAGERS = ds.Tables[0].Rows[0]["ALL_MANAGERS"].ToString();
                em.SITE_ALL_MANAGERS = ds.Tables[0].Rows[0]["SITE_ALL_MANAGERS"].ToString();
                em.BU_ALL_MANAGERS = ds.Tables[0].Rows[0]["BU_ALL_MANAGERS"].ToString();

                em.UPPER_OU_CODE = ds.Tables[0].Rows[0]["UPPER_OU_CODE"].ToString();
                //NOTDUTY   No: work nomarly. Yes: Duty
                em.NOTDUTY = ds.Tables[0].Rows[0]["NOTDUTY"].ToString();
                //TRAVEL    No: work nomarly. Yes: Go to travel in out side
                em.TRAVEL = ds.Tables[0].Rows[0]["TRAVEL"].ToString();
                em.HIREDATE = ds.Tables[0].Rows[0]["HIREDATE"].ToString();
                //Date off out-work
                em.LEAVEDAY = ds.Tables[0].Rows[0]["LEAVEDAY"].ToString();
                em.USER_ID_EXT = ds.Tables[0].Rows[0]["USER_ID_EXT"].ToString();
                em.JOB_TYPE = ds.Tables[0].Rows[0]["JOB_TYPE"].ToString();
                //Level off Employee
                em.USER_LEVEL = ds.Tables[0].Rows[0]["USER_LEVEL"].ToString();

                em.List_manager = em.BU_ALL_MANAGERS.Split(';');
            }
        }

        return em;
    }
    public static string GetEmployeeName(string _EmployeeIdOrUserName)
    {
        _EmployeeIdOrUserName = _EmployeeIdOrUserName.ToUpper();
        string name = _EmployeeIdOrUserName;
        if (hr != null)
        {
            DataSet ds = hr.ByUserID(_EmployeeIdOrUserName);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                ds = hr.ByUserName(_EmployeeIdOrUserName);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                name = ds.Tables[0].Rows[0]["USER_NAME"].ToString();
            }
        }
        return name;
    }
    public static string GetEmployeeMail(string _EmployeeIdOrUserName)
    {
        _EmployeeIdOrUserName = _EmployeeIdOrUserName.ToUpper();
        string mail = "";
        if (hr != null)
        {
            DataSet ds = hr.ByUserID(_EmployeeIdOrUserName);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                ds = hr.ByUserName(_EmployeeIdOrUserName);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                mail = ds.Tables[0].Rows[0]["NOTES_ID"].ToString();
                if (string.IsNullOrWhiteSpace(mail)) mail = ds.Tables[0].Rows[0]["EMAIL"].ToString();
            }
        }
        return mail;
    }
}
