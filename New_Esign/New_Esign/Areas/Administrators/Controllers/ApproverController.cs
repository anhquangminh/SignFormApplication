using New_Esign.Areas.Administrators.Models;
using New_Esign.Areas.Employee.Models;
using NewModel.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New_Esign.Areas.Administrators.Controllers
{
    public class ApproverController : Controller
    {
       
        // GET: Administrators/Approver
        public ActionResult Index(ApproverManagerModel amm, int? page = 1)
        {
            if (amm == null) amm = new ApproverManagerModel();
            if (amm.CurentPage == null) amm.CurentPage = page;
            amm.ListApproverModel = GetListApprover(page, amm.SearchData);

            //For paging
            int totalRecord = amm.ListApproverModel.Count;
            int totalPage = totalRecord / PagerModel.PageSize;
            if (totalRecord % PagerModel.PageSize != 0) totalPage += 1;
            ViewBag.Pager = new PagerModel("Index", "Approver", "Administrators", (int)amm.CurentPage, totalPage);

            return View(amm);
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            return View(GetApproverDetail(ID.ToString()));
        }

        [HttpPost]
        public ActionResult Edit(ApproverDetailModel adm)
        {
            string approverID = adm.ApproverModel.ApproverID;
            adm.ApproverModel.SiteId = adm.SelectedSite;
            adm.ApproverModel.BUID = adm.SelectedBU;
            adm.ApproverModel.ApproverType = adm.SelectedType;
            UpdateApprover(adm.ApproverModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(int? ID)
        {
            return View(GetApproverDetail(ID == null ? "" : ID.ToString()));
        }

        [HttpPost]
        public ActionResult Detail(ApproverDetailModel adm)
        {
            if (!ModelState.IsValid)
            {
                RepairSelectListModel(adm);
                return View(adm);
            }
            string approverID = adm.ApproverModel.ApproverID;
            adm.ApproverModel.SiteId = adm.SelectedSite;
            adm.ApproverModel.BUID = adm.SelectedBU;
            adm.ApproverModel.ApproverType = adm.SelectedType;
            if (string.IsNullOrWhiteSpace(approverID))
                CreateApprover(adm.ApproverModel);
            else
                UpdateApprover(adm.ApproverModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(ApproverManagerModel amm)
        {
            int page = (int)amm.CurentPage;
            string approverID = amm.DeleteApproverId;

            if (!string.IsNullOrWhiteSpace(approverID))
            {
                DeleteApprover(approverID);
            }
            if (page > 1)
                return RedirectToAction("Index", "Approver", new { area = "Administrators", page = page });
            else
                return RedirectToAction("Index", "Approver", new { area = "Administrators" });
        }

        //create du lieu moi
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ApproverModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Approver", new { area = "Administrators" });
        }

        // function
        public void RepairSelectListModel(ApproverDetailModel adm)
        {
            //Get List Type
            string SelectedType = adm.SelectedType;
            adm.TypeSelector = EsignCommon.GetSelectListType(ref SelectedType);
            adm.SelectedType = SelectedType;
            //Get List Site
            string SelectedSite = adm.SelectedSite;
            adm.SiteSelector = EsignCommon.GetSelectListSite(ref SelectedSite);
            adm.SelectedSite = SelectedSite;
            //Get List BU
            string SelectedBU = adm.SelectedBU;
            adm.BUSelector = EsignCommon.GetSelectListBU(adm.SelectedSite, ref SelectedBU);
        }

        #region Get functions
        public ApproverDetailModel GetApproverDetail(string ApproverID)
        {
            ApproverDetailModel adm = new ApproverDetailModel();
            string tempStr = "SELECT * FROM Approver WHERE ApproverID='" + ApproverID + "'";
            SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            DataTable dt = db.DoSQLSelect(tempStr);
            adm.ApproverModel = new ApproverModel();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                adm.ApproverModel = new ApproverModel(dr["ApproverID"].ToString(), dr["SiteID"].ToString().Trim(), dr["BUID"].ToString(), "", dr["ApproverType"].ToString().Trim(), dr["ApproverEmpNo"].ToString().Trim(), dr["ApproverEmpName"].ToString().Trim(), dr["SetupEmp"].ToString().Trim(), dr["SetupTime"].ToString());
                adm.SelectedSite = dr["SiteID"].ToString().Trim();
                adm.SelectedBU = dr["BUID"].ToString().Trim();
                adm.SelectedType = dr["ApproverType"].ToString().Trim();
            }
            RepairSelectListModel(adm);
            return adm;
        }
        

        public List<ApproverModel> GetListApprover(int? page, string SearchData, int PageSize = PagerModel.PageSize)
        {
            List<ApproverModel> listAM = new List<ApproverModel>();
            DataTable dt = new DataTable();
            string tempStr = "SELECT a.*,b.BUName FROM Approver a, BU b WHERE a.BUID=b.BUID";
            if (!string.IsNullOrEmpty(SearchData)) tempStr += " AND (a.ApproverEmpNo LIKE N'%" + SearchData + "%' OR a.ApproverEmpName LIKE N'%" + SearchData + "%')";
            SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            if (page != null)
                dt = db.DoSQLSelect(tempStr, page, PageSize);
            else
                dt = db.DoSQLSelect(tempStr);

            foreach (DataRow dr in dt.Rows)
            {
                listAM.Add(new ApproverModel(dr["ApproverID"].ToString(), dr["SiteID"].ToString(), dr["BUID"].ToString(), dr["BUName"].ToString(), dr["ApproverType"].ToString(), dr["ApproverEmpNo"].ToString(), dr["ApproverEmpName"].ToString(), dr["SetupEmp"].ToString(), dr["SetupTime"].ToString()));
            }
            return listAM;
        }

        #endregion

        #region Update/Insert/Delete
        public void DeleteApprover(string ApproverID)
        {
            SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            string deleteSql = "DELETE Approver WHERE ApproverID='" + ApproverID.Trim() + "'";
            if (db.ExcuteNonQuery(deleteSql))
                Ultils.WriteCookie("Success", LanguageHelper.GetResource("DeleteSuccess"));
            else
                Ultils.WriteCookie("Error", LanguageHelper.GetResource("DeleteFail"));
        }
        public void UpdateApprover(ApproverModel am)
        {
            if (am != null && !string.IsNullOrWhiteSpace(am.ApproverID))
            {
                SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                string UpdateSql = "UPDATE Approver SET SiteID='" + am.SiteId + "',BUID='" + am.BUID + "',ApproverType=N'" + am.ApproverType + "',ApproverEmpNo='" + am.ApproverEmpNo + "',ApproverEmpName=N'" + am.ApproverEmpName + "',SetupEmp='" + Ultils.GetCookie("UserId") + "',SetupTime=getDate() WHERE ApproverID='" + am.ApproverID.Trim() + "'";
                if (db.ExcuteNonQuery(UpdateSql))
                    Ultils.WriteCookie("Success", LanguageHelper.GetResource("UpdateSuccess"));
                else
                    Ultils.WriteCookie("Error", LanguageHelper.GetResource("UpdateFail"));
            }
            else
            {
                Ultils.WriteCookie("Error", LanguageHelper.GetResource("ApproverUpdateEmpty"));
            }

        }
        public void CreateApprover(ApproverModel am)
        {
            if (am != null)
            {
                SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                string InsertSQL = "INSERT INTO Approver(SiteID, BUID, ApproverType, ApproverEmpNo, ApproverEmpName, SetupEmp) VALUES('" + am.SiteId + "','" + am.BUID + "',N'" + am.ApproverType + "','" + am.ApproverEmpNo + "',N'" + am.ApproverEmpName + "','" + Ultils.GetCookie("UserId") + "')";
                if (db.ExcuteNonQuery(InsertSQL))
                    Ultils.WriteCookie("Success", LanguageHelper.GetResource("AddSuccess"));
                else
                    Ultils.WriteCookie("Error", LanguageHelper.GetResource("AddFail"));
            }
            else
            {
                Ultils.WriteCookie("Error", LanguageHelper.GetResource("ApproverUpdateEmpty"));
            }
        }
        #endregion

    }
}