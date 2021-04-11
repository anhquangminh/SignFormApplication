using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class LanguageHelper
{
    public const string languageVI = "VI";
    public const string languageEN = "EN";
    public const string languageCH = "ZH";


    public static string languageId { get; set; }

    /// <summary>
    /// Lấy giá trị string của resource theo ngôn ngữ người dùng hiện tại.
    /// Các giá trị này được lưu trong database tb_Resource
    /// Ví dụ ResourceID= Account.Username;
    /// GetResource("Account.Username","vi")= "Tài khoản"
    /// GetResource("Account.Username","en")= "Username"
    /// GetResource("Account.Username","zh")= "用户名"
    /// </summary>
    /// <param name="_resourceId">Mã resource. VD: Home.LabelLanguage; Account.Username; Account.Password; ...</param>
    /// <returns> Giá trị text  </returns>
    public static string GetResource(string _resourceId, bool _notFoundAdd = false)
    {
        return GetResource(_resourceId, languageId, _notFoundAdd);
    }

    /// <summary>
    /// Lấy giá trị string của resource theo ngôn ngữ chỉ định.
    /// Các giá trị này được lưu trong database tb_Resource
    /// </summary>
    /// <param name="_resourceId">Mã resource. VD: Home.LabelLanguage; Account.Username; Account.Password; ...</param>
    /// <param name="_languageId">Mã ngôn ngữ cần lấy giá trị. Tiếng Anh: en, Tiếng Việt: vi, Tiếng Trung: zh</param>
    /// <returns> Giá trị text  </returns>
    public static string GetResource(string _resourceId, string _languageId, bool _notFoundAdd = false)
    {
        string value = _resourceId;
        if (_notFoundAdd) value = _languageId + "." + value;
        SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
        string tempStr = "SELECT resourceValue FROM Resources WHERE languageId='" + _languageId + "' AND resourceName='" + _resourceId + "'";
        tempStr = db.GetSingleValueSelect(tempStr);
        if (!string.IsNullOrWhiteSpace(tempStr)) value = tempStr;
        return value;
    }
    public static DataTable GetListLanguage()
    {
        DataTable dt = new DataTable();
        SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
        string tempStr = "SELECT * FROM Languages";
        dt = db.DoSQLSelect(tempStr);
        return dt;
    }

    public static DataTable GetListLanguage(int _startIndex, int _pageNumberRow)
    {
        DataTable dt = new DataTable();
        SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
        string tempStr = "SELECT * FROM Languages";
        dt = db.DoSQLSelect(tempStr, _startIndex, _pageNumberRow);
        return dt;
    }
}
