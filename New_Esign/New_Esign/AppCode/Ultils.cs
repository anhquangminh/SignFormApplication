using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserInfo
/// </summary>
public class Ultils
{
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
    #region 读取或写入cookie

    /// <summary>
    /// 写cookie值
    /// </summary>
    /// <param name="strName">名称</param>
    /// <param name="strValue">值</param>
    public static void UpdateCookie(string strName, string strValue)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
        if (cookie == null)
        {
            cookie = new HttpCookie(strName);
        }
        cookie.Value = UrlEncode(strValue);
        HttpContext.Current.Response.SetCookie(cookie);
    }

    /// <summary>
    /// 写cookie值
    /// </summary>
    /// <param name="strName">名称</param>
    /// <param name="strValue">值</param>
    public static void WriteCookie(string strName, string strValue)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
        if (cookie == null)
        {
            cookie = new HttpCookie(strName);
        }
        cookie.Value = UrlEncode(strValue);
        HttpContext.Current.Response.AppendCookie(cookie);
    }

    /// <summary>
    /// 写cookie值
    /// </summary>
    /// <param name="strName">名称</param>
    /// <param name="strValue">值</param>
    public static void WriteCookie(string strName, string key, string strValue)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
        if (cookie == null)
        {
            cookie = new HttpCookie(strName);
        }
        cookie[key] = UrlEncode(strValue);
        HttpContext.Current.Response.AppendCookie(cookie);
    }

    /// <summary>
    /// 写cookie值
    /// </summary>
    /// <param name="strName">名称</param>
    /// <param name="strValue">值</param>
    public static void WriteCookie(string strName, string key, string strValue, int expires)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
        if (cookie == null)
        {
            cookie = new HttpCookie(strName);
        }
        cookie[key] = UrlEncode(strValue);
        cookie.Expires = DateTime.Now.AddMinutes(expires);
        HttpContext.Current.Response.AppendCookie(cookie);
    }

    /// <summary>
    /// 写cookie值
    /// </summary>
    /// <param name="strName">名称</param>
    /// <param name="strValue">值</param>
    /// <param name="strValue">过期时间(分钟)</param>
    public static void WriteCookie(string strName, string strValue, int expires)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
        if (cookie == null)
        {
            cookie = new HttpCookie(strName);
        }
        cookie.Value = UrlEncode(strValue);
        cookie.Expires = DateTime.Now.AddMinutes(expires);
        HttpContext.Current.Response.AppendCookie(cookie);
    }

    /// <summary>
    /// 读cookie值
    /// </summary>
    /// <param name="strName">名称</param>
    /// <returns>cookie值</returns>
    public static string GetCookie(string strName)
    {
        try
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
                return UrlDecode(HttpContext.Current.Request.Cookies[strName].Value.ToString());
        }
        catch (Exception exc) { }
        return "";
    }

    /// <summary>
    /// 读cookie值
    /// </summary>
    /// <param name="strName">名称</param>
    /// <returns>cookie值</returns>
    public static string GetCookie(string strName, string key)
    {
        try
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[strName][key] != null)
                return UrlDecode(HttpContext.Current.Request.Cookies[strName][key].ToString());
        }
        catch (Exception exc) { }
        return "";
    }
    #endregion

    #region URL处理
    /// <summary>
    /// URL字符编码
    /// </summary>
    public static string UrlEncode(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return "";
        }
        str = str.Replace("'", "");
        return HttpContext.Current.Server.UrlEncode(str);
    }

    /// <summary>
    /// URL字符解码
    /// </summary>
    public static string UrlDecode(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return "";
        }
        return HttpContext.Current.Server.UrlDecode(str);
    }

    #endregion

}