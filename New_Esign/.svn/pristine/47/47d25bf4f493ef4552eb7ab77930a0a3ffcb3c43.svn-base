using New_Esign.Areas.Administrators.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class EsignCommon
{
    public static SelectList GetSelectListSite(ref string selectedSite,bool haveDefault=false)
    {
        List<SiteModel> ListSite = GetListSite();
        if(haveDefault) ListSite.Insert(0,new SiteModel("-",LanguageHelper.GetResource("Selector.SelectSite")));
        if (string.IsNullOrWhiteSpace(selectedSite)) selectedSite = ListSite.Count > 0 ? ListSite[0].SiteID : null;
        return new SelectList(ListSite, "SiteID", "SiteName", selectedSite);
    }
    public static SelectList GetSelectListType(ref string selectedType)
    {
        List<string> ListType = EsignCommon.GetListType();
        if (string.IsNullOrWhiteSpace(selectedType)) selectedType = ListType.Count > 0 ? ListType[0] : null;
        return new SelectList(ListType, selectedType);
    }
    public static SelectList GetSelectListBU(string selectedSite, ref string selectedBU, bool haveDefault = false)
    {
        List<BusinessUnitModel> ListBU = GetListBU(selectedSite);
        if (haveDefault) ListBU.Insert(0, new BusinessUnitModel("-", LanguageHelper.GetResource("Selector.SelectBU")));
        if (string.IsNullOrWhiteSpace(selectedBU)) selectedBU = ListBU.Count > 0 ? ListBU[0].BUID : null;
        return new SelectList(ListBU, "BUID", "BUName", selectedBU);
    }

    public static List<string> GetListType()
    {
        SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
        string tempStr = "SELECT ApproverTypeID FROM ApproverType";
        DataTable dt = db.DoSQLSelect(tempStr);
        List<string> ListType = new List<string>();
        foreach (DataRow dr in dt.Rows)
        {
            ListType.Add(dr[0].ToString().Trim());
        }
        return ListType;
    }
    public static List<SiteModel> GetListSite()
    {
        SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
        string tempStr = "SELECT * FROM Site";
        DataTable dt = db.DoSQLSelect(tempStr);
        List<SiteModel> ListSite = new List<SiteModel>();
        foreach (DataRow dr in dt.Rows)
        {
            ListSite.Add(new SiteModel(dr["SiteID"].ToString().Trim(), dr["SiteName"].ToString().Trim()));
        }
        return ListSite;
    }
    public static List<BusinessUnitModel> GetListBU(string SiteID)
    {
        string tempStr = "SELECT * FROM BU";
        SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
        DataTable dt = db.DoSQLSelect(tempStr);
        if (!string.IsNullOrWhiteSpace(SiteID))
            tempStr += " WHERE SiteID='" + SiteID + "'";
        dt = db.DoSQLSelect(tempStr);
        List<BusinessUnitModel> ListBU = new List<BusinessUnitModel>();
        foreach (DataRow dr in dt.Rows)
        {
            ListBU.Add(new BusinessUnitModel(dr["BUID"].ToString().Trim(), dr["BUName"].ToString().Trim()));
        }
        return ListBU;
    }
}